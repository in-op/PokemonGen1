using MonteCarloPlayer;

namespace PokemonGeneration1.Source.Battles
{
    public sealed class Substitute : Copyable<Substitute>
    {
        public bool IsActive { get; private set; }
        public bool BrokeThisTurn { get; private set; }
        public float CurrentHP { get; private set; }
        

        public void Activate(float hp)
        {
            IsActive = true;
            CurrentHP = hp;
        }

        public void Damage(float amount)
        {
            CurrentHP -= amount;
            if (CurrentHP <= 0)
            {
                IsActive = false;
                BrokeThisTurn = true;
            }
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void SetBrokeThisTurnFalse()
        {
            BrokeThisTurn = false;
        }



        public void CopyTo(Substitute other)
        {
            if (IsActive)
            {
                other.BrokeThisTurn = BrokeThisTurn;
                other.CurrentHP = CurrentHP;
            }
            other.IsActive = IsActive;
        }

        public Substitute DeepCopy()
        {
            return new Substitute(IsActive, BrokeThisTurn, CurrentHP);
        }



        public Substitute() { }

        private Substitute(bool isActive, bool brokeThisTurn, float currentHP)
        {
            IsActive = isActive;
            BrokeThisTurn = brokeThisTurn;
            CurrentHP = currentHP;
        }
    }
}
