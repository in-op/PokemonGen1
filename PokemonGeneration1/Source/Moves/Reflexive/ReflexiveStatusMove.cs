using PokemonGeneration1.Source.Battles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Moves.Reflexive
{
    public abstract class ReflexiveStatusMove : Move
    {
        public override sealed void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            Execute(user);
        }
        protected abstract void Execute(BattlePokemon user);

        protected ReflexiveStatusMove(int index, string name, Types type, int startingPP, int absoluteMaxPP)
            : base(index, name, type, startingPP, absoluteMaxPP, 0, Category.STATUS) { }
    }
}
