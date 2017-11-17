namespace PokemonGeneration1.Source.PokemonData
{
    public abstract class ExperienceGroup
    {
        public static readonly ExperienceGroup Fast = new FastGroup();
        public static readonly ExperienceGroup MediumFast = new MediumFastGroup();
        public static readonly ExperienceGroup MediumSlow = new MediumSlowGroup();
        public static readonly ExperienceGroup Slow = new SlowGroup();

        public abstract float ExpAt(float level);
        

        private sealed class FastGroup : ExperienceGroup
        {
            public sealed override float ExpAt(float level)
            {
                return
                    ((4f * (level * level * level))
                    / 5f);
            }
        }

        private sealed class MediumFastGroup : ExperienceGroup
        {
            public sealed override float ExpAt(float level)
            {
                return (level * level * level);
            }
        }

        private sealed class MediumSlowGroup : ExperienceGroup
        {
            public sealed override float ExpAt(float level)
            {
                return
                    (((6f * (level * level * level)) / 5f)
                    - (15f * (level * level))
                    + (100f * level) - 140f);
            }
        }

        private sealed class SlowGroup : ExperienceGroup
        {
            public sealed override float ExpAt(float level)
            {
                return
                    ((5f * (level * level * level))
                    / 4f);
            }
        }
    }
}
