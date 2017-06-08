using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Battles
{
    public sealed class Substitute
    {
        private bool Active;
        private bool BrokeThisTurn;
        private float CurrentHP;
        private float MaxHP;

        public bool IsActive() { return this.Active; }
        public bool IsBrokeThisTurn() { return this.BrokeThisTurn; }
        public float GetCurrentHP() { return this.CurrentHP; }
        public float GetMaxHP() { return this.MaxHP; }

        public Substitute()
        {
            this.Active = false;
            this.BrokeThisTurn = false;
            this.CurrentHP = 0f;
            this.MaxHP = 0f;
        }

        public void Activate(float hp)
        {
            this.Active = true;
            this.CurrentHP = hp;
            this.MaxHP = hp;
        }
        
        public void UpdateBrokeThisTurnToFalse()
        {
            this.BrokeThisTurn = false;
        }

        public void Damage(float amount)
        {
            this.CurrentHP -= amount;
            if (this.CurrentHP <= 0)
            {
                this.CurrentHP = 0f;
                this.BrokeThisTurn = true;
                this.Active = false;
                this.MaxHP = 0f;
            }
        }

        public void Deactivate()
        {
            this.Active = false;
            this.BrokeThisTurn = false;
            this.CurrentHP = 0f;
            this.MaxHP = 0f;
        }

    }
}
