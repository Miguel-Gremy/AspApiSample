using System.Threading.Tasks;
using IO.Swagger.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspApiSample.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        public AdminController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}