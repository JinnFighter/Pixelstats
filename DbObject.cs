using Pixelstats.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pixelstats
{
    public class DbObject
    {
            private static Dictionary<string, GameMode> _gameModes;

            public static void Init(AppDbContext context)
            {
                User user;
                if(!context.Users.Any())
                {
                    user = new User { StudyGroup = "Mosm-191" };
                    context.Users.Add(user);
                }
                else
                {
                    user = context.Users.First(user => user.StudyGroup == "Mosm-191");
                }
                if (!context.GameModes.Any())
                        context.GameModes.AddRange(GameModes.Select(category => category.Value));

                if (!context.StatDatas.Any())
                    context.StatDatas.AddRange(new List<StatData>
                {
                    new StatData
                    {
                        Time = 30f,
                        CorrectAnswers = 5,
                        WrongAnswers = 10,

                        GameMode = GameModes["Brezenheim"],
                        User = user
                    }
                });

                context.SaveChanges();
            }

            private static Dictionary<string, GameMode> GameModes
            {
                get
                {
                    if (_gameModes == null)
                    {
                        var gameModes = new List<GameMode>
                        {
                            new GameMode{Name = "Brezenheim", StatDatas = new List<StatData>()}
                        };
                        _gameModes = new Dictionary<string, GameMode>();
                        foreach (var gameMode in gameModes)
                            _gameModes.Add(gameMode.Name, gameMode);
                    }

                    return _gameModes;
                }
            }
        }
}
