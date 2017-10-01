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

        public static DeterminantValues CreatePremade(
            float hp,
            float attack,
            float defense,
            float special,
            float speed)
        {
            return new DeterminantValues(hp, attack, defense, special, speed);
        }

        public static DeterminantValues CreateRandom()
        {
            Random rng = new Random();

            float attack = rng.Next(0, 16);
            float defense = rng.Next(0, 16);
            float special = rng.Next(0, 16);
            float speed = rng.Next(0, 16);

            float hp = 0f;
            if (attack % 2 == 1) hp += 8f;
            if (defense % 2 == 1) hp += 4f;
            if (special % 2 == 1) hp += 1f;
            if (speed % 2 == 1) hp += 2f;

            return new DeterminantValues(
                hp, attack, defense, special, speed);
        }


        private DeterminantValues(
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
    }
}
