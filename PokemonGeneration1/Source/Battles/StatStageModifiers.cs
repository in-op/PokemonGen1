namespace PokemonGeneration1.Source.Battles
{
    public sealed class StatStageModifiers
    {
        private int attack;
        public int Attack
        { get => attack; private set { attack = value; } }

        private int defense;
        public int Defense
        { get => defense; private set { defense = value; } }

        private int special;
        public int Special
        { get => special; private set { special = value; } }

        private int speed;
        public int Speed
        { get => speed; private set { speed = value; } }

        private int accuracy;
        public int Accuracy
        { get => accuracy; private set { accuracy = value; } }

        private int evasion;
        public int Evasion
        { get => evasion; private set { evasion = value; } }
        


        public bool CanGoHigher(StatType type) =>
            GetModifierForType(type) < 6;

        public bool CanGoLower(StatType type) =>
            GetModifierForType(type) > -6;



        public void Modify(StatType type, int delta)
        {
            ref int stat = ref GetModifierForType(type);
            stat += delta;
            if (stat > 6) stat = 6;
            if (stat < 0) stat = 0;
        }
        


        public void Reset()
        {
            attack = 0;
            defense = 0;
            special = 0;
            speed = 0;
            accuracy = 0;
            evasion = 0;
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
            this.attack = attack;
            this.defense = defense;
            this.special = special;
            this.speed = speed;
            this.accuracy = accuracy;
            this.evasion = evasion;
        }



        private ref int GetModifierForType(StatType type)
        {
            switch (type)
            {
                case StatType.Attack: return ref attack;
                case StatType.Defense: return ref defense;
                case StatType.Special: return ref special;
                case StatType.Speed: return ref speed;
                case StatType.Accuracy: return ref accuracy;
                case StatType.Evasion: return ref evasion;
                default: throw new System.Exception("You changed the StatType enum; update GetRefToModiferOfType");
            }
        }
    }
}
