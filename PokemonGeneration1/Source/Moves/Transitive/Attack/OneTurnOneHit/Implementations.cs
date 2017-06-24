using PokemonGeneration1.Source.Battles;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Moves.Transitive.Attack.OneTurnOneHit
{

    // 1
    public sealed class Pound : OneTurnOneHitAttackMove
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
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Pound() : base(1, "Pound", Type.Normal, 35, 56, 100f, 40f, 0, false, Category.PHYSICAL)
        {
        }
    }

    //2
    public sealed class KarateChop : OneTurnOneHitAttackMove
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
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);

        }

        public KarateChop() : base(2, "Karate Chop", Type.Normal, 25, 40, 100f, 50, 0, true, Category.PHYSICAL) { }
    }

    //5
    public sealed class MegaPunch : OneTurnOneHitAttackMove
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
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public MegaPunch() : base(5, "Mega Punch", Type.Normal, 20, 32, 85f, 80f, 0, false, Category.PHYSICAL) { }
    }

    //6
    public sealed class PayDay : OneTurnOneHitAttackMove
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
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                OnPayDayTriggered();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public PayDay() : base(6, "Pay Day", Type.Normal, 20, 32, 100f, 40f, 0, false, Category.PHYSICAL) { }
    }

    //7
    public sealed class FirePunch : OneTurnOneHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.IsStatusClear())
                {
                    if (new Random().Next(0, 100) < 10)
                    {
                        defender.BurnAsSecondaryEffect();
                    }
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public FirePunch() : base(7, "Fire Punch", Type.Fire, 15, 34, 100f, 75f, 0, false, Category.SPECIAL) { }
    }

    //8
    public sealed class IcePunch : OneTurnOneHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.IsStatusClear())
                {
                    if (new Random().Next(0, 100) < 10)
                    {
                        defender.FreezeAsSecondaryEffect();
                    }
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public IcePunch() : base(8, "Ice Punch", Type.Ice, 15, 24, 100f, 75f, 0, false, Category.SPECIAL) { }
    }

    //9
    public sealed class ThunderPunch : OneTurnOneHitAttackMove
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
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.IsStatusClear())
                {
                    if (new Random().Next(0, 100) < 10)
                    {
                        defender.ParalyzeAsSecondaryEffect();
                    }
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public ThunderPunch() : base(9, "Thunder Punch", Type.Electric, 15, 24, 100f, 75f, 0, false, Category.SPECIAL) { }
    }

    //10
    public sealed class Scratch : OneTurnOneHitAttackMove
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
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Scratch() : base(10, "Scratch", Type.Normal, 35, 56, 100f, 40f, 0, false, Category.PHYSICAL) { }
    }

    //11
    public sealed class ViceGrip : OneTurnOneHitAttackMove
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
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public ViceGrip() : base(11, "Vice Grip", Type.Normal, 30, 48, 100f, 55f, 0, false, Category.PHYSICAL) { }
    }

    //12
    public sealed class Guillotine : OneTurnOneHitAttackMove
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
                OnOneHitKO();
                defender.Damage(defender.GetMaxHP(), this.Type);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Guillotine() : base(12, "Guillotine", Type.Normal, 5, 8, 30f, 0f, 0, false, Category.PHYSICAL) { }
    }


    //15
    public sealed class Cut : OneTurnOneHitAttackMove
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
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Cut() : base(15, "Cut", Type.Normal, 30, 48, 95f, 50f, 0, false, Category.PHYSICAL) { }
    }


    //16
    public sealed class Gust : OneTurnOneHitAttackMove
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
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Gust() : base(16, "Gust", Type.Flying, 35, 56, 100f, 40f, 0, false, Category.PHYSICAL) { }
    }


    //17
    public sealed class WingAttack : OneTurnOneHitAttackMove
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
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public WingAttack() : base(17, "Wing Attack", Type.Flying, 35, 56, 100f, 35f, 0, false, Category.PHYSICAL) { }
    }


    //21
    public sealed class Slam : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Slam() : base(21, "Slam", Type.Normal, 20, 32, 75f, 80f, 0, false, Category.PHYSICAL) { }
    }


    //22
    public sealed class VineWhip : OneTurnOneHitAttackMove
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
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public VineWhip() : base(22, "Vine Whip", Type.Grass, 10, 16, 100f, 35f, 0, false, Category.SPECIAL) { }
    }

    //23
    public sealed class Stomp : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    new Random().Next(0, 100) < 30)
                {
                    defender.Flinch();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Stomp() : base(23, "Stomp", Type.Normal, 20, 32, 100f, 65f, 0, false, Category.PHYSICAL) { }
    }

    //25
    public sealed class MegaKick : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public MegaKick() : base(25, "Mega Kick", Type.Fighting, 5, 8, 75f, 120f, 0, false, Category.PHYSICAL) { }
    }

    //26
    public sealed class JumpKick : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
                OnCrashDamage();
                user.DamagePokemonOnlyNoEffects(1f);
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public JumpKick() : base(26, "Jump Kick", Type.Fighting, 10, 16, 95f, 100f, 0, false, Category.PHYSICAL) { }
    }

    //27
    public sealed class RollingKick : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    !defender.IsSubstituteActive() &&
                    new Random().Next(0, 100) < 30)
                {
                    defender.Flinch();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public RollingKick() : base(27, "Rolling Kick", Type.Fighting, 15, 24, 85f, 60f, 0, false, Category.PHYSICAL) { }
    }

    //29
    public sealed class Headbutt : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    new Random().Next(0, 100) < 30)
                {
                    defender.Flinch();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Headbutt() : base(29, "Headbutt", Type.Normal, 15, 24, 100f, 70f, 0, false, Category.PHYSICAL) { }
    }

    //30
    public sealed class HornAttack : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public HornAttack() : base(30, "Horn Attack", Type.Normal, 25, 40, 100f, 65f, 0, false, Category.PHYSICAL) { }
    }

    //32
    public sealed class HornDrill : OneTurnOneHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.HasNoEffect(defender) ||
                defender.GetSpeed() > user.GetSpeed())
            {
                OnNoEffect();
            }
            else if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                OnOneHitKO();
                defender.Damage(defender.GetMaxHP(), this.Type);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public HornDrill() : base(32, "Horn Drill", Type.Normal, 5, 8, 30f, 0f, 0, false, Category.PHYSICAL) { }
    }

    //33
    public sealed class Tackle : OneTurnOneHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Tackle() : base(33, "Tackle", Type.Normal, 35, 56, 100f, 40f, 0, false, Category.PHYSICAL) { }
    }

    //34
    public sealed class BodySlam : OneTurnOneHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.Status == PokemonData.Status.Null &&
                    defender.GetType1() != Type.Normal &&
                    defender.GetType2() != Type.Normal &&
                    new Random().Next(0,100) < 30)
                {
                    defender.ParalyzeAsSecondaryEffect();
                } 
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public BodySlam() : base(34, "Body Slam", Type.Normal, 15, 24, 100f, 85f, 0, false, Category.PHYSICAL) { }
    }


    //36
    public sealed class TakeDown : OneTurnOneHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectiveness(defender);
                UpdateCritFlag(user);
                float damage = calculateDamage(user, defender);
                defender.Damage(damage, this.Type);

                if (!defender.DidSubstituteBreakThisTurn())
                {
                    OnHurtByRecoilDamage();
                    float recoilDamage = (float)Math.Floor(damage / 4f);
                    user.RecoilDamage(recoilDamage);
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public TakeDown() : base(36, "Take Down", Type.Normal, 20, 32, 85f, 90f, 0, false, Category.PHYSICAL) { }
        
    }

    //38
    public sealed class DoubleEdge : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectiveness(defender);
                UpdateCritFlag(user);
                float damage = calculateDamage(user, defender);
                defender.Damage(damage, this.Type);

                if (!defender.DidSubstituteBreakThisTurn())
                {
                    OnHurtByRecoilDamage();
                    float recoilDamage = (float)Math.Floor(damage / 4f);
                    user.RecoilDamage(recoilDamage);
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public DoubleEdge() : base(38, "Double-Edge", Type.Normal, 15, 24, 100f, 100f, 0, false, Category.PHYSICAL) { }
    }


    //40
    public sealed class PoisonSting : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.IsStatusClear())
                {
                    if (new Random().Next(0, 100) < 30)
                    {
                        defender.PoisonAsSecondaryEffect();
                    }
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public PoisonSting() : base(40, "Poison Sting", Type.Poison, 35, 56, 100f, 15f, 0, false, Category.PHYSICAL) { }
    }

    //44
    public sealed class Bite : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.Flinch();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Bite() : base(44, "Bite", Type.Normal, 25, 40, 100f, 60f, 0, false, Category.PHYSICAL) { }
    }


    //49
    public sealed class SonicBoom : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                defender.Damage(20f, this.Type);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public SonicBoom() : base(49, "Sonic Boom", Type.Normal, 20, 32, 90f, 0f, 0, false, Category.PHYSICAL) { }
    }

    //51
    public sealed class Acid : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.GetStatStageModifers().CanDefenseGoLower() &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.ModifyStatStageAsSecondaryEffect(StatsEnum.DEFENSE, -1);
                }
            }
        }

        public Acid() : base(51, "Acid", Type.Poison, 30, 48, 100f, 40f, 0, false, Category.PHYSICAL) { }
    }



    //52
    public sealed class Ember : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.IsStatusClear())
                {
                    if (new Random().Next(0, 100) < 10)
                    {
                        defender.BurnAsSecondaryEffect();
                    }
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Ember() : base(52, "Ember", Type.Fire, 25, 40, 100f, 40f, 0, false, Category.SPECIAL) { }
    }

    //53
    public sealed class Flamethrower : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.IsStatusClear())
                {
                    if (new Random().Next(0, 100) < 10)
                    {
                        defender.BurnAsSecondaryEffect();
                    }
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Flamethrower() : base(53, "Flamethrower", Type.Fire, 15, 24, 100f, 90f, 0, false, Category.SPECIAL) { }
    }


    //55
    public sealed class WaterGun : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public WaterGun() : base(55, "Water Gun", Type.Water, 25, 40, 100f, 40f, 0, false, Category.SPECIAL) { }
    }

    //56
    public sealed class HydroPump : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public HydroPump() : base(56, "Hydro Pump", Type.Water, 5, 8, 80f, 110f, 0, false, Category.SPECIAL) { }
    }

    //57
    public sealed class Surf : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Surf() : base(57, "Surf", Type.Water, 15, 24, 100f, 90f, 0, false, Category.SPECIAL) { }
    }

    //58
    public sealed class IceBeam : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.Status == PokemonData.Status.Null &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.FreezeAsSecondaryEffect();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public IceBeam() : base(58, "Ice Beam", Type.Ice, 10, 16, 100f, 95f, 0, false, Category.SPECIAL) { }
    }

    //59
    public sealed class Blizzard : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.Status == PokemonData.Status.Null &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.FreezeAsSecondaryEffect();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Blizzard() : base(59, "Blizzard", Type.Ice, 5, 8, 90f, 110f, 0, false, Category.SPECIAL) { }
    }

    //60
    public sealed class Psybeam : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    !defender.IsConfused() &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.Confuse();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Psybeam() : base(60, "Psybeam", Type.Psychic, 20, 32, 100f, 65f, 0, false, Category.SPECIAL) { }
    }

    //61
    public sealed class BubbleBeam : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.GetStatStageModifers().CanSpeedGoLower() &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.ModifyStatStageAsSecondaryEffect(StatsEnum.SPEED, -1);
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public BubbleBeam() : base(61, "Bubble Beam", Type.Water, 20, 32, 100f, 65f, 0, false, Category.SPECIAL) { }
    }

    //62
    public sealed class AuroraBeam : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.GetStatStageModifers().CanAttackGoLower() &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.ModifyStatStageAsSecondaryEffect(StatsEnum.ATTACK, -1);
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public AuroraBeam() : base(61, "Aurora Beam", Type.Ice, 20, 32, 100f, 65f, 0, false, Category.SPECIAL) { }
    }


    //64
    public sealed class Peck : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Peck() : base(64, "Peck", Type.Flying, 35, 56, 100f, 35f, 0, false, Category.PHYSICAL) { }
    }

    //65
    public sealed class DrillPeck : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public DrillPeck() : base(65, "Drill Peck", Type.Flying, 20, 32, 100f, 80f, 0, false, Category.PHYSICAL) { }
    }

    //66
    public sealed class Submission : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectiveness(defender);
                UpdateCritFlag(user);
                float damage = calculateDamage(user, defender);
                defender.Damage(damage, this.Type);

                if (!defender.DidSubstituteBreakThisTurn())
                {
                    OnHurtByRecoilDamage();
                    float recoilDamage = (float)Math.Floor(damage / 4f);
                    user.RecoilDamage(recoilDamage);
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Submission() : base(66, "Submission", Type.Fighting, 20, 32, 80f, 80f, 0, false, Category.PHYSICAL) { }
    }


    //67
    public sealed class LowKick : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    !defender.IsSubstituteActive() &&
                    new Random().Next(0, 100) < 30)
                {
                    defender.Flinch();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public LowKick() : base(67, "Low Kick", Type.Fighting, 20, 32, 90f, 50f, 0, false, Category.PHYSICAL) { }
    }


    //68
    public sealed class Counter : OneTurnOneHitAttackMove
    {
        private bool fromMetronome = false;
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (user.GetDamageForCounter() > 0f &&
                defender.GetLastMoveUsed()?.Category != Category.STATUS &&
                defender.GetLastMoveUsed()?.GetIndex() != 68 &&
                !fromMetronome)
            {
                defender.Damage(2f * user.GetDamageForCounter(), this.Type);
            }
            else
            {
                OnMissed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Counter() : base(68, "Counter", Type.Fighting, 20, 32, 100f, 0f, -1, false, Category.PHYSICAL)
        {
            this.fromMetronome = false;
        }
        public Counter(bool fromMetronome) : this()
        {
            if (fromMetronome)
            {
                this.fromMetronome = true;
            }
        }
    }

    //69
    public sealed class SeismicToss : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                defender.Damage(user.GetLevel(), this.Type);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public SeismicToss() : base(69, "Seismic Toss", Type.Fighting, 20, 32, 100f, 0f, 0, false, Category.PHYSICAL) { }
    }

    //70
    public sealed class Strength : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Strength() : base(70, "Strength", Type.Normal, 15, 24, 100f, 80f, 0, false, Category.PHYSICAL) { }
    }

    //71
    public sealed class Absorb : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {

                UpdateEffectivenessUpdateCritDoDamageAndRestoreHP(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Absorb() : base(71, "Absorb", Type.Grass, 20, 32, 100f, 20f, 0, false, Category.SPECIAL) { }
    }


    //72
    public sealed class MegaDrain : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritDoDamageAndRestoreHP(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public MegaDrain() : base(72, "Mega Drain", Type.Grass, 15, 24, 100f, 40f, 0, false, Category.SPECIAL) { }
    }


    //75
    public sealed class RazorLeaf : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public RazorLeaf() : base(75, "Razor Leaf", Type.Grass, 25, 40, 95f, 55f, 0, true, Category.SPECIAL) { }
    }


    //82
    public sealed class DragonRage : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                defender.Damage(40f, Type.Dragon);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public DragonRage() : base(82, "Dragon Rage", Type.Dragon, 10, 16, 100f, 0f, 0, false, Category.SPECIAL) { }
    }

    //84
    public sealed class ThunderShock : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (defender.Status == PokemonData.Status.Null &&
                    defender.GetType1() != Type.Electric &&
                    defender.GetType2() != Type.Electric &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.ParalyzeAsSecondaryEffect();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public ThunderShock() : base(84, "ThunderShock", Type.Electric, 30, 48, 100f, 40f, 0, false, Category.SPECIAL) { }
    }

    //85
    public sealed class Thunderbolt : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.Status == PokemonData.Status.Null &&
                    defender.GetType1() != Type.Electric &&
                    defender.GetType2() != Type.Electric &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.ParalyzeAsSecondaryEffect();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Thunderbolt() : base(85, "Thunderbolt", Type.Electric, 15, 24, 100f, 90f, 0, false, Category.SPECIAL) { }
    }

    //87
    public sealed class Thunder : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.Status == PokemonData.Status.Null &&
                    defender.GetType1() != Type.Electric &&
                    defender.GetType2() != Type.Electric &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.ParalyzeAsSecondaryEffect();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Thunder() : base(87, "Thunder", Type.Electric, 10, 16, 70f, 110f, 0, false, Category.SPECIAL) { }
    }

    //88
    public sealed class RockThrow : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public RockThrow() : base(88, "Rock Throw", Type.Rock, 15, 24, 65f, 50f, 0, false, Category.PHYSICAL) { }
    }

    //89
    public sealed class Earthquake : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Earthquake() : base(89, "Earthquake", Type.Ground, 10, 16, 100f, 100f, 0, false, Category.PHYSICAL) { }
    }

    //90
    public sealed class Fissure : OneTurnOneHitAttackMove
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
            else if (user.GetSpeed() > defender.GetSpeed())
            {
                OnOneHitKO();
                defender.Damage(defender.GetMaxHP(), this.Type);
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Fissure() : base(90, "Fissure", Type.Ground, 5, 8, 30f, 0f, 0, false, Category.PHYSICAL) { }
    }

    //93
    public sealed class Confusion : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    !defender.IsConfused() &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.Confuse();
                }
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Confusion() : base(93, "Confusion", Type.Psychic, 25, 40, 100f, 50f, 0, false, Category.SPECIAL) { }
    }

    //94
    public sealed class Psychic : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);

                if (!defender.IsFainted() &&
                    defender.GetStatStageModifers().CanSpecialGoLower() &&
                    new Random().Next(0, 1000) < 332)
                {
                    defender.ModifyStatStageAsSecondaryEffect(StatsEnum.SPECIAL, -1);
                }
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Psychic() : base(94, "Psychic", Type.Psychic, 10, 16, 100f, 90f, 0, false, Category.SPECIAL) { }
    }

    //98
    public sealed class QuickAttack : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public QuickAttack() : base(98, "Quick Attack", Type.Normal, 30, 48, 100f, 40f, 1, false, Category.PHYSICAL) { }
    }


    //101
    public sealed class NightShade : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                defender.Damage(user.GetLevel(), this.Type);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public NightShade() : base(101, "Night Shade", Type.Ghost, 15, 24, 100f, 0f, 0, false, Category.PHYSICAL) { }
    }

    //120
    public sealed class Selfdestruct : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }

            user.DamagePokemonOnlyNoEffects(user.GetMaxHP());

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Selfdestruct() : base(120, "Selfdestruct", Type.Normal, 5, 8, 100f, 260f, 0, false, Category.PHYSICAL) { }
    }

    //121
    public sealed class EggBomb : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public EggBomb() : base(121, "Egg Bomb", Type.Normal, 10, 16, 75f, 100f, 0, false, Category.PHYSICAL) { }
    }

    //122
    public sealed class Lick : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.Status == PokemonData.Status.Null &&
                    defender.GetType1() != Type.Ghost &&
                    defender.GetType2() != Type.Ghost &&
                    new Random().Next(0,100) < 30)
                {
                    defender.ParalyzeAsSecondaryEffect();
                }
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Lick() : base(122, "Lick", Type.Ghost, 30, 48, 100f, 20f, 0, false, Category.PHYSICAL) { }
    }

    //123
    public sealed class Smog : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);

                if (!defender.IsFainted() &&
                    defender.IsStatusClear() &&
                    new Random().Next(0,100) < 40)
                {
                    defender.PoisonAsSecondaryEffect();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Smog() : base(123, "Smog", Type.Poison, 20, 32, 70f, 20f, 0, false, Category.PHYSICAL) { }
    }

    //124
    public sealed class Sludge : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);

                if (!defender.IsFainted() &&
                    defender.IsStatusClear() &&
                    new Random().Next(0, 100) < 30)
                {
                    defender.PoisonAsSecondaryEffect();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Sludge() : base(124, "Sludge", Type.Poison, 20, 32, 100f, 65f, 0, false, Category.PHYSICAL) { }
    }

    //125
    public sealed class BoneClub : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    new Random().Next(0,100) < 10)
                {
                    defender.Flinch();
                }
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public BoneClub() : base(125, "Bone Club", Type.Ground, 20, 32, 85f, 65f, 0, false, Category.PHYSICAL) { }
    }

    //126
    public sealed class FireBlast : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.IsStatusClear())
                {
                    if (new Random().Next(0, 100) < 30)
                    {
                        defender.BurnAsSecondaryEffect();
                    }
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public FireBlast() : base(126, "Fire Blast", Type.Fire, 5, 8, 85f, 110f, 0, false, Category.SPECIAL) { }
    }

    //127
    public sealed class Waterfall : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Waterfall() : base(127, "Waterfall", Type.Water, 15, 24, 100f, 80f, 0, false, Category.SPECIAL) { }
    }

    //129
    public sealed class Swift : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Swift() : base(129, "Swift", Type.Normal, 20, 32, 100f, 60f, 0, false, Category.PHYSICAL) { }
    }

    //132
    public sealed class Constrict : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.GetStatStageModifers().CanSpeedGoLower() &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.ModifyStatStageAsSecondaryEffect(StatsEnum.SPEED, -1);
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Constrict() : base(132, "Constrict", Type.Normal, 35, 56, 100f, 10f, 0, false, Category.PHYSICAL) { }
    }

    //136
    public sealed class HiJumpKick : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (IsAMiss(user, defender) ||
                defender.GetType1() == Type.Ghost ||
                defender.GetType2() == Type.Ghost)
            {
                OnMissed();
                OnCrashDamage();
                user.DamagePokemonOnlyNoEffects(1f);
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public HiJumpKick() : base(136, "Hi Jump Kick", Type.Fighting, 10, 16, 90f, 85f, 0, false, Category.PHYSICAL) { }
    }

    //138
    public sealed class DreamEater : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.IsSleeping())
            {
                UpdateEffectivenessUpdateCritDoDamageAndRestoreHP(user, defender);
            }
            else
            {
                OnFailed();
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public DreamEater() : base(138, "Dream Eater", Type.Psychic, 15, 24, 100f, 100f ,0, false, Category.SPECIAL) { }
    }

    //141
    public sealed class LeechLife : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectiveness(defender);
                UpdateCritFlag(user);
                float damage = calculateDamage(user, defender);
                float remainingHP = defender.HP;
                defender.Damage(damage, this.Type);
                if (!defender.DidSubstituteBreakThisTurn())
                {
                    float sap = (float)Math.Ceiling(Math.Min(damage, remainingHP) / 2f);
                    user.RestoreHP(sap);
                    OnSuckedHealth();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public LeechLife() : base(141, "Leech Life", Type.Bug, 15, 24, 100f, 20f, 0, false, Category.SPECIAL) { }
    }

    //145
    public sealed class Bubble : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    defender.GetStatStageModifers().CanSpeedGoLower() &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.ModifyStatStageAsSecondaryEffect(StatsEnum.SPEED, -1);
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Bubble() : base(145, "Bubble", Type.Water, 30, 48, 100f, 20f, 0, false, Category.SPECIAL) { }
    }

    //146
    public sealed class DizzyPunch : OneTurnOneHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public DizzyPunch() : base(146, "Dizzy Punch", Type.Normal, 10, 16, 100f, 70f, 0, false, Category.PHYSICAL) { }

    }

    //149
    public sealed class Psywave : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                int max = (int) Math.Floor(user.GetLevel() * 1.5f);
                float randomDamage = new Random().Next(1, max);
                defender.Damage(randomDamage, this.Type);
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Psywave() : base(149, "Psywave", Type.Psychic, 15, 24, 80f, 0f, 0, false, Category.SPECIAL) { }
    }

    //152
    public sealed class Crabhammer : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Crabhammer() : base(152, "Crabhammer", Type.Water, 10, 16, 85f, 90f, 0, true, Category.SPECIAL) { }
    }

    //153
    public sealed class Explosion : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }

            user.DamagePokemonOnlyNoEffects(user.GetMaxHP());

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Explosion() : base(153, "Explosion", Type.Normal, 5, 8, 100f, 340f, 0, false, Category.PHYSICAL) { }
    }

    //157
    public sealed class RockSlide : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public RockSlide() : base(157, "Rock Slide", Type.Rock, 10, 16, 90f, 75f, 0, false, Category.PHYSICAL) { }
    }

    //158
    public sealed class HyperFang : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                if (!defender.IsFainted() &&
                    new Random().Next(0, 100) < 10)
                {
                    defender.Flinch();
                }
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public HyperFang() : base(158, "Hyper Fang", Type.Normal, 15, 24, 90f, 80f, 0, false, Category.PHYSICAL) { }
    }

    //161
    public sealed class TriAttack : OneTurnOneHitAttackMove
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
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public TriAttack() : base(161, "Tri Attack", Type.Normal, 10, 16, 100f, 80f, 0, false, Category.PHYSICAL)
        {
        }
    }

    //162
    public sealed class SuperFang : OneTurnOneHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                float damage =
                    (defender.HP == 1f) ? 1f : defender.HP / 2f;
                defender.Damage(damage, this.Type);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public SuperFang() : base(162, "Super Fang", Type.Normal, 10, 16, 90f, 0f, 0, false, Category.PHYSICAL)
        {
        }
    }

    //163
    public sealed class Slash : OneTurnOneHitAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else
            {
                UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Slash() : base(163, "Slash", Type.Normal, 20, 32, 100f, 70f, 0, true, Category.PHYSICAL) { }
    }

    //165
    public sealed class Struggle : OneTurnOneHitAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else
            {
                UpdateEffectiveness(defender);
                UpdateCritFlag(user);
                float damage = calculateDamage(user, defender);
                float remainingHP = defender.HP;
                defender.Damage(damage, Type);

                if (!defender.DidSubstituteBreakThisTurn())
                {
                    float recoilDamage = (float) Math.Floor(Math.Min(damage, remainingHP) / 2f);
                    user.RecoilDamage(recoilDamage);
                }
            }

            SetLastMoveAndMirrorMove(user, defender);
        }

        public Struggle() : base(165, "Struggle", Type.Normal, 10, 10, 100f, 50f, 0, false, Category.PHYSICAL) { }
    }

}
