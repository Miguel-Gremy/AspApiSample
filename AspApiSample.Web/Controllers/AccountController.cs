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
        private readonly IAdminApi _adminApi;
        private readonly IAuthApi _authApi;

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
                    User = (await _adminApi.ApiAdminUserUserEmailGetAsync(
                            User.FindFirstValue(ClaimTypes.Email)))
                        .User
                };
            else
                model.User ??=
                    (await _adminApi.ApiAdminUserUserEmailGetAsync(
                        User.FindFirstValue(ClaimTypes.Email))).User;

            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View(new ChangePasswordModel
            {
                EmailAddress = User.FindFirstValue(ClaimTypes.Email)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            IActionResult output;

            if (ModelState.IsValid)
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
                    output = this.ViewWithErrors(model, e);
                }
            }
            else
            {
                output = this.ViewWithErrors(model, ModelState);
            }

            return output;
        }
    }
}