namespace PokemonGeneration1.Source.Battles
{
    public sealed class Substitute
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

    }
}
