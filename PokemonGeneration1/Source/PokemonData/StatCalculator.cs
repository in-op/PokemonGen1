using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.PokemonData
{
    public static class StatCalculator
    {
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


        public static float StatPoint(
            float statExp)
        {
            return (float)Math.Floor(Math.Min(255f, Math.Floor(Math.Sqrt(Math.Max(0, statExp - 1f)) + 1f)) / 4f);
        }
    }
}
