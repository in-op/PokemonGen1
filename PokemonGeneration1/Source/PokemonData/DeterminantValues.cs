using System;

namespace PokemonGeneration1.Source.PokemonData
{
    public sealed class DeterminantValues
    {
        public readonly float HP;
        public readonly float Attack;
        public readonly float Defense;
        public readonly float Special;
        public readonly float Speed;

        /// <summary>
        /// Create a pre-determined set of DVs. Range 0-15.
        /// </summary>
        public DeterminantValues(
            float hp,
            float attack,
            float defense,
            float special,
            float speed)
        {
            HP = hp;
            Attack = attack;
            Defense = defense;
            Special = special;
            Speed = speed;
        }

        /// <summary>
        /// Create a randomly-generated set of DVs.
        /// </summary>
        public DeterminantValues()
        {
            Random rng = new Random();
            Attack = rng.Next(0, 16);
            Defense = rng.Next(0, 16);
            Special = rng.Next(0, 16);
            Speed = rng.Next(0, 16);

            float x = 0f;
            if (Attack % 2 == 1) x += 8f;
            if (Defense % 2 == 1) x += 4f;
            if (Special % 2 == 1) x += 1f;
            if (Speed % 2 == 1) x += 2f;
            HP = x;
        }
    }
}
