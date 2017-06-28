namespace PokemonGeneration1.Source.Battles
{
    public sealed class Conversion
    {
        public bool IsActive { get; private set; }
        public Type Type1 { get; private set; }
        public Type Type2 { get; private set; }
        

        public void Activate(
            BattlePokemon pokemonToConvertInto)
        {
            IsActive = true;
            Type1 = pokemonToConvertInto.GetType1();
            Type2 = pokemonToConvertInto.GetType2();
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
