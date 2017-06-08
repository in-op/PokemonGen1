using System;

namespace PokemonGeneration1.Source.Battles
{
    public class Bide
    {
        public bool Active { get; private set; }
        public int TurnsLeft { get; private set; }
        public float DamageAccrued { get; private set; }
        

        public void Activate()
        {
            Active = true;
            TurnsLeft = new Random().Next(3, 5);
        }

        public void Deactivate()
        {
            Active = false;
            TurnsLeft = 0;
            DamageAccrued = 0;
        }

        public void Tick()
        {
            if (TurnsLeft > 0) --TurnsLeft;
        }

        public void Damage(float amount)
        {
            DamageAccrued += amount;
        }
    }
}
