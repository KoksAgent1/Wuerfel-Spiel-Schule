using DiceGame.Enums;

namespace DiceGame.Models
{
    public class GameSettings
    {
        public int NumberOfRounds { get; set; }
        public int NumberOfDice { get; set; }
        public int NumberOfSides { get; set; }
        public int MaxRollsPerPlayer { get; set; }
        public TieBreakerRule TieBreakerRule { get; set; }
        public bool IsConfigured { get; set; }
    }
}
