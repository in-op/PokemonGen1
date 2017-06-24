using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Battles
{
    public sealed class Conversion
    {
        private bool Active;
        private Type Type1;
        private Type Type2;

        public bool IsActive() { return this.Active; }
        public Type GetType1() { return this.Type1; }
        public Type GetType2() { return this.Type2; }

        public static Conversion GenerateBlankConversion()
        {
            return new Conversion(Type.Null, Type.Null);
        }

        public void Activate(BattlePokemon pokemonToConvertInto)
        {
            this.Active = true;
            this.Type1 = pokemonToConvertInto.GetType1();
            this.Type2 = pokemonToConvertInto.GetType2();
        }

        public void Deactivate()
        {
            this.Active = false;
            this.Type1 = Type.Null;
            this.Type2 = Type.Null;
        }

        private Conversion(Type type1, Type type2)
        {
            this.Active = false;
            this.Type1 = type1;
            this.Type2 = type2;
        }
    }
}
