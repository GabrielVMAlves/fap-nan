using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaN.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Controllers
{
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [Route("api/[controller]/GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _gameService.ListAllGames();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return ValidationProblem();
            }
        }
    }
}
