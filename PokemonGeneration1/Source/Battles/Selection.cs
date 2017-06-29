using PokemonGeneration1.Source.Moves;
using PokemonGeneration1.Source.PokemonData;

namespace PokemonGeneration1.Source.Battles
{
    public abstract class Selection
    {

        public abstract int Priority { get; }
        public abstract void Execute();



        public static Selection MakeFight(
            BattlePokemon user,
            BattlePokemon opponent,
            Move move)
        {
            return new Fight(user, opponent, move);
        }

        public static Selection MakeContinueMultiTurnMove(
            BattlePokemon user,
            BattlePokemon opponent)
        {
            return new ContinueMultiTurnMove(user, opponent);
        }

        public static Selection MakeEmptyFight()
        {
            return new EmptyFight();
        }

        public static Selection MakeSwitchOut(
            BattlePokemon myBattlePokemon,
            BattlePokemon opponentBattlePokemon,
            Pokemon pokemonToSwitchIn)
        {
            return new SwitchOut(
                myBattlePokemon,
                opponentBattlePokemon,
                pokemonToSwitchIn);
        }





        private sealed class Fight : Selection
        {
            private BattlePokemon user;
            private BattlePokemon opponent;
            private Move moveUsed;

            public Fight(
                BattlePokemon user,
                BattlePokemon opponent,
                Move moveUsed)
            {
                this.user = user;
                this.opponent = opponent;
                this.moveUsed = moveUsed;
            }

            public sealed override void Execute()
            {
                if (!user.PartiallyTrapped)
                    user.AttemptMoveExecution(moveUsed, opponent);
            }

            public sealed override int Priority => moveUsed.Priority;
        }




        private sealed class ContinueMultiTurnMove : Selection
        {
            private BattlePokemon user;
            private BattlePokemon defender;

            public ContinueMultiTurnMove(
                BattlePokemon user,
                BattlePokemon defender)
            {
                this.user = user;
                this.defender = defender;
            }
            public sealed override void Execute()
            {
                user.AttemptMoveExecution(
                    user.GetMultiTurnMove(),
                    defender);
            }

            public sealed override int Priority => 0;
        }




        private sealed class EmptyFight : Selection
        {
            public sealed override void Execute() { /* do nothing */ }
            public sealed override int Priority => 0;
        }




        private sealed class SwitchOut : Selection
        {
            BattlePokemon myBattlePokemon;
            BattlePokemon opponentBattlePokemon;
            Pokemon pokemonToSwitchIn;

            public sealed override void Execute()
            {
                myBattlePokemon.SwitchOut(pokemonToSwitchIn);
                opponentBattlePokemon.MirrorMove = null;
            }

            public sealed override int Priority => 2;

            public SwitchOut(
                BattlePokemon myBattlePokemon,
                BattlePokemon opponentBattlePokemon,
                Pokemon pokemonToSwitchIn)
            {
                this.myBattlePokemon = myBattlePokemon;
                this.opponentBattlePokemon = opponentBattlePokemon;
                this.pokemonToSwitchIn = pokemonToSwitchIn;
            }
        }




    }
}
