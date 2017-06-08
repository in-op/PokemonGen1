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
        private Types Type1;
        private Types Type2;

        public bool IsActive() { return this.Active; }
        public Types GetType1() { return this.Type1; }
        public Types GetType2() { return this.Type2; }

        public static Conversion GenerateBlankConversion()
        {
            return new Conversion(Types.NONE, Types.NONE);
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
            this.Type1 = Types.NONE;
            this.Type2 = Types.NONE;
        }

        private Conversion(Types type1, Types type2)
        {
            this.Active = false;
            this.Type1 = type1;
            this.Type2 = type2;
        }
    }
}
