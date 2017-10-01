using PokemonGeneration1.Source.Battles;
using System;

namespace PokemonGeneration1.Source.Moves.Transitive.Attack.MultiTurn
{

    //13
    public sealed class RazorWind : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            switch (this.TurnsLeft)
            {
                case 0:
                    OnRazorWindFirstTurn();
                    user.ActivateTwoTurnMove(this);
                    this.TurnsLeft = 1;
                    break;

                case 1:
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
                    user.DeactivateTwoTurnMove();
                    this.TurnsLeft = 0;
                    SetLastMoveAndMirrorMove(user, defender);
                    SubtractPP(1);
                    break;
            }
        }

        public RazorWind() : base(13, "Razor Wind", Type.Normal, 10, 16, 75f, 80f, Category.PHYSICAL) { }
    }



    //19
    public sealed class Fly : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            switch (this.TurnsLeft)
            {
                case 0:
                    OnFlyFirstTurn();
                    user.ActivateSemiInvulnerable();
                    user.ActivateTwoTurnMove(this);
                    this.TurnsLeft = 1;
                    break;
                case 1:
                    OnUsed();
                    if (IsAMiss(user, defender))
                    {
                        OnMissed();
                    }
                    else
                    {
                        UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                    }
                    user.DeactivateSemiInvulnerable();
                    user.DeactivateTwoTurnMove();
                    SetLastMoveAndMirrorMove(user, defender);
                    this.TurnsLeft = 0;
                    SubtractPP(1);
                    break;
            }
        }

        public Fly() : base(19, "Fly", Type.Flying, 15, 24, 95f, 90f, Category.PHYSICAL) { }
    }



    //20
    public sealed class Bind : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            ExecuteBindingMove(user, defender);
        }

        public Bind() : base(20, "Bind", Type.Normal, 20, 32, 85f, 15f, Category.PHYSICAL) { }
    }


    //35
    public sealed class Wrap : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            ExecuteBindingMove(user, defender);
        }

        public Wrap() : base(35, "Wrap", Type.Normal, 20, 32, 90f, 15f, Category.PHYSICAL) { }
    }

    //37
    public sealed class Thrash : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            if (TurnsLeft == 0)
            {
                OnUsed();
                TurnsLeft = new Random().Next(3, 5);
                user.ActivateMultiTurnMove(this);

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
                SubtractPP(1);
                SetLastMoveAndMirrorMove(user, defender);
            }
            else
            {
                OnThrashingAbout();

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

                if (TurnsLeft == 1)
                {
                    user.DeactivateMultiTurnMove();
                    user.Confuse();
                }
            }
            --TurnsLeft;
        }
        public sealed override void IfActiveDisruptThrashingMove(BattlePokemon user)
        {
            TurnsLeft = 0;
            user.DeactivateMultiTurnMove();
        }

        public Thrash() : base(37, "Thrash", Type.Normal, 20, 32, 100f, 90f, Category.PHYSICAL) { }
    }


    //63
    public sealed class HyperBeam : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            switch (this.TurnsLeft)
            {
                case 0:
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

                        if (!defender.DidSubstituteBreakThisTurn() &&
                            !defender.IsFainted)
                        {
                            user.ActivateTwoTurnMove(this);
                            this.TurnsLeft = 1;
                        }
                    }
                    SetLastMoveAndMirrorMove(user, defender);
                    SubtractPP(1);
                    break;
                case 1:
                    OnHyperBeamRecharging();
                    this.TurnsLeft = 0;
                    user.DeactivateTwoTurnMove();
                    break;
            }
        }

        public HyperBeam() : base(63, "Hyper Beam", Type.Normal, 5, 8, 90f, 150f, Category.PHYSICAL) { }
    }



    //76
    public sealed class SolarBeam : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            switch (this.TurnsLeft)
            {
                case 0:
                    OnSolarBeamFirstTurn();
                    user.ActivateTwoTurnMove(this);
                    this.TurnsLeft = 1;
                    break;
                case 1:
                    OnUsed();
                    if (IsAMiss(user, defender))
                    {
                        OnMissed();
                    }
                    else
                    {
                        UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                    }
                    this.TurnsLeft = 0;
                    user.DeactivateTwoTurnMove();
                    SetLastMoveAndMirrorMove(user, defender);
                    SubtractPP(1);
                    break;
            }
        }

        public SolarBeam() : base(76, "Solar Beam", Type.Grass, 10, 16, 100f, 120f, Category.SPECIAL) { }
    }

    //80
    public sealed class PetalDance : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            if (TurnsLeft == 0)
            {
                OnUsed();
                TurnsLeft = new Random().Next(3, 5);
                user.ActivateMultiTurnMove(this);

                if (IsAMiss(user, defender))
                {
                    OnMissed();
                }
                else
                {
                    UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                }
                SubtractPP(1);
                SetLastMoveAndMirrorMove(user, defender);
            }
            else
            {
                OnThrashingAbout();

                if (IsAMiss(user, defender))
                {
                    OnMissed();
                }
                else
                {
                    UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                }

                if (TurnsLeft == 1)
                {
                    user.DeactivateMultiTurnMove();
                    user.Confuse();
                }
            }
            --TurnsLeft;
        }
        public sealed override void IfActiveDisruptThrashingMove(BattlePokemon user)
        {
            TurnsLeft = 0;
            user.DeactivateMultiTurnMove();
        }

        public PetalDance() : base(80, "Petal Dance", Type.Grass, 20, 32, 100f, 70f, Category.SPECIAL) { }
    }

    //83
    public sealed class FireSpin : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            ExecuteBindingMove(user, defender);
        }

        public FireSpin() : base(83, "Fire Spin", Type.Fire, 15, 24, 70f, 15f, Category.SPECIAL) { }
    }

    //91
    public sealed class Dig : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            switch (this.TurnsLeft)
            {
                case 0:
                    OnDugAHole();
                    user.ActivateSemiInvulnerable();
                    user.ActivateTwoTurnMove(this);
                    this.TurnsLeft = 1;
                    SetLastMoveAndMirrorMove(user, defender);
                    SubtractPP(1);
                    break;
                case 1:
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
                    user.DeactivateSemiInvulnerable();
                    user.DeactivateTwoTurnMove();
                    this.TurnsLeft = 0;
                    break;
            }
        }

        public Dig() : base(91, "Dig", Type.Ground, 10, 16, 100f, 80f, Category.PHYSICAL) { }
    }

    //99
    public sealed class Rage : MultiTurnAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            switch (this.TurnsLeft)
            {
                case 0:
                    if (IsAMiss(user, defender))
                    {
                        OnMissed();
                    }
                    else
                    {
                        this.TurnsLeft = 1;
                        user.ActivateMultiTurnMove(this);

                        if (HasNoEffect(defender)) //in which case, yer fucked
                        {
                            OnNoEffect();
                        }
                        else
                        {
                            UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                        }
                    }
                    SubtractPP(1);
                    break;

                case 1:
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
                    break;
            }
            SetLastMoveAndMirrorMove(user, defender);
        }

        public Rage() : base(99, "Rage", Type.Normal, 20, 32, 100f, 20f, Category.PHYSICAL) { }
    }


    //117
    public sealed class Bide : MultiTurnAttackMove
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            //CASE 0: execute first turn
            if (!user.IsBideActive())
            {
                OnUsed();
                user.ActivateBide();
                user.ActivateMultiTurnMove(this);
                SubtractPP(1);
            }

            //CASE 1: execute damage turn
            else if (user.TurnsLeftOfBide() == 1)
            {
                OnBideUnleased();
                defender.Damage(2 * user.GetBideDamage(), this.Type);
                user.DeactivateBide();
                user.DeactivateMultiTurnMove();
            }

            //CASE 2: biding time
            else
            {
                OnBidingTime();
                user.TickBide();
            }
            SetLastMoveAndMirrorMove(user, defender);
        }

        public Bide() : base(117, "Bide", Type.Normal, 10, 16, 100f, 0f, Category.PHYSICAL)  { }
    }


    //128
    public sealed class Clamp : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            ExecuteBindingMove(user, defender);
        }

        public Clamp() : base(128, "Clamp", Type.Water, 15, 24, 85f, 35f, Category.SPECIAL) { }
    }


    //130
    public sealed class SkullBash : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            switch (this.TurnsLeft)
            {
                case 0:
                    OnSkullBashFirstTurn();
                    user.ActivateTwoTurnMove(this);
                    this.TurnsLeft = 1;
                    break;

                case 1:
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
                    user.DeactivateTwoTurnMove();
                    this.TurnsLeft = 0;
                    SetLastMoveAndMirrorMove(user, defender);
                    SubtractPP(1);
                    break;
            }
        }

        public SkullBash() : base(130, "Skull Bash", Type.Normal, 10, 16, 100f, 130f, Category.PHYSICAL) { }
    }


    //143
    public sealed class SkyAttack : MultiTurnAttackMove
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            switch (this.TurnsLeft)
            {
                case 0:
                    OnSkyAttackFirstTurn();
                    user.ActivateTwoTurnMove(this);
                    this.TurnsLeft = 1;
                    break;

                case 1:
                    OnUsed();
                    if (IsAMiss(user, defender))
                    {
                        OnMissed();
                    }
                    else
                    {
                        UpdateEffectivenessUpdateCritFlagAndDoDamage(user, defender);
                    }
                    user.DeactivateTwoTurnMove();
                    this.TurnsLeft = 0;
                    SetLastMoveAndMirrorMove(user, defender);
                    SubtractPP(1);
                    break;
            }
        }

        public SkyAttack() : base(143, "Sky Attack", Type.Flying, 5, 8, 90f, 140f, Category.PHYSICAL) { }
    }




}
