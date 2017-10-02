using PokemonGeneration1.Source.Moves.Reflexive;
using PokemonGeneration1.Source.Moves.Transitive.Attack.OneTurnOneHit;
using PokemonGeneration1.Source.Moves.Transitive.Status;
using PokemonGeneration1.Source.PokemonData;
using PokemonGeneration1.Source.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonStadiumConsoleApp
{
    public static class PrimeCupEnemies
    {

        public static Trainer Get(int round, BallTrophy ballTrophy, RoundBattle roundBattle)
        {
            switch (round)
            {
                case 1:
                    switch (ballTrophy)
                    {
                        case BallTrophy.PokeBall:
                            switch (roundBattle)
                            {
                                case RoundBattle.Match1:
                                    return Trainer.Create("Cueball", new List<Pokemon>()
                                    {
                                        Pokemon.Builder.Init(46, 100)
                                            .Nickname("paras")
                                            .Move1(new LeechLife())
                                            .Move2(new StunSpore())
                                            .Move3(new Scratch())
                                            .Move4(new Growth())
                                            .DVs(DVs.Round1PokeBall).Create()
                                    });
                                case RoundBattle.Match2:
                                    break;
                                case RoundBattle.Match3:
                                    break;
                                case RoundBattle.Match4:
                                    break;
                                case RoundBattle.Match5:
                                    break;
                                case RoundBattle.Match6:
                                    break;
                                case RoundBattle.SemiFinals:
                                    break;
                                case RoundBattle.Finals:
                                    break;
                            }
                            break;


                        case BallTrophy.GreatBall:
                            switch (roundBattle)
                            {
                                case RoundBattle.Match1:
                                    break;
                                case RoundBattle.Match2:
                                    break;
                                case RoundBattle.Match3:
                                    break;
                                case RoundBattle.Match4:
                                    break;
                                case RoundBattle.Match5:
                                    break;
                                case RoundBattle.Match6:
                                    break;
                                case RoundBattle.SemiFinals:
                                    break;
                                case RoundBattle.Finals:
                                    break;
                            }
                            break;



                        case BallTrophy.UltraBall:
                            switch (roundBattle)
                            {
                                case RoundBattle.Match1:
                                    break;
                                case RoundBattle.Match2:
                                    break;
                                case RoundBattle.Match3:
                                    break;
                                case RoundBattle.Match4:
                                    break;
                                case RoundBattle.Match5:
                                    break;
                                case RoundBattle.Match6:
                                    break;
                                case RoundBattle.SemiFinals:
                                    break;
                                case RoundBattle.Finals:
                                    break;
                            }
                            break;



                        case BallTrophy.MasterBall:
                            switch (roundBattle)
                            {
                                case RoundBattle.Match1:
                                    break;
                                case RoundBattle.Match2:
                                    break;
                                case RoundBattle.Match3:
                                    break;
                                case RoundBattle.Match4:
                                    break;
                                case RoundBattle.Match5:
                                    break;
                                case RoundBattle.Match6:
                                    break;
                                case RoundBattle.SemiFinals:
                                    break;
                                case RoundBattle.Finals:
                                    break;
                            }
                            break;
                    }
                    break;






                case 2:
                    break;
            }
            return null;
        }
    }
}
