using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;

namespace Domain
{
    public class T3Alarm
    {
        
        private readonly double _waitTime;
        private readonly Dictionary<string, SoundPlayer> _soundPlayers;
        private readonly TimeToDing _timeCheck;

        public T3Alarm()
        {
            _waitTime = new ApplicationConfig().WaitTime;
            _soundPlayers = new Dictionary<string, SoundPlayer>
            {
                {"MLC", new SoundPlayer(Resource.MLC)},
                {"MLAW", new SoundPlayer(Resource.MLAW)},
                {"LFM", new SoundPlayer(Resource.LFM)},
                {"IQL", new SoundPlayer(Resource.IQL)},
                {"ERROR", new SoundPlayer(Resource.scream)},
            };
            _timeCheck = new TimeToDing();
        }

        // ReSharper disable once FunctionNeverReturns -- Infinite Poller Loop
        public void Start(Func<PingResult> request)
        {
            Console.Clear();
            while (true)
            {
                if (_timeCheck.CheckTime(DateTime.Now))
                {
                    var pingResult = request();
                    var projectsWithT3 = pingResult.ProjectsWithT3;
                    if (projectsWithT3.Count >= 1)
                    {
                        foreach (var project in projectsWithT3)
                        {
                            _soundPlayers[project.Key].Play();
                        }
                    }

                    if (pingResult.Errors)
                        _soundPlayers["ERROR"].Play();
                }
                Thread.Sleep(TimeSpan.FromSeconds(_waitTime));
            }
        }
    }
}