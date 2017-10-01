using PokemonGeneration1.Source.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Moves.Transitive.Attack.OneTurnMultiHit
{

    //3
    public sealed class DoubleSlap : OneTurnMultiHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                SetRandomNumberOfHits();

                this.UpdateEffectiveness(defender);
                this.UpdateCritFlag(user);

                float damageAmount = CalcDamage(user, defender);
                this.ExecuteMultiHitDamage(defender, damageAmount);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public DoubleSlap() : base(3, "Double Slap", Type.Normal, 10, 16, 85f, 15f, Category.PHYSICAL) { }
    }

    //4
    public sealed class CometPunch : OneTurnMultiHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                SetRandomNumberOfHits();

                this.UpdateEffectiveness(defender);
                this.UpdateCritFlag(user);

                float damageAmount = CalcDamage(user, defender);
                this.ExecuteMultiHitDamage(defender, damageAmount);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public CometPunch() : base(4, "Comet Punch", Type.Normal, 15, 24, 85f, 18f, Category.PHYSICAL) { }
    }


    //24
    public sealed class DoubleKick : OneTurnMultiHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectiveness(defender);
                UpdateCritFlag(user);
                float damageAmount = CalcDamage(user, defender);
                this.ExecuteMultiHitDamage(defender, damageAmount);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public DoubleKick() : base(24, "Double Kick", Type.Fighting, 30, 48, 100f, 30f, Category.PHYSICAL)
        {
            numberOfHits = 2;
        }
    }

    //31
    public sealed class FuryAttack : OneTurnMultiHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                SetRandomNumberOfHits();
                UpdateEffectiveness(defender);
                UpdateCritFlag(user);
                float damageAmount = CalcDamage(user, defender);
                this.ExecuteMultiHitDamage(defender, damageAmount);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public FuryAttack() : base(31, "Fury Attack", Type.Normal, 20, 32, 85f, 15f, Category.PHYSICAL) { }
    }

    //41
    public sealed class Twineedle : OneTurnMultiHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectiveness(defender);
                UpdateCritFlag(user);
                float damageAmount = CalcDamage(user, defender);
                ExecuteMultiHitDamageAndAttemptPoison(defender, damageAmount);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Twineedle() : base(41, "Twineedle", Type.Poison, 20, 32, 100f, 25f, Category.PHYSICAL)
        {
            numberOfHits = 2;
        }
    }

    //42
    public sealed class PinMissile : OneTurnMultiHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                SetRandomNumberOfHits();
                UpdateEffectiveness(defender);
                UpdateCritFlag(user);
                float damageAmount = CalcDamage(user, defender);
                this.ExecuteMultiHitDamage(defender, damageAmount);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public PinMissile() : base(42, "Pin Missile", Type.Bug, 20, 32, 85f, 14f, Category.PHYSICAL) { }
    }

    //131
    public sealed class SpikeCannon : OneTurnMultiHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                SetRandomNumberOfHits();

                this.UpdateEffectiveness(defender);
                this.UpdateCritFlag(user);

                float damageAmount = CalcDamage(user, defender);
                this.ExecuteMultiHitDamage(defender, damageAmount);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public SpikeCannon() : base(131, "Spike Cannon", Type.Normal, 15, 24, 100f, 20f, Category.PHYSICAL) { }
    }

    //140
    public sealed class Barrage : OneTurnMultiHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                SetRandomNumberOfHits();

                this.UpdateEffectiveness(defender);
                this.UpdateCritFlag(user);

                float damageAmount = CalcDamage(user, defender);
                this.ExecuteMultiHitDamage(defender, damageAmount);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Barrage() : base(140, "Barrage", Type.Normal, 20, 32, 85f, 15f, Category.PHYSICAL) { }
    }

    //154
    public sealed class FurySwipes : OneTurnMultiHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                SetRandomNumberOfHits();

                this.UpdateEffectiveness(defender);
                this.UpdateCritFlag(user);

                float damageAmount = CalcDamage(user, defender);
                this.ExecuteMultiHitDamage(defender, damageAmount);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public FurySwipes() : base(154, "Fury Swipes", Type.Normal, 15, 24, 80f, 18f, Category.PHYSICAL) { }
    }


    //155
    public sealed class Bonemerang : OneTurnMultiHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectiveness(defender);
                UpdateCritFlag(user);
                float damageAmount = CalcDamage(user, defender);
                ExecuteMultiHitDamageAndAttemptPoison(defender, damageAmount);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Bonemerang() : base(155, "Bonemerang", Type.Ground, 10, 16, 90f, 50f, Category.PHYSICAL)
        {
            numberOfHits = 2;
        }
    }

}
