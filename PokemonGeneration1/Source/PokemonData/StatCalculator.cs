using System;

namespace PokemonGeneration1.Source.PokemonData
{
    public static class StatCalculator
    {
        public static Stats CreateStatsFor(Pokemon pokemon)
        {
            return new Stats(
                HPStat(
                    pokemon.BaseHP,
                    pokemon.HPDV,
                    StatPoint(pokemon.HPExp),
                    pokemon.Level),
                NonHPStat(
                    pokemon.BaseAttack,
                    pokemon.AttackDV,
                    StatPoint(pokemon.AttackExp),
                    pokemon.Level),
                NonHPStat(
                    pokemon.BaseDefense,
                    pokemon.DefenseDV,
                    StatPoint(pokemon.DefenseExp),
                    pokemon.Level),
                NonHPStat(
                    pokemon.BaseSpecial,
                    pokemon.SpecialDV,
                    StatPoint(pokemon.SpecialExp),
                    pokemon.Level),
                NonHPStat(
                    pokemon.BaseSpeed,
                    pokemon.SpeedDV,
                    StatPoint(pokemon.SpeedExp),
                    pokemon.Level));
        }

        public static float NonHPStat(
            float baseStat,
            float DV,
            float statPoint,
            float level)
        {
            return (float)Math.Floor(((((baseStat + DV) * 2) + statPoint) * level / 100) + 5);
        }


        public static float HPStat(
            float baseStat,
            float DV,
            float statPoint,
            float level)
        {
            return (float)Math.Floor(((((baseStat + DV) * 2) + statPoint) * level / 100) + level + 10);
        }


        public static float StatPoint(float statExp)
        {
            return (float)Math.Floor(Math.Min(255f, Math.Floor(Math.Sqrt(Math.Max(0, statExp - 1f)) + 1f)) / 4f);
        }
    }
}
