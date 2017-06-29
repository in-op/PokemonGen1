using PokemonGeneration1.Source.Battles;

namespace PokemonGeneration1.Source.Moves
{
    public sealed class Metronome : Move
    {
        public sealed override void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender)
        {
            OnUsed();
            
            Move newMove = MoveFactory.CreateRandomMoveForMetronome();
            user.AttachMoveEventHandlers(newMove);
            newMove.ExecuteAndUpdate(user, defender);
            user.DetachMoveEventHandlers(newMove);

            user.LastMoveUsed = this;
            SubtractPP(1);
        }

        public Metronome() : base(118, "Metronome", Type.Normal, 10, 16, 0, Category.PHYSICAL) { }
    }
}
