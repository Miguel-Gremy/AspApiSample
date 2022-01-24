using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
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
        private readonly IAdminApi _adminApi;

        public AccountController(IAuthApi authApi, IAdminApi adminApi)
        {
            _authApi = authApi;
            _adminApi = adminApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index(IndexModel model)
        {
            if (model is null)
                model = new IndexModel
                {
                    User = (await _adminApi.ApiAdminUserUserEmailGetAsync(User.FindFirstValue(ClaimTypes.Email)))
                        .User
                };
            else
                model.User ??=
                    (await _adminApi.ApiAdminUserUserEmailGetAsync(User.FindFirstValue(ClaimTypes.Email))).User;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var model = new ChangePasswordModel
            {
                EmailAddress =
                    (await _adminApi.ApiAdminUserUserEmailGetAsync(User.FindFirstValue(ClaimTypes.Email))).User
                    .Email
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
                    await _authApi.ApiAuthChangePasswordPutAsync(
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
                    model.Errors = new List<string> { new string(e.ErrorContent.ToString()).RemoveChar('\"') };
                    output = View(model);
                }
            }
            else
            {
                model.CurrentPassword = string.Empty;
                model.NewPassword = string.Empty;
                model.ConfirmNewPassword = string.Empty;
                model.Errors = new List<string>
                    { "New password and confirm new password are not the same" };
                output = View(model);
            }

            return output;
        }
    }
}