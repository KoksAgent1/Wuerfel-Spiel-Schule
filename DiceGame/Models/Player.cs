using System.Collections.Generic;

namespace DiceGame.Models
{
    public class Player
    {
        public string Name { get; set; }
        public List<int> CurrentRoll { get; set; }
        public int TotalScore { get; set; }
        public int RoundsWon { get; set; }

        public Player(string name)
        {
            Name = name;
            CurrentRoll = new List<int>();
            TotalScore = 0;
            RoundsWon = 0;
        }

        public Player()
        {
            // Parameterless constructor for deserialization
            CurrentRoll = new List<int>();
        }

        public List<int> RollDice(Dice dice, int numberOfDice)
        {
            CurrentRoll.Clear();
            for (int i = 0; i < numberOfDice; i++)
            {
                int roll = dice.Roll();
                CurrentRoll.Add(roll);
            }
            return new List<int>(CurrentRoll);
        }
    }
}
