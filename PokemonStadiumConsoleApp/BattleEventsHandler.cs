using PokemonGeneration1.Source.Battles;
using System;
using System.Threading;

namespace PokemonStadiumConsoleApp
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
            myPoke.SwitchedOut += MySwitchedOutEventHandler;
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
            enemyPoke.SwitchedOut += EnemySwitchedOutEventHandler;
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
            if (args.thisBattle.IsPlayerDefeated)
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
            Display.Pokemon(args.thisBattle.PlayerSide.CurrentBattlePokemon,
                            args.thisBattle.OpponentSide.CurrentBattlePokemon,
                            args.thisBattle.PlayerSide.Name,
                            args.thisBattle.OpponentSide.Name);
        }
        


        //===================================================================================//
        //                         POKEMON EVENT HANDLERS                                    //
        //===================================================================================//
        private static void MyBurnedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " was burned!");
        }
        private static void EnemyBurnedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " was burned!");
        }
        private static void MyFrozenEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " was frozen!");
        }
        private static void EnemyFrozenEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " was frozen!");
        }
        private static void MyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " was paralyzed!");
        }
        private static void EnemyParalyzedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " was paralyzed!");
        }
        private static void MyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " was poisoned!");
        }
        private static void EnemyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " was poisoned!");
        }
        private static void MyBadlyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " was badly poisoned!");
        }
        private static void EnemyBadlyPoisonedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " was badly poisoned!");
        }
        private static void MyFellAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " fell asleep!");
        }
        private static void EnemyFellAsleepEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " fell asleep!");
        }
        private static void MyStatusClearedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + "'s status was cleared!");
        }
        private static void EnemyStatusClearedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + "'s status was cleared!");
        }
        private static void MyFaintedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " fainted!");
        }
        private static void EnemyFaintedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " fainted!");
        }
        


        //===================================================================================//
        //                           MOVE EVENT HANDLERS                                     //
        //===================================================================================//
        private static void MyMoveUsedEventHandler(MoveEventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine(args.pokemon.Nickname + " used " + args.move.Name + "!");
            Thread.Sleep(1500);
        }
        private static void EnemyMoveUsedEventHandler(MoveEventArgs args)
        {
            Console.WriteLine();
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " used " + args.move.Name + "!");
            Thread.Sleep(1500);
        }
        private static void MoveFailedEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("... but it failed!");
        }
        private static void MoveMissedEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("but it missed!");
        }
        private static void MoveHadNoEffectEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("but it had no effect!");
        }
        private static void MoveSuperEffectiveEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("It's super effective!");
        }
        private static void MoveNotVeryEffectiveEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("It's not very effective!");
        }
        private static void MoveCriticalHitEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Critical hit!");
        }
        private static void MoveOneHitKOEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("One-hit KO!");
        }
        private static void PayDayTriggeredEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Coins scattered everywhere!");
        }
        private static void MySolarBeamFirstTurnEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " took in sunlight!");
        }
        private static void EnemySolarBeamFirstTurnEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " took in sunlight!");
        }
        private static void MyRazorWindFirstTurnEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " made a whirlwind!");
        }
        private static void EnemyRazorWindFirstTurnEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " made a whirlwind!");
        }
        private static void MyBidingTimeEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " is biding its time!");
        }
        private static void EnemyBidingTimeEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " is biding its time!");
        }
        private static void MyBideUnleashedEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " unleased bide!");
        }
        private static void EnemyBideUnleashedEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " unleased bide!");
        }
        private static void MyFlyFirstTurnEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " flew up high!");
        }
        private static void EnemyFlyFirstTurnEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " flew up high!");
        }
        private static void MyAttackContinuesEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + "'s attack continues!");
        }
        private static void EnemyAttackContinuesEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + "'s attack continues!");
        }
        private static void MyCrashDamageEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " was hurt by crash damage!");
        }
        private static void EnemyCrashDamageEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " was hurt by crash damage!");
        }
        private static void MyHurtByRecoilDamageEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " was hurt by recoil damage!");
        }
        private static void EnemyHurtByRecoilDamageEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " was hurt by recoil damage!");
        }
        private static void MyThrashingAboutEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " is thrashing about!");
        }
        private static void EnemyThrashingAboutEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " is thrashing about!");
        }
        private static void MyHyperBeamRechargingEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " is recharging!");
        }
        private static void EnemyHyperBeamRechargingEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " is recharging!");
        }
        private static void MySuckedHealthEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " sucked health!");
        }
        private static void EnemySuckedHealthEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " sucked health!");
        }
        private static void MyDugAHoleEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " dug a hole!");
        }
        private static void EnemyDugAHoleEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " dug a hole!");
        }
        private static void MySkullBashFirstTurnEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " withdrew its head!");
        }
        private static void EnemySkullBashFirstTurnEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " withdrew its head!");
        }
        private static void MySkyAttackFirstTurnEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " is glowing!");
        }
        private static void EnemySkyAttackFirstTurnEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " is glowing!");
        }
        private static void MyRegainedHealthEventHandler(MoveEventArgs args)
        {
            Console.WriteLine(args.battlePokemon.Name + " regained health!");
        }
        private static void EnemyRegainedHealthEventHandler(MoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " regained health!");
        }



        //===================================================================================//
        //                       BATTLE POKEMON EVENT HANDLERS                               //
        //===================================================================================//
        private static void MySwitchedOutEventHandler(object sender, SwitchedOutEventArgs args)
        {
            Console.WriteLine("Come back " + args.pokemon.Nickname + "!");
            Thread.Sleep(2200);
            Console.WriteLine("Go " + args.switchIn.Nickname + "!");
            Thread.Sleep(2200);
        }
        private static void EnemySwitchedOutEventHandler(object sender, SwitchedOutEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " was withdrawn!");
            Thread.Sleep(2200);
            Console.WriteLine("Go " + args.switchIn.Nickname + "!");
            Thread.Sleep(2200);
        }
        private static void MyStatStageChangedEventHandler(object sender, PokemonGeneration1.Source.Battles.StatStageChangedEventArgs args)
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
        private static void EnemyStatStageChangedEventHandler(object sender, PokemonGeneration1.Source.Battles.StatStageChangedEventArgs args)
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
            Console.WriteLine(args.battlePokemon.Name + " was seeded!");
            Console.WriteLine();
        }
        private static void EnemyLeechSeedActivatedEventHandler(object sender, BattlePokemonEventArgs args)
        {
            Console.WriteLine("Enemy " + args.battlePokemon.Name + " was seeded!");
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
            Console.WriteLine(args.pokemon.Nickname + " transformed into " + args.transformInto.Name + "!");
        }
        private static void EnemyTransformActivatedEventHandler(object sender, TransformedEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " transformed into " + args.transformInto.Name + "!");
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
        private static void MyDisabledEventHandler(object sender, MoveEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + "'s " + args.move.Name + " was disabled!");
        }
        private static void EnemyDisabledEventHandler(object sender, MoveEventArgs args)
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
        private static void MyMimicEventHandler(object sender, PokemonGeneration1.Source.Battles.MimicMoveEventArgs args)
        {
            Console.WriteLine(args.pokemon.Nickname + " copied enemy " + args.opponent.Name + "'s " + args.moveMimiced.Name);
        }
        private static void EnemyMimicEventHandler(object sender, PokemonGeneration1.Source.Battles.MimicMoveEventArgs args)
        {
            Console.WriteLine("Enemy " + args.pokemon.Nickname + " copied " + args.opponent.Name + "'s " + args.moveMimiced.Name);
        }
        

    }
}
