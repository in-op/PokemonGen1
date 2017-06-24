using System;
using PokemonGeneration1.Source.Battles;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Moves.Reflexive
{

    //14
    public sealed class SwordsDance : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.GetStatStageModifers().CanAttackGoHigher())
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.ATTACK, 2);
            }
            else
            {
                OnFailed();
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public SwordsDance() : base(14, "Swords Dance", Type.Normal, 20, 32) { }
    }


    //54
    public sealed class Mist : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (!user.IsMistActive())
            {
                user.ActivateMist();
            }
            else
            {
                OnFailed();
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Mist() : base(54, "Mist", Type.Ice, 30, 48) { }
    }



    //74
    public sealed class Growth : ReflexiveStatusMove
    {
        protected override sealed void Execute(BattlePokemon user)
        {
            OnUsed();
            if (!user.GetStatStageModifers().CanSpecialGoHigher())
            {
                OnFailed();
            }
            else
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.SPECIAL, 1);
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Growth() : base(74, "Growth", Type.Normal, 20, 32) { }
    }


    //96
    public sealed class Meditate : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (!user.GetStatStageModifers().CanAttackGoHigher())
            {
                OnFailed();
            }
            else
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.ATTACK, 1);
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Meditate() : base(96, "Meditate", Type.Psychic, 40, 64) { }
    }

    //97
    public sealed class Agility : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (!user.GetStatStageModifers().CanSpeedGoHigher())
            {
                OnFailed();
            }
            else
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.SPEED, 2);
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Agility() : base(97, "Agility", Type.Psychic, 30, 48) { }
    }

    //104
    public sealed class DoubleTeam : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.GetStatStageModifers().CanEvasionGoHigher())
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.EVASION, 1);
            }
            else
            {
                OnFailed();
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public DoubleTeam() : base(104, "Double Team", Type.Normal, 15, 24) { }
    }


    //105
    public sealed class Recover : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.HP < user.GetMaxHP())
            {
                float amount = (float) Math.Floor(user.GetMaxHP() / 2f);
                user.RestoreHP(amount);
                OnRegainedHealth();
            }
            else
            {
                OnFailed();
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Recover() : base(105, "Recover", Type.Normal, 20, 32) { }
    }


    //106
    public sealed class Harden : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.GetStatStageModifers().CanDefenseGoHigher())
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.DEFENSE, 1);
            }
            else
            {
                OnFailed();
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Harden() : base(106, "Harden", Type.Normal, 30, 48) { }
    }


    //107
    public sealed class Minimize : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();

            if (user.GetStatStageModifers().CanEvasionGoHigher())
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.EVASION, 1);
            }
            else
            {
                OnFailed();
            }

            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Minimize() : base(107, "Minimize", Type.Normal, 10, 16) { }
    }

    //110
    public sealed class Withdraw : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();

            if (user.GetStatStageModifers().CanDefenseGoHigher())
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.DEFENSE, 1);
            }
            else
            {
                OnFailed();
            }

            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Withdraw() : base(110, "Withdraw", Type.Water, 40, 64) { }
    }

    //111
    public sealed class DefenseCurl : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();

            if (user.GetStatStageModifers().CanDefenseGoHigher())
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.DEFENSE, 1);
            }
            else
            {
                OnFailed();
            }

            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public DefenseCurl() : base(111, "Defense Curl", Type.Normal, 40, 64) { }
    }


    //112
    public sealed class Barrier : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();

            if (user.GetStatStageModifers().CanDefenseGoHigher())
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.DEFENSE, 2);
            }
            else
            {
                OnFailed();
            }

            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Barrier() : base(112, "Barrier", Type.Psychic, 20, 32) { }
    }

    //113
    public sealed class LightScreen : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();

            if (!user.IsLightScreenActive())
            {
                user.ActivateLightScreen();
            }
            else
            {
                OnFailed();
            }

            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public LightScreen() : base(113, "Light Screen", Type.Psychic, 30, 48) { }
    }

    //115
    public sealed class Reflect : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();

            if (!user.IsReflectActive())
            {
                user.ActivateReflect();
            }
            else
            {
                OnFailed();
            }

            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Reflect() : base(115, "Reflect", Type.Psychic, 20, 32) { }
    }


    //116
    public sealed class FocusEnergy : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();

            user.ActivateFocusEnergy();

            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public FocusEnergy() : base(116, "Focus Energy", Type.Normal, 30, 48) { }
    }

    //133
    public sealed class Amnesia : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.GetStatStageModifers().CanSpecialGoHigher())
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.SPECIAL, 2);
            }
            else
            {
                OnFailed();
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Amnesia() : base(133, "Amnesia", Type.Psychic, 20, 32) { }
    }

    //135
    public sealed class SoftBoiled : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.HP < user.GetMaxHP())
            {
                float amount = (float)Math.Floor(user.HP / 2f);
                user.RestoreHP(amount);
                OnRegainedHealth();
            }
            else
            {
                OnFailed();
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public SoftBoiled() : base(105, "Soft-Boiled", Type.Normal, 10, 16) { }
    }

    //150
    public sealed class Splash : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            OnNoEffect();
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Splash() : base(150, "Splash", Type.Normal, 40, 64) { }
    }

    //151
    public sealed class AcidArmor : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.GetStatStageModifers().CanDefenseGoHigher())
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.DEFENSE, 2);
            }
            else
            {
                OnFailed();
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public AcidArmor() : base(151, "Acid Armor", Type.Poison, 40, 64) { }
    }

    //164
    public sealed class Substitute : ReflexiveStatusMove
    {
        protected override sealed void Execute(BattlePokemon user)
        {
            OnUsed();
            float quarterHP = (float)Math.Floor(user.GetMaxHP() / 4f);
            if ((user.HP < quarterHP) ||
                 user.IsSubstituteActive())
            {
                OnFailed();
            }
            else if (user.HP == quarterHP)
            {
                user.Damage(quarterHP, this.Type);
            }
            else
            {
                user.ActivateSubstitute(quarterHP + 1f);
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Substitute() : base(164, "Substitute", Type.Normal, 10, 16) { }
    }

    //156
    public sealed class Rest : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            user.SleepFor(2);
            user.RestoreHP(user.GetMaxHP());
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Rest() : base(156, "Rest", Type.Psychic, 10, 16) { }
    }

    //159
    public sealed class Sharpen : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.GetStatStageModifers().CanAttackGoHigher())
            {
                user.ModifyStatStageAsPrimaryEffect(StatsEnum.ATTACK, 1);
            }
            else
            {
                OnFailed();
            }
            user.SetLastMoveUsed(this);
            SubtractPP(1);
        }

        public Sharpen() : base(159, "Sharpen", Type.Normal, 30, 48) { }
    }
}
