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

        protected virtual void OnStatStageChanged(StatsEnum stat, int amount)
        {
            Battles.StatStageChangedEventArgs args = new StatStageChangedEventArgs();
            args.pokemon = this.Pokemon;
            args.battlePokemon = this;
            args.statChanged = stat;
            args.change = amount;
            StatStageChanged?.Invoke(this, args);
        }
        protected virtual void OnSubstituteActivated()
        {
            BattlePokemonEventArgs args = new BattlePokemonEventArgs();
            args.pokemon = this.Pokemon;
            args.battlePokemon = this;
            SubstituteActivated?.Invoke(this, args);
        }
        protected virtual void OnConversionActivated()
        {
            BattlePokemonEventArgs args = new BattlePokemonEventArgs();
            args.pokemon = this.Pokemon;
            args.battlePokemon = this;
            ConversionActivated?.Invoke(this, args);
        }
        protected virtual void OnTransformActivated(BattlePokemon transformInto)
        {
            TransformedEventArgs args = new TransformedEventArgs();
            args.pokemon = this.Pokemon;
            args.battlePokemon = this;
            args.transformInto = transformInto;
            TransformActivated?.Invoke(this, args);
        }
        protected virtual void OnLeechSeedActivated()
        {
            LeechSeedActivated?.Invoke(this, this.EventArgs);
        }
        protected virtual void OnLeechSeedSaps()
        {
            BattlePokemonEventArgs args = new BattlePokemonEventArgs();
            args.pokemon = this.Pokemon;
            args.battlePokemon = this;
            LeechSeedSaps?.Invoke(this, args);
        }
        protected virtual void OnConfused()
        {
            Confused?.Invoke(this, this.EventArgs);
        }
        protected virtual void OnHurtFromConfusion()
        {
            HurtFromConfusion?.Invoke(this, this.EventArgs);
        }
        protected virtual void OnFlinched()
        {
            Flinched?.Invoke(this, this.EventArgs);
        }
        protected virtual void OnFullyParalyzed()
        {
            FullyParalyzed?.Invoke(this, this.EventArgs);
        }
        protected virtual void OnFrozenSolid()
        {
            FrozenSolid?.Invoke(this, this.EventArgs);
        }
        protected virtual void OnFastAsleep()
        {
            FastAsleep?.Invoke(this, this.EventArgs);
        }
        protected virtual void OnWokeUp()
        {
            WokeUp?.Invoke(this, this.EventArgs);
        }
        protected virtual void OnDisabled(Move move)
        {
            var args = new Battles.MoveEventArgs();
            args.battlePokemon = this;
            args.pokemon = this.Pokemon;
            args.move = move;
            Disabled?.Invoke(this, args);
        }
        protected virtual void OnMoveAttemptedButIsDisabled()
        {
            MoveAttemptedButIsDisabled?.Invoke(this, this.EventArgs);
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
            this.LastMoveUsed = move;
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
            return this.SwitchedPokemonThisTurn;
        }



        public void ActivatePartialTrapping()
        {
            this.PartiallyTrapped = true;
        }
        public void DeactivatePartialTrappingAtEndOfTurn()
        {
            this.PartiallyTrappedEndingThisTurn = true;
        }



        public void Confuse()
        {
            this.ConfusionTurnsLeft = new Random().Next(1, 5);
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
            if (!this.Substitute.IsActive())
            {
                this.Flinching = true;
            }
        }



        public void AttemptChangeBadlyPoisonToPoison()
        {
            if (this.IsBadlyPoisoned())
            {
                this.Pokemon.ChangeBadlyPoisonToPoison();
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
            this.MistActive = true;
        }
        public void DeactivateMist()
        {
            this.MistActive = false;
        }
        public bool IsMistActive() { return this.MistActive; }


        public bool IsLightScreenActive() { return LightScreen; }
        public void ActivateLightScreen() { LightScreen = true; }
        public void DeactivateLightScreen() { LightScreen = false; }

        public bool IsReflectActive() { return Reflect; }
        public void ActivateReflect() { Reflect = true; }
        public void DeactivateReflect() { Reflect = false; }


        public float GetDamageForCounter()
        {
            return this.DamageForCounter;
        }
        


        public void MimicMove(Move mimicItself, BattlePokemon opponent)
        {
            Move moveToCopy = opponent.LastMoveUsed;

            if (moveToCopy == null) //failsafe for using mimic on first turn before a last move used is even initialized
            {
                moveToCopy = opponent.GetMove1();
            }

            OnMimic(moveToCopy, opponent);
            Move newMove = MoveFactory.CreateMove(moveToCopy.Index);
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
            this.SwitchedPokemonThisTurn = false;
            this.Flinching = false;

            if (SleepTurnsLeft > 0)
            {
                --SleepTurnsLeft;
            }

            if (this.PartiallyTrappedEndingThisTurn)
            {
                this.PartiallyTrapped = false;
                this.PartiallyTrappedEndingThisTurn = false;
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
                this.DamagePokemonOnlyNoEffects(GetStatusConditionDamage());
                N += 1f;
            }
            //poisoned
            else if (Status == Status.Poison)
            {
                this.DamagePokemonOnlyNoEffects(GetStatusConditionDamage());
            }
            //burned
            else if (Status == Status.Burn)
            {
                this.DamagePokemonOnlyNoEffects(GetStatusConditionDamage());
            }
        }
        private void IfSeededThenSapHP(BattlePokemon opponent)
        {
            if (this.Seeded && !opponent.IsFainted())
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
                this.DamagePokemonOnlyNoEffects(sap);
                opponent.RestoreHP(restore);
            }
        }
        private float GetStatusConditionDamage()
        {
            return (float)Math.Floor(HP / 16f) * N;
        }
        public void AttachMoveEventHandlers(Move move)
        {
            move.Used += this.MoveUsedHandler;
            move.Failed += this.MoveFailedHandler;
            move.Missed += this.MoveMissedHandler;
            move.NoEffect += this.MoveHadNoEffectHandler;
            move.SuperEffective += this.MoveSuperEffectiveHandler;
            move.NotVeryEffective += this.MoveNotVeryEffectiveHandler;
            move.CriticalHit += this.MoveCriticalHitHandler;
            move.OneHitKO += this.MoveOneHitKOHandler;
            move.PayDayTriggered += this.PayDayTriggeredHandler;
            move.SolarBeamFirstTurn += this.SolarBeamFirstTurnHandler;
            move.RazorWindFirstTurn += this.RazorWindFirstTurnHandler;
            move.BidingTime += this.BidingTimeHandler;
            move.BideUnleased += this.BideUnleashedHandler;
            move.FlyFirstTurn += this.FlyFirstTurnHandler;
            move.AttackContinues += this.AttackContinuesHandler;
            move.CrashDamage += this.CrashDamageHandler;
            move.HurtByRecoilDamage += this.HurtByRecoilDamageHandler;
            move.ThrashingAbout += this.ThrashingAboutHandler;
            move.HyperBeamRecharging += this.HyperBeamRechargingHandler;
            move.SuckedHealth += this.SuckedHealthHandler;
            move.DugAHole += this.DugAHoleHandler;
            move.SkullBashFirstTurn += this.SkullBashFirstTurnHandler;
            move.SkyAttackFirstTurn += this.SkyAttackFirstTurnHandler;
            move.RegainedHealth += this.RegainedHealthHandler;
        }
        public void DetachMoveEventHandlers(Move move)
        {
            move.Used -= this.MoveUsedHandler;
            move.Failed -= this.MoveFailedHandler;
            move.Missed -= this.MoveMissedHandler;
            move.NoEffect -= this.MoveHadNoEffectHandler;
            move.SuperEffective -= this.MoveSuperEffectiveHandler;
            move.NotVeryEffective -= this.MoveNotVeryEffectiveHandler;
            move.CriticalHit -= this.MoveCriticalHitHandler;
            move.OneHitKO -= this.MoveOneHitKOHandler;
            move.PayDayTriggered -= this.PayDayTriggeredHandler;
            move.SolarBeamFirstTurn -= this.SolarBeamFirstTurnHandler;
            move.RazorWindFirstTurn -= this.RazorWindFirstTurnHandler;
            move.BidingTime -= this.BidingTimeHandler;
            move.BideUnleased -= this.BideUnleashedHandler;
            move.FlyFirstTurn -= this.FlyFirstTurnHandler;
            move.AttackContinues -= this.AttackContinuesHandler;
            move.CrashDamage -= this.CrashDamageHandler;
            move.HurtByRecoilDamage -= this.HurtByRecoilDamageHandler;
            move.ThrashingAbout -= this.ThrashingAboutHandler;
            move.HyperBeamRecharging -= this.HyperBeamRechargingHandler;
            move.SuckedHealth -= this.SuckedHealthHandler;
            move.DugAHole -= this.DugAHoleHandler;
            move.SkullBashFirstTurn -= this.SkullBashFirstTurnHandler;
            move.SkyAttackFirstTurn -= this.SkyAttackFirstTurnHandler;
            move.RegainedHealth -= this.RegainedHealthHandler;
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
            args.pokemon = this.Pokemon;
            args.battlePokemon = this;
            args.move = e.move;
            return args;
        }





        public void SwitchOut(Pokemon switchIn)
        {
            if (IsBadlyPoisoned())
            {
                Pokemon.ChangeBadlyPoisonToPoison();
            }
            
            DetachPokemonEventHandlers();
            this.Pokemon = switchIn;
            AttachPokemonEventHandlers();
            SetMovesToPokemonMoves();
            
            this.TwoTurnMove.Abort();
            this.TwoTurnMove = null;
            this.MultiTurnMove.Abort();
            this.MultiTurnMove = null;

            this.SwitchedPokemonThisTurn = true;
            this.Seeded = false;
            this.Conversion.Deactivate();
            this.Substitute.Deactivate();
            this.Transform.Deactivate();
            this.Bide.Deactivate();
            this.SemiInvulnerable = false;
            this.Flinching = false;
            this.ConfusionTurnsLeft = 0;
            this.Disable.Deactivate();
            this.MistActive = false;
            this.N = 1f;

            if (Pokemon.Status == Status.Paralysis)
            {
                ParalysisDecreasingSpeed = true;
            }
            else
            {
                ParalysisDecreasingSpeed = false;
            }
            if (Pokemon.Status == Status.Burn)
            {
                BurnDecreasingAttack = true;
            }
            else
            {
                BurnDecreasingAttack = false;
            }
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
            this.Pokemon = pokemon;
            AttachPokemonEventHandlers();
            SetMovesToPokemonMoves();
            
            this.StatStageModifiers = new StatStageModifiers();
            this.Conversion = Conversion.GenerateBlankConversion();
            this.Substitute = new Substitute();
            this.Transform = new Transform();
            this.Bide = new Bide();
            this.MultiTurnMove = null;
            this.TwoTurnMove = null;
            this.Disable = new Disable();
            this.MistActive = false;
            this.LightScreen = false;
            this.N = 1f;
            InitializeEventArgs();
        }
        private void InitializeEventArgs()
        {
            this.EventArgs = new BattlePokemonEventArgs();
            this.EventArgs.battlePokemon = this;
            this.EventArgs.pokemon = this.Pokemon;
        }
        private void AttachPokemonEventHandlers()
        {
            this.Pokemon.Burned += this.BurnedHandler;
            this.Pokemon.Frozen += this.FreezeHandler;
            this.Pokemon.Paralyzed += this.ParalyzedHandler;
            this.Pokemon.Poisoned += this.PoisonedHandler;
            this.Pokemon.BadlyPoisoned += this.BadlyPoisonedHandler;
            this.Pokemon.FellAsleep += this.FellAsleepHandler;
            this.Pokemon.StatusCleared += this.StatusClearedHandler;
            this.Pokemon.Fainted += this.FaintedHandler;
            this.Pokemon.LeveledUp += this.LeveledUpHandler;
            this.Pokemon.GainedExp += this.GainedExpHandler;
            this.Pokemon.GainedHP += this.GainedHPHandler;
        }
        private void DetachPokemonEventHandlers()
        {
            this.Pokemon.Burned -= this.BurnedHandler;
            this.Pokemon.Frozen -= this.FreezeHandler;
            this.Pokemon.Paralyzed -= this.ParalyzedHandler;
            this.Pokemon.Poisoned -= this.PoisonedHandler;
            this.Pokemon.BadlyPoisoned -= this.BadlyPoisonedHandler;
            this.Pokemon.FellAsleep -= this.FellAsleepHandler;
            this.Pokemon.StatusCleared -= this.StatusClearedHandler;
            this.Pokemon.Fainted -= this.FaintedHandler;
            this.Pokemon.LeveledUp -= this.LeveledUpHandler;
            this.Pokemon.GainedExp -= this.GainedExpHandler;
            this.Pokemon.GainedHP -= this.GainedHPHandler;
        }
        private void BurnedHandler(object sender, PokemonEventArgs e)
        {
            Burned?.Invoke(this, this.EventArgs);
        }
        private void FreezeHandler(object sender, PokemonEventArgs e)
        {
            Frozen?.Invoke(this, this.EventArgs);
        }
        private void ParalyzedHandler(object sender, PokemonEventArgs e)
        {
            Paralyzed?.Invoke(this, this.EventArgs);
        }
        private void PoisonedHandler(object sender, PokemonEventArgs e)
        {
            Poisoned?.Invoke(this, this.EventArgs);
        }
        private void BadlyPoisonedHandler(object sender, PokemonEventArgs e)
        {
            BadlyPoisoned?.Invoke(this, this.EventArgs);
        }
        private void FellAsleepHandler(object sender, PokemonEventArgs e)
        {
            FellAsleep?.Invoke(this, this.EventArgs);
        }
        private void StatusClearedHandler(object sender, PokemonEventArgs e)
        {
            StatusCleared?.Invoke(this, this.EventArgs);
        }
        private void FaintedHandler(object sender, PokemonEventArgs e)
        {
            Fainted?.Invoke(this, this.EventArgs);
        }
        private void GainedExpHandler(object sender, PokemonData.GainedExpEventArgs e)
        {
            Battles.GainedExpEventArgs args = new Battles.GainedExpEventArgs();
            args.pokemon = this.Pokemon;
            args.battlePokemon = this;
            args.gainedExp = e.exp;

            GainedExp?.Invoke(this, args);
        }
        private void LeveledUpHandler(object sender, PokemonEventArgs e)
        {
            LeveledUp?.Invoke(this, this.EventArgs);
        }
        private void GainedHPHandler(object sender, PokemonData.GainedHPEventArgs e)
        {
            Battles.GainedHPEventArgs args = new Battles.GainedHPEventArgs();
            args.pokemon = this.Pokemon;
            args.battlePokemon = this;
            args.gainedHP = e.gainedHP;
            GainedHP?.Invoke(this, args);
        }






        public bool IsPartiallyTrapped() { return this.PartiallyTrapped; }






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






        public bool IsSemiInvulnerable() { return this.SemiInvulnerable; }
        public void ActivateSemiInvulnerable() { this.SemiInvulnerable = true; }
        public void DeactivateSemiInvulnerable() { this.SemiInvulnerable = false; }
        







        public bool IsBurned() { return this.Pokemon.Status == Status.Burn; }
        public bool IsFrozen() { return this.Pokemon.Status == Status.Freeze; }
        public bool IsParalyzed() { return this.Pokemon.Status == Status.Paralysis; }
        public bool IsPoisoned() { return this.Pokemon.Status == Status.Poison; }
        public bool IsBadlyPoisoned() { return this.Pokemon.Status == Status.BadlyPoisoned; }
        public bool IsSleeping() { return this.Pokemon.Status == Status.Sleep; }
        public bool IsFainted() { return this.Pokemon.Status == Status.Fainted; }
        public bool IsStatusClear() { return this.Pokemon.Status == Status.Null; }

        public bool IsLeechSeedActive() { return this.Seeded; }

        //exclusively used to activate a transform
        public float GetPokemonsAttackStat() { return this.Pokemon.Attack; }
        public float GetPokemonsDefenseStat() { return this.Pokemon.Defense; }
        public float GetPokemonsSpecialStat() { return this.Pokemon.Special; }
        public float GetPokemonsSpeedStat() { return this.Pokemon.Speed; }


        //exclusively used when crit hit on transformed pokemon
        public float GetPokemonsDefenseStatWithModifiers()
        {
            float defense = this.Pokemon.Defense;
            defense *= StatStageMultiplier[this.StatStageModifiers.GetDefense()];
            return (float)Math.Floor(defense);
        }
        public float GetPokemonsSpecialStatWithModifiers()
        {
            float special = this.Pokemon.Special;
            special *= StatStageMultiplier[this.StatStageModifiers.GetSpecial()];
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
                    this.StatStageModifiers.ModifyAccuracy(delta);
                    break;
                case StatsEnum.EVASION:
                    this.StatStageModifiers.ModifyEvasion(delta);
                    break;
                case StatsEnum.ATTACK:
                    this.BurnDecreasingAttack = false;
                    this.StatStageModifiers.ModifyAttack(delta);
                    break;
                case StatsEnum.DEFENSE:
                    this.StatStageModifiers.ModifyDefense(delta);
                    break;
                case StatsEnum.SPECIAL:
                    this.StatStageModifiers.ModifySpecial(delta);
                    break;
                case StatsEnum.SPEED:
                    this.ParalysisDecreasingSpeed = false;
                    this.StatStageModifiers.ModifySpecial(delta);
                    break;
            }
        }




        public StatStageModifiers GetStatStageModifers()
        {
            return this.StatStageModifiers;
        }
        public string GetName()
        {
            return this.Pokemon.Nickname;
        }
        public float GetAttack()
        {
            float attack;
            if (this.Transform.IsActive()) { attack = this.Transform.GetAttack(); }
            else { attack = this.Pokemon.Attack; }
            attack *= StatStageMultiplier[this.StatStageModifiers.GetAttack()];
            if (BurnDecreasingAttack)
            {
                attack *= 0.5f;
            }
            return (float)Math.Floor(attack);
        }
        public float GetDefense()
        {
            float defense;
            if (this.Transform.IsActive()) { defense = this.Transform.GetDefense(); }
            else { defense = this.Pokemon.Defense; }
            defense *= StatStageMultiplier[this.StatStageModifiers.GetDefense()];
            return (float)Math.Floor(defense);
        }
        public float GetSpecial()
        {
            float special;
            if (this.Transform.IsActive()) { special = this.Transform.GetSpecial(); }
            else { special = this.Pokemon.Special; }
            special *= StatStageMultiplier[this.StatStageModifiers.GetSpecial()];
            return (float)Math.Floor(special);
        }
        public float GetSpeed()
        {
            float speed;
            if (this.Transform.IsActive()) { speed = this.Transform.GetSpeed(); }
            else { speed = this.Pokemon.Speed; }
            speed *= StatStageMultiplier[this.StatStageModifiers.GetSpeed()];
            if (ParalysisDecreasingSpeed)
            {
                speed *= 0.25f;
            }
            return (float)Math.Floor(speed);
        }
        public Type GetType1()
        {
            if (this.Transform.IsActive()) { return this.Transform.GetType1(); }
            else if (this.Conversion.IsActive()) { return this.Conversion.GetType1(); }
            else return this.Pokemon.Type1;
        }
        public Type GetType2()
        {
            if (this.Transform.IsActive()) { return this.Transform.GetType2(); }
            else if (this.Conversion.IsActive()) { return this.Conversion.GetType2(); }
            else return this.Pokemon.Type2;
        }
        public Move GetMove1()
        {
            if (this.Transform.IsActive()) { return this.Transform.GetMove1(); }
            else return move1;
        }
        public Move GetMove2()
        {
            if (this.Transform.IsActive()) { return this.Transform.GetMove2(); }
            else return move2;
        }
        public Move GetMove3()
        {
            if (this.Transform.IsActive()) { return this.Transform.GetMove3(); }
            else return move3;
        }
        public Move GetMove4()
        {
            if (this.Transform.IsActive()) { return this.Transform.GetMove4(); }
            else return move4;
        }
        


        public float HP
        {
            get
            {
                if (IsSubstituteActive()) return Substitute.GetCurrentHP();
                else return Pokemon.HP;
            }
        }
        public float GetMaxHP()
        {
            if (this.IsSubstituteActive()) { return this.Substitute.GetMaxHP(); }
            else return this.Pokemon.HPStat;
        }



        public float GetAccuracyMultiplier()
        {
            return AccuracyStageToMultiplier[this.StatStageModifiers.GetAccuracy()];
        }
        public float GetEvasionMultiplier()
        {
            return EvasionStageToMultiplier[this.StatStageModifiers.GetEvasion()];
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



        public float GetBaseSpeed() { return this.Pokemon.BaseSpeed; }
        public float GetLevel() { return this.Pokemon.Level; }



        public bool IsFocusEnergyActive() { return this.FocusEnergyActive; }
        public void ActivateFocusEnergy()
        {
            FocusEnergyActive = true;
        }
        public bool IsDireHitActive() { return this.DireHitActive; }
        public bool IsTransformActive() { return this.Transform.IsActive(); }



        public bool IsSubstituteActive() { return this.Substitute.IsActive(); }
        public bool DidSubstituteBreakThisTurn() { return this.Substitute.IsBrokeThisTurn(); }


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
            this.ParalysisDecreasingSpeed = true;
            this.Pokemon.Paralyze();
        }
        public void ParalyzeAsSecondaryEffect()
        {
            if (!this.Substitute.IsActive())
            {
                this.ParalysisDecreasingSpeed = true;
                this.Pokemon.Paralyze();
            }
        }
        public void DeactivateBurnDecreasingAttack()
        {
            BurnDecreasingAttack = false;
        }
		public void BurnAsPrimaryEffect()
        {
            BurnDecreasingAttack = true;
            this.Pokemon.Burn();
        }
        public void BurnAsSecondaryEffect()
        {
            if (!this.Substitute.IsActive())
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
            this.Pokemon.ClearStatus();
            this.N = 1f;
        }










        public void Damage(float amount, Type damageType)
        {
            //1) account for substitute
            if (this.IsSubstituteActive())
            {
                this.Substitute.Damage(amount);
            }
            else
            {
                this.Pokemon.Damage(amount);
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
                this.DamageForCounter = amount;
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
            if (this.IsSubstituteActive())
            {
                this.Substitute.Damage(amount);
            }
            else
            {
                this.Pokemon.Damage(amount);
            }
        }
        //this should only be referenced by the move Counter.
        public void DamageMethodForCounterOnly(float amount)
        {
            this.DamageForCounter = 0f;
            if (this.IsSubstituteActive())
            {
                this.Substitute.Damage(amount);
            }
            else
            {
                this.Pokemon.Damage(amount);
            }

            if (this.Bide.Active)
            {
                this.Bide.Damage(amount);
            }
        }
        public void DamagePokemonOnlyNoEffects(float amount)
        {
            this.Pokemon.Damage(amount);
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
                if (this.StatStageModifiers.CanAttackGoHigher())
                {
                    this.ModifyStatStageAsPrimaryEffect(StatsEnum.ATTACK, 1);
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
            this.Pokemon.RestoreHP(amount);
        }
        public void ActivateBide()
        {
            this.Bide.Activate();
        }
        public void DeactivateBide()
        {
            this.Bide.Deactivate();
        }
        public void TickBide()
        {
            this.Bide.Tick();
        }
        public float GetBideDamage()
        {
            return this.Bide.DamageAccrued;
        }
        public bool IsBideActive()
        {
            return this.Bide.Active;
        }
        public int TurnsLeftOfBide()
        {
            return this.Bide.TurnsLeft;
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
            this.Conversion.Activate(pokemonToConvertInto);
            OnConversionActivated();
        }
        public void ActivateSubstitute(float hp)
        {
            this.Substitute.Activate(hp);
            OnSubstituteActivated();
        }
        public void ActivateTransform(BattlePokemon pokemonToTransformInto)
        {
            this.Transform.Activate(pokemonToTransformInto);
            this.StatStageModifiers = new StatStageModifiers(pokemonToTransformInto.GetStatStageModifiers().GetAttack(),
                                                             pokemonToTransformInto.GetStatStageModifiers().GetDefense(),
                                                             pokemonToTransformInto.GetStatStageModifiers().GetSpecial(),
                                                             pokemonToTransformInto.GetStatStageModifiers().GetSpeed(),
                                                             pokemonToTransformInto.GetStatStageModifiers().GetAccuracy(),
                                                             pokemonToTransformInto.GetStatStageModifiers().GetEvasion());

            OnTransformActivated(pokemonToTransformInto);
        }
        private StatStageModifiers GetStatStageModifiers()
        {
            return this.StatStageModifiers;
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
