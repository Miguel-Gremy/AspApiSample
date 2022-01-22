using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AspApiSample.API.Resources.Auth;
using AspApiSample.API.Responses.Auth;
using AspApiSample.Lib.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspApiSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole<long>> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(UserManager<User> userManager,
            RoleManager<IdentityRole<long>> roleManager, SignInManager<User> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<ActionResult<UserSignUpResponse>> SignUp(UserSignUpResource resource)
        {
            var user = _mapper.Map<UserSignUpResource, User>(resource);

            var userCreateResult = await _userManager.CreateAsync(user, resource.Password);

            if (!userCreateResult.Succeeded) return Problem("Cannot create user");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return Ok(new UserSignUpResponse { Token = token });
        }

        [HttpGet]
        [Route("SignUpConfirm")]
        public async Task<IActionResult> SignUpConfirm(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null) return NotFound("User not found");

            var userSignUpConfirmResult = await _userManager.ConfirmEmailAsync(user, token);

            return userSignUpConfirmResult.Succeeded
                ? Ok()
                : Problem("The link is no longer working");
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<ActionResult<UserSignInResponse>> SignIn(UserSignInResource resource)
        {
            var user = await _userManager.FindByEmailAsync(resource.Email);

            if (user is null) return NotFound("User not found");

            var userSignInResult = await _userManager.CheckPasswordAsync(user, resource.Password);

            if (!userSignInResult) return Problem("Password incorrect");

            var userCanSignInResult = await _signInManager.CanSignInAsync(user);

            return userCanSignInResult
                ? Ok(new UserSignInResponse
                    { Email = user.Email, Roles = await _userManager.GetRolesAsync(user) })
                : Problem("User cannot sign in");
        }

        [HttpPut]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(UserPasswordChangeResource resource)
        {
            var user = await _userManager.FindByEmailAsync(resource.Email);

            if (user is null) return NotFound("User not found");

            var userChangePasswordResult =
                await _userManager.ChangePasswordAsync(user, resource.CurrentPassword,
                    resource.NewPassword);

            return userChangePasswordResult.Succeeded
                ? Ok()
                : Problem("Password incorrect");
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<ActionResult<UserForgotPasswordResponse>> ForgotPassword(
            UserPasswordForgotResource resource)
        {
            var user = await _userManager.FindByEmailAsync(resource.Email);

            if (user is null) return NotFound("User not found");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return Ok(new UserForgotPasswordResponse { Token = token });
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(UserPasswordResetResource resource)
        {
            var user = await _userManager.FindByEmailAsync(resource.Email);

            if (user is null) return NotFound("User not found");

            var userResetPasswordResult =
                await _userManager.ResetPasswordAsync(user, resource.Token, resource.Password);

            return userResetPasswordResult.Succeeded
                ? Ok()
                : Problem("The link is no longer working");
        }
    }
}