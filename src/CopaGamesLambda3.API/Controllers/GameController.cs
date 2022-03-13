using CopaGamesLambda3.API.ViewModels;
using CopaGamesLambda3.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CopaGamesLambda3.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameApplicationService _gameApplicationService;
        private readonly ILogger _logger;

        public GameController(
            IGameApplicationService gameApplicationService,
            ILogger<GameController> logger)
        {
            _gameApplicationService = gameApplicationService;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("get-all")]
        public async Task<IActionResult> GetGamesAsync()
        {
            try
            {
                var games = await _gameApplicationService.GetGamesAsync();

                return Ok(new ResultViewModel
                {
                    Message = "Games found with success!",
                    Success = true,
                    Data = games,
                });
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message, error.InnerException);

                return StatusCode(500, new ResultViewModel
                {
                    Message = "An error has been occurred, please try again",
                    Success = false,
                    Data = null,
                });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("start-matches")]
        public IActionResult StartMatches([FromBody] StartMatchesViewModel startMatchesViewModel)
        {
            try
            {
                if(startMatchesViewModel.Games.Count != 8)
                {
                    return BadRequest(new ResultViewModel
                    {
                        Message = "You need to inform 8 games to start the matches",
                        Success = false,
                        Data = null,
                    });
                }

                var matchFinalists = _gameApplicationService.GetMatchFinalists(startMatchesViewModel.Games);

                return Ok(new ResultViewModel
                {
                    Message = "Successful completed matches",
                    Success = true,
                    Data = matchFinalists,
                });
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message, error.InnerException);

                return StatusCode(500, new ResultViewModel
                {
                    Message = "An error has been occurred, please try again",
                    Success = false,
                    Data = null,
                });
            }
        }
    }
}
