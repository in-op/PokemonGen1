using PokemonGeneration1.Source.Battles;
using PokemonGeneration1.Source.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PokemonGeneration1.Source.Trainers;
using PokemonGeneration1.Source.Moves;

namespace PokemonGeneration1.Source.ConsoleUI
{
    public static class BattleEventsHandler
    {
        public static void AttachMyBattlePokemonEventHandlers(BattlePokemon myPoke)
        {
            //pokemon events
            myPoke.Burned += MyBurnedEventHandler;
            myPoke.Frozen += MyFrozenEventHandler;
            myPoke.Paralyzed += MyParalyzedEventHandler;
            myPoke.Poisoned += MyPoisonedEventHandler;
            myPoke.BadlyPoisoned += MyBadlyPoisonedEventHandler;
            myPoke.FellAsleep += MyFellAsleepEventHandler;
            myPoke.StatusCleared += MyStatusClearedEventHandler;
            myPoke.Fainted += MyFaintedEventHandler;

            //move events
            myPoke.MoveUsed += MyMoveUsedEventHandler;
            myPoke.MoveFailed += MoveFailedEventHandler;
            myPoke.MoveMissed += MoveMissedEventHandler;
            myPoke.MoveHadNoEffect += MoveHadNoEffectEventHandler;
            myPoke.MoveSuperEffective += MoveSuperEffectiveEventHandler;
            myPoke.MoveNotVeryEffective += MoveNotVeryEffectiveEventHandler;
            myPoke.MoveCriticalHit += MoveCriticalHitEventHandler;
            myPoke.MoveOneHitKO += MoveOneHitKOEventHandler;
            myPoke.PayDayTriggered += PayDayTriggeredEventHandler;
            myPoke.SolarBeamFirstTurn += MySolarBeamFirstTurnEventHandler;
            myPoke.RazorWindFirstTurn += MyRazorWindFirstTurnEventHandler;
            myPoke.BidingTime += MyBidingTimeEventHandler;
            myPoke.BideUnleased += MyBideUnleashedEventHandler;
            myPoke.FlyFirstTurn += MyFlyFirstTurnEventHandler;
            myPoke.AttackContinues += MyAttackContinuesEventHandler;
            myPoke.CrashDamage += MyCrashDamageEventHandler;
            myPoke.HurtByRecoilDamage += MyHurtByRecoilDamageEventHandler;
            myPoke.ThrashingAbout += MyThrashingAboutEventHandler;
            myPoke.HyperBeamRecharging += MyHyperBeamRechargingEventHandler;
            myPoke.SuckedHealth += MySuckedHealthEventHandler;
            myPoke.DugAHole += MyDugAHoleEventHandler;
            myPoke.SkullBashFirstTurn += MySkullBashFirstTurnEventHandler;
            myPoke.SkyAttackFirstTurn += MySkyAttackFirstTurnEventHandler;
            myPoke.RegainedHealth += MyRegainedHealthEventHandler;

            //battlePokemon events
            myPoke.StatStageChanged += MyStatStageChangedEventHandler;
            myPoke.SubstituteActivated += MySubstituteActivatedEventHandler;
            myPoke.ConversionActivated += MyConversionActivatedEventHandler;
            myPoke.TransformActivated += MyTransformActivatedEventHandler;
            myPoke.LeechSeedActivated += MyLeechSeedActivatedEventHandler;
            myPoke.LeechSeedSaps += MyLeechSeedSapsEventHandler;
            myPoke.HurtFromConfusion += HurtFromConfusionEventHandler;
            myPoke.Flinched += MyFlinchedEventHandler;
            myPoke.FullyParalyzed += MyFullyParalyzedEventHandler;
            myPoke.FrozenSolid += MyFrozenSolidEventHandler;
            myPoke.FastAsleep += MyFastAsleepEventHandler;
            myPoke.WokeUp += MyWokeUpEventHandler;
            myPoke.Disabled += MyDisabledEventHandler;
            myPoke.MoveAttemptedButIsDisabled += MyMoveAttemptedButIsDisabledEventHandler;
            myPoke.Mimic += MyMimicEventHandler;
        }
        public static void AttachOpponentBattlePokemonEventHandlers(BattlePokemon enemyPoke)
        {
            //pokemon events
            enemyPoke.Burned += EnemyBurnedEventHandler;
            enemyPoke.Frozen += EnemyFrozenEventHandler;
            enemyPoke.Paralyzed += EnemyParalyzedEventHandler;
            enemyPoke.Poisoned += EnemyPoisonedEventHandler;
            enemyPoke.BadlyPoisoned += EnemyBadlyPoisonedEventHandler;
            enemyPoke.FellAsleep += EnemyFellAsleepEventHandler;
            enemyPoke.StatusCleared += EnemyStatusClearedEventHandler;
            enemyPoke.Fainted += EnemyFaintedEventHandler;

            //move events
            enemyPoke.MoveUsed += EnemyMoveUsedEventHandler;
            enemyPoke.MoveFailed += MoveFailedEventHandler;
            enemyPoke.MoveMissed += MoveMissedEventHandler;
            enemyPoke.MoveHadNoEffect += MoveHadNoEffectEventHandler;
            enemyPoke.MoveSuperEffective += MoveSuperEffectiveEventHandler;
            enemyPoke.MoveNotVeryEffective += MoveNotVeryEffectiveEventHandler;
            enemyPoke.MoveCriticalHit += MoveCriticalHitEventHandler;
            enemyPoke.MoveOneHitKO += MoveOneHitKOEventHandler;
            enemyPoke.PayDayTriggered += PayDayTriggeredEventHandler;
            enemyPoke.SolarBeamFirstTurn += EnemySolarBeamFirstTurnEventHandler;
            enemyPoke.RazorWindFirstTurn += EnemyRazorWindFirstTurnEventHandler;
            enemyPoke.BidingTime += EnemyBidingTimeEventHandler;
            enemyPoke.BideUnleased += EnemyBideUnleashedEventHandler;
            enemyPoke.FlyFirstTurn += EnemyFlyFirstTurnEventHandler;
            enemyPoke.AttackContinues += EnemyAttackContinuesEventHandler;
            enemyPoke.CrashDamage += EnemyCrashDamageEventHandler;
            enemyPoke.HurtByRecoilDamage += EnemyHurtByRecoilDamageEventHandler;
            enemyPoke.ThrashingAbout += EnemyThrashingAboutEventHandler;
            enemyPoke.HyperBeamRecharging += EnemyHyperBeamRechargingEventHandler;
            enemyPoke.SuckedHealth += EnemySuckedHealthEventHandler;
            enemyPoke.DugAHole += EnemyDugAHoleEventHandler;
            enemyPoke.SkullBashFirstTurn += EnemySkullBashFirstTurnEventHandler;
            enemyPoke.SkyAttackFirstTurn += EnemySkyAttackFirstTurnEventHandler;
            enemyPoke.RegainedHealth += EnemyRegainedHealthEventHandler;

            //battlePokemon events
            enemyPoke.StatStageChanged += EnemyStatStageChangedEventHandler;
            enemyPoke.SubstituteActivated += EnemySubstituteActivatedEventHandler;
            enemyPoke.ConversionActivated += EnemyConversionActivatedEventHandler;
            enemyPoke.TransformActivated += EnemyTransformActivatedEventHandler;
            enemyPoke.LeechSeedActivated += EnemyLeechSeedActivatedEventHandler;
            enemyPoke.LeechSeedSaps += EnemyLeechSeedSapsEventHandler;
            enemyPoke.HurtFromConfusion += HurtFromConfusionEventHandler;
            enemyPoke.Flinched += EnemyFlinchedEventHandler;
            enemyPoke.FullyParalyzed += EnemyFullyParalyzedEventHandler;
            enemyPoke.FrozenSolid += EnemyFrozenSolidEventHandler;
            enemyPoke.FastAsleep += EnemyFastAsleepEventHandler;
            enemyPoke.WokeUp += EnemyWokeUpEventHandler;
            enemyPoke.Disabled += EnemyDisabledEventHandler;
            enemyPoke.MoveAttemptedButIsDisabled += EnemyMoveAttemptedButIsDisabledEventHandler;
            enemyPoke.Mimic += EnemyMimicEventHandler;
        }
        public static void AttachBattleEventHandlers(Battle battle)
        {
            battle.BattleBegun += BattleBegunEventHandler;
            battle.BattleOver += BattleOverEventHandler;
            battle.MakingSelections += MakingSelectionsEventHandler;
            battle.FirstExecutionBegun += FirstExecutionBegunHandler;
            battle.FirstExecutionOver += FirstExecutionOverHandler;
            battle.SecondExecutionBegun += SecondExecutionBegunHandler;
            battle.SecondExecutionOver += SecondExecutionOverHandler;
        }




        //===================================================================================//
        //                          BATTLE EVENT HANDLERS                                    //
        //===================================================================================//
        private static void BattleBegunEventHandler(object sender, BattleEventArgs args)
        {
            Console.WriteLine("Battle has begun!");
            Thread.Sleep(2700);
            Console.Clear();
        }
        private static void BattleOverEventHandler(object sender, BattleEventArgs args)
        {
            Console.Clear();
            DisplayPokemon(args);
            Console.WriteLine();
            Console.WriteLine("Battle over!");
            Thread.Sleep(2500);
            if (args.thisBattle.IsPlayerDefeated())
            {
                Console.WriteLine("Player lost!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("You won!");
                Console.WriteLine();
            }
        }
        private static void MakingSelectionsEventHandler(object sender, BattleEventArgs args)
        {
            DisplayPokemon(args);
        }
        private static void FirstExecutionBegunHandler(object sender, BattleEventArgs args)
        {
            Console.Clear();
            DisplayPokemon(args);
        }
        private static void FirstExecutionOverHandler(object sender, BattleEventArgs args)
        {
            Thread.Sleep(2200);
        }
        private static void SecondExecutionBegunHandler(object sender, BattleEventArgs args)
        {
            Console.Clear();
            DisplayPokemon(args);
        }
        private static void SecondExecutionOverHandler(object sender, BattleEventArgs args)
        {
            Thread.Sleep(2200);
        }
        private static void DisplayPokemon(BattleEventArgs args)
        {
            Display.Pokemon(args.thisBattle.GetPlayerSide().GetCurrentBattlePokemon(),
                            args.thisBattle.GetOpponentSide().GetCurrentBattlePokemon(),
                            args.thisBattle.GetPlayerSide().GetName(),
                            args.thisBattle.GetOpponentSide().GetName());
        }
        


        //===================================================================================//
        //                         POKEMON EVENT HANDLERS                                    //
        //===================================================================================//
        private static void MyBurnedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " was burned!");
        }
        private static void EnemyBurnedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " was burned!");
        }
        private static void MyFrozenEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " was frozen!");
        }
        private static void EnemyFrozenEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " was frozen!");
        }
        private static void MyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " was paralyzed!");
        }
        private static void EnemyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " was paralyzed!");
        }
        private static void MyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " was poisoned!");
        }
        private static void EnemyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " was poisoned!");
        }
        private static void MyBadlyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " was badly poisoned!");
        }
        private static void EnemyBadlyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " was badly poisoned!");
        }
        private static void MyFellAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " fell asleep!");
        }
        private static void EnemyFellAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " fell asleep!");
        }
        private static void MyStatusClearedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + "'s status was cleared!");
        }
        private static void EnemyStatusClearedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + "'s status was cleared!");
        }
        private static void MyFaintedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " fainted!");
        }
        private static void EnemyFaintedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " fainted!");
        }
        


        //===================================================================================//
        //                           MOVE EVENT HANDLERS                                     //
        //===================================================================================//
        private static void MyMoveUsedEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine(args.pokemon.Nickname + " used " + args.move.Name + "!");
            Thread.Sleep(1500);
        }
        private static void EnemyMoveUsedEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " used " + args.move.Name + "!");
            Thread.Sleep(1500);
        }
        private static void MoveFailedEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("... but it failed!");
        }
        private static void MoveMissedEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("but it missed!");
        }
        private static void MoveHadNoEffectEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("but it had no effect!");
        }
        private static void MoveSuperEffectiveEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("It's super effective!");
        }
        private static void MoveNotVeryEffectiveEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("It's not very effective!");
        }
        private static void MoveCriticalHitEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Critical hit!");
        }
        private static void MoveOneHitKOEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("One-hit KO!");
        }
        private static void PayDayTriggeredEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Coins scattered everywhere!");
        }
        private static void MySolarBeamFirstTurnEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " took in sunlight!");
        }
        private static void EnemySolarBeamFirstTurnEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " took in sunlight!");
        }
        private static void MyRazorWindFirstTurnEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " made a whirlwind!");
        }
        private static void EnemyRazorWindFirstTurnEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " made a whirlwind!");
        }
        private static void MyBidingTimeEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " is biding its time!");
        }
        private static void EnemyBidingTimeEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " is biding its time!");
        }
        private static void MyBideUnleashedEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " unleased bide!");
        }
        private static void EnemyBideUnleashedEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " unleased bide!");
        }
        private static void MyFlyFirstTurnEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " flew up high!");
        }
        private static void EnemyFlyFirstTurnEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " flew up high!");
        }
        private static void MyAttackContinuesEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + "'s attack continues!");
        }
        private static void EnemyAttackContinuesEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + "'s attack continues!");
        }
        private static void MyCrashDamageEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " was hurt by crash damage!");
        }
        private static void EnemyCrashDamageEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " was hurt by crash damage!");
        }
        private static void MyHurtByRecoilDamageEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " was hurt by recoil damage!");
        }
        private static void EnemyHurtByRecoilDamageEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " was hurt by recoil damage!");
        }
        private static void MyThrashingAboutEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " is thrashing about!");
        }
        private static void EnemyThrashingAboutEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " is thrashing about!");
        }
        private static void MyHyperBeamRechargingEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " is recharging!");
        }
        private static void EnemyHyperBeamRechargingEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " is recharging!");
        }
        private static void MySuckedHealthEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " sucked health!");
        }
        private static void EnemySuckedHealthEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " sucked health!");
        }
        private static void MyDugAHoleEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " dug a hole!");
        }
        private static void EnemyDugAHoleEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " dug a hole!");
        }
        private static void MySkullBashFirstTurnEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " withdrew its head!");
        }
        private static void EnemySkullBashFirstTurnEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " withdrew its head!");
        }
        private static void MySkyAttackFirstTurnEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " is glowing!");
        }
        private static void EnemySkyAttackFirstTurnEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " is glowing!");
        }
        private static void MyRegainedHealthEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " regained health!");
        }
        private static void EnemyRegainedHealthEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " regained health!");
        }



        //===================================================================================//
        //                       BATTLE POKEMON EVENT HANDLERS                               //
        //===================================================================================//
        private static void MyStatStageChangedEventHandler(object sender, Battles.StatStageChangedEventArgs args)
        {
            string stat = args.statChanged.ToString();
            string change;
            if (args.change == 2)
            {
                change = "sharply rose!";
            }
            else if (args.change == 1)
            {
                change = "rose!";
            }
            else if (args.change == -1)
            {
                change = "decreased!";
            }
            else
            {
                change = "sharply decreased!";
            }
            Console.WriteLine(args.pokemon.Nickname + "'s " + stat + " stat " + change);
            Console.WriteLine();
        }
        private static void EnemyStatStageChangedEventHandler(object sender, Battles.StatStageChangedEventArgs args)
        {
            string stat = args.statChanged.ToString();
            string change;
            if (args.change == 2)
            {
                change = "sharply rose!";
            }
            else if (args.change == 1)
            {
                change = "rose!";
            }
            else if (args.change == -1)
            {
                change = "decreased!";
            }
            else
            {
                change = "sharply decreased!";
            }
            Console.WriteLine("Enemy " + args.pokemon.Nickname + "'s " + stat + " stat " + change);
            Console.WriteLine();
        }
        private static void MyLeechSeedActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.GetName() + " was seeded!");
            Console.WriteLine();
        }
        private static void EnemyLeechSeedActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.GetName() + " was seeded!");
            Console.WriteLine();
        }
        private static void MyLeechSeedSapsEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Leech seed saps " + args.pokemon.Nickname);
        }
        private static void EnemyLeechSeedSapsEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Leech seed saps enemy " + args.pokemon.Nickname);
        }
        private static void MySubstituteActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " created a substitute!");
        }
        private static void EnemySubstituteActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " created a substitute!");
        }
        private static void MyConversionActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " changed type!");
        }
        private static void EnemyConversionActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " changed type!");
        }
        private static void MyTransformActivatedEventHandler(object sender, TransformedEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " transformed into " + args.transformInto.GetName() + "!");
        }
        private static void EnemyTransformActivatedEventHandler(object sender, TransformedEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " transformed into " + args.transformInto.GetName() + "!");
        }
        private static void HurtFromConfusionEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("It hurt itself in confusion!");
        }
        private static void MyFlinchedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " flinched!");
        }
        private static void EnemyFlinchedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " flinched!");
        }
        private static void MyFullyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " is fully paralyzed!");
        }
        private static void EnemyFullyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " is fully paralyzed!");
        }
        private static void MyFrozenSolidEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " is frozen solid!");
        }
        private static void EnemyFrozenSolidEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " is frozen solid!");
        }
        private static void MyFastAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " is fast asleep!");
        }
        private static void EnemyFastAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " is fast asleep!");
        }
        private static void MyWokeUpEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " woke up!");
        }
        private static void EnemyWokeUpEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " woke up!");
        }
        private static void MyDisabledEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + "'s " + args.move.Name + " was disabled!");
        }
        private static void EnemyDisabledEventHandler(object sender, Battles.MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + "'s " + args.move.Name + " was disabled!");
        }
        private static void MyMoveAttemptedButIsDisabledEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " is disabled!");
        }
        private static void EnemyMoveAttemptedButIsDisabledEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " is disabled!");
        }
        private static void MyMimicEventHandler(object sender, Battles.MimicMoveEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " copied enemy " + args.opponent.GetName() + "'s " + args.moveMimiced.Name);
        }
        private static void EnemyMimicEventHandler(object sender, Battles.MimicMoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " copied " + args.opponent.GetName() + "'s " + args.moveMimiced.Name);
        }
        

    }
}
