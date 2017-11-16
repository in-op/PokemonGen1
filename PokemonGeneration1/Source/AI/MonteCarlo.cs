using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.AI
{
    public static class MonteCarlo<TGame, TMove, TPlayer>
        where TGame : MonteCarlo<TGame, TMove, TPlayer>.Game
    {
        public static TMove Simultaneous(int iterations, TGame game, TPlayer npc)
        {
            Random rng = new Random();
            LegalMoves moves = game.LegalMoves(npc);
            int playerMoveCount = moves.player.Count;
            int enemyMoveCount = moves.enemy.Count;
            int[] wins = new int[playerMoveCount];

            //perform once on a fresh copy
            TGame copy = game.DeepCopy();
            int randomPlayerIndex = rng.Next(playerMoveCount);
            int randomEnemyIndex = rng.Next(enemyMoveCount);
            copy.DoMove(
                npc,
                moves.player[randomPlayerIndex],
                moves.enemy[randomEnemyIndex]);
            copy.Playout();
            if (copy.IsVictor(npc))
                ++wins[randomPlayerIndex];

            //perform rest on the same copy
            for (int i = 1; i < iterations; i++)
            {
                copy.CopyFrom(game);
                randomPlayerIndex = rng.Next(playerMoveCount);
                randomEnemyIndex = rng.Next(enemyMoveCount);
                copy.DoMove(
                    npc,
                    moves.player[randomPlayerIndex],
                    moves.enemy[randomEnemyIndex]);
                copy.Playout();
                if (copy.IsVictor(npc))
                    ++wins[randomPlayerIndex];
            }

            double score;
            int bestIndex = 0;
            double bestScore = double.MinValue;
            for (int i = 0; i < playerMoveCount; i++)
            {
                score = wins[i] / iterations;
                if (score > bestScore)
                {
                    bestScore = score;
                    bestIndex = i;
                }
            }
            return moves.player[bestIndex];
        }

        public interface Game
        {
            TGame DeepCopy();
            void CopyFrom(TGame game);
            LegalMoves LegalMoves(TPlayer player);
            void DoMove(TPlayer player, TMove playerMove, TMove enemyMove);
            void Playout();
            bool IsVictor(TPlayer player);
        }

        public struct LegalMoves
        {
            public readonly List<TMove> player;
            public readonly List<TMove> enemy;

            public LegalMoves(List<TMove> player, List<TMove> enemy)
            {
                this.player = player;
                this.enemy = enemy;
            }
        }
    }
}
