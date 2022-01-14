using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AspApiSample.API.Resources.Auth;
using AspApiSample.API.Responses.Auth;
using AspApiSample.Lib.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("User/{userEmail}")]
        public async Task<ActionResult<User>> GetUser([Required] [EmailAddress] string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user is null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
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

            return Ok(token);
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
        public async Task<ActionResult<UserSignInResponse>> SignIn(UserSignInResource resource)
        {
            var user = await _userManager.FindByEmailAsync(resource.Email);

            if (user is null)
            {
                return NotFound("User not found");
            }

            var userSignInResult = await _userManager.CheckPasswordAsync(user, resource.Password);

            if (!userSignInResult)
            {
                return Problem("Password incorrect");
            }

            var userCanSignInResult = await _signInManager.CanSignInAsync(user);

            return userCanSignInResult
                ? Ok(new UserSignInResponse{User = user, Roles = await _userManager.GetRolesAsync(user)})
                : Problem("User cannot sign in");
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
        public async Task<ActionResult<string>> ForgotPassword(UserPasswordForgotResource resource)
        {
            var user = await _userManager.FindByEmailAsync(resource.Email);

            if (user is null)
            {
                return NotFound("User not found");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return Ok(token);
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
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
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