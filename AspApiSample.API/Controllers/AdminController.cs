using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AspApiSample.API.Resources.Admin;
using AspApiSample.API.Responses.Admin;
using AspApiSample.Lib.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspApiSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<long>> _roleManager;

        public AdminController(UserManager<User> userManager, RoleManager<IdentityRole<long>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [Route("User/{userEmail}")]
        public async Task<ActionResult<UserGetUserResponse>> GetUser(
            [Required] [EmailAddress] string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user is null) return NotFound("User not found");

            return Ok(new UserGetUserResponse { User = user });
        }

        [HttpGet]
        [Route("Users")]
        public async Task<ActionResult<UserGetUsersResponse>> GetUsers()
        {
            return new UserGetUsersResponse{Users = await _userManager.Users.ToListAsync()};
        }

        //TODO Create user (no signup)

        [HttpDelete]
        [Route("Users/Delete/{userName}")]
        public async Task<IActionResult> DeleteUser([Required] string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return BadRequest("User name should be provided");

            var user = await _userManager.FindByEmailAsync(userName);

            if (user is null) return NotFound("User not found");

            var userDeleteResult = await _userManager.DeleteAsync(user);

            return userDeleteResult.Succeeded
                ? Ok()
                : Problem("Problem occured while deleting user");
        }

        [HttpGet]
        [Route("Role/{roleName}")]
        public async Task<ActionResult<RoleGetRoleResponse>> GetRole([Required] string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role is null) return NotFound("User not found");

            return Ok(new RoleGetRoleResponse{ Role = await _roleManager.FindByNameAsync(roleName)});
        }

        [HttpGet]
        [Route("Roles")]
        public async Task<ActionResult<RoleGetRolesResponse>> GetRoles()
        {
            return new RoleGetRolesResponse { Roles = await _roleManager.Roles.ToListAsync() };
        }

        [HttpPost]
        [Route("Roles/Create")]
        public async Task<IActionResult> CreateRole(RoleCreateResource resource)
        {
            if (string.IsNullOrEmpty(resource.RoleName))
                return BadRequest("Role name should be provided");

            var newRole = new IdentityRole<long>
            {
                Name = resource.RoleName
            };

            var roleCreateResult = await _roleManager.CreateAsync(newRole);

            return roleCreateResult.Succeeded
                ? Ok()
                : Problem("Problem occured while creating the role");
        }

        [HttpDelete]
        [Route("Roles/Delete/{roleName}")]
        public async Task<IActionResult> DeleteRole([Required] string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return BadRequest("Role name should be provided");

            var role = await _roleManager.FindByNameAsync(roleName);

            if (role is null) return NotFound("Role not found");

            var roleDeleteResult = await _roleManager.DeleteAsync(role);

            return roleDeleteResult.Succeeded
                ? Ok()
                : Problem("Problem occured while deleting role");
        }

        [HttpPost]
        [Route("User/{userEmail}/Roles")]
        public async Task<IActionResult> AddUserToRole([Required] string userEmail,
            RoleAddUserResource resource)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var role = await _roleManager.FindByNameAsync(resource.RoleName);

            if (user is null) return NotFound("User not found");
            if (role is null) return NotFound("Role not found");

            var userAddRoleResult = await _userManager.AddToRoleAsync(user, resource.RoleName);

            return userAddRoleResult.Succeeded
                ? Ok()
                : Problem("Problem occured while adding user to role");
        }
    }
}