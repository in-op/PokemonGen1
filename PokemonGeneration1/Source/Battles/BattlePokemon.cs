using System;
using PokemonGeneration1.Source.PokemonData;
using PokemonGeneration1.Source.Moves;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Battles
{
    /// <summary>
    /// Wrapper class for Pokemon objects including all
    /// satellite data for battling.
    /// </summary>
    public class BattlePokemon
    {
        private BattlePokemonEventArgs EventArgs;

        private Pokemon Pokemon;
        private StatStageModifiers StatStageModifiers;

        private Move move1;
        private Move move2;
        private Move move3;
        private Move move4;

        private Move LastMoveUsed;
        private Move TwoTurnMove;
        private Move MultiTurnMove;
        private Move MirrorMove;

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
        private bool PartiallyTrapped;
        private bool PartiallyTrappedEndingThisTurn;
        private bool Flinching;
        private bool ParalysisDecreasingSpeed;
        private bool BurnDecreasingAttack;
        private bool MistActive;
        private bool LightScreen;
        private bool Reflect;


        public Status Status { get => Pokemon.Status; }



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
        public event EventHandler<Battles.MoveEventArgs> MoveUsed;
        public event EventHandler<Battles.MoveEventArgs> MoveFailed;
        public event EventHandler<Battles.MoveEventArgs> MoveMissed;
        public event EventHandler<Battles.MoveEventArgs> MoveHadNoEffect;
        public event EventHandler<Battles.MoveEventArgs> MoveSuperEffective;
        public event EventHandler<Battles.MoveEventArgs> MoveNotVeryEffective;
        public event EventHandler<Battles.MoveEventArgs> MoveCriticalHit;
        public event EventHandler<Battles.MoveEventArgs> MoveOneHitKO;
        public event EventHandler<Battles.MoveEventArgs> PayDayTriggered;
        public event EventHandler<Battles.MoveEventArgs> SolarBeamFirstTurn;
        public event EventHandler<Battles.MoveEventArgs> RazorWindFirstTurn;
        public event EventHandler<Battles.MoveEventArgs> BidingTime;
        public event EventHandler<Battles.MoveEventArgs> BideUnleased;
        public event EventHandler<Battles.MoveEventArgs> FlyFirstTurn;
        public event EventHandler<Battles.MoveEventArgs> AttackContinues;
        public event EventHandler<Battles.MoveEventArgs> CrashDamage;
        public event EventHandler<Battles.MoveEventArgs> HurtByRecoilDamage;
        public event EventHandler<Battles.MoveEventArgs> ThrashingAbout;
        public event EventHandler<Battles.MoveEventArgs> HyperBeamRecharging;
        public event EventHandler<Battles.MoveEventArgs> SuckedHealth;
        public event EventHandler<Battles.MoveEventArgs> DugAHole;
        public event EventHandler<Battles.MoveEventArgs> SkullBashFirstTurn;
        public event EventHandler<Battles.MoveEventArgs> SkyAttackFirstTurn;
        public event EventHandler<Battles.MoveEventArgs> RegainedHealth;


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
            SwitchedOut?.Invoke(
                this,
                new SwitchedOutEventArgs()
                {
                    switchIn = switchIn,
                    battlePokemon = this,
                    pokemon = Pokemon
                });
        }
        protected virtual void OnStatStageChanged(StatsEnum stat, int amount)
        {
            Battles.StatStageChangedEventArgs args = new StatStageChangedEventArgs();
            args.pokemon = Pokemon;
            args.battlePokemon = this;
            args.statChanged = stat;
            args.change = amount;
            StatStageChanged?.Invoke(this, args);
        }
        protected virtual void OnSubstituteActivated()
        {
            BattlePokemonEventArgs args = new BattlePokemonEventArgs();
            args.pokemon = Pokemon;
            args.battlePokemon = this;
            SubstituteActivated?.Invoke(this, args);
        }
        protected virtual void OnConversionActivated()
        {
            BattlePokemonEventArgs args = new BattlePokemonEventArgs();
            args.pokemon = Pokemon;
            args.battlePokemon = this;
            ConversionActivated?.Invoke(this, args);
        }
        protected virtual void OnTransformActivated(BattlePokemon transformInto)
        {
            TransformedEventArgs args = new TransformedEventArgs();
            args.pokemon = Pokemon;
            args.battlePokemon = this;
            args.transformInto = transformInto;
            TransformActivated?.Invoke(this, args);
        }
        protected virtual void OnLeechSeedActivated()
        {
            LeechSeedActivated?.Invoke(this, EventArgs);
        }
        protected virtual void OnLeechSeedSaps()
        {
            BattlePokemonEventArgs args = new BattlePokemonEventArgs();
            args.pokemon = Pokemon;
            args.battlePokemon = this;
            LeechSeedSaps?.Invoke(this, args);
        }
        protected virtual void OnConfused()
        {
            Confused?.Invoke(this, EventArgs);
        }
        protected virtual void OnHurtFromConfusion()
        {
            HurtFromConfusion?.Invoke(this, EventArgs);
        }
        protected virtual void OnFlinched()
        {
            Flinched?.Invoke(this, EventArgs);
        }
        protected virtual void OnFullyParalyzed()
        {
            FullyParalyzed?.Invoke(this, EventArgs);
        }
        protected virtual void OnFrozenSolid()
        {
            FrozenSolid?.Invoke(this, EventArgs);
        }
        protected virtual void OnFastAsleep()
        {
            FastAsleep?.Invoke(this, EventArgs);
        }
        protected virtual void OnWokeUp()
        {
            WokeUp?.Invoke(this, EventArgs);
        }
        protected virtual void OnDisabled(Move move)
        {
            var args = new Battles.MoveEventArgs();
            args.battlePokemon = this;
            args.pokemon = Pokemon;
            args.move = move;
            Disabled?.Invoke(this, args);
        }
        protected virtual void OnMoveAttemptedButIsDisabled()
        {
            MoveAttemptedButIsDisabled?.Invoke(this, EventArgs);
        }
        protected virtual void OnMimic(Move moveToCopy, BattlePokemon opponent)
        {
            var args = new Battles.MimicMoveEventArgs();
            args.pokemon = Pokemon;
            args.battlePokemon = this;
            args.opponent = opponent;
            args.moveMimiced = moveToCopy;

            Mimic?.Invoke(this, args);
        }



        public Move GetLastMoveUsed()
        {
            return LastMoveUsed;
        }
        public void SetLastMoveUsed(Move move)
        {
            LastMoveUsed = move;
        }
        public void SetMirrorMove(Move move)
        {
            MirrorMove = move;
        }
        public Move GetMirrorMove()
        {
            return MirrorMove;
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
            if (!Substitute.IsActive())
            {
                Flinching = true;
            }
        }



        public void AttemptChangeBadlyPoisonToPoison()
        {
            if (IsBadlyPoisoned())
            {
                Pokemon.ChangeBadlyPoisonToPoison();
            }
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
            {
                moveToCopy = opponent.GetMove1();
            }

            OnMimic(moveToCopy, opponent);
            Move newMove = MoveFactory.Create(moveToCopy.Index);
            if (move1 == mimicItself)
            {
                move1 = newMove;
            }
            else if (move2 == mimicItself)
            {
                move2 = newMove;
            }
            else if (move3 == mimicItself)
            {
                move3 = newMove;
            }
            else if (move4 == mimicItself)
            {
                move4 = newMove;
            }
        }









        public void UpdateForEndOfTurn()
        {
            SwitchedPokemonThisTurn = false;
            Flinching = false;

            if (SleepTurnsLeft > 0)
            {
                --SleepTurnsLeft;
            }

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

                if (ConfusionTurnsLeft > 0)
                {
                    --ConfusionTurnsLeft;
                }

                if (IsDisabled())
                {
                    Disable.Tick();
                }
            }

            EndOfTurnEffects(opponent);
        }
        private void BeginningOfTurnEffects(ref bool canMove, Move move)
        {
            // sleep
            if (Pokemon.Status == Status.Sleep)
            {
                canMove = false;
                if (SleepTurnsLeft > 0)
                {
                    OnFastAsleep();
                }
                else
                {
                    OnWokeUp();
                    Pokemon.ClearStatus();
                }
                return;
            }
            // freeze
            if (Pokemon.Status == Status.Freeze)
            {
                canMove = false;
                OnFrozenSolid();
                return;
            }
            // paralysis:
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
            // confusion:
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
            // flinching:
            if (Flinching)
            {
                canMove = false;
                OnFlinched();
                return;
            }
            // move disabled: 
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
            //leechseed
            IfSeededThenSapHP(opponent);
            //badly poisoned
            if (Status == Status.BadlyPoisoned)
            {
                DamagePokemonOnlyNoEffects(GetStatusConditionDamage());
                N += 1f;
            }
            //poisoned
            else if (Status == Status.Poison)
            {
                DamagePokemonOnlyNoEffects(GetStatusConditionDamage());
            }
            //burned
            else if (Status == Status.Burn)
            {
                DamagePokemonOnlyNoEffects(GetStatusConditionDamage());
            }
        }
        private void IfSeededThenSapHP(BattlePokemon opponent)
        {
            if (Seeded && !opponent.IsFainted())
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
        protected virtual void MoveUsedHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            MoveUsed?.Invoke(this, args);
        }
        protected virtual void MoveFailedHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            MoveFailed?.Invoke(this, args);
        }
        protected virtual void MoveMissedHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            MoveMissed?.Invoke(this, args);
        }
        protected virtual void MoveHadNoEffectHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            MoveHadNoEffect?.Invoke(this, args);
        }
        protected virtual void MoveSuperEffectiveHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            MoveSuperEffective?.Invoke(this, args);
        }
        protected virtual void MoveNotVeryEffectiveHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            MoveNotVeryEffective?.Invoke(this, args);
        }
        protected virtual void MoveCriticalHitHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            MoveCriticalHit?.Invoke(this, args);
        }
        protected virtual void MoveOneHitKOHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            MoveOneHitKO?.Invoke(this, args);
        }
        protected virtual void PayDayTriggeredHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            PayDayTriggered?.Invoke(this, args);
        }
        protected virtual void SolarBeamFirstTurnHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            SolarBeamFirstTurn?.Invoke(this, args);
        }
        protected virtual void RazorWindFirstTurnHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            RazorWindFirstTurn?.Invoke(this, args);
        }
        protected virtual void BidingTimeHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            BidingTime?.Invoke(this, args);
        }
        protected virtual void BideUnleashedHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            BideUnleased?.Invoke(this, args);
        }
        protected virtual void FlyFirstTurnHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            FlyFirstTurn?.Invoke(this, args);
        }
        protected virtual void AttackContinuesHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            AttackContinues?.Invoke(this, args);
        }
        protected virtual void CrashDamageHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            CrashDamage?.Invoke(this, args);
        }
        protected virtual void HurtByRecoilDamageHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            HurtByRecoilDamage?.Invoke(this, args);
        }
        protected virtual void ThrashingAboutHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            ThrashingAbout?.Invoke(this, args);
        }
        protected virtual void HyperBeamRechargingHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            HyperBeamRecharging?.Invoke(this, args);
        }
        protected virtual void SuckedHealthHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            SuckedHealth?.Invoke(this, args);
        }
        protected virtual void DugAHoleHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            DugAHole?.Invoke(this, args);
        }
        protected virtual void SkullBashFirstTurnHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            SkullBashFirstTurn?.Invoke(this, args);
        }
        protected virtual void SkyAttackFirstTurnHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            SkyAttackFirstTurn?.Invoke(this, args);
        }
        protected virtual void RegainedHealthHandler(object sender, Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = GenerateMoveEventArgs(e);
            RegainedHealth?.Invoke(this, args);
        }
        private Battles.MoveEventArgs GenerateMoveEventArgs(Moves.MoveEventArgs e)
        {
            Battles.MoveEventArgs args = new MoveEventArgs();
            args.pokemon = Pokemon;
            args.battlePokemon = this;
            args.move = e.move;
            return args;
        }





        public void SwitchOut(Pokemon switchIn)
        {
            OnSwitchedOut(switchIn);

            if (IsBadlyPoisoned())
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
            move1 = Pokemon.Move1;
            move2 = Pokemon.Move2;
            move3 = Pokemon.Move3;
            move4 = Pokemon.Move4;
        }





        public BattlePokemon(Pokemon pokemon)
        {
            Pokemon = pokemon;
            AttachPokemonEventHandlers();
            SetMovesToPokemonMoves();

            StatStageModifiers = new StatStageModifiers();
            Conversion = Conversion.GenerateBlankConversion();
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
            EventArgs = new BattlePokemonEventArgs();
            EventArgs.battlePokemon = this;
            EventArgs.pokemon = Pokemon;
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
        {
            Burned?.Invoke(this, EventArgs);
        }
        private void FreezeHandler(object sender, PokemonEventArgs e)
        {
            Frozen?.Invoke(this, EventArgs);
        }
        private void ParalyzedHandler(object sender, PokemonEventArgs e)
        {
            Paralyzed?.Invoke(this, EventArgs);
        }
        private void PoisonedHandler(object sender, PokemonEventArgs e)
        {
            Poisoned?.Invoke(this, EventArgs);
        }
        private void BadlyPoisonedHandler(object sender, PokemonEventArgs e)
        {
            BadlyPoisoned?.Invoke(this, EventArgs);
        }
        private void FellAsleepHandler(object sender, PokemonEventArgs e)
        {
            FellAsleep?.Invoke(this, EventArgs);
        }
        private void StatusClearedHandler(object sender, PokemonEventArgs e)
        {
            StatusCleared?.Invoke(this, EventArgs);
        }
        private void FaintedHandler(object sender, PokemonEventArgs e)
        {
            Fainted?.Invoke(this, EventArgs);
        }
        private void GainedExpHandler(object sender, PokemonData.GainedExpEventArgs e)
        {
            Battles.GainedExpEventArgs args = new Battles.GainedExpEventArgs();
            args.pokemon = Pokemon;
            args.battlePokemon = this;
            args.gainedExp = e.exp;

            GainedExp?.Invoke(this, args);
        }
        private void LeveledUpHandler(object sender, PokemonEventArgs e)
        {
            LeveledUp?.Invoke(this, EventArgs);
        }
        private void GainedHPHandler(object sender, PokemonData.GainedHPEventArgs e)
        {
            Battles.GainedHPEventArgs args = new Battles.GainedHPEventArgs();
            args.pokemon = Pokemon;
            args.battlePokemon = this;
            args.gainedHP = e.gainedHP;
            GainedHP?.Invoke(this, args);
        }






        public bool IsPartiallyTrapped() { return PartiallyTrapped; }






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
        







        public bool IsBurned() { return Pokemon.Status == Status.Burn; }
        public bool IsFrozen() { return Pokemon.Status == Status.Freeze; }
        public bool IsParalyzed() { return Pokemon.Status == Status.Paralysis; }
        public bool IsPoisoned() { return Pokemon.Status == Status.Poison; }
        public bool IsBadlyPoisoned() { return Pokemon.Status == Status.BadlyPoisoned; }
        public bool IsSleeping() { return Pokemon.Status == Status.Sleep; }
        public bool IsFainted() { return Pokemon.Status == Status.Fainted; }
        public bool IsStatusClear() { return Pokemon.Status == Status.Null; }

        public bool IsLeechSeedActive() { return Seeded; }

        //exclusively used to activate a transform
        public float GetPokemonsAttackStat() { return Pokemon.Attack; }
        public float GetPokemonsDefenseStat() { return Pokemon.Defense; }
        public float GetPokemonsSpecialStat() { return Pokemon.Special; }
        public float GetPokemonsSpeedStat() { return Pokemon.Speed; }


        //exclusively used when crit hit on transformed pokemon
        public float GetPokemonsDefenseStatWithModifiers()
        {
            float defense = Pokemon.Defense;
            defense *= StatStageMultiplier[StatStageModifiers.GetDefense()];
            return (float)Math.Floor(defense);
        }
        public float GetPokemonsSpecialStatWithModifiers()
        {
            float special = Pokemon.Special;
            special *= StatStageMultiplier[StatStageModifiers.GetSpecial()];
            return (float)Math.Floor(special);
        }




        public void ModifyStatStageAsPrimaryEffect(StatsEnum statType, int delta)
        {
            ModifyStats(statType, delta);
        }
        public void ModifyStatStageAsSecondaryEffect(StatsEnum statType, int delta)
        {
            if (!Substitute.IsActive() &&
                !MistActive)
            {
                ModifyStats(statType, delta);
            }
        }
        private void ModifyStats(StatsEnum statType, int delta)
        {
            OnStatStageChanged(statType, delta);
            switch (statType)
            {
                case StatsEnum.ACCURACY:
                    StatStageModifiers.ModifyAccuracy(delta);
                    break;
                case StatsEnum.EVASION:
                    StatStageModifiers.ModifyEvasion(delta);
                    break;
                case StatsEnum.ATTACK:
                    BurnDecreasingAttack = false;
                    StatStageModifiers.ModifyAttack(delta);
                    break;
                case StatsEnum.DEFENSE:
                    StatStageModifiers.ModifyDefense(delta);
                    break;
                case StatsEnum.SPECIAL:
                    StatStageModifiers.ModifySpecial(delta);
                    break;
                case StatsEnum.SPEED:
                    ParalysisDecreasingSpeed = false;
                    StatStageModifiers.ModifySpecial(delta);
                    break;
            }
        }




        public StatStageModifiers GetStatStageModifers()
        {
            return StatStageModifiers;
        }
        public string GetName()
        {
            return Pokemon.Nickname;
        }
        public float GetAttack()
        {
            float attack;
            if (Transform.Active) { attack = Transform.Attack; }
            else { attack = Pokemon.Attack; }
            attack *= StatStageMultiplier[StatStageModifiers.GetAttack()];
            if (BurnDecreasingAttack)
            {
                attack *= 0.5f;
            }
            return (float)Math.Floor(attack);
        }
        public float GetDefense()
        {
            float defense;
            if (Transform.Active) { defense = Transform.Defense; }
            else { defense = Pokemon.Defense; }
            defense *= StatStageMultiplier[StatStageModifiers.GetDefense()];
            return (float)Math.Floor(defense);
        }
        public float GetSpecial()
        {
            float special;
            if (Transform.Active) { special = Transform.Special; }
            else { special = Pokemon.Special; }
            special *= StatStageMultiplier[StatStageModifiers.GetSpecial()];
            return (float)Math.Floor(special);
        }
        public float GetSpeed()
        {
            float speed;
            if (Transform.Active) { speed = Transform.Speed; }
            else { speed = Pokemon.Speed; }
            speed *= StatStageMultiplier[StatStageModifiers.GetSpeed()];
            if (ParalysisDecreasingSpeed)
            {
                speed *= 0.25f;
            }
            return (float)Math.Floor(speed);
        }
        public Type GetType1()
        {
            if (Transform.Active) { return Transform.Type1; }
            else if (Conversion.IsActive()) { return Conversion.GetType1(); }
            else return Pokemon.Type1;
        }
        public Type GetType2()
        {
            if (Transform.Active) { return Transform.Type2; }
            else if (Conversion.IsActive()) { return Conversion.GetType2(); }
            else return Pokemon.Type2;
        }
        public Move GetMove1()
        {
            if (Transform.Active) { return Transform.Move1; }
            else return move1;
        }
        public Move GetMove2()
        {
            if (Transform.Active) { return Transform.Move2; }
            else return move2;
        }
        public Move GetMove3()
        {
            if (Transform.Active) { return Transform.Move3; }
            else return move3;
        }
        public Move GetMove4()
        {
            if (Transform.Active) { return Transform.Move4; }
            else return move4;
        }
        


        public float HP
        {
            get
            {
                if (IsSubstituteActive()) return Substitute.GetCurrentHP();
                else return Pokemon.CurrentHP;
            }
        }
        public float GetMaxHP()
        {
            if (IsSubstituteActive()) { return Substitute.GetMaxHP(); }
            else return Pokemon.HP;
        }



        public float GetAccuracyMultiplier()
        {
            return AccuracyStageToMultiplier[StatStageModifiers.GetAccuracy()];
        }
        public float GetEvasionMultiplier()
        {
            return EvasionStageToMultiplier[StatStageModifiers.GetEvasion()];
        }
        private static readonly Dictionary<int, float> AccuracyStageToMultiplier = new Dictionary<int, float>()
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
        private static readonly Dictionary<int, float> EvasionStageToMultiplier = new Dictionary<int, float>
        {
            {6, (25f/100f) },
            {5, (28f/100f) },
            {4, (33f/100f) },
            {3, (40f/100f) },
            {2, (50f/100f) },
            {1, (66f/100f) },
            {0, 1f },
            {-1, 1.5f },
            {-2, 2f },
            {-3, 2.5f },
            {-4, 3f },
            {-5, 3.5f },
            {-6, 4f }
        };



        public float GetBaseSpeed() { return Pokemon.BaseSpeed; }
        public float GetLevel() { return Pokemon.Level; }



        public bool IsFocusEnergyActive() { return FocusEnergyActive; }
        public void ActivateFocusEnergy()
        {
            FocusEnergyActive = true;
        }
        public bool IsDireHitActive() { return DireHitActive; }
        public bool IsTransformActive() { return Transform.Active; }



        public bool IsSubstituteActive() { return Substitute.IsActive(); }
        public bool DidSubstituteBreakThisTurn() { return Substitute.IsBrokeThisTurn(); }


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
            if (!Substitute.IsActive())
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
            if (!Substitute.IsActive())
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
            if (!Substitute.IsActive())
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
            if (!Substitute.IsActive())
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
            if (!Substitute.IsActive())
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
            if (IsSubstituteActive())
            {
                Substitute.Damage(amount);
            }
            else
            {
                Pokemon.Damage(amount);
            }

            //2) account for Bide
            if (Bide.Active)
            {
                Bide.Damage(amount);
            }

            //3) account for Counter
            if (damageType == Type.Normal ||
                damageType == Type.Fighting)
            {
                DamageForCounter = amount;
            }

            //4) account for thawing
            if (damageType == Type.Fire &&
                Pokemon.Status == Status.Freeze)
            {
                Pokemon.ClearStatus();
            }

            CheckForRageAndUpdateAttackStatStageIfNecessary();
        }
        //this should be referenced exclusively by OneTurnMultiHitAttackMove
        public void DamageWithoutBideOrCounterSideEffects(float amount)
        {
            if (IsSubstituteActive())
            {
                Substitute.Damage(amount);
            }
            else
            {
                Pokemon.Damage(amount);
            }
        }
        //this should only be referenced by the move Counter.
        public void DamageMethodForCounterOnly(float amount)
        {
            DamageForCounter = 0f;
            if (IsSubstituteActive())
            {
                Substitute.Damage(amount);
            }
            else
            {
                Pokemon.Damage(amount);
            }

            if (Bide.Active)
            {
                Bide.Damage(amount);
            }
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
                MultiTurnMove.Index == 99)
            {
                if (StatStageModifiers.CanAttackGoHigher())
                {
                    ModifyStatStageAsPrimaryEffect(StatsEnum.ATTACK, 1);
                }
            }
        }
        private void DamageFromConfusion()
        {
            float damage = AttackMove.damageFormula(Pokemon.Level,
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
            StatStageModifiers = new StatStageModifiers(pokemonToTransformInto.GetStatStageModifiers().GetAttack(),
                                                             pokemonToTransformInto.GetStatStageModifiers().GetDefense(),
                                                             pokemonToTransformInto.GetStatStageModifiers().GetSpecial(),
                                                             pokemonToTransformInto.GetStatStageModifiers().GetSpeed(),
                                                             pokemonToTransformInto.GetStatStageModifiers().GetAccuracy(),
                                                             pokemonToTransformInto.GetStatStageModifiers().GetEvasion());

            OnTransformActivated(pokemonToTransformInto);
        }
        private StatStageModifiers GetStatStageModifiers()
        {
            return StatStageModifiers;
        }
        private static readonly Dictionary<int, float> StatStageMultiplier = new Dictionary<int, float>()
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
