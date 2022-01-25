using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspApiSample.Web.Extensions;
using AspApiSample.Web.Models.Login;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp.Contrib;

namespace AspApiSample.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthApi _authApi;
        private readonly ILogger<LoginController> _logger;
        private readonly IMailApi _mailApi;

        public LoginController(ILogger<LoginController> logger, IAuthApi authApi, IMailApi mailApi)
        {
            _logger = logger;
            _authApi = authApi;
            _mailApi = mailApi;
        }

        public IActionResult Index()
        {
            IActionResult output = null;

            /* Check if the User is already connected */
            if (User.Identity is { IsAuthenticated: true })
                /* If so, redirect to Home */
                output = RedirectToAction("Index", "Home");
            else
                /* Else, redirect to login page */
                output = View(new IndexModel());

            return output;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(IndexModel model)
        {
            IActionResult output = null;

            if (ModelState.IsValid)
            {
                /* If not empty, create the object we have to send to the API to login in application */
                var userLoginResource = new UserSignInResource(model.Email, model.Password);
                try
                {
                    /* Try calling API with EmailAddress and Password provided by user */
                    var userSignInResponse =
                        await _authApi.ApiAuthSignInPostAsync(userLoginResource);
                    /* If the API don't throw ApiException, user is well authenticated */
                    /* Create Cookies for the user */
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Email, model.Email)
                    };
                    claims.AddRange(userSignInResponse.Roles.Select(role =>
                        new Claim(ClaimTypes.Role, role)));
                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    /* Sign in user in the application */
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                    output = RedirectToAction("Index", "Home");
                }
                /* If catching ApiException, the user cannot authenticate */
                catch (ApiException e)
                {
                    model.Password = string.Empty;
                    model.Errors = new List<string>(e.GetDetailTable());
                    output = View("Index", model);
                }
            }
            else
            {
                model.Password = string.Empty;
                model.Errors = new List<string>(ModelState.GetErrorsAsStringTable());
                output = View("Index", model);
            }

            return output;
        }

        [HttpGet]
        [Authorize]
        public new async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordModel());
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            IActionResult output = null;

            if (ModelState.IsValid)
            {
                try
                {
                    /* Getting reset Password token from the API for the entered Email */
                    var token = HttpUtility.HtmlDecode(
                        (await _authApi.ApiAuthForgotPasswordPostAsync(
                            new UserPasswordForgotResource(model.Email)
                        )).Token.RemoveChar('\"')
                    );
                    /* Preparing the callback Url to enter a new Password */
                    var callback = Url.Action("ResetPassword", "Login",
                        new { token, email = model.Email }, Request.Scheme);
                    /* Call the API to send the mail */
                    await _mailApi.ApiMailSendPostAsync(new EmailSendResource(model.Email,
                        "Reset password", callback));
                    output = RedirectToAction("ForgotPasswordConfirm", "Login",
                        new ForgotPasswordConfirmModel { Email = model.Email });
                }
                catch (ApiException e)
                {
                    /* If catching ApiException, display the error from the API */
                    model.Errors = new List<string>(e.GetDetailTable());
                    output = View(model);
                }
            }
            else
            {
                model.Errors = ModelState.GetErrorsAsStringTable();
                output = View(model);
            }

            return output;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPasswordConfirm(ForgotPasswordConfirmModel model)
        {
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ResetPassword([Required] string token, [Required] string email)
        {
            IActionResult output = null;

            if (ModelState.IsValid)
            {
                output = View(new ResetPasswordModel
                {
                    Email = email,
                    Token = token,
                    Password = string.Empty,
                    ConfirmPassword = string.Empty
                });
            }
            else
            {
                RedirectToAction("Index", "Login", new IndexModel
                {
                    Errors = ModelState.GetErrorsAsStringTable(),
                });
            }

            return output;
        }

    [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            IActionResult output = null;

            if (ModelState.IsValid)
            {
                try
                {
                    /* Call the API to reset the password */
                    await _authApi.ApiAuthResetPasswordPostAsync(
                        new UserPasswordResetResource(model.Email, model.Password, model.Token)
                    );
                    output = RedirectToAction("ResetPasswordConfirm", "Login");
                }
                /* If catching ApiException, display the error from the API */
                catch (ApiException e)
                {
                    model.Password = string.Empty;
                    model.ConfirmPassword = string.Empty;
                    model.Errors = e.GetDetailTable();
                    output = View(model);
                }
            }
            else
            {
                model.Password = string.Empty;
                model.ConfirmPassword = string.Empty;
                model.Errors = ModelState.GetErrorsAsStringTable();
                output = View(model);
            }

            return output;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ResetPasswordConfirm()
        {
            return View();
        }
    }
}