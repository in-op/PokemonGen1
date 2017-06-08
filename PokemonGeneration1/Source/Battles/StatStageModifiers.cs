using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Battles
{
    public sealed class StatStageModifiers
    {
        private int Attack;
        private int Defense;
        private int Special;
        private int Speed;
        private int Accuracy;
        private int Evasion;



        public int GetAttack() { return this.Attack; }
        public int GetDefense() { return this.Defense; }
        public int GetSpecial() { return this.Special; }
        public int GetSpeed() { return this.Speed; }
        public int GetAccuracy() { return this.Accuracy; }
        public int GetEvasion() { return this.Evasion; }



        public bool CanAttackGoHigher() { return (this.Attack < 6); }
        public bool CanDefenseGoHigher() { return (this.Defense < 6); }
        public bool CanSpecialGoHigher() { return (this.Special < 6); }
        public bool CanSpeedGoHigher() { return (this.Speed < 6); }
        public bool CanAccuracyGoHigher() { return (this.Accuracy < 6); }
        public bool CanEvasionGoHigher() { return (this.Evasion < 6); }
        public bool CanAttackGoLower() { return (this.Attack > -6); }
        public bool CanDefenseGoLower() { return (this.Defense > -6); }
        public bool CanSpecialGoLower() { return (this.Special > -6); }
        public bool CanSpeedGoLower() { return (this.Speed > -6); }
        public bool CanAccuracyGoLower() { return (this.Accuracy > -6); }
        public bool CanEvasionGoLower() { return (this.Evasion > -6); }



        public void ModifyAttack(int delta)
        {
            this.Attack += delta;
            if (this.Attack > 6) { this.Attack = 6; }
            if (this.Attack < -6) { this.Attack = -6; }
        }
        public void ModifyDefense(int delta)
        {
            this.Defense += delta;
            if (this.Defense > 6) { this.Defense = 6; }
            if (this.Defense < -6) { this.Defense = -6; }
        }
        public void ModifySpecial(int delta)
        {
            this.Special += delta;
            if (this.Special > 6) { this.Special = 6; }
            if (this.Special < -6) { this.Special = -6; }
        }
        public void ModifySpeed(int delta)
        {
            this.Speed += delta;
            if (this.Speed > 6) { this.Speed = 6; }
            if (this.Speed < -6) { this.Speed = -6; }
        }
        public void ModifyAccuracy(int delta)
        {
            this.Accuracy += delta;
            if (this.Accuracy > 6) { this.Accuracy = 6; }
            if (this.Accuracy < -6) { this.Accuracy = -6; }
        }
        public void ModifyEvasion(int delta)
        {
            this.Evasion += delta;
            if (this.Evasion > 6) { this.Evasion = 6; }
            if (this.Evasion < -6) { this.Evasion = -6; }
        }

        public void Reset()
        {
            this.Attack = 0;
            this.Defense = 0;
            this.Special = 0;
            this.Speed = 0;
            this.Accuracy = 0;
            this.Evasion = 0;
        }



        public StatStageModifiers()
        {
            this.Attack = 0;
            this.Defense = 0;
            this.Special = 0;
            this.Speed = 0;
            this.Accuracy = 0;
            this.Evasion = 0;
        }
        public StatStageModifiers(int attack, int defense, int special, int speed, int accuracy, int evasion)
        {
            this.Attack = attack;
            this.Defense = defense;
            this.Special = special;
            this.Speed = speed;
            this.Accuracy = accuracy;
            this.Evasion = evasion;
        }
    }
}
