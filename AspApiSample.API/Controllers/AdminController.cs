using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AspApiSample.API.Configuration;
using AspApiSample.API.Extensions;
using AspApiSample.API.Resources.Admin;
using AspApiSample.API.Responses.Admin;
using AspApiSample.Lib.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AspApiSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminController> _logger;

        public AdminController(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, ILogger<AdminController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("Users")]
        public async Task<ActionResult<UserGetUsersResponse>> GetUsers()
        {
            _logger.LogInformation(LogEvents.ListItems, LogMessages.ListItems, "AspNetUser");

            return new UserGetUsersResponse { Users = await _userManager.Users.ToListAsync() };
        }

        [HttpGet]
        [Route("User/{userEmail}")]
        public async Task<ActionResult<UserGetUserResponse>> GetUser(
            [Required][EmailAddress] string userEmail)
        {
            _logger.LogInformation(LogEvents.GetItem, LogMessages.GetItem, "AspNetUser", userEmail);

            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user is null) return NotFound("User not found");

            return Ok(new UserGetUserResponse { User = user });
        }

        [HttpPost]
        [Route("User/Create")]
        public async Task<IActionResult> CreateUser(UserCreateResource resource)
        {
            _logger.LogInformation(LogEvents.CreateItem, LogMessages.CreateItem, "AspNetUser", resource.Email);

            var user = _mapper.Map<UserCreateResource, User>(resource);

            var userCreateResult = await _userManager.CreateAsync(user, resource.Password);

            if (userCreateResult.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var userConfirmEmailResult = await _userManager.ConfirmEmailAsync(user, token);

                if (userConfirmEmailResult.Succeeded)
                {
                    var addUserRolesResult = await _userManager.AddToRolesAsync(user, resource.Roles);

                    if (addUserRolesResult.Succeeded)
                    {
                        return Ok();
                    }

                    var errorStringAddUserRoles = addUserRolesResult.Errors.GetErrorsAsString();

                    return BadRequest(errorStringAddUserRoles);
                }

                var errorStringConfirmEmail = userCreateResult.Errors.GetErrorsAsString();

                return BadRequest(errorStringConfirmEmail);
            }

            var errorStringUserCreate = userCreateResult.Errors.GetErrorsAsString();

            return BadRequest(errorStringUserCreate);
        }

        [HttpDelete]
        [Route("Users/Delete/{userName}")]
        public async Task<IActionResult> DeleteUser([Required] string userName)
        {
            _logger.LogInformation(LogEvents.DeleteItem, LogMessages.DeleteItem, "AspNetUser", userName);

            if (string.IsNullOrEmpty(userName))
                return BadRequest("User name should be provided");

            var user = await _userManager.FindByEmailAsync(userName);

            if (user is null) return NotFound("User not found");

            var userDeleteResult = await _userManager.DeleteAsync(user);

            if (userDeleteResult.Succeeded) return Ok();

            var errorString = userDeleteResult.Errors.GetErrorsAsString();

            return BadRequest(errorString);
        }

        [HttpGet]
        [Route("Roles")]
        public async Task<ActionResult<RoleGetRolesResponse>> GetRoles()
        {
            _logger.LogInformation(LogEvents.ListItems, LogMessages.ListItems, "AspNetRole");

            return new RoleGetRolesResponse { Roles = await _roleManager.Roles.ToListAsync() };
        }

        [HttpGet]
        [Route("Role/{roleName}")]
        public async Task<ActionResult<RoleGetRoleResponse>> GetRole([Required] string roleName)
        {
            _logger.LogInformation(LogEvents.GetItem, LogMessages.GetItem, "AspNetRole", roleName);

            var role = await _roleManager.FindByNameAsync(roleName);

            if (role is null) return BadRequest("User not found");

            return Ok(new RoleGetRoleResponse
            { Role = await _roleManager.FindByNameAsync(roleName) });
        }

        [HttpPost]
        [Route("Roles/Create")]
        public async Task<IActionResult> CreateRole(RoleCreateResource resource)
        {
            _logger.LogInformation(LogEvents.CreateItem, LogMessages.CreateItem, "AspNetRole", resource.RoleName);

            if (string.IsNullOrEmpty(resource.RoleName))
                return BadRequest("Role name should be provided");

            var newRole = new Role
            {
                Name = resource.RoleName
            };

            var roleCreateResult = await _roleManager.CreateAsync(newRole);

            if (roleCreateResult.Succeeded) return Ok();

            var errorString = roleCreateResult.Errors.GetErrorsAsString();

            return BadRequest(errorString);
        }

        [HttpDelete]
        [Route("Roles/Delete/{roleName}")]
        public async Task<IActionResult> DeleteRole([Required] string roleName)
        {
            _logger.LogInformation(LogEvents.DeleteItem, LogMessages.DeleteItem, "AspNetRole", roleName);

            if (string.IsNullOrEmpty(roleName))
                return BadRequest("Role name should be provided");

            var role = await _roleManager.FindByNameAsync(roleName);

            if (role is null) return NotFound("Role not found");

            var roleDeleteResult = await _roleManager.DeleteAsync(role);

            if (roleDeleteResult.Succeeded) return Ok();

            var errorString = roleDeleteResult.Errors.GetErrorsAsString();

            return BadRequest(errorString);
        }

        [HttpPost]
        [Route("User/{userEmail}/Roles")]
        public async Task<IActionResult> AddUserToRole([Required] string userEmail,
            RoleAddUserResource resource)
        {
            _logger.LogInformation(LogEvents.UpdateItem, LogMessages.UpdateItem, "AspNetUserRoles", userEmail);

            var user = await _userManager.FindByEmailAsync(userEmail);
            var role = await _roleManager.FindByNameAsync(resource.RoleName);

            if (user is null) return NotFound("User not found");
            if (role is null) return NotFound("Role not found");

            var userAddRoleResult = await _userManager.AddToRoleAsync(user, resource.RoleName);

            if (userAddRoleResult.Succeeded) return Ok();

            var errorString = userAddRoleResult.Errors.GetErrorsAsString();

            return BadRequest(errorString);
        }
    }
}