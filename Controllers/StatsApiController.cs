using Microsoft.AspNetCore.Mvc;
using Pixelstats.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pixelstats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsApiController : ControllerBase
    {
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
        }
    }
}
