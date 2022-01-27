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
                var model = new UsersModel
                {
                    Errors = e.GetDetailTable()
                };
                output = View(model);
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
                var model = new RolesModel
                {
                    Errors = e.GetDetailTable()
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
                RoleName = string.Empty
            });
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
                    model.ResetData();
                    model.Errors = e.GetDetailTable();
                    output = View("AddRole", model);
                }
            }
            else
            {
                model.ResetData();
                model.Errors = ModelState.GetErrorsAsStringTable();
                output = View("AddRole", model);
            }

            return output;
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View(new AddUserModel
            {
                Email = string.Empty,
                FirstName = string.Empty,
                LastName = string.Empty,
                Password = string.Empty,
                ConfirmPassword = string.Empty
            });
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
                    model.ResetData();
                    model.Errors = e.GetDetailTable();
                    output = View("AddUser", model);
                }
            }
            else
            {
                model.ResetData();
                model.Errors = ModelState.GetErrorsAsStringTable();
                output = View("AddUser", model);
            }

            return output;
        }
    }
}