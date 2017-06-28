using System.Collections.Generic;

namespace PokemonGeneration1.Source.Battles
{
    public static class StatStageMultipliers
    {
        public static readonly Dictionary<int, float> Multiplier = new Dictionary<int, float>()
        {
            {-6, (25f/100f) },
            {-5, (28f/100f) },
            {-4, (33f/100f) },
            {-3, (40f/100f) },
            {-2, (50f/100f) },
            {-1, (66f/100f) },
            {0, 1f },
            {1, 1.5f },
            {2, 2f },
            {3, 2.5f },
            {4, 3f },
            {5, 3.5f },
            {6, 4f }
        };
    }
}
