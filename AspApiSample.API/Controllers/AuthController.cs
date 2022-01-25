using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<ActionResult<UserSignUpResponse>> SignUp(UserSignUpResource resource)
        {
            var user = _mapper.Map<UserSignUpResource, User>(resource);

            var userCreateResult = await _userManager.CreateAsync(user, resource.Password);

            if (userCreateResult.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                return Ok(new UserSignUpResponse { Token = token });
            }

            var errorString = userCreateResult.Errors.Aggregate(string.Empty, (current, error) => current + $"{error.Code} : {error.Description} \r\n ");

            return BadRequest(errorString);
        }

        [HttpGet]
        [Route("SignUpConfirm")]
        public async Task<IActionResult> SignUpConfirm(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null) return Problem("User not found");

            var userSignUpConfirmResult = await _userManager.ConfirmEmailAsync(user, token);

            if (userSignUpConfirmResult.Succeeded) return Ok();

            var errorString = userSignUpConfirmResult.Errors.Aggregate(string.Empty, (current, error) => current + $"{error.Code} : {error.Description} \r\n ");

            return BadRequest(errorString);
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<ActionResult<UserSignInResponse>> SignIn(UserSignInResource resource)
        {
            var user = await _userManager.FindByEmailAsync(resource.Email);

            if (user is null) return NotFound("User not found");

            var userSignInResult = await _userManager.CheckPasswordAsync(user, resource.Password);

            if (!userSignInResult) return BadRequest("Password incorrect");

            var userCanSignInResult = await _signInManager.CanSignInAsync(user);

            return userCanSignInResult
                ? Ok(new UserSignInResponse
                { Email = user.Email, Roles = await _userManager.GetRolesAsync(user) })
                : BadRequest("User cannot sign in");
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

            if (userChangePasswordResult.Succeeded)
            {
                return Ok();
            }

            var errorString = userChangePasswordResult.Errors.Aggregate(string.Empty, (current, error) => current + $"{error.Code} : {error.Description} \r\n ");

            return BadRequest(errorString);
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

            if (userResetPasswordResult.Succeeded)
            {
                return Ok();
            }

            var errorString = userResetPasswordResult.Errors.Aggregate(string.Empty, (current, error) => current + $"{error.Code} : {error.Description} \r\n ");

            return BadRequest(errorString);
        }
    }
}