namespace PokemonGeneration1.Source.Battles
{
    public sealed class StatStageModifiers
    {
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public int Special { get; private set; }
        public int Speed { get; private set; }
        public int Accuracy { get; private set; }
        public int Evasion { get; private set; }



        public bool CanAttackGoHigher => Attack < 6;
        public bool CanDefenseGoHigher => Defense < 6;
        public bool CanSpecialGoHigher => Special < 6;
        public bool CanSpeedGoHigher => Speed < 6;
        public bool CanAccuracyGoHigher => Accuracy < 6;
        public bool CanEvasionGoHigher => Evasion < 6;
        public bool CanAttackGoLower => Attack > -6;
        public bool CanDefenseGoLower => Defense > -6;
        public bool CanSpecialGoLower => Special > -6;
        public bool CanSpeedGoLower => Speed > -6;
        public bool CanAccuracyGoLower => Accuracy > -6;
        public bool CanEvasionGoLower => Evasion > -6;



        public void ModifyAttack(int delta)
        {
            Attack += delta;
            if (Attack > 6) Attack = 6;
            if (Attack < -6) Attack = -6;
        }
        public void ModifyDefense(int delta)
        {
            Defense += delta;
            if (Defense > 6) Defense = 6;
            if (Defense < -6) Defense = -6;
        }
        public void ModifySpecial(int delta)
        {
            Special += delta;
            if (Special > 6) Special = 6;
            if (Special < -6) Special = -6;
        }
        public void ModifySpeed(int delta)
        {
            Speed += delta;
            if (Speed > 6) Speed = 6;
            if (Speed < -6) Speed = -6;
        }
        public void ModifyAccuracy(int delta)
        {
            Accuracy += delta;
            if (Accuracy > 6) Accuracy = 6;
            if (Accuracy < -6) Accuracy = -6;
        }
        public void ModifyEvasion(int delta)
        {
            Evasion += delta;
            if (Evasion > 6) Evasion = 6;
            if (Evasion < -6) Evasion = -6;
        }

        public void Reset()
        {
            Attack = 0;
            Defense = 0;
            Special = 0;
            Speed = 0;
            Accuracy = 0;
            Evasion = 0;
        }

        public StatStageModifiers() { }
        
        public StatStageModifiers(
            int attack,
            int defense,
            int special,
            int speed,
            int accuracy,
            int evasion)
        {
            Attack = attack;
            Defense = defense;
            Special = special;
            Speed = speed;
            Accuracy = accuracy;
            Evasion = evasion;
        }
    }
}
