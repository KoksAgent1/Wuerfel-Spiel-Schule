using System;

namespace DiceGame.Models
{
    public class Dice
    {
        public int NumberOfSides { get; private set; }

        private Random random;

        public Dice(int numberOfSides)
        {
            NumberOfSides = numberOfSides;
            random = new Random();
        }

        public int Roll()
        {
            return random.Next(1, NumberOfSides + 1);
        }
    }
}
