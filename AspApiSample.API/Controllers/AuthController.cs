using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AspApiSample.API.Resources.Auth;
using AspApiSample.Lib.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspApiSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("User/SignUp")]
        public async Task<ActionResult<string>> SignUp(UserSignUpResource resource)
        {
            var user = _mapper.Map<UserSignUpResource, User>(resource);

            var userCreateResult = await _userManager.CreateAsync(user, resource.Password);

            if (!userCreateResult.Succeeded)
            {
                return Problem("Cannot create user");
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("SignUpConfirm", "Auth",
                new { token, email = resource.Email }, Request.Scheme);

            return Ok(confirmationLink);
        }

        [HttpGet]
        [Route("User/SignUpConfirm")]
        public async Task<IActionResult> SignUpConfirm(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return NotFound("User not found");
            }

            var userSignUpConfirmResult = await _userManager.ConfirmEmailAsync(user, token);

            return userSignUpConfirmResult.Succeeded
                ? Ok()
                : Problem("The link is no longer working");
        }

        [HttpPost]
        [Route("User/SignIn")]
        public async Task<IActionResult> SignIn(UserSignInResource resource)
        {
            var user = await _userManager.FindByEmailAsync(resource.Email);

            if (user is null)
            {
                return NotFound("User not found");
            }

            var userSignInResult = await _userManager.CheckPasswordAsync(user, resource.Password);

            return userSignInResult
                ? Ok()
                : Problem("Password incorrect");
        }

        [HttpPut]
        [Route("User/ChangePassword")]
        public async Task<IActionResult> ChangePassword(UserPasswordChangeResource resource)
        {
            var user = await _userManager.FindByEmailAsync(resource.Email);

            if (user is null)
            {
                return NotFound("User not found");
            }

            var userChangePasswordResult =
                await _userManager.ChangePasswordAsync(user, resource.CurrentPassword,
                    resource.NewPassword);

            return userChangePasswordResult.Succeeded
                ? Ok()
                : Problem("Password incorrect");
        }

        [HttpPost]
        [Route("User/ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(UserPasswordForgotResource resource)
        {
            var user = await _userManager.FindByEmailAsync(resource.Email);

            if (user is null)
            {
                return NotFound("User not found");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action("ResetPassword", "Auth",
                new { token, email = resource.Email }, Request.Scheme);

            return Ok(resetLink);
        }

        [HttpPost]
        [Route("User/ResetPassword")]
        public async Task<IActionResult> ResetPassword(UserPasswordResetResource resource)
        {
            var user = await _userManager.FindByEmailAsync(resource.Email);

            if (user is null)
            {
                return NotFound("User not found");
            }

            var userResetPasswordResult =
                await _userManager.ResetPasswordAsync(user, resource.Token, resource.Password);

            return userResetPasswordResult.Succeeded
                ? Ok()
                : Problem("The link is no longer working");
        }

        [HttpPost]
        [Route("Roles")]
        public async Task<IActionResult> CreateRole(RoleCreateResource resource)
        {
            if (string.IsNullOrEmpty(resource.RoleName))
            {
                return BadRequest("Role name should be provided");
            }

            var newRole = new Role
            {
                Name = resource.RoleName,
            };

            var roleCreateResult = await _roleManager.CreateAsync(newRole);

            return roleCreateResult.Succeeded
                ? Ok()
                : Problem("Problem occured while creating the role");
        }

        [HttpPost]
        [Route("User/{userEmail}/Roles")]
        public async Task<IActionResult> AddUserToRole([Required] string userEmail, RoleAddUserResource resource)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var role = await _roleManager.FindByNameAsync(resource.RoleName);

            if (user is null)
            {
                return NotFound("User not found");
            }
            if (role is null)
            {
                return NotFound("Role not found");
            }

            var userAddRoleResult = await _userManager.AddToRoleAsync(user, resource.RoleName);

            return userAddRoleResult.Succeeded
                ? Ok()
                : Problem("Problem occured while adding user to role");
        }
    }
}