using System;
using System.Collections.Generic;
using PokemonGeneration1.Source.Moves;

namespace PokemonGeneration1.Source.PokemonData
{
    /// <summary>
    /// Represents a Pokemon with all core data.
    /// </summary>
    public sealed class Pokemon
    {
        public int Number { get; private set; }
        public string Species { get; private set; }
        public Type Type1 { get; private set; }
        public Type Type2 { get; private set; }

        public float Level { get; private set; }
        public Status Status { get; private set; }
        public float HP { get; private set; }

        public Move Move1 { get; private set; }
        public Move Move2 { get; private set; }
        public Move Move3 { get; private set; }
        public Move Move4 { get; private set; }

        public float Exp { get; private set; }
        public float ExpYield { get; private set; }
        public ExperienceGroup ExpGroup { get; private set; }

        private Stats Stats;
        public float HPStat { get => Stats.HP; }
        public float Attack { get => Stats.Attack; }
        public float Defense { get => Stats.Defense; }
        public float Special { get => Stats.Special; }
        public float Speed { get => Stats.Speed; }

        private BaseStats BaseStats;
        public float BaseSpeed { get => BaseStats.Speed; }

        private StatExp StatExp;
        private DeterminantValues DVs;
        private PokemonEventArgs EventArgs;
        public float CatchRate { get; private set; }

        private string nickname;
        public string Nickname
        {
            get
            {
                if (nickname == null)
                    return Species;
                else return nickname;
            }
            set { nickname = value; }
        }



        public event EventHandler<PokemonEventArgs> Burned;
        public event EventHandler<PokemonEventArgs> Frozen;
        public event EventHandler<PokemonEventArgs> Paralyzed;
        public event EventHandler<PokemonEventArgs> Poisoned;
        public event EventHandler<PokemonEventArgs> BadlyPoisoned;
        public event EventHandler<PokemonEventArgs> FellAsleep;
        public event EventHandler<PokemonEventArgs> StatusCleared;
        public event EventHandler<PokemonEventArgs> Fainted;
        public event EventHandler<PokemonEventArgs> LeveledUp;
        public event EventHandler<GainedExpEventArgs> GainedExp;
        public event EventHandler<GainedHPEventArgs> GainedHP;




        public void Burn()
        {
            Status = Status.BURN;
            Burned?.Invoke(this, EventArgs);
        }
        public void Freeze()
        {
            Status = Status.FREEZE;
            Frozen?.Invoke(this, EventArgs);
        }
        public void Paralyze()
        {
            Status = Status.PARALYSIS;
            Paralyzed?.Invoke(this, EventArgs);
        }
        public void Poison()
        {
            Status = Status.POISON;
            Poisoned?.Invoke(this, EventArgs);
        }
        public void BadlyPoison()
        {
            Status = Status.BADLYPOISONED;
            BadlyPoisoned?.Invoke(this, EventArgs);
        }
        public void ChangeBadlyPoisonToPoison()
        {
            Status = Status.POISON;
        }
        public void Sleep()
        {
            Status = Status.SLEEP;
            FellAsleep?.Invoke(this, EventArgs);
        }
        public void ClearStatus()
        {
            Status = Status.NONE;
            StatusCleared?.Invoke(this, EventArgs);
        }
        public void Faint()
        {
            Status = Status.FAINTED;
            Fainted?.Invoke(this, EventArgs);
        }



        public void Damage(float amount)
        {
            HP -= amount;
            if (HP <= 0 ) {
                HP = 0;
                Faint();
            }
        }
        public void RestoreHP(float amount)
        {
            float gained = 0f;
            while (HP < Stats.HP &&
                   gained < amount)
            {
                HP++;
                gained++;
            }

            GainedHP?.Invoke(this, new GainedHPEventArgs(this, gained));
        }




        public void GainExp(Pokemon fallenFoe, int numberOfPokemonParticipated)
        {
            //TODO finish
            //  gain exp, and gain statexp
            float expToGain = 0;
            GainedExp?.Invoke(this, new GainedExpEventArgs(this, expToGain));

            while (Exp > ExpNeededForLevel(Level + 1f))
            {
                LevelUp();
            }
        }
        private void LevelUp()
        {
            Level++;
            Stats = CalculateStats();
            OnLeveledUp();
        }
        private void OnLeveledUp()
        {
            LeveledUp?.Invoke(this, EventArgs);
        }


        


        
        public static Pokemon GeneratePreMadePokemon(int index,
                                                     int level,
                                                     Move move1,
                                                     Move move2,
                                                     Move move3,
                                                     Move move4)
        {
            Pokemon poke = new Pokemon(index);
            poke.Move1 = move1;
            poke.Move2 = move2;
            poke.Move3 = move3;
            poke.Move4 = move4;
            poke.Level = level;
            poke.Stats = poke.CalculateStats();
            poke.HP = poke.Stats.HP;
            return poke;
        }
        public static Pokemon GenerateWildPokemon(int index, int level)
        {
            return new Pokemon(index, level);
        }
        private Pokemon(int index)
        {
            Number = index;
            Species = PokemonInitialization.Species(index);
            Type1 = PokemonInitialization.Type1(index);
            Type2 = PokemonInitialization.Type2(index);
            ExpGroup = PokemonInitialization.ExpGroup(index);
            StatExp = new StatExp();
            BaseStats = PokemonInitialization.BaseStats(index);
            DVs = new DeterminantValues();
            Status = Status.NONE;
            EventArgs = new PokemonEventArgs() { pokemon = this };
        }
        private Pokemon(int index, int level) : this(index)
        {
            Exp = ExpNeededForLevel(level);
            Level = 1;

            //fill out moves by growing the Pokemon level by level
            for (int i = 1; i < level + 1; i++)
            {
                if (PokemonLearnset.CanLearnMoveAtThisLevel(index, i))
                {
                    LearnMovesForLevel85PercentProb(index);
                }
                Level++;
            }

            Stats = CalculateStats();
            HP = Stats.HP;
        }

        private void LearnMovesForLevel85PercentProb(int index)
        {
            List<int> indicesOfMovesToLearn = PokemonLearnset.GetAllMoveIndicesOfMovesLearnedAtThisLevel(index, (int)Level);
            foreach (int moveIndex in indicesOfMovesToLearn)
            {
                //only add move if it doesn't already know it
                if (!AlreadyKnowsMove(moveIndex))
                {
                    if (Move1 == null)
                    {
                        Move1 = MoveFactory.CreateMove(moveIndex);
                    }
                    else if (Move2 == null)
                    {
                        Move2 = MoveFactory.CreateMove(moveIndex);
                    }
                    else if (Move3 == null)
                    {
                        Move3 = MoveFactory.CreateMove(moveIndex);
                    }
                    else if (Move4 == null)
                    {
                        Move4 = MoveFactory.CreateMove(moveIndex);
                    }
                    else
                    {
                        Random rng = new Random();
                        if (rng.Next(0, 100) < 85)
                        {
                            int moveSlot = rng.Next(1, 5);
                            switch (moveSlot)
                            {
                                case 1:
                                    Move1 = MoveFactory.CreateMove(moveIndex);
                                    break;
                                case 2:
                                    Move2 = MoveFactory.CreateMove(moveIndex);
                                    break;
                                case 3:
                                    Move3 = MoveFactory.CreateMove(moveIndex);
                                    break;
                                case 4:
                                    Move4 = MoveFactory.CreateMove(moveIndex);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public bool AlreadyKnowsMove(int moveIndex)
        {
            return (Move1 != null && Move1.GetIndex() == moveIndex) ||
                   (Move2 != null && Move2.GetIndex() == moveIndex) ||
                   (Move3 != null && Move3.GetIndex() == moveIndex) ||
                   (Move4 != null && Move4.GetIndex() == moveIndex);
        }
        
        private float ExpNeededForLevel(float level)
        {
            switch (ExpGroup)
            {
                case ExperienceGroup.Fast:
                    return ((4f * (level * level * level)) / 5f);
                case ExperienceGroup.MediumFast:
                    return (level * level * level);
                case ExperienceGroup.MediumSlow:
                    return (((6f * (level * level * level)) / 5f) - (15f * (level * level)) + (100f * level) - 140f);
                case ExperienceGroup.Slow:
                    return ((5f * (level * level * level)) / 4f);
            }
            throw new Exception("error in ExpNeededForLevel()");
        }
        private Stats CalculateStats()
        {
            return new Stats(
                calculateHPStat(BaseStats.HP, DVs.HP, calculateStatPoint(StatExp.HP), Level),
                calculateNonHPStat(BaseStats.Attack, DVs.Attack, calculateStatPoint(StatExp.Attack), Level),
                calculateNonHPStat(BaseStats.Defense, DVs.Defense, calculateStatPoint(StatExp.Defense), Level),
                calculateNonHPStat(BaseStats.Special, DVs.Special, calculateStatPoint(StatExp.Special), Level),
                calculateNonHPStat(BaseStats.Speed, DVs.Speed, calculateStatPoint(StatExp.Speed), Level)
                );
        }
        private static float calculateNonHPStat(float baseStat,
                                               float DV,
                                               float statPoint,
                                               float level)
        {
            return (float)Math.Floor(((((baseStat + DV) * 2) + statPoint) * level / 100) + 5);
        }
        private static float calculateHPStat(float baseStat,
                                            float DV,
                                            float statPoint,
                                            float level)
        {
            return (float)Math.Floor(((((baseStat + DV) * 2) + statPoint) * level / 100) + level + 10);
        }



        private static float calculateStatPoint(float statExp)
        {
            return (float)Math.Floor( Math.Min(255f, Math.Floor(Math.Sqrt( Math.Max(0, statExp - 1f)) + 1f ) ) / 4f );
        }

    }
}
