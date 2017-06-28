using PokemonGeneration1.Source.Battles;

namespace PokemonGeneration1.Source.Moves.Reflexive
{
    public abstract class ReflexiveStatusMove : Move
    {
        public override sealed void ExecuteAndUpdate(
            BattlePokemon user, BattlePokemon defender)
        {
            Execute(user);
        }

        protected abstract void Execute(BattlePokemon user);
        
        protected void SetLastMoveAndSubtractPP(BattlePokemon user)
        {
            user.LastMoveUsed = this;
            SubtractPP(1);
        }
        
        protected ReflexiveStatusMove(int index, string name, Type type, int startingPP, int absoluteMaxPP)
            : base(index, name, type, startingPP, absoluteMaxPP, 0, Category.STATUS) { }
    }
}
