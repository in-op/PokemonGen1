using System;

namespace PokemonGeneration1.Source.PokemonData
{
    public static class ExpCalculator
    {
        public static float ExpNeededForLevel(
            ExperienceGroup expGroup,
            float level)
        {
            switch (expGroup)
            {
                case ExperienceGroup.Fast:
                    return
                        ((4f * (level * level * level))
                        / 5f);
                case ExperienceGroup.MediumFast:
                    return
                        (level * level * level);
                case ExperienceGroup.MediumSlow:
                    return
                        (((6f * (level * level * level)) / 5f)
                        - (15f * (level * level))
                        + (100f * level) - 140f);
                case ExperienceGroup.Slow:
                    return
                        ((5f * (level * level * level))
                        / 4f);
                default:
                    throw new Exception("Invalid ExperienceGroup value given as input");
            }
        }
    }
}
