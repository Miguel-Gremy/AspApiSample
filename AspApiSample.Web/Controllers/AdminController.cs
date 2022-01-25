using System.Collections.Generic;
using System.Threading.Tasks;
using AspApiSample.Web.Extensions;
using AspApiSample.Web.Models.Admin;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspApiSample.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IAdminApi _adminApi;

        public AdminController(IAdminApi adminApi)
        {
            _adminApi = adminApi;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new IndexModel());
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            IActionResult output = null;

            try
            {
                var usersGetResponse = await _adminApi.ApiAdminUsersGetAsync();
                var model = new UsersModel
                {
                    Users = usersGetResponse.Users,
                };
                output = View(model);
            }
            catch (ApiException e)
            {
                var model = new UsersModel
                {
                    Errors = new List<string> { new string(e.ErrorContent.ToString()).RemoveChar('\"') },
                };
                output = View(model);
            }

            return output;
        }

        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            IActionResult output = null;

            try
            {
                var rolesGetResponse = await _adminApi.ApiAdminRolesGetAsync();
                var model = new RolesModel
                {
                    Roles = rolesGetResponse.Roles,
                };
                output = View(model);
            }
            catch (ApiException e)
            {
                var model = new RolesModel
                {
                    Errors = new List<string> { new string(e.ErrorContent.ToString()).RemoveChar('\"') },
                };
                output = View(model);
            }

            return output;
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View(new AddRoleModel
            {
                RoleName = string.Empty,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(AddRoleModel model)
        {
            IActionResult output = null;

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.RoleName))
                {
                    try
                    {
                        await _adminApi.ApiAdminRolesCreatePostAsync(new RoleCreateResource(model.RoleName));
                        var outputModel = new IndexModel
                        { Messages = new List<string> { "Role has been added" } };
                        output = RedirectToAction("Index", "Admin", outputModel);
                    }
                    catch (ApiException e)
                    {
                        model.RoleName = string.Empty;
                        model.Errors = new List<string> { e.Message.RemoveChar('\"') };
                        output = View("AddRole", model);
                    }
                }
                else
                {
                    model.RoleName = string.Empty;
                    model.Errors = new List<string> { "Role name is empty" };
                    output = View("AddRole", model);
                }
            }
            else
            {
                model.RoleName = string.Empty;
                model.Errors = new List<string> { "Error while sending the request" };
                output = View("AddRole", model);
            }

            return output;
        }
    }
}