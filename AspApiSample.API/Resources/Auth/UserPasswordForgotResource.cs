using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace AspApiSample.API.Resources.Auth
{
    public class UserPasswordForgotResource
    {
        [FromBody] [Required] public string Email { get; set; }
    }
}