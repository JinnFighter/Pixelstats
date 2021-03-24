using Pixelstats.Models;
using System;
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
                if(context.Users.Any())
                {
                    user = context.Users.First(user => user.UserName == "test");
                }
                else
                {
                    user = new User { StudyGroup = "Mosm-191", UserName = "test" };
                    context.Users.Add(user);
                }
                if (!context.GameModes.Any())
                        context.GameModes.AddRange(GameModes.Select(category => category.Value));

                if (!context.StatDatas.Any())
            {
                var data = new List<StatData>
                {
                    new StatData
                    {
                        Time = 30f,
                        CorrectAnswers = 5,
                        WrongAnswers = 10,
                        GameMode = GameModes["Brezenheim"],
                        User = user
                    } 
                };

                context.StatDatas.AddRange(data);
            }
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
                            new GameMode{Name = "Brezenheim"}
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
