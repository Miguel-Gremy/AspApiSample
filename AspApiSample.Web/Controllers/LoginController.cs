using System.Collections.Generic;
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

namespace AspApiSample.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IAuthApi _authApi;

        public LoginController(ILogger<LoginController> logger, IAuthApi authApi)
        {
            _logger = logger;
            _authApi = authApi;
        }

        public IActionResult Index()
        {
            IActionResult output = null;

            /* Check if the User is already connected */
            if (User.Identity is { IsAuthenticated: true })
            {
                /* If so, redirect to Home */
                output = RedirectToAction("Index", "Home");
            }
            else
            {
                /* Else, redirect to login page */
                output = View(new IndexModel());
            }

            return output;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(IndexModel model)
        {
            IActionResult output = null;

            if (ModelState.IsValid)
            {
                /* Check if EmailAddress and Password are empty or not */
                if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
                {
                    /* If not empty, create the object we have to send to the API to login in application */
                    var userLoginResource = new UserSignInResource(model.Email, model.Password);
                    try
                    {
                        /* Try calling API with EmailAddress and Password provided by user */
                        var userSignInResponse = await _authApi.ApiAuthUserSignInPostAsync(userLoginResource);
                        /* If the API don't throw ApiException, user is well authenticated */
                        /* Create Cookies for the user */
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, model.Email)
                        };
                        claims.AddRange(userSignInResponse.Roles.Select(role => new Claim(ClaimTypes.Role, role)));
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
                        model.Errors = new List<string> { e.Message.RemoveChar('\"') };
                        output = View("Index", model);
                    }
                }
                /* If EmailAddress or Password is empty, the user cannot authenticate */
                else
                {
                    model.Password = string.Empty;
                    model.Errors = new List<string> { "Email or password is empty" };
                }
            }
            /* If the ModelState is not valid, then redirect to the page */
            else
            {
                model.Password = string.Empty;
                model.Errors = new List<string> { "Error while sending the request" };
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
    }
}