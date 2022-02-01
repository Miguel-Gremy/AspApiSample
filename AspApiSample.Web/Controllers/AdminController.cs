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
            IActionResult output;

            try
            {
                var usersGetResponse = await _adminApi.ApiAdminUsersGetAsync();
                var model = new UsersModel
                {
                    Users = usersGetResponse.Users
                };
                output = View(model);
            }
            catch (ApiException e)
            {
                output = this.ViewWithErrors<UsersModel>(null, e);
            }

            return output;
        }

        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            IActionResult output;

            try
            {
                var rolesGetResponse = await _adminApi.ApiAdminRolesGetAsync();
                var model = new RolesModel
                {
                    Roles = rolesGetResponse.Roles
                };
                output = View(model);
            }
            catch (ApiException e)
            {
                output = this.ViewWithErrors<RolesModel>(null, e);
            }

            return output;
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View(new AddRoleModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(AddRoleModel model)
        {
            IActionResult output;

            if (ModelState.IsValid)
            {
                try
                {
                    await _adminApi.ApiAdminRolesCreatePostAsync(
                        new RoleCreateResource(model.RoleName));
                    var outputModel = new IndexModel
                    { Messages = new List<string> { "Role has been added" } };
                    output = RedirectToAction("Index", "Admin", outputModel);
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

        [HttpGet]
        public IActionResult AddUser()
        {
            return View(new AddUserModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(AddUserModel model)
        {
            IActionResult output;

            if (ModelState.IsValid)
            {
                try
                {
                    await _adminApi.ApiAdminUserCreatePostAsync(
                        new UserCreateResource(model.Email, model.FirstName, model.LastName, model.Password)
                        );
                    var outputModel = new IndexModel
                    { Messages = new List<string> { "User has been added" } };
                    output = RedirectToAction("Index", "Admin", outputModel);
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