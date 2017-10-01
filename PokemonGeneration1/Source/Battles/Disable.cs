using PokemonGeneration1.Source.Moves;

namespace PokemonGeneration1.Source.Battles
{
    public class Disable
    {
        private Move DisabledMove;
        private int TurnsLeft;

        public Disable()
        {
            DisabledMove = null;
            TurnsLeft = 0;
        }

        public void Activate(Move move, int turnsLeft)
        {
            DisabledMove = move;
            TurnsLeft = turnsLeft;

            if (TurnsLeft == 0)
            {
                Deactivate();
            }
        }

        public void Deactivate()
        {
            DisabledMove = null;
            TurnsLeft = 0;
        }

        public bool IsActive()
        {
            return DisabledMove != null;
        }

        public Move GetDisabledMove()
        {
            return DisabledMove;
        }

        public void Tick()
        {
            --TurnsLeft;
            if (TurnsLeft == 0)
            {
                DisabledMove = null;
            }
        }
    }
}
