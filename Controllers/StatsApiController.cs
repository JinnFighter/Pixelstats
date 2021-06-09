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
        private readonly IGetStats _statsRepository;

        public StatsApiController(IGetUsers userRepository, IGetGameModes gameModesRepository,
            IStatUpdater statUpdater, IGetStats statsRepository)
        {
            _usersRepository = userRepository;
            _gameModesRepository = gameModesRepository;
            _statUpdater = statUpdater;
            _statsRepository = statsRepository;
        }

        // GET api/<StatsApiController>/name
        [HttpGet("{name}")]
        public IEnumerable<ApiData> Get(string name)
        {
            var res = new List<ApiData>();

            foreach(var statData in _statsRepository.GetStats.Where(statData => statData.User.UserName == name))
            {
                res.Add(new ApiData
                {
                    PlayerName = name,
                    GameModeName = statData.GameMode.Name,
                    Time = statData.Time,
                    CorrectAnswers = statData.CorrectAnswers,
                    WrongAnswers = statData.WrongAnswers
                });
            }

            return res;
        }

        // POST api/<StatsApiController>
        [HttpPost]
        public void Post([FromBody] ApiData value)
        {
            if(_usersRepository.GetUsers().Any(user => user.UserName == value.PlayerName) && 
                _gameModesRepository.GetGameModes().Any(gameMode => gameMode.Name == value.GameModeName))
            {
                var user = _usersRepository.GetUsers().FirstOrDefault(user => user.UserName == value.PlayerName);
                var gameMode = _gameModesRepository.GetGameModes().FirstOrDefault(gameMode =>
                    gameMode.Name == value.GameModeName);

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
