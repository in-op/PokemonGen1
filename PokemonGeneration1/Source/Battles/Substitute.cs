namespace PokemonGeneration1.Source.Battles
{
    public sealed class Substitute
    {
        public bool IsActive { get; private set; }
        public bool BrokeThisTurn { get; private set; }
        public float CurrentHP { get; private set; }
        public float MaxHP { get; private set; }
        

        public void Activate(float hp)
        {
            IsActive = true;
            CurrentHP = hp;
            MaxHP = hp;
        }

        public void Damage(float amount)
        {
            CurrentHP -= amount;
            if (CurrentHP <= 0)
            {
                CurrentHP = 0f;
                BrokeThisTurn = true;
                IsActive = false;
                MaxHP = 0f;
            }
        }

        public void Deactivate()
        {
            IsActive = false;
            BrokeThisTurn = false;
            CurrentHP = 0f;
            MaxHP = 0f;
        }

    }
}
