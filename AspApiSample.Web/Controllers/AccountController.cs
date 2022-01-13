using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AspApiSample.Web.Extensions;
using AspApiSample.Web.Models.Account;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspApiSample.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthApi _authApi;
        private readonly IMailApi _mailApi;

        public AccountController(IAuthApi authApi, IMailApi mailApi)
        {
            _authApi = authApi;
            _mailApi = mailApi;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordModel());
        }

        [HttpGet]
        public async Task<IActionResult> Index(IndexModel model)
        {
            if (model is null)
            {
                model = new IndexModel
                {
                    User = await _authApi.ApiAuthUserUserEmailGetAsync(User.Claims.First().Value)
                };
            }
            else
            {
                model.User ??=
                    await _authApi.ApiAuthUserUserEmailGetAsync(User.Claims.First().Value);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var model = new ChangePasswordModel
            {
                EmailAddress =
                    (await _authApi.ApiAuthUserUserEmailGetAsync(User.Claims.First().Value)).Email,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            IActionResult output = null;

            if (model.NewPassword.Equals(model.ConfirmNewPassword))
            {
                try
                {
                    await _authApi.ApiAuthUserChangePasswordPutAsync(
                        new UserPasswordChangeResource(model.EmailAddress, model.CurrentPassword,
                            model.NewPassword)
                    );
                    var outputModel = new IndexModel
                        { Messages = new List<string> { "Password has been changed" } };
                    output = RedirectToAction("Index", "Account", outputModel);
                }
                catch (ApiException e)
                {
                    model.CurrentPassword = string.Empty;
                    model.NewPassword = string.Empty;
                    model.ConfirmNewPassword = string.Empty;
                    model.Errors = new List<string> { "Password incorrect" };
                    output = View(model);
                }
            }
            else
            {
                model.CurrentPassword = string.Empty;
                model.NewPassword = string.Empty;
                model.ConfirmNewPassword = string.Empty;
                model.Errors = new List<string> { "New password and confirm new password are not the same" };
                output = View(model);
            }

            return output;
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            IActionResult output = null;

            try
            {
                /* Getting reset Password token from the API for the entered Email */
                var token = HttpUtility.HtmlDecode(
                    (await _authApi.ApiAuthUserForgotPasswordPostAsync(
                        new UserPasswordForgotResource(model.Email)
                    )).RemoveChar('\"')
                );
                /* Preparing the callback Url to enter a new Password */
                var callback = Url.Action("ResetPassword", "Account",
                    new { token, email = model.Email }, Request.Scheme);
                /* Call the API to send the mail */
                await _mailApi.ApiMailSendPostAsync(new EmailSendResource(model.Email,
                    "Reset password", callback));
                output = RedirectToAction("ForgotPasswordConfirm", "Account",
                    new ForgotPasswordConfirmModel { Email = model.Email });
            }
            catch (ApiException e)
            {
                /* If catching ApiException, display the error from the API */
                model.Errors = new List<string> { new string(e.ErrorContent.ToString()).RemoveChar('\"') };
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
        public IActionResult ResetPassword(string token, string email)
        {
            return View(new ResetPasswordModel
            {
                Email = email,
                Token = token,
                Password = string.Empty,
                ConfirmPassword = string.Empty,
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            IActionResult output = null;

            if (model.Password.Equals(model.ConfirmPassword))
            {
                try
                {
                    /* Call the API to reset the password */
                    await _authApi.ApiAuthUserResetPasswordPostAsync(
                        new UserPasswordResetResource(model.Email, model.Password, model.Token)
                    );
                    output = RedirectToAction("ResetPasswordConfirm", "Account");
                }
                /* If catching ApiException, display the error from the API */
                catch (ApiException e)
                {
                    model.Password = string.Empty;
                    model.ConfirmPassword = string.Empty;
                    model.Errors = new List<string>
                        { new string(e.ErrorContent.ToString()).RemoveChar('\"') };
                    output = View(model);
                }
            }
            else
            {
                model.Password = string.Empty;
                model.ConfirmPassword = string.Empty;
                model.Errors = new List<string> { "Password and confirm password are not the same" };
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