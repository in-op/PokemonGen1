namespace PokemonGeneration1.Source.PokemonData
{
    public sealed class Stats
    {
        public readonly float HP;
        public readonly float Attack;
        public readonly float Defense;
        public readonly float Special;
        public readonly float Speed;

        private Stats() { }

        public Stats(float hp, float attack, float defense, float special, float speed)
        {
            HP = hp;
            Attack = attack;
            Defense = defense;
            Special = special;
            Speed = speed;
        }
    }
}
