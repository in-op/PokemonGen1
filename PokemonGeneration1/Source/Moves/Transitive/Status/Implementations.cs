using PokemonGeneration1.Source.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Moves.Transitive.Status
{
    //28
    public sealed class SandAttack : TransitiveStatusMove
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
            else if (defender.GetStatStageModifers().CanAccuracyGoLower() &&
                     !defender.IsSubstituteActive() &&
                     !defender.IsMistActive())
            {
                defender.ModifyStatStageAsPrimaryEffect(StatsEnum.ACCURACY, -1);
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public SandAttack() : base(28, "Sand-Attack", Types.NORMAL, 15, 24, 100f) { }
    }

    //39
    public sealed class TailWhip : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {

            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.GetStatStageModifers().CanDefenseGoLower() &&
                     !defender.IsSubstituteActive() &&
                     !defender.IsMistActive())
            {
                defender.ModifyStatStageAsPrimaryEffect(StatsEnum.DEFENSE, -1);
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public TailWhip() : base(39, "Tail Whip", Types.NORMAL, 30, 48, 100f) { }
    }

    //43
    public sealed class Leer : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.GetStatStageModifers().CanDefenseGoLower() &&
                     !defender.IsSubstituteActive() &&
                     !defender.IsMistActive())
            {
                defender.ModifyStatStageAsPrimaryEffect(StatsEnum.DEFENSE, -1);
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Leer() : base(43, "Leer", Types.NORMAL, 30, 48, 100f) { }
    }


    //45
    public sealed class Growl : TransitiveStatusMove
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
            else if (defender.GetStatStageModifers().CanAttackGoLower() &&
                     !defender.IsSubstituteActive() &&
                     !defender.IsMistActive())
            {
                defender.ModifyStatStageAsPrimaryEffect(StatsEnum.ATTACK, -1);
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Growl() : base(45, "Growl", Types.NORMAL, 40, 64, 100f) { }
    }

    //47
    public sealed class Sing : TransitiveStatusMove
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
            else if (defender.Status == PokemonData.Status.NONE)
            {
                defender.Sleep();
            }
            else
            {
                OnFailed();
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Sing() : base(47, "Sing", Types.NORMAL, 15, 24, 55f) { }
    }


    //48
    public sealed class Supersonic : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (!defender.IsSubstituteActive() &&
                     !defender.IsConfused())
            {
                defender.Confuse();
            }
            else
            {
                OnFailed();
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Supersonic() : base(48, "Supersonic", Types.NORMAL, 20, 32, 55f) { }
    }


    //50
    public sealed class Disable : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            Move move1 = defender.GetMove1();
            Move move2 = defender.GetMove2();
            Move move3 = defender.GetMove3();
            Move move4 = defender.GetMove4();


            OnUsed();
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
                defender.CheckForRageAndUpdateAttackStatStageIfNecessary();
            }
            //success condition:
            else if (!defender.IsDisabled() &&
                     (
                     (move1 != null && move1.GetCurrentPP() > 0) ||
                     (move2 != null && move2.GetCurrentPP() > 0) ||
                     (move3 != null && move3.GetCurrentPP() > 0) ||
                     (move4 != null && move4.GetCurrentPP() > 0)
                     )
                    )
            {
                bool disabled = false;
                while (!disabled)
                {
                    Random rng = new Random();
                    int rando = rng.Next(1, 5);
                    if (rando == 1 &&
                        move1 != null &&
                        move1.GetCurrentPP() > 0)
                    {
                        defender.ActivateDisable(move1, rng.Next(0, 7));
                        disabled = true;
                    }
                    else if (rando == 2 &&
                             move2 != null &&
                             move2.GetCurrentPP() > 0)
                    {
                        defender.ActivateDisable(move2, rng.Next(0, 7));
                        disabled = true;
                    }
                    else if (rando == 3 &&
                             move3 != null &&
                             move3.GetCurrentPP() > 0)
                    {
                        defender.ActivateDisable(move3, rng.Next(0, 7));
                        disabled = true;
                    }
                    else if (rando == 4 &&
                             move4 != null &&
                             move4.GetCurrentPP() > 0)
                    {
                        defender.ActivateDisable(move4, rng.Next(0, 7));
                        disabled = true;
                    }
                }
            }
            else
            {
                OnFailed();
                defender.CheckForRageAndUpdateAttackStatStageIfNecessary();
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Disable() : base(50, "Disable", Types.NORMAL, 20, 32, 90f) { }
    }


    //73
    public sealed class LeechSeed : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.GetType1() == Types.GRASS ||
                     defender.GetType2() == Types.GRASS)
            {
                OnNoEffect();
            }
            else if (defender.IsLeechSeedActive())
            {
                OnFailed();
            }
            else
            {
                defender.ActivateLeechSeed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public LeechSeed() : base(73, "Leech Seed", Types.GRASS, 10, 16, 90f) { }
    }




    //77
    public sealed class PoisonPowder : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.GetType1() == Types.POISON ||
                     defender.GetType2() == Types.POISON)
            {
                OnNoEffect();
            }
            else if (defender.IsStatusClear() &&
                     !defender.IsSubstituteActive())
            {
                defender.PoisonAsPrimaryEffect();
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public PoisonPowder() : base(77, "PoisonPowder", Types.POISON, 35, 56, 75f) { }
    }

    //78
    public sealed class StunSpore : TransitiveStatusMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.IsStatusClear())
            {
                defender.ParalyzeAsPrimaryEffect();
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public StunSpore() : base(78, "Stun Spore", Types.GRASS, 30, 48, 75f) { }
    }

    //79
    public sealed class SleepPowder : TransitiveStatusMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.IsStatusClear())
            {
                defender.Sleep();
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public SleepPowder() : base(79, "Sleep Powder", Types.GRASS, 15, 24, 75f) { }
    }

    //81
    public sealed class StringShot : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.GetStatStageModifers().CanSpeedGoLower() &&
                     !defender.IsSubstituteActive() &&
                     !defender.IsMistActive())
            {
                defender.ModifyStatStageAsPrimaryEffect(StatsEnum.SPEED, -1);
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public StringShot(): base(81, "String Shot", Types.BUG, 40, 64, 95f) { }
    }

    //86
    public sealed class ThunderWave : TransitiveStatusMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (this.IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (this.HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (!defender.IsStatusClear())
            {
                OnFailed();
            }
            else
            {
                defender.ParalyzeAsPrimaryEffect();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public ThunderWave() : base(86, "Thunder Wave", Types.ELECTRIC, 20, 32, 100f) { }
    }

    //92
    public sealed class Toxic : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.Status == PokemonData.Status.NONE &&
                     !defender.IsSubstituteActive())
            {
                defender.BadlyPoisonAsPrimaryEffect();
            }
            else
            {
                OnFailed();
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Toxic() : base(92, "Toxic", Types.POISON, 10, 16, 85f) { }
    }


    //95
    public sealed class Hypnosis : TransitiveStatusMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.IsStatusClear())
            {
                defender.Sleep();
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Hypnosis() : base(95, "Hypnosis", Types.PSYCHIC, 20, 32, 60f) { }
    }

    //102
    public sealed class Mimic : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (!defender.IsSemiInvulnerable())
            {
                user.MimicMove(this, defender);
            }
            else
            {
                OnMissed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Mimic() : base(102, "Mimic", Types.NORMAL, 10, 16, 100f) { }
    }

    //103
    public sealed class Screech : TransitiveStatusMove
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
            else if (defender.GetStatStageModifers().CanDefenseGoLower() &&
                     !defender.IsSubstituteActive() &&
                     !defender.IsMistActive())
            {
                defender.ModifyStatStageAsPrimaryEffect(StatsEnum.DEFENSE, -2);
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Screech() : base(103, "Screech", Types.NORMAL, 40, 64, 85f) { }
    }

    //108
    public sealed class Smokescreen : TransitiveStatusMove
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
            else if (defender.GetStatStageModifers().CanAccuracyGoLower() &&
                     !defender.IsSubstituteActive() &&
                     !defender.IsMistActive())
            {
                defender.ModifyStatStageAsPrimaryEffect(StatsEnum.ACCURACY, -1);
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Smokescreen() : base(108, "Smokescreen", Types.NORMAL, 20, 32, 100f) { }
    }

    //109
    public sealed class ConfuseRay : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            if (HasNoEffect(defender))
            {
                OnNoEffect();
            }
            else if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (!defender.IsSubstituteActive() &&
                     !defender.IsConfused())
            {
                defender.Confuse();
            }
            else
            {
                OnFailed();
            }

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public ConfuseRay() : base(109, "Confuse Ray", Types.GHOST, 10, 16, 100f) { }
    }

    //114
    public sealed class Haze : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            user.GetStatStageModifers().Reset();
            defender.GetStatStageModifers().Reset();

            user.DeactivateBurnDecreasingAttack();
            defender.DeactivateBurnDecreasingAttack();

            user.DeactivateParalysisDecreasingSpeed();
            defender.DeactivateParalysisDecreasingSpeed();

            user.DeactivateFocusEnergy();
            defender.DeactivateFocusEnergy();

            user.DeactivateMist();
            defender.DeactivateMist();

            user.DeactivateLeechSeed();
            defender.DeactivateLeechSeed();

            user.DeactivateLightScreen();
            defender.DeactivateLightScreen();

            user.DeactivateReflect();
            defender.DeactivateReflect();

            user.DeactivateDisable();
            defender.DeactivateDisable();

            user.DeactivateConfusion();
            defender.DeactivateConfusion();

            user.AttemptChangeBadlyPoisonToPoison();
            defender.ClearStatus();

            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Haze() : base(114, "Haze", Types.ICE, 30, 48, 100f) { }
    }

    //119
    public sealed class MirrorMove : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();

            if (defender.GetMirrorMove() != null &&
                defender.GetMirrorMove().GetIndex() != 119)
            {
                Move copy = MoveFactory.CreateMove(defender.GetMirrorMove().GetIndex());
                copy.ExecuteAndUpdate(user, defender);
            }
            else
            {
                OnFailed();
            }
            //MirrorMove does NOT set the last move and update mirror move,
            // it delegates those responsibilities to the move that it executes
            SubtractPP(1);
        }

        public MirrorMove() : base(119, "Mirror Move", Types.FLYING, 20, 32, 100f) { }
    }

    //134
    public sealed class Kinesis : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.GetStatStageModifers().CanAccuracyGoLower() &&
                     !defender.IsSubstituteActive() &&
                     !defender.IsMistActive())
            {
                defender.ModifyStatStageAsPrimaryEffect(StatsEnum.ACCURACY, -1);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Kinesis() : base(134, "Kinesis", Types.PSYCHIC, 15, 24, 80f) { }
    }

    //137
    public sealed class Glare : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.IsStatusClear())
            {
                defender.ParalyzeAsPrimaryEffect();
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Glare() : base(137, "Glare", Types.NORMAL, 30, 48, 75f) { }
    }

    //139
    public sealed class PoisonGas : TransitiveStatusMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.IsStatusClear() &&
                     !defender.IsSubstituteActive())
            {
                defender.PoisonAsPrimaryEffect();
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public PoisonGas() : base(139, "Poison Gas", Types.POISON, 40, 64, 55f) { }
    }

    //142
    public sealed class LovelyKiss : TransitiveStatusMove
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
            else if (defender.IsStatusClear())
            {
                defender.Sleep();
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public LovelyKiss() : base(142, "Lovely Kiss", Types.NORMAL, 10, 16, 75f) { }
    }

    //144
    public sealed class Transform : TransitiveStatusMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            user.ActivateTransform(defender);
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Transform() : base(144, "Transform", Types.NORMAL, 10, 16, 100f) { }
    }

    //147
    public sealed class Spore : TransitiveStatusMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            if (IsAMiss(user, defender))
            {
                OnMissed();
            }
            else if (defender.IsStatusClear())
            {
                defender.Sleep();
            }
            else
            {
                OnFailed();
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Spore() : base(147, "Spore", Types.GRASS, 15, 24, 100f) { }
    }

    //148
    public sealed class Flash : TransitiveStatusMove
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
            else if (defender.GetStatStageModifers().CanAccuracyGoLower() &&
                     !defender.IsSubstituteActive() &&
                     !defender.IsMistActive())
            {
                defender.ModifyStatStageAsPrimaryEffect(StatsEnum.ACCURACY, -1);
            }
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Flash() : base(148, "Flash", Types.NORMAL, 29, 32, 70f) { }
    }

    //160
    public sealed class Conversion : TransitiveStatusMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            user.ActivateConversion(defender);
            SetLastMoveAndMirrorMove(user, defender);
            SubtractPP(1);
        }

        public Conversion() : base(160, "Conversion", Types.NORMAL, 30, 48, 100f) { }

    }


}
