namespace PokemonGeneration1.Source.PokemonData
{
    public sealed class BaseStats
    {
        public readonly float HP;
        public readonly float Attack;
        public readonly float Defense;
        public readonly float Special;
        public readonly float Speed;

        public BaseStats(float hp, float attack, float defense, float special, float speed)
        {
            HP = hp;
            Attack = attack;
            Defense = defense;
            Special = special;
            Speed = speed;
        }
        
    }
}
