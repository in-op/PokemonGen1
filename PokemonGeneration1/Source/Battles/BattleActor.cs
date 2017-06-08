using PokemonGeneration1.Source.Moves;

namespace PokemonGeneration1.Source.Battles
{
    public interface BattleActor
    {
        Selection MakeBeginningOfTurnSelection(Battle battle, Side actorSide);
        Selection MakeForcedSwitchSelection(Battle battle, Side actorSide);
        Move PickMoveToMimic(Side opponentSide);
    }
}
