using DiceGame.Enums;
using System.Collections.Generic;

namespace DiceGame.Models
{
    public class GameData
    {
        public List<Player> Players { get; set; }
        public GameSettings Settings { get; set; }
        public Dictionary<TieBreakerRule, int> TieBreakerUsage { get; set; }
        public int CurrentRound { get; set; }
        public bool GameInProgress { get; set; }
        public List<Player> GamePlayers { get; set; }

        public GameData()
        {
            Players = new List<Player>();
            Settings = new GameSettings();
            TieBreakerUsage = new Dictionary<TieBreakerRule, int>
            {
                { TieBreakerRule.AcceptTie, 0 },
                { TieBreakerRule.SuddenDeath, 0 },
                { TieBreakerRule.HighestSingleDie, 0 },
                { TieBreakerRule.ReRoll, 0 }
            };
            GameInProgress = false;
            CurrentRound = 1;
            GamePlayers = new List<Player>();
        }
    }
}
