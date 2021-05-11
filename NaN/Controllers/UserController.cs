using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaN.Interfaces.Services;
using NaN.Models;
using NaN.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/[controller]/ListUser")]
        public IActionResult ListUser() 
        {
            try
            {
                List<User> result = _userService.ListAllUsers();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ValidationProblem();
            }
        }

        [HttpGet]
        [Route("api/[controller]/ListUserByFunction/{gameId}/{functionId}")]
        public IActionResult ListUserByFunction(int gameId, int functionId)
        {
            try
            {
                List<User> result = _userService.GetUserByFunction(gameId, functionId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ValidationProblem();
            }
        }

        [HttpGet]
        [Route("api/[controller]/ListUserByRank/{gameId}/{rankId}")]
        public IActionResult ListUserByRank(int gameId, int rankId)
        {
            try
            {
                List<User> result = _userService.GetUserByRank(gameId, rankId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ValidationProblem();
            }
        }

        [HttpGet]
        [Route("api/[controller]/ListUserByGame/{gameId}")]
        public IActionResult ListUserByGame(int gameId)
        {
            try
            {
                List<User> result = _userService.GetUserByGame(gameId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ValidationProblem();
            }
        }

        [HttpGet]
        [Route("api/[controller]/ListUserByName/{userName}")]
        public IActionResult ListUserByName(string userName)
        {
            try
            {
                List<User> result = _userService.GetUserByName(userName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ValidationProblem();
            }
        }

        [HttpGet]
        [Route("api/[controller]/ListUserByProfile/{profile}")]
        public IActionResult ListUserByProfile(string profile)
        {
            try
            {
                List<User> result = _userService.GetUserByProfile(profile);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ValidationProblem();
            }
        }

        [HttpGet]
        [Route("api/[controller]/ListUserById/{userId}")]
        public IActionResult ListUserById(int userId)
        {
            try
            {
                User result = _userService.GetUserById(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ValidationProblem();
            }
        }

        [HttpPost]
        [Route("api/[controller]/CreateUser")]
        public IActionResult CreateUser([FromBody] User user, bool returnUserData = false)
        {
            try
            {
                user = _userService.CreateUser(user);

                if (returnUserData)
                    return Ok(user);
                return Ok();
            }
            catch(Exception ex)
            {
                return ValidationProblem();
            }
        }

        [HttpPut]
        [Route("api/[controller]/UpdateUser")]
        public IActionResult UpdateUser([FromBody] User user, bool returnUserData = false)
        {
            try
            {
                user = _userService.UpdateUser(user);

                if (returnUserData)
                    return Ok(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return ValidationProblem();
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return ValidationProblem();
            }
        }
    }
}
