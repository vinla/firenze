using System;
using System.Collections.Generic;
using System.Linq;

namespace Firenze.Core
{
    public class GameState
    {
        private static GameState _current;

        public static GameState Current => _current;

        public static void StartNew()
        {
            _current = new GameState
            {
                Characters = new List<Character>
                {
                    new Character { Level = 1, Name = "Storn", XP = 0},
                    new Character { Level = 1, Name = "Ragnorn", XP = 0},
                    new Character { Level = 1, Name = "Mercy", XP = 0},
                    new Character { Level = 1, Name = "Reaper", XP = 0 }
                }
            };
        }

        private GameState()
        {
            ActiveMissions = new List<Mission>();
        }

        public List<Character> Characters { get; private set; }

        public IEnumerable<Tuple<Character, Boolean>> CharactersWithAvailability
        {
            get
            {
                return
                    Characters.Select(
                        ch => Tuple.Create(ch, ActiveMissions.Any(m => m.Characters.Any(mch => mch.Id == ch.Id)) == false));
            }
        }

        public List<Mission> ActiveMissions { get; }        
    }
}
