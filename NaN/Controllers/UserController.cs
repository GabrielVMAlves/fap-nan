using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaN.Interfaces.Services;
using NaN.Models;
using NaN.Utils;
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
                return Error(ex);
            }
        }

        [HttpGet]
        [Route("api/[controller]/ListUserByFunction/{gameId}/{functionId}")]
        public IActionResult ListUserByFunction(int gameId, int functionId)
        {
            try
            {
                List<User> result = _userService.GetUserByFunction(gameId, functionId);

                if (result.Count == 0)
                    throw new ErrorHandling(404, "Not Found", "Cant find a user with this attributes");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpGet]
        [Route("api/[controller]/ListUserByRank/{gameId}/{rankId}")]
        public IActionResult ListUserByRank(int gameId, int rankId)
        {
            try
            {
                List<User> result = _userService.GetUserByRank(gameId, rankId);

                if (result.Count == 0)
                    throw new ErrorHandling(404, "Not Found", "Cant find a user with this attributes");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpGet]
        [Route("api/[controller]/ListUserByGame/{gameId}")]
        public IActionResult ListUserByGame(int gameId)
        {
            try
            {
                List<User> result = _userService.GetUserByGame(gameId);

                if (result.Count == 0)
                    throw new ErrorHandling(404, "Not Found", "Cant find a user with this attributes");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpGet]
        [Route("api/[controller]/ListUserByName/{userName}")]
        public IActionResult ListUserByName(string userName)
        {
            try
            {
                List<User> result = _userService.GetUserByName(userName);

                if (result.Count == 0)
                    throw new ErrorHandling(404, "Not Found", "Cant find a user with this attributes");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpGet]
        [Route("api/[controller]/ListUserByProfile/{profile}")]
        public IActionResult ListUserByProfile(string profile)
        {
            try
            {
                List<User> result = _userService.GetUserByProfile(profile);

                if (result.Count == 0)
                    throw new ErrorHandling(404, "Not Found", "Cant find a user with this attributes");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        [HttpGet]
        [Route("api/[controller]/ListUserById/{userId}")]
        public IActionResult ListUserById(int userId)
        {
            try
            {
                User result = _userService.GetUserById(userId);

                if (result == null)
                    throw new ErrorHandling(404, "Not Found", "Cant find a user with this attribute");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Error(ex);
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
                return Error(ex);
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
                return Error(ex);
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
                return Error(ex);
            }
        }

        private ObjectResult Error(Exception ex)
        {
            if (ex is ErrorHandling eh)
            {
                return Problem(eh.Message, statusCode: eh.Code, type: eh.Type);
            }
            return Problem(ex.Message, statusCode: 500, type: ex.GetType().Name);
        }
    }
}
