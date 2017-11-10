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

        public string Species => SpeciesData.Names[Number];
        public Type Type1 => SpeciesData.Types[Number][0];
        public Type Type2 => SpeciesData.Types[Number][1];

        public float Level { get; private set; }
        public Status Status { get; private set; }
        public float CurrentHP { get; private set; }

        public Move Move1 { get; private set; }
        public Move Move2 { get; private set; }
        public Move Move3 { get; private set; }
        public Move Move4 { get; private set; }

        public float Exp { get; private set; }
        public float ExpYield => SpeciesData.ExpYield[Number]; 
        public ExperienceGroup ExpGroup => SpeciesData.ExpGroup[Number];

        private Stats Stats;
        public float HP => Stats.HP; 
        public float Attack => Stats.Attack; 
        public float Defense => Stats.Defense; 
        public float Special => Stats.Special; 
        public float Speed => Stats.Speed; 

        private Stats BaseStats => SpeciesData.BaseStats[Number];
        public float BaseHP => BaseStats.HP;
        public float BaseAttack => BaseStats.Attack;
        public float BaseDefense => BaseStats.Defense;
        public float BaseSpecial => BaseStats.Special;
        public float BaseSpeed => BaseStats.Speed;
        
        private readonly Stats DVs;
        public float HPDV => DVs.HP;
        public float AttackDV => DVs.Attack;
        public float DefenseDV => DVs.Defense;
        public float SpecialDV => DVs.Special;
        public float SpeedDV => DVs.Speed;

        private StatExp StatExp;
        public float HPExp => StatExp.HP;
        public float AttackExp => StatExp.Attack;
        public float DefenseExp => StatExp.Defense;
        public float SpecialExp => StatExp.Special;
        public float SpeedExp => StatExp.Speed;
        
        private PokemonEventArgs EventArgs;

        public float CatchRate => SpeciesData.CatchRate[Number];

        private string nickname;
        public string Nickname
        {
            get => nickname ?? Species;
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
            float gained = GainHP(amount);
            GainedHP?.Invoke(this, new GainedHPEventArgs(this, gained));
        }
        private float GainHP(float amount)
        {
            float gained = 0f;
            while (CurrentHP < Stats.HP && gained < amount)
            {
                CurrentHP++;
                gained++;
            }
            return gained;
        }

        

        private Pokemon(
            int number,
            float level,
            Status status,
            float currentHp,
            Move move1,
            Move move2,
            Move move3,
            Move move4,
            float exp,
            Stats stats,
            Stats dvs,
            StatExp statExp,
            string nickname)
        {
            Number = number;
            Level = level;
            Status = status;
            CurrentHP = currentHp;
            Move1 = move1;
            Move2 = move2;
            Move3 = move3;
            Move4 = move4;
            Exp = exp;
            Stats = stats;
            DVs = dvs;
            StatExp = statExp;
            EventArgs = new PokemonEventArgs() { pokemon = this };
            Nickname = nickname;
        }

        public static Pokemon GenerateWildPokemon(int number, int level) =>
            new Pokemon(number, level);

        public static Stats CreateRandomDVs()
        {
            Random rng = new Random();

            float attack = rng.Next(0, 16);
            float defense = rng.Next(0, 16);
            float special = rng.Next(0, 16);
            float speed = rng.Next(0, 16);

            float hp = 0f;
            if (attack % 2f == 1f) hp += 8f;
            if (defense % 2f == 1f) hp += 4f;
            if (special % 2f == 1f) hp += 1f;
            if (speed % 2f == 1f) hp += 2f;

            return new Stats(
                hp, attack, defense, special, speed);
        }

        private Pokemon(int number)
        {
            Number = number;
            StatExp = new StatExp();
            DVs = CreateRandomDVs();
            Status = Status.Null;
            EventArgs = new PokemonEventArgs() { pokemon = this };
        }
        private Pokemon(int number, int level) : this(number)
        {
            Exp = ExpCalculator.ExpNeededForLevel(ExpGroup, level);
            Level = 1;

            //fill out moves by growing the Pokemon level by level
            for (int i = 1; i < level + 1; i++)
            {
                if (PokemonLearnset.CanLearnMoveAtThisLevel(number, i))
                {
                    LearnMovesForLevel85PercentProb(number);
                }
                Level++;
            }

            Stats = StatCalculator.CreateStatsFor(this);
            CurrentHP = Stats.HP;
        }

        private void LearnMovesForLevel85PercentProb(int number)
        {
            List<int> indicesOfMovesToLearn = PokemonLearnset.GetAllMoveIndicesOfMovesLearnedAtThisLevel(number, (int)Level);
            foreach (int moveIndex in indicesOfMovesToLearn)
                if (!AlreadyKnowsMove(moveIndex))
                    if (Move1 == null)
                        Move1 = MoveFactory.Create(moveIndex);
                    else if (Move2 == null)
                        Move2 = MoveFactory.Create(moveIndex);
                    else if (Move3 == null)
                        Move3 = MoveFactory.Create(moveIndex);
                    else if (Move4 == null)
                        Move4 = MoveFactory.Create(moveIndex);
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


        private bool AlreadyKnowsMove(int moveIndex) =>
            (Move1?.Index == moveIndex) ||
            (Move2?.Index == moveIndex) ||
            (Move3?.Index == moveIndex) ||
            (Move4?.Index == moveIndex);






        public class Builder
        {
            //must be specified:
            int number;
            float level;
            //optional:
            Status status;

            float currentHP;
            bool currentHpPreset;

            Move move1;
            Move move2;
            Move move3;
            Move move4;

            float exp;
            bool expPreset;

            Stats stats;
            Stats dvs;
            StatExp statExp;
            string nickname;

            private Builder() { }

            public static Builder Init(int number, float level)
            {
                return new Builder() { number = number, level = level };
            }

            public Builder Status(Status status)
            {
                this.status = status;
                return this;
            }

            public Builder CurrentHP(float currentHP)
            {
                this.currentHP = currentHP;
                currentHpPreset = true;
                return this;
            }

            public Builder Move1(Move move1)
            {
                this.move1 = move1;
                return this;
            }

            public Builder Move2(Move move2)
            {
                this.move2 = move2;
                return this;
            }

            public Builder Move3(Move move3)
            {
                this.move3 = move3;
                return this;
            }

            public Builder Move4(Move move4)
            {
                this.move4 = move4;
                return this;
            }

            public Builder Exp(float exp)
            {
                this.exp = exp;
                expPreset = true;
                return this;
            }

            public Builder Stats(Stats stats)
            {
                this.stats = stats;
                return this;
            }

            public Builder DVs(Stats dvs)
            {
                this.dvs = dvs;
                return this;
            }

            public Builder StatExp(StatExp statExp)
            {
                this.statExp = statExp;
                return this;
            }

            public Builder Nickname(string nickname)
            {
                this.nickname = nickname;
                return this;
            }


            public Pokemon Create()
            {
                if (statExp == null) statExp = new StatExp();
                if (dvs == null) dvs = CreateRandomDVs();
                Stats baseStats = SpeciesData.BaseStats[number];
                if (stats == null) stats = new Stats(
                    StatCalculator.HPStat(baseStats.HP, dvs.HP, StatCalculator.StatPoint(statExp.HP), level),
                    StatCalculator.NonHPStat(baseStats.Attack, dvs.Attack, StatCalculator.StatPoint(statExp.Attack), level),
                    StatCalculator.NonHPStat(baseStats.Defense, dvs.Defense, StatCalculator.StatPoint(statExp.Defense), level),
                    StatCalculator.NonHPStat(baseStats.Special, dvs.Special, StatCalculator.StatPoint(statExp.Special), level),
                    StatCalculator.NonHPStat(baseStats.Speed, dvs.Speed, StatCalculator.StatPoint(statExp.Speed), level));
                if (!expPreset) exp = ExpCalculator.ExpNeededForLevel(SpeciesData.ExpGroup[number], level);

                bool movesPreset = false;
                if (move1 != null) movesPreset = true;
                if (move2 != null) movesPreset = true;
                if (move3 != null) movesPreset = true;
                if (move4 != null) movesPreset = true;
                if (!movesPreset)
                {
                    //grow
                }

                if (!currentHpPreset) currentHP = stats.HP;

                return new Pokemon(
                    number,
                    level,
                    status,
                    currentHP,
                    move1,
                    move2,
                    move3,
                    move4,
                    exp,
                    stats,
                    dvs,
                    statExp,
                    nickname);
            }
        }


    }
}
