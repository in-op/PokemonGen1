using System;
using System.Collections.Generic;
using PokemonGeneration1.Source.Moves;

namespace PokemonGeneration1.Source.PokemonData
{
    /// <summary>
    /// Represents a Pokemon with all core data and legal tranformation functions.
    /// </summary>
    public sealed class Pokemon
    {
        public int Number { get; private set; }

        public string Species { get => SpeciesData.Names[Number]; }
        public Type Type1 { get => SpeciesData.Types[Number][0]; }
        public Type Type2 { get => SpeciesData.Types[Number][1]; }

        public float Level { get; private set; }
        public Status Status { get; private set; }
        public float CurrentHP { get; private set; }

        public Move Move1 { get; private set; }
        public Move Move2 { get; private set; }
        public Move Move3 { get; private set; }
        public Move Move4 { get; private set; }

        public float Exp { get; private set; }
        public float ExpYield { get => SpeciesData.ExpYield[Number]; }
        public ExperienceGroup ExpGroup { get => SpeciesData.ExpGroup[Number]; }

        private Stats Stats;
        public float HP { get => Stats.HP; }
        public float Attack { get => Stats.Attack; }
        public float Defense { get => Stats.Defense; }
        public float Special { get => Stats.Special; }
        public float Speed { get => Stats.Speed; }

        private BaseStats BaseStats { get => SpeciesData.BaseStats[Number]; }
        public float BaseHP { get => BaseStats.HP; }
        public float BaseAttack { get => BaseStats.Attack; }
        public float BaseDefense { get => BaseStats.Defense; }
        public float BaseSpecial { get => BaseStats.Special; }
        public float BaseSpeed { get => BaseStats.Speed; }
        
        private readonly DeterminantValues DVs;
        public float HPDV { get => DVs.HP; }
        public float AttackDV { get => DVs.Attack; }
        public float DefenseDV { get => DVs.Defense; }
        public float SpecialDV { get => DVs.Special; }
        public float SpeedDV { get => DVs.Speed; }

        private StatExp StatExp;
        public float HPExp { get => StatExp.HP; }
        public float AttackExp { get => StatExp.Attack; }
        public float DefenseExp { get => StatExp.Defense; }
        public float SpecialExp { get => StatExp.Special; }
        public float SpeedExp { get => StatExp.Speed; }
        
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
            Status = Status.Burn;
            Burned?.Invoke(this, EventArgs);
        }
        public void Freeze()
        {
            Status = Status.Freeze;
            Frozen?.Invoke(this, EventArgs);
        }
        public void Paralyze()
        {
            Status = Status.Paralysis;
            Paralyzed?.Invoke(this, EventArgs);
        }
        public void Poison()
        {
            Status = Status.Poison;
            Poisoned?.Invoke(this, EventArgs);
        }
        public void BadlyPoison()
        {
            Status = Status.BadlyPoisoned;
            BadlyPoisoned?.Invoke(this, EventArgs);
        }
        public void ChangeBadlyPoisonToPoison()
        {
            Status = Status.Poison;
        }
        public void Sleep()
        {
            Status = Status.Sleep;
            FellAsleep?.Invoke(this, EventArgs);
        }
        public void ClearStatus()
        {
            Status = Status.Null;
            StatusCleared?.Invoke(this, EventArgs);
        }
        public void Faint()
        {
            Status = Status.Fainted;
            Fainted?.Invoke(this, EventArgs);
        }



        public void Damage(float amount)
        {
            CurrentHP -= amount;
            if (CurrentHP < 0) CurrentHP = 0;
            if (CurrentHP == 0) Faint();
        }

        public void RestoreHP(float amount)
        {
            float gained = 0f;
            while (CurrentHP < Stats.HP &&
                   gained < amount)
            {
                CurrentHP++;
                gained++;
            }

            GainedHP?.Invoke(this, new GainedHPEventArgs(this, gained));
        }


        public static Pokemon GeneratePreMadePokemon(
            int index,
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
            poke.Stats = StatCalculator.CreateStatsFor(poke);
            poke.CurrentHP = poke.Stats.HP;
            return poke;
        }

        public static Pokemon GenerateWildPokemon(int index, int level)
        {
            return new Pokemon(index, level);
        }

        private Pokemon(int index)
        {
            Number = index;
            StatExp = new StatExp();
            DVs = DeterminantValues.CreateRandom();
            Status = Status.Null;
            EventArgs = new PokemonEventArgs() { pokemon = this };
        }
        private Pokemon(int index, int level) : this(index)
        {
            Exp = ExpCalculator.ExpNeededForLevel(ExpGroup, level);
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

            Stats = StatCalculator.CreateStatsFor(this);
            CurrentHP = Stats.HP;
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
                        Move1 = MoveFactory.Create(moveIndex);
                    }
                    else if (Move2 == null)
                    {
                        Move2 = MoveFactory.Create(moveIndex);
                    }
                    else if (Move3 == null)
                    {
                        Move3 = MoveFactory.Create(moveIndex);
                    }
                    else if (Move4 == null)
                    {
                        Move4 = MoveFactory.Create(moveIndex);
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
                                    Move1 = MoveFactory.Create(moveIndex);
                                    break;
                                case 2:
                                    Move2 = MoveFactory.Create(moveIndex);
                                    break;
                                case 3:
                                    Move3 = MoveFactory.Create(moveIndex);
                                    break;
                                case 4:
                                    Move4 = MoveFactory.Create(moveIndex);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private bool AlreadyKnowsMove(int moveIndex)
        {
            return (Move1?.Index == moveIndex) ||
                   (Move2?.Index == moveIndex) ||
                   (Move3?.Index == moveIndex) ||
                   (Move4?.Index == moveIndex);
        }
        

    }
}
