using Microsoft.AspNetCore.Mvc;
using Pixelstats.Data.Interfaces;
using Pixelstats.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pixelstats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsApiController : ControllerBase
    {
        private readonly IGetUsers _usersRepository;
        private readonly IGetGameModes _gameModesRepository;
        private readonly IStatUpdater _statUpdater;

        public StatsApiController(IGetUsers userRepository, IGetGameModes gameModesRepository, IStatUpdater statUpdater)
        {
            _usersRepository = userRepository;
            _gameModesRepository = gameModesRepository;
            _statUpdater = statUpdater;
        }

        // GET: api/<StatsApiController>
        [HttpGet]
        public IEnumerable<ApiData> Get()
        {
            return new List<ApiData>
            {
                new ApiData
                {
                    PlayerName = "test",
                    GameModeName = "testMode",
                    Time = 30f,
                    CorrectAnswers = 1,
                    WrongAnswers = 2
                }
            };
        }

        // GET api/<StatsApiController>/5
        [HttpGet("{id}")]
        public ApiData Get(int id)
        {
            return
                new ApiData
                {
                    PlayerName = "test",
                    GameModeName = "testMode",
                    Time = 30f,
                    CorrectAnswers = 1,
                    WrongAnswers = 2
            };
        }

        // POST api/<StatsApiController>
        [HttpPost]
        public void Post([FromBody] ApiData value)
        {
            if(_usersRepository.GetUsers().Any(user => user.UserName == value.PlayerName) && 
                _gameModesRepository.GetGameModes().Any(gameMode => gameMode.Name == value.GameModeName))
            {
                var user = _usersRepository.GetUsers().FirstOrDefault(user => user.UserName == value.PlayerName);
                var gameMode = _gameModesRepository.GetGameModes().FirstOrDefault(gameMode => gameMode.Name == value.GameModeName);

                var statData = new StatData
                {
                    CorrectAnswers = value.CorrectAnswers,
                    WrongAnswers = value.WrongAnswers,
                    Time = value.Time,
                    GameMode = gameMode,
                    User = user
                };

                _statUpdater.AddStats(statData);
            }
        }
    }
}
