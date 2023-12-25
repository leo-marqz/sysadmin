using Api.DTOs.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost("SignIn")]
        public ActionResult SigIn(SignIn signIn)
        {
            return Ok(new {id="kladonr"});
        }

        [HttpPost("SignUp")]
        public ActionResult SignUp(SignUp signUp)
        {
            return Ok(new { signUp.Email});
        }

        [HttpPost("Verification")]
        public ActionResult Verification()
        {
            return Ok();
        }

        [HttpPost("ResetPassword")]
        public ActionResult ResetPassword(Guid token)
        {
            return Ok(new {token});
        }

        [HttpGet("EditProfile")]
        public ActionResult EditProfile(Guid token)
        {
            return Ok(new {token});
        }

        [HttpPut("UpdateProfile")]
        public ActionResult UpdateProfile(Guid token)
        {
            return Ok(new {token});
        }

        [HttpPut("RefreshToken")]
        public ActionResult RefreshToken(Guid token)
        {
            return Ok(new {token});
        }

        [HttpDelete("Logout")]
        public ActionResult Logout()
        {
            return Ok();
        }

        [HttpDelete("Account/{id}")]
        public ActionResult DeleteAccount(Guid id)
        {
            return Ok(id);    
        }

        #region OAuth - Google

        [HttpGet("Google/SignIn")]
        public ActionResult GoogleSignIn()
        {
            return Ok();
        }

        #endregion

        #region OAuth - Microsoft

        [HttpGet("Microsoft/SignIn")]
        public ActionResult MicrosoftSignIn()
        {
            return Ok();
        }

        #endregion

    }
}
