using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NaN.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login (string Username, string Password)
        {
            try
            {
                if(_loginService.Login(Username, Password))
                    return Ok();
                return Unauthorized();

            } catch(Exception ex)
            {
                return ValidationProblem();
            }
        }
    }
}
