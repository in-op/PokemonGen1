using System;
using PokemonGeneration1.Source.PokemonData;
using PokemonGeneration1.Source.Moves;
using System.Collections.Generic;

namespace PokemonGeneration1.Source.Battles
{
    /// <summary>
    /// Wrapper class for Pokemon objects covering all data and logic for battling.
    /// </summary>
    public class BattlePokemon
    {
        private BattlePokemonEventArgs EventArgs;

        public Pokemon Pokemon { get; private set; }
        private StatStageModifiers StatStageModifiers;

        public Move Move1 { get; private set; }
        public Move Move2 { get; private set; }
        public Move Move3 { get; private set; }
        public Move Move4 { get; private set; }

        public Move LastMoveUsed { get; set; }
        public Move MirrorMove { get; set; }
        private Move TwoTurnMove;
        private Move MultiTurnMove;

        private Conversion Conversion;
        private Substitute Substitute;
        private Transform Transform;
        private Bide Bide;
        private Disable Disable;

        private float DamageForCounter;
        private float N;

        private int ConfusionTurnsLeft;
        private int SleepTurnsLeft;

        private bool SwitchedPokemonThisTurn;
        private bool FocusEnergyActive;
        private bool DireHitActive;
        private bool Seeded;
        private bool SemiInvulnerable;
        public bool PartiallyTrapped { get; private set; }
        private bool PartiallyTrappedEndingThisTurn;
        private bool Flinching;
        private bool ParalysisDecreasingSpeed;
        private bool BurnDecreasingAttack;
        private bool MistActive;
        private bool LightScreen;
        private bool Reflect;


        public string Name => Pokemon.Nickname;
        public Status Status => Pokemon.Status;


        public Type Type1 =>
            Conversion.IsActive ? Conversion.Type1 :
            Transform.Active ? Transform.Type1 :
            Pokemon.Type1;

        public Type Type2 =>
            Conversion.IsActive ? Conversion.Type2 :
            Transform.Active ? Transform.Type2 :
            Pokemon.Type2;



        //events from Pokemon
        public event EventHandler<BattlePokemonEventArgs> Burned;
        public event EventHandler<BattlePokemonEventArgs> Frozen;
        public event EventHandler<BattlePokemonEventArgs> Paralyzed;
        public event EventHandler<BattlePokemonEventArgs> Poisoned;
        public event EventHandler<BattlePokemonEventArgs> BadlyPoisoned;
        public event EventHandler<BattlePokemonEventArgs> FellAsleep;
        public event EventHandler<BattlePokemonEventArgs> StatusCleared;
        public event EventHandler<BattlePokemonEventArgs> Fainted;
        public event EventHandler<BattlePokemonEventArgs> LeveledUp;
        public event EventHandler<Battles.GainedExpEventArgs> GainedExp;
        public event EventHandler<Battles.GainedHPEventArgs> GainedHP;

        //events from Move
        public Action<MoveEventArgs> MoveUsed;
        public Action<MoveEventArgs> MoveFailed;
        public Action<MoveEventArgs> MoveMissed;
        public Action<MoveEventArgs> MoveHadNoEffect;
        public Action<MoveEventArgs> MoveSuperEffective;
        public Action<MoveEventArgs> MoveNotVeryEffective;
        public Action<MoveEventArgs> MoveCriticalHit;
        public Action<MoveEventArgs> MoveOneHitKO;
        public Action<MoveEventArgs> PayDayTriggered;
        public Action<MoveEventArgs> SolarBeamFirstTurn;
        public Action<MoveEventArgs> RazorWindFirstTurn;
        public Action<MoveEventArgs> BidingTime;
        public Action<MoveEventArgs> BideUnleased;
        public Action<MoveEventArgs> FlyFirstTurn;
        public Action<MoveEventArgs> AttackContinues;
        public Action<MoveEventArgs> CrashDamage;
        public Action<MoveEventArgs> HurtByRecoilDamage;
        public Action<MoveEventArgs> ThrashingAbout;
        public Action<MoveEventArgs> HyperBeamRecharging;
        public Action<MoveEventArgs> SuckedHealth;
        public Action<MoveEventArgs> DugAHole;
        public Action<MoveEventArgs> SkullBashFirstTurn;
        public Action<MoveEventArgs> SkyAttackFirstTurn;
        public Action<MoveEventArgs> RegainedHealth;


        //events unique to BattlePokemon
        public event EventHandler<SwitchedOutEventArgs> SwitchedOut;
        public event EventHandler<Battles.StatStageChangedEventArgs> StatStageChanged;
        public event EventHandler<BattlePokemonEventArgs> SubstituteActivated;
        public event EventHandler<BattlePokemonEventArgs> ConversionActivated;
        public event EventHandler<TransformedEventArgs> TransformActivated;
        public event EventHandler<BattlePokemonEventArgs> LeechSeedActivated;
        public event EventHandler<BattlePokemonEventArgs> LeechSeedSaps;
        public event EventHandler<BattlePokemonEventArgs> Confused;
        public event EventHandler<BattlePokemonEventArgs> HurtFromConfusion;
        public event EventHandler<BattlePokemonEventArgs> Flinched;
        public event EventHandler<BattlePokemonEventArgs> FullyParalyzed;
        public event EventHandler<BattlePokemonEventArgs> FrozenSolid;
        public event EventHandler<BattlePokemonEventArgs> FastAsleep;
        public event EventHandler<BattlePokemonEventArgs> WokeUp;
        public event EventHandler<Battles.MoveEventArgs> Disabled;
        public event EventHandler<BattlePokemonEventArgs> MoveAttemptedButIsDisabled;
        public event EventHandler<Battles.MimicMoveEventArgs> Mimic;

        protected virtual void OnSwitchedOut(Pokemon switchIn)
        {
            SwitchedOut?.Invoke(this, new SwitchedOutEventArgs()
            {
                switchIn = switchIn,
                battlePokemon = this,
                pokemon = Pokemon
            });
        }

        protected virtual void OnStatStageChanged(StatType stat, int amount)
        {
            StatStageChanged?.Invoke(this, new StatStageChangedEventArgs()
            {
                pokemon = Pokemon,
                battlePokemon = this,
                statChanged = stat,
                change = amount
            });
        }

        protected virtual void OnSubstituteActivated()
        {
            SubstituteActivated?.Invoke(this, new BattlePokemonEventArgs()
            {
                pokemon = Pokemon,
                battlePokemon = this
            });
        }

        protected virtual void OnConversionActivated()
        {
            ConversionActivated?.Invoke(this, new BattlePokemonEventArgs()
            {
                pokemon = Pokemon,
                battlePokemon = this
            });
        }

        protected virtual void OnTransformActivated(BattlePokemon transformInto)
        {
            TransformActivated?.Invoke(this, new TransformedEventArgs()
            {
                pokemon = Pokemon,
                battlePokemon = this,
                transformInto = transformInto
            });
        }

        protected virtual void OnLeechSeedActivated()
        { LeechSeedActivated?.Invoke(this, EventArgs); }

        protected virtual void OnLeechSeedSaps()
        {
            LeechSeedSaps?.Invoke(this, new BattlePokemonEventArgs()
            {
                pokemon = Pokemon,
                battlePokemon = this
            });
        }

        protected virtual void OnConfused()
        { Confused?.Invoke(this, EventArgs); }

        protected virtual void OnHurtFromConfusion()
        { HurtFromConfusion?.Invoke(this, EventArgs); }

        protected virtual void OnFlinched()
        { Flinched?.Invoke(this, EventArgs); }

        protected virtual void OnFullyParalyzed()
        { FullyParalyzed?.Invoke(this, EventArgs); }

        protected virtual void OnFrozenSolid()
        { FrozenSolid?.Invoke(this, EventArgs); }

        protected virtual void OnFastAsleep()
        { FastAsleep?.Invoke(this, EventArgs); }

        protected virtual void OnWokeUp()
        { WokeUp?.Invoke(this, EventArgs); }

        protected virtual void OnDisabled(Move move)
        {
            Disabled?.Invoke(this, new MoveEventArgs()
            {
                battlePokemon = this,
                pokemon = Pokemon,
                move = move
            });
        }

        protected virtual void OnMoveAttemptedButIsDisabled()
        { MoveAttemptedButIsDisabled?.Invoke(this, EventArgs); }

        protected virtual void OnMimic(Move moveToCopy, BattlePokemon opponent)
        {
            Mimic?.Invoke(this, new MimicMoveEventArgs()
            {
                pokemon = Pokemon,
                battlePokemon = this,
                opponent = opponent,
                moveMimiced = moveToCopy
            });
        }




        public bool DidPokemonSwitchThisTurn()
        {
            return SwitchedPokemonThisTurn;
        }



        public void ActivatePartialTrapping()
        {
            PartiallyTrapped = true;
        }
        public void DeactivatePartialTrappingAtEndOfTurn()
        {
            PartiallyTrappedEndingThisTurn = true;
        }



        public void Confuse()
        {
            ConfusionTurnsLeft = new Random().Next(1, 5);
        }
        public bool IsConfused()
        {
            return ConfusionTurnsLeft > 0;
        }
        public void DeactivateConfusion()
        {
            ConfusionTurnsLeft = 0;
        }



        public void Flinch()
        {
            if (!Substitute.IsActive) Flinching = true;
        }



        public void AttemptChangeBadlyPoisonToPoison()
        {
            if (IsBadlyPoisoned) Pokemon.ChangeBadlyPoisonToPoison();
        }


        public void ActivateDisable(Move move, int turns)
        {
            OnDisabled(move);
            Disable.Activate(move, turns);
        }
        public void DeactivateDisable()
        {
            Disable.Deactivate();
        }
        public bool IsDisabled()
        {
            return Disable.IsActive();
        }



        public void ActivateMist()
        {
            MistActive = true;
        }
        public void DeactivateMist()
        {
            MistActive = false;
        }
        public bool IsMistActive() { return MistActive; }


        public bool IsLightScreenActive() { return LightScreen; }
        public void ActivateLightScreen() { LightScreen = true; }
        public void DeactivateLightScreen() { LightScreen = false; }

        public bool IsReflectActive() { return Reflect; }
        public void ActivateReflect() { Reflect = true; }
        public void DeactivateReflect() { Reflect = false; }


        public float GetDamageForCounter()
        {
            return DamageForCounter;
        }
        


        public void MimicMove(Move mimicItself, BattlePokemon opponent)
        {
            Move moveToCopy = opponent.LastMoveUsed;

            if (moveToCopy == null) //failsafe for using mimic on first turn before a last move used is even initialized
                moveToCopy = opponent.Move1;

            OnMimic(moveToCopy, opponent);
            Move newMove = MoveFactory.Create(moveToCopy.Index);

            if (Move1 == mimicItself) Move1 = newMove;
            else if (Move2 == mimicItself) Move2 = newMove;
            else if (Move3 == mimicItself) Move3 = newMove;
            else if (Move4 == mimicItself) Move4 = newMove;
        }









        public void UpdateForEndOfTurn()
        {
            SwitchedPokemonThisTurn = false;
            Flinching = false;

            if (SleepTurnsLeft > 0) --SleepTurnsLeft;

            if (PartiallyTrappedEndingThisTurn)
            {
                PartiallyTrapped = false;
                PartiallyTrappedEndingThisTurn = false;
            }
        }




        





        public void AttemptMoveExecution(Move move, BattlePokemon opponent)
        {
            bool canMove = true;
            BeginningOfTurnEffects(ref canMove, move);

            if (canMove)
            {
                AttachMoveEventHandlers(move);
                move.ExecuteAndUpdate(this, opponent);
                DetachMoveEventHandlers(move);

                if (ConfusionTurnsLeft > 0) --ConfusionTurnsLeft;

                if (IsDisabled()) Disable.Tick();
            }

            EndOfTurnEffects(opponent);
        }
        private void BeginningOfTurnEffects(ref bool canMove, Move move)
        {
            if (Pokemon.Status == Status.Sleep)
            {
                canMove = false;
                if (SleepTurnsLeft > 0) OnFastAsleep();
                else
                {
                    OnWokeUp();
                    Pokemon.ClearStatus();
                }
                return;
            }
            if (Pokemon.Status == Status.Freeze)
            {
                canMove = false;
                OnFrozenSolid();
                return;
            }
            if (Pokemon.Status == Status.Paralysis &&
                new Random().Next(0, 100) < 25)
            {
                canMove = false;
                OnFullyParalyzed();

                if (LastMoveUsed != null)
                {
                    LastMoveUsed.IfActiveDisruptThrashingMove(this);
                }

                if (MultiTurnMove != null)
                {
                    DeactivateMultiTurnMove();
                }

                if (TwoTurnMove != null)
                {
                    DeactivateTwoTurnMove();
                }

                if (IsDisabled())
                {
                    Disable.Tick();
                }
                return;
            }

            if (ConfusionTurnsLeft > 0)
            {
                OnConfused();
                if (new Random().Next(0, 100) < 50)
                {
                    canMove = false;
                    OnHurtFromConfusion();
                    DamageFromConfusion();
                    if (LastMoveUsed != null)
                    {
                        LastMoveUsed.IfActiveDisruptThrashingMove(this);
                    }
                    --ConfusionTurnsLeft;

                    if (IsDisabled())
                    {
                        Disable.Tick();
                    }
                    return;
                }
            }

            if (Flinching)
            {
                canMove = false;
                OnFlinched();
                return;
            }

            if (IsDisabled() &&
                Disable.GetDisabledMove() == move)
            {
                canMove = false;
                OnMoveAttemptedButIsDisabled();
                return;
            }
        }
        private void EndOfTurnEffects(BattlePokemon opponent)
        {

            IfSeededThenSapHP(opponent);

            if (Status == Status.BadlyPoisoned)
            {
                DamagePokemonOnlyNoEffects(GetStatusConditionDamage());
                N += 1f;
            }

            else if (Status == Status.Poison)
            {
                DamagePokemonOnlyNoEffects(GetStatusConditionDamage());
            }

            else if (Status == Status.Burn)
            {
                DamagePokemonOnlyNoEffects(GetStatusConditionDamage());
            }
        }
        private void IfSeededThenSapHP(BattlePokemon opponent)
        {
            if (Seeded && !opponent.IsFainted)
            {
                OnLeechSeedSaps();
                float sap;
                if (HP < 16f)
                {
                    sap = 1f;
                }
                else
                {
                    sap = GetStatusConditionDamage();
                }
                float restore = Math.Min(sap, opponent.HP);
                DamagePokemonOnlyNoEffects(sap);
                opponent.RestoreHP(restore);
            }
        }
        private float GetStatusConditionDamage()
        {
            return (float)Math.Floor(HP / 16f) * N;
        }
        public void AttachMoveEventHandlers(Move move)
        {
            move.Used += MoveUsedHandler;
            move.Failed += MoveFailedHandler;
            move.Missed += MoveMissedHandler;
            move.NoEffect += MoveHadNoEffectHandler;
            move.SuperEffective += MoveSuperEffectiveHandler;
            move.NotVeryEffective += MoveNotVeryEffectiveHandler;
            move.CriticalHit += MoveCriticalHitHandler;
            move.OneHitKO += MoveOneHitKOHandler;
            move.PayDayTriggered += PayDayTriggeredHandler;
            move.SolarBeamFirstTurn += SolarBeamFirstTurnHandler;
            move.RazorWindFirstTurn += RazorWindFirstTurnHandler;
            move.BidingTime += BidingTimeHandler;
            move.BideUnleased += BideUnleashedHandler;
            move.FlyFirstTurn += FlyFirstTurnHandler;
            move.AttackContinues += AttackContinuesHandler;
            move.CrashDamage += CrashDamageHandler;
            move.HurtByRecoilDamage += HurtByRecoilDamageHandler;
            move.ThrashingAbout += ThrashingAboutHandler;
            move.HyperBeamRecharging += HyperBeamRechargingHandler;
            move.SuckedHealth += SuckedHealthHandler;
            move.DugAHole += DugAHoleHandler;
            move.SkullBashFirstTurn += SkullBashFirstTurnHandler;
            move.SkyAttackFirstTurn += SkyAttackFirstTurnHandler;
            move.RegainedHealth += RegainedHealthHandler;
        }
        public void DetachMoveEventHandlers(Move move)
        {
            move.Used -= MoveUsedHandler;
            move.Failed -= MoveFailedHandler;
            move.Missed -= MoveMissedHandler;
            move.NoEffect -= MoveHadNoEffectHandler;
            move.SuperEffective -= MoveSuperEffectiveHandler;
            move.NotVeryEffective -= MoveNotVeryEffectiveHandler;
            move.CriticalHit -= MoveCriticalHitHandler;
            move.OneHitKO -= MoveOneHitKOHandler;
            move.PayDayTriggered -= PayDayTriggeredHandler;
            move.SolarBeamFirstTurn -= SolarBeamFirstTurnHandler;
            move.RazorWindFirstTurn -= RazorWindFirstTurnHandler;
            move.BidingTime -= BidingTimeHandler;
            move.BideUnleased -= BideUnleashedHandler;
            move.FlyFirstTurn -= FlyFirstTurnHandler;
            move.AttackContinues -= AttackContinuesHandler;
            move.CrashDamage -= CrashDamageHandler;
            move.HurtByRecoilDamage -= HurtByRecoilDamageHandler;
            move.ThrashingAbout -= ThrashingAboutHandler;
            move.HyperBeamRecharging -= HyperBeamRechargingHandler;
            move.SuckedHealth -= SuckedHealthHandler;
            move.DugAHole -= DugAHoleHandler;
            move.SkullBashFirstTurn -= SkullBashFirstTurnHandler;
            move.SkyAttackFirstTurn -= SkyAttackFirstTurnHandler;
            move.RegainedHealth -= RegainedHealthHandler;
        }
        protected virtual void MoveUsedHandler(Move m)
        {
            MoveUsed?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void MoveFailedHandler(Move m)
        {
            MoveFailed?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void MoveMissedHandler(Move m)
        {
            MoveMissed?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void MoveHadNoEffectHandler(Move m)
        {
            MoveHadNoEffect?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void MoveSuperEffectiveHandler(Move m)
        {
            MoveSuperEffective?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void MoveNotVeryEffectiveHandler(Move m)
        {
            MoveNotVeryEffective?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void MoveCriticalHitHandler(Move m)
        {
            MoveCriticalHit?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void MoveOneHitKOHandler(Move m)
        {
            MoveOneHitKO?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void PayDayTriggeredHandler(Move m)
        {
            PayDayTriggered?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void SolarBeamFirstTurnHandler(Move m)
        {
            SolarBeamFirstTurn?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void RazorWindFirstTurnHandler(Move m)
        {
            RazorWindFirstTurn?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void BidingTimeHandler(Move m)
        {
            BidingTime?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void BideUnleashedHandler(Move m)
        {
            BideUnleased?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void FlyFirstTurnHandler(Move m)
        {
            FlyFirstTurn?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void AttackContinuesHandler(Move m)
        {
            AttackContinues?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void CrashDamageHandler(Move m)
        {
            CrashDamage?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void HurtByRecoilDamageHandler(Move m)
        {
            HurtByRecoilDamage?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void ThrashingAboutHandler(Move m)
        {
            ThrashingAbout?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void HyperBeamRechargingHandler(Move m)
        {
            HyperBeamRecharging?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void SuckedHealthHandler(Move m)
        {
            SuckedHealth?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void DugAHoleHandler(Move m)
        {
            DugAHole?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void SkullBashFirstTurnHandler(Move m)
        {
            SkullBashFirstTurn?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void SkyAttackFirstTurnHandler(Move m)
        {
            SkyAttackFirstTurn?.Invoke(CreateMoveEventArgs(m));
        }
        protected virtual void RegainedHealthHandler(Move m)
        {
            RegainedHealth?.Invoke(CreateMoveEventArgs(m));
        }
        private MoveEventArgs CreateMoveEventArgs(Moves.MoveEventArgs e)
        {
            return new MoveEventArgs()
            {
                pokemon = Pokemon,
                battlePokemon = this,
                move = e.move
            };
        }
        private MoveEventArgs CreateMoveEventArgs(Move m)
        {
            return new MoveEventArgs()
            {
                pokemon = Pokemon,
                battlePokemon = this,
                move = m
            };
        }





        public void SwitchOut(Pokemon switchIn)
        {
            OnSwitchedOut(switchIn);

            if (IsBadlyPoisoned)
                Pokemon.ChangeBadlyPoisonToPoison();
            
            DetachPokemonEventHandlers();
            Pokemon = switchIn;
            AttachPokemonEventHandlers();
            
            SetMovesToPokemonMoves();

            TwoTurnMove?.Abort();
            TwoTurnMove = null;
            MultiTurnMove?.Abort();
            MultiTurnMove = null;

            SwitchedPokemonThisTurn = true;
            Seeded = false;
            Conversion.Deactivate();
            Substitute.Deactivate();
            Transform.Deactivate();
            Bide.Deactivate();
            SemiInvulnerable = false;
            Flinching = false;
            ConfusionTurnsLeft = 0;
            Disable.Deactivate();
            MistActive = false;
            N = 1f;

            if (Pokemon.Status == Status.Paralysis)
                ParalysisDecreasingSpeed = true;
            else ParalysisDecreasingSpeed = false;

            if (Pokemon.Status == Status.Burn)
                BurnDecreasingAttack = true;
            else BurnDecreasingAttack = false;
        }
        private void SetMovesToPokemonMoves()
        {
            Move1 = Pokemon.Move1;
            Move2 = Pokemon.Move2;
            Move3 = Pokemon.Move3;
            Move4 = Pokemon.Move4;
        }





        public BattlePokemon(Pokemon pokemon)
        {
            Pokemon = pokemon;
            AttachPokemonEventHandlers();
            SetMovesToPokemonMoves();

            StatStageModifiers = new StatStageModifiers();
            Conversion = new Conversion();
            Substitute = new Substitute();
            Transform = new Transform();
            Bide = new Bide();
            MultiTurnMove = null;
            TwoTurnMove = null;
            Disable = new Disable();
            MistActive = false;
            LightScreen = false;
            N = 1f;
            InitializeEventArgs();
        }
        private void InitializeEventArgs()
        {
            EventArgs = new BattlePokemonEventArgs()
            {
                battlePokemon = this,
                pokemon = Pokemon
            };
        }
        private void AttachPokemonEventHandlers()
        {
            Pokemon.Burned += BurnedHandler;
            Pokemon.Frozen += FreezeHandler;
            Pokemon.Paralyzed += ParalyzedHandler;
            Pokemon.Poisoned += PoisonedHandler;
            Pokemon.BadlyPoisoned += BadlyPoisonedHandler;
            Pokemon.FellAsleep += FellAsleepHandler;
            Pokemon.StatusCleared += StatusClearedHandler;
            Pokemon.Fainted += FaintedHandler;
            Pokemon.LeveledUp += LeveledUpHandler;
            Pokemon.GainedExp += GainedExpHandler;
            Pokemon.GainedHP += GainedHPHandler;
        }
        private void DetachPokemonEventHandlers()
        {
            Pokemon.Burned -= BurnedHandler;
            Pokemon.Frozen -= FreezeHandler;
            Pokemon.Paralyzed -= ParalyzedHandler;
            Pokemon.Poisoned -= PoisonedHandler;
            Pokemon.BadlyPoisoned -= BadlyPoisonedHandler;
            Pokemon.FellAsleep -= FellAsleepHandler;
            Pokemon.StatusCleared -= StatusClearedHandler;
            Pokemon.Fainted -= FaintedHandler;
            Pokemon.LeveledUp -= LeveledUpHandler;
            Pokemon.GainedExp -= GainedExpHandler;
            Pokemon.GainedHP -= GainedHPHandler;
        }
        private void BurnedHandler(object sender, PokemonEventArgs e)
        { Burned?.Invoke(this, EventArgs); }

        private void FreezeHandler(object sender, PokemonEventArgs e)
        { Frozen?.Invoke(this, EventArgs); }

        private void ParalyzedHandler(object sender, PokemonEventArgs e)
        { Paralyzed?.Invoke(this, EventArgs); }

        private void PoisonedHandler(object sender, PokemonEventArgs e)
        { Poisoned?.Invoke(this, EventArgs); }

        private void BadlyPoisonedHandler(object sender, PokemonEventArgs e)
        { BadlyPoisoned?.Invoke(this, EventArgs); }

        private void FellAsleepHandler(object sender, PokemonEventArgs e)
        { FellAsleep?.Invoke(this, EventArgs); }

        private void StatusClearedHandler(object sender, PokemonEventArgs e)
        { StatusCleared?.Invoke(this, EventArgs); }

        private void FaintedHandler(object sender, PokemonEventArgs e)
        { Fainted?.Invoke(this, EventArgs); }

        private void GainedExpHandler(object sender, PokemonData.GainedExpEventArgs e)
        {
            GainedExp?.Invoke(this, new GainedExpEventArgs()
            {
                pokemon = Pokemon,
                battlePokemon = this,
                gainedExp = e.exp
            });
        }

        private void LeveledUpHandler(object sender, PokemonEventArgs e)
        { LeveledUp?.Invoke(this, EventArgs);
        }

        private void GainedHPHandler(object sender, PokemonData.GainedHPEventArgs e)
        {
            GainedHP?.Invoke(this, new GainedHPEventArgs()
            {
                pokemon = Pokemon,
                battlePokemon = this,
                gainedHP = e.gainedHP
            });
        }






        public bool IsTwoTurnMoveActive()
        {
            return TwoTurnMove != null;
        }
        public void ActivateTwoTurnMove(Move move)
        {
            TwoTurnMove = move;
        }
        public void DeactivateTwoTurnMove()
        {
            TwoTurnMove = null;
        }
        public Move GetTwoTurnMove()
        {
            return TwoTurnMove;
        }






        public bool IsSemiInvulnerable() { return SemiInvulnerable; }
        public void ActivateSemiInvulnerable() { SemiInvulnerable = true; }
        public void DeactivateSemiInvulnerable() { SemiInvulnerable = false; }
        







        public bool IsBurned => Pokemon.Status == Status.Burn;
        public bool IsFrozen => Pokemon.Status == Status.Freeze;
        public bool IsParalyzed => Pokemon.Status == Status.Paralysis;
        public bool IsPoisoned => Pokemon.Status == Status.Poison;
        public bool IsBadlyPoisoned => Pokemon.Status == Status.BadlyPoisoned;
        public bool IsSleeping => Pokemon.Status == Status.Sleep;
        public bool IsFainted => Pokemon.Status == Status.Fainted;
        public bool IsStatusClear => Pokemon.Status == Status.Null;

        public bool IsLeechSeedActive => Seeded;

        //exclusively used to activate a transform
        public float PokemonsAttackStat => Pokemon.Attack;
        public float PokemonsDefenseStat => Pokemon.Defense;
        public float PokemonsSpecialStat => Pokemon.Special;
        public float PokemonsSpeedStat => Pokemon.Speed;


        //exclusively used when crit hit on transformed pokemon
        public float PokemonsDefenseStatWithModifiers =>
            (float)Math.Floor(
                Pokemon.Defense *
                StatStageData.Multiplier[StatStageModifiers.Defense]);

        public float PokemonsSpecialStatWithModifiers => 
            (float)Math.Floor(
                Pokemon.Special *
                StatStageData.Multiplier[StatStageModifiers.Special]);




        public void ModifyStatStageAsPrimaryEffect(StatType statType, int delta)
        {
            ModifyStats(statType, delta);
        }

        public void ModifyStatStageAsSecondaryEffect(StatType statType, int delta)
        {
            if (!Substitute.IsActive && !MistActive)
                ModifyStats(statType, delta);
        }

        private void ModifyStats(StatType statType, int delta)
        {
            OnStatStageChanged(statType, delta);
            StatStageModifiers.Modify(statType, delta);
        }

        public bool CanStatGoHigher(StatType type) =>
            StatStageModifiers.CanGoHigher(type);
        

        public bool CanStatGoLower(StatType type) =>
            StatStageModifiers.CanGoLower(type);
        
        public void ResetStatStageModifiers()
        {
            StatStageModifiers.Reset();
        }




        public float Attack
        {
            get
            {
                float attack = Transform.Active ? Transform.Attack : Pokemon.Attack;
                attack *= StatStageData.Multiplier[StatStageModifiers.Attack];
                if (BurnDecreasingAttack) attack *= 0.5f;
                return (float)Math.Floor(attack);
            }
        }


        public float Defense
        {
            get
            {
                float defense = Transform.Active ? Transform.Defense : Pokemon.Defense;
                defense *= StatStageData.Multiplier[StatStageModifiers.Defense];
                return (float)Math.Floor(defense);
            }
        }

        public float Special
        {
            get
            {
                float special = Transform.Active ? Transform.Special : Pokemon.Special;
                special *= StatStageData.Multiplier[StatStageModifiers.Special];
                return (float)Math.Floor(special);
            }
        }
        
        public float Speed
        {
            get
            {
                float speed = Transform.Active ? Transform.Speed : Pokemon.Speed;
                speed *= StatStageData.Multiplier[StatStageModifiers.Speed];
                if (ParalysisDecreasingSpeed) speed *= 0.25f;
                return (float)Math.Floor(speed);
            }
        }
        


        public float HP => Pokemon.CurrentHP;
        public float MaxHP => Pokemon.HP;



        public float AccuracyMultiplier =>
            StatStageData.Multiplier[StatStageModifiers.Accuracy];

        public float EvasionMultiplier =>
            StatStageData.Multiplier[-StatStageModifiers.Evasion];



        public float BaseSpeed => Pokemon.BaseSpeed;
        public float Level => Pokemon.Level;



        public bool IsFocusEnergyActive => FocusEnergyActive;
        public void ActivateFocusEnergy()
        {
            FocusEnergyActive = true;
        }
        public bool IsDireHitActive() { return DireHitActive; }
        public bool IsTransformActive() { return Transform.Active; }


        public bool IsSubstituteActive => Substitute.IsActive;
        public bool DidSubstituteBreakThisTurn() { return Substitute.BrokeThisTurn; }


        public void DeactivateFocusEnergy()
        {
            FocusEnergyActive = false;
        }



        public void DeactivateParalysisDecreasingSpeed()
        {
            ParalysisDecreasingSpeed = false;
        }
		public void ParalyzeAsPrimaryEffect()
        {
            ParalysisDecreasingSpeed = true;
            Pokemon.Paralyze();
        }
        public void ParalyzeAsSecondaryEffect()
        {
            if (!Substitute.IsActive)
            {
                ParalysisDecreasingSpeed = true;
                Pokemon.Paralyze();
            }
        }
        public void DeactivateBurnDecreasingAttack()
        {
            BurnDecreasingAttack = false;
        }
		public void BurnAsPrimaryEffect()
        {
            BurnDecreasingAttack = true;
            Pokemon.Burn();
        }
        public void BurnAsSecondaryEffect()
        {
            if (!Substitute.IsActive)
            {
                BurnDecreasingAttack = true;
                Pokemon.Burn();
            }
        }
		public void FreezeAsPrimaryEffect()
        {
            Pokemon.Freeze();
        }
        public void FreezeAsSecondaryEffect()
        {
            if (!Substitute.IsActive)
            {
                Pokemon.Freeze();
            }
        }
		public void PoisonAsPrimaryEffect()
        {
            Pokemon.Poison();
        }
        public void PoisonAsSecondaryEffect()
        {
            if (!Substitute.IsActive)
            {
                Pokemon.Poison();
            }
        }
		public void BadlyPoisonAsPrimaryEffect()
        {
            Pokemon.BadlyPoison();
            N = 1f;
        }
        public void BadlyPoisonAsSecondaryEffect()
        {
            if (!Substitute.IsActive)
            {
                Pokemon.BadlyPoison();
                N = 1f;
            }
        }
        public void Sleep()
        {
            Pokemon.Sleep();
            SleepTurnsLeft = new Random().Next(1, 8);
        }
        public void SleepFor(int numberOfTurns)
        {
            Pokemon.Sleep();
            SleepTurnsLeft = numberOfTurns;
        }
		public void ClearStatus()
        {
            Pokemon.ClearStatus();
            N = 1f;
        }










        public void Damage(float amount, Type damageType)
        {
            //1) account for substitute
            if (Substitute.IsActive) Substitute.Damage(amount);
            else Pokemon.Damage(amount);

            //2) account for Bide
            if (Bide.Active) Bide.Damage(amount);

            //3) account for Counter
            if (damageType == Type.Normal || damageType == Type.Fighting)
                DamageForCounter = amount;

            //4) account for thawing
            if (Pokemon.Status == Status.Freeze && damageType == Type.Fire)
                Pokemon.ClearStatus();

            CheckForRageAndUpdateAttackStatStageIfNecessary();
        }
        //this should be referenced exclusively by OneTurnMultiHitAttackMove
        public void DamageWithoutBideOrCounterSideEffects(float amount)
        {
            if (Substitute.IsActive) Substitute.Damage(amount);
            else Pokemon.Damage(amount);
        }
        //this should only be referenced by the move Counter.
        public void DamageMethodForCounterOnly(float amount)
        {
            DamageForCounter = 0f;
            if (Substitute.IsActive) Substitute.Damage(amount);
            else Pokemon.Damage(amount);

            if (Bide.Active) Bide.Damage(amount);
        }
        public void DamagePokemonOnlyNoEffects(float amount)
        {
            Pokemon.Damage(amount);
        }
        public void RecoilDamage(float amount)
        {
            Pokemon.Damage(amount);
            DamageForCounter = amount;
        }
        public void CheckForRageAndUpdateAttackStatStageIfNecessary()
        {
            if (MultiTurnMove != null &&
                MultiTurnMove.Index == 99 &&
                StatStageModifiers.CanGoHigher(StatType.Attack))
            {
                ModifyStatStageAsPrimaryEffect(StatType.Attack, 1);
            }
        }
        private void DamageFromConfusion()
        {
            float damage = AttackMove.DamageFormula(
                Pokemon.Level,
                Pokemon.Attack,
                Pokemon.Defense,
                40f,
                1f,
                1f);
            Pokemon.Damage(damage);
        }










        public void RestoreHP(float amount)
        {
            Pokemon.RestoreHP(amount);
        }
        public void ActivateBide()
        {
            Bide.Activate();
        }
        public void DeactivateBide()
        {
            Bide.Deactivate();
        }
        public void TickBide()
        {
            Bide.Tick();
        }
        public float GetBideDamage()
        {
            return Bide.DamageAccrued;
        }
        public bool IsBideActive()
        {
            return Bide.Active;
        }
        public int TurnsLeftOfBide()
        {
            return Bide.TurnsLeft;
        }





        public void ActivateMultiTurnMove(Move move)
        {
            MultiTurnMove = move;
        }
        public void DeactivateMultiTurnMove()
        {
            MultiTurnMove = null;
        }
        public bool IsMultiTurnMoveActive()
        {
            return MultiTurnMove != null;
        }
        public Move GetMultiTurnMove()
        {
            return MultiTurnMove;
        }








        public void ActivateLeechSeed()
        {
            Seeded = true;
            OnLeechSeedActivated();
        }
        public void DeactivateLeechSeed()
        {
            Seeded = false;
        }
        public void ActivateConversion(BattlePokemon pokemonToConvertInto)
        {
            Conversion.Activate(pokemonToConvertInto);
            OnConversionActivated();
        }
        public void ActivateSubstitute(float hp)
        {
            Substitute.Activate(hp);
            OnSubstituteActivated();
        }
        public void ActivateTransform(BattlePokemon pokemonToTransformInto)
        {
            Transform.Activate(pokemonToTransformInto);

            Move1 = Transform.Move1;
            Move2 = Transform.Move2;
            Move3 = Transform.Move3;
            Move4 = Transform.Move4;

            StatStageModifiers = new StatStageModifiers(
                pokemonToTransformInto.StatStageModifiers.Attack,
                pokemonToTransformInto.StatStageModifiers.Defense,
                pokemonToTransformInto.StatStageModifiers.Special,
                pokemonToTransformInto.StatStageModifiers.Speed,
                pokemonToTransformInto.StatStageModifiers.Accuracy,
                pokemonToTransformInto.StatStageModifiers.Evasion);

            OnTransformActivated(pokemonToTransformInto);
        }


    }
}
