using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.PokemonData
{
    public static class PokemonLearnset
    {

        public static bool CanLearnMoveAtThisLevel(int pokemonIndex, int level)
        {
            int length = AllMovesLearnedAtLevel[pokemonIndex].Length;
            for (int i = 0; i < length; i++)
            {
                if (AllMovesLearnedAtLevel[pokemonIndex][i].Level == level)
                {
                    return true;
                }
            }
            return false;
        }



        public static List<int> GetAllMoveIndicesOfMovesLearnedAtThisLevel(int pokemonIndex, int level)
        {
            List<int> listOfMoves = new List<int>(5);

            int length = AllMovesLearnedAtLevel[pokemonIndex].Length;
            for (int i = 0; i < length; i++)
            {
                if (AllMovesLearnedAtLevel[pokemonIndex][i].Level == level)
                {
                    listOfMoves.Add(AllMovesLearnedAtLevel[pokemonIndex][i].MoveIndex);
                }
            }
            return listOfMoves;
        }

        private static readonly MoveLevelPair[][] AllMovesLearnedAtLevel = new MoveLevelPair[][]
        {
            // 0 - No Pokemon
            new MoveLevelPair[]
            {

            },

            // 1 - Bulbasaur
            new MoveLevelPair[]
            {
                new MoveLevelPair(1, 33),
                new MoveLevelPair(1, 45),
                new MoveLevelPair(7, 73),
                new MoveLevelPair(13, 22),
                new MoveLevelPair(20, 77),
                new MoveLevelPair(27, 75),
                new MoveLevelPair(34, 74),
                new MoveLevelPair(41, 79),
                new MoveLevelPair(48, 76)
            },

            // 2 - Ivysaur
            new MoveLevelPair[]
            {
                new MoveLevelPair(1, 33),
                new MoveLevelPair(1, 45),
                new MoveLevelPair(1, 73),
                new MoveLevelPair(7, 73),
                new MoveLevelPair(13, 22),
                new MoveLevelPair(22, 77),
                new MoveLevelPair(30, 75),
                new MoveLevelPair(38, 74),
                new MoveLevelPair(46, 79),
                new MoveLevelPair(54, 76)
            },

            // 3 - Venusaur
            new MoveLevelPair[]
            {
                new MoveLevelPair(1, 33),
                new MoveLevelPair(1, 45),
                new MoveLevelPair(1, 73),
                new MoveLevelPair(1, 22),
                new MoveLevelPair(7, 73),
                new MoveLevelPair(13, 22),
                new MoveLevelPair(22, 77),
                new MoveLevelPair(30, 75),
                new MoveLevelPair(43, 74),
                new MoveLevelPair(55, 79),
                new MoveLevelPair(65, 76)
            },

            // 4 - Charmander
            new MoveLevelPair[]
            {
                new MoveLevelPair(1, 10),
                new MoveLevelPair(1, 45),
                new MoveLevelPair(9, 52),
                new MoveLevelPair(15, 43),
                new MoveLevelPair(22, 99),
                new MoveLevelPair(30, 163),
                new MoveLevelPair(38, 53),
                new MoveLevelPair(46, 83)
            },

            // 5 - Charmeleon

            // 6 - Charizard
        };





        private struct MoveLevelPair
        {
            public readonly int Level;
            public readonly int MoveIndex;

            public MoveLevelPair(int level, int moveIndex)
            {
                this.Level = level;
                this.MoveIndex = moveIndex;
            }
        }

    }
}
