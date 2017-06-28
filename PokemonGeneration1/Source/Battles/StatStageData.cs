using System.Collections.Generic;

namespace PokemonGeneration1.Source.Battles
{
    public static class StatStageData
    {
        public static readonly Dictionary<int, float> Multiplier =
            new Dictionary<int, float>()
        {
            {-6, 0.25f },
            {-5, 0.28f },
            {-4, 0.33f },
            {-3, 0.4f },
            {-2, 0.5f },
            {-1, 0.66f },
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
