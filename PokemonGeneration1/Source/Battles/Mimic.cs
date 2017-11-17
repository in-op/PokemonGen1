using PokemonGeneration1.Source.Moves;

namespace PokemonGeneration1.Source.Battles
{
    public sealed class Mimic
    {
        public bool Active { get; private set; }
        public Move Move { get; private set; }
        public int MoveIndex { get; private set; }

        public void Activate(Move move, int moveIndex)
        {
            Active = true;
            Move = move;
            MoveIndex = moveIndex;
        }

        public void Deactivate()
        {
            Active = false;
            Move = null;
        }
    }
}
