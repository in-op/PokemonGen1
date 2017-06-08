using PokemonGeneration1.Source.Items;
using PokemonGeneration1.Source.Moves;
using PokemonGeneration1.Source.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Battles
{
    public abstract class Selection
    {
        public abstract void Execute();
        public abstract int GetPriority();

        public static Selection MakeFight(BattlePokemon user, BattlePokemon opponent, Move moveUsed)
        {
            return new Fight(user, opponent, moveUsed);
        }

        public static Selection MakeContinueMultiTurnMove(BattlePokemon user, BattlePokemon opponent)
        {
            return new ContinueMultiTurnMove(user, opponent);
        }

        public static Selection MakeEmptyFight()
        {
            return new EmptyFight();
        }

        public static Selection MakeSwitchOut(BattlePokemon myBattlePokemon,
                                              BattlePokemon opponentBattlePokemon,
                                              Pokemon pokemonToSwitchIn)
        {
            return new SwitchOut(myBattlePokemon, opponentBattlePokemon, pokemonToSwitchIn);
        }
    }

    public sealed class Fight : Selection
    {
        private BattlePokemon user;
        private BattlePokemon opponent;
        private Move moveUsed;
        public Fight(BattlePokemon user, BattlePokemon opponent, Move moveUsed)
        {
            this.user = user;
            this.opponent = opponent;
            this.moveUsed = moveUsed;
        }

        public sealed override void Execute()
        {
            if (!user.IsPartiallyTrapped())
            {
                user.AttemptMoveExecution(moveUsed, opponent);
            }
        }

        public sealed override int GetPriority()
        {
            return moveUsed.GetPriority();
        }
    }

    public sealed class ContinueMultiTurnMove : Selection
    {
        BattlePokemon user;
        BattlePokemon defender;

        public ContinueMultiTurnMove(BattlePokemon user, BattlePokemon defender)
        {
            this.user = user;
            this.defender = defender;
        }
        public sealed override void Execute()
        {
            user.AttemptMoveExecution(user.GetMultiTurnMove(),
                                      defender);
        }
        public sealed override int GetPriority()
        {
            return 0;
        }
    }
    
    public sealed class EmptyFight : Selection
    {
        public sealed override void Execute()
        {
            //do nothing
        }
        public sealed override int GetPriority()
        {
            return 0;
        }
    }

    public sealed class SwitchOut : Selection
    {
        BattlePokemon myBattlePokemon;
        BattlePokemon opponentBattlePokemon;
        Pokemon pokemonToSwitchIn;

        public sealed override void Execute()
        {
            myBattlePokemon.SwitchOut(pokemonToSwitchIn);
            opponentBattlePokemon.SetMirrorMove(null);
        }

        public sealed override int GetPriority()
        {
            return 2;
        }

        public SwitchOut(BattlePokemon myBattlePokemon,
                         BattlePokemon opponentBattlePokemon,
                         Pokemon pokemonToSwitchIn)
        {
            this.myBattlePokemon = myBattlePokemon;
            this.opponentBattlePokemon = opponentBattlePokemon;
            this.pokemonToSwitchIn = pokemonToSwitchIn;
        }
    }
    

}
