using System;
using PokemonGeneration1.Source.Battles;

namespace PokemonGeneration1.Source.Moves.Reflexive
{

    //14
    public sealed class SwordsDance : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.CanStatGoHigher(StatType.Attack))
                user.ModifyStatStageAsPrimaryEffect(StatType.Attack, 2);
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public SwordsDance() : base(14, "Swords Dance", Type.Normal, 20, 32) { }
    }


    //54
    public sealed class Mist : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (!user.IsMistActive()) user.ActivateMist();
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public Mist() : base(54, "Mist", Type.Ice, 30, 48) { }
    }



    //74
    public sealed class Growth : ReflexiveStatusMove
    {
        protected override sealed void Execute(BattlePokemon user)
        {
            OnUsed();
            if (!user.CanStatGoHigher(StatType.Special)) OnFailed();
            else user.ModifyStatStageAsPrimaryEffect(StatType.Special, 1);
            SetLastMoveAndSubtractPP(user);
        }

        public Growth() : base(74, "Growth", Type.Normal, 20, 32) { }
    }


    //96
    public sealed class Meditate : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (!user.CanStatGoHigher(StatType.Attack)) OnFailed();
            else user.ModifyStatStageAsPrimaryEffect(StatType.Attack, 1);
            SetLastMoveAndSubtractPP(user);
        }

        public Meditate() : base(96, "Meditate", Type.Psychic, 40, 64) { }
    }

    //97
    public sealed class Agility : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (!user.CanStatGoHigher(StatType.Speed)) OnFailed();
            else user.ModifyStatStageAsPrimaryEffect(StatType.Speed, 2);
            SetLastMoveAndSubtractPP(user);
        }

        public Agility() : base(97, "Agility", Type.Psychic, 30, 48) { }
    }

    //104
    public sealed class DoubleTeam : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.CanStatGoHigher(StatType.Evasion))
                user.ModifyStatStageAsPrimaryEffect(StatType.Evasion, 1);
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public DoubleTeam() : base(104, "Double Team", Type.Normal, 15, 24) { }
    }


    //105
    public sealed class Recover : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.HP < user.MaxHP)
            {
                float amount = (float) Math.Floor(user.MaxHP / 2f);
                user.RestoreHP(amount);
                OnRegainedHealth();
            }
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public Recover() : base(105, "Recover", Type.Normal, 20, 32) { }
    }


    //106
    public sealed class Harden : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.CanStatGoHigher(StatType.Defense))
                user.ModifyStatStageAsPrimaryEffect(StatType.Defense, 1);
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public Harden() : base(106, "Harden", Type.Normal, 30, 48) { }
    }


    //107
    public sealed class Minimize : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.CanStatGoHigher(StatType.Evasion))
                user.ModifyStatStageAsPrimaryEffect(StatType.Evasion, 1);
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public Minimize() : base(107, "Minimize", Type.Normal, 10, 16) { }
    }

    //110
    public sealed class Withdraw : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.CanStatGoHigher(StatType.Defense))
                user.ModifyStatStageAsPrimaryEffect(StatType.Defense, 1);
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public Withdraw() : base(110, "Withdraw", Type.Water, 40, 64) { }
    }

    //111
    public sealed class DefenseCurl : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.CanStatGoHigher(StatType.Defense))
                user.ModifyStatStageAsPrimaryEffect(StatType.Defense, 1);
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public DefenseCurl() : base(111, "Defense Curl", Type.Normal, 40, 64) { }
    }


    //112
    public sealed class Barrier : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.CanStatGoHigher(StatType.Defense))
                user.ModifyStatStageAsPrimaryEffect(StatType.Defense, 2);
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public Barrier() : base(112, "Barrier", Type.Psychic, 20, 32) { }
    }

    //113
    public sealed class LightScreen : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (!user.IsLightScreenActive()) user.ActivateLightScreen();
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public LightScreen() : base(113, "Light Screen", Type.Psychic, 30, 48) { }
    }

    //115
    public sealed class Reflect : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (!user.IsReflectActive()) user.ActivateReflect();
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
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
            SetLastMoveAndSubtractPP(user);
        }

        public FocusEnergy() : base(116, "Focus Energy", Type.Normal, 30, 48) { }
    }

    //133
    public sealed class Amnesia : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.CanStatGoHigher(StatType.Special))
                user.ModifyStatStageAsPrimaryEffect(StatType.Special, 2);
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public Amnesia() : base(133, "Amnesia", Type.Psychic, 20, 32) { }
    }

    //135
    public sealed class SoftBoiled : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.HP < user.MaxHP)
            {
                float amount = (float)Math.Floor(user.HP / 2f);
                user.RestoreHP(amount);
                OnRegainedHealth();
            }
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
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
            SetLastMoveAndSubtractPP(user);
        }

        public Splash() : base(150, "Splash", Type.Normal, 40, 64) { }
    }

    //151
    public sealed class AcidArmor : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.CanStatGoHigher(StatType.Defense))
                user.ModifyStatStageAsPrimaryEffect(StatType.Defense, 2);
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public AcidArmor() : base(151, "Acid Armor", Type.Poison, 40, 64) { }
    }

    //164
    public sealed class Substitute : ReflexiveStatusMove
    {
        protected override sealed void Execute(BattlePokemon user)
        {
            OnUsed();
            float quarterHP = (float)Math.Floor(user.MaxHP / 4f);
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
            SetLastMoveAndSubtractPP(user);
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
            user.RestoreHP(user.MaxHP);
            SetLastMoveAndSubtractPP(user);
        }

        public Rest() : base(156, "Rest", Type.Psychic, 10, 16) { }
    }

    //159
    public sealed class Sharpen : ReflexiveStatusMove
    {
        protected sealed override void Execute(BattlePokemon user)
        {
            OnUsed();
            if (user.CanStatGoHigher(StatType.Attack))
                user.ModifyStatStageAsPrimaryEffect(StatType.Attack, 1);
            else OnFailed();
            SetLastMoveAndSubtractPP(user);
        }

        public Sharpen() : base(159, "Sharpen", Type.Normal, 30, 48) { }
    }
}
