using System.Threading.Tasks;
using AspApiSample.Web.Models.Admin;
using IO.Swagger.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspApiSample.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IAdminApi _adminApi;HEADER

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
        public IActionResult Users()
        {
            return View(new UsersModel());
        }

        [HttpGet]
        public IActionResult Roles()
        {
            return View(new RolesModel());
        }
    }
}