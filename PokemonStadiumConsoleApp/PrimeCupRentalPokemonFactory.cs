using PokemonGeneration1.Source.Moves;
using PokemonGeneration1.Source.Moves.Reflexive;
using PokemonGeneration1.Source.Moves.Transitive.Attack.MultiTurn;
using PokemonGeneration1.Source.Moves.Transitive.Attack.OneTurnMultiHit;
using PokemonGeneration1.Source.Moves.Transitive.Attack.OneTurnOneHit;
using PokemonGeneration1.Source.Moves.Transitive.Status;
using PokemonGeneration1.Source.PokemonData;
using System;

namespace PokemonStadiumConsoleApp
{
    public static class PrimeCupRentalPokemonFactory
    {
        private static Pokemon Create(int number, float level, Move move1, Move move2, Move move3, Move move4)
        {
            return Pokemon.GenPreMade(number, level, move1, move2, move3, move4, DVs.Rental);
        }

        public static Pokemon Create(int index)
        {
            switch (index)
            {
                case 1: // Bulbasaur
                    return Create(1, 100, new RazorLeaf(), new LeechSeed(), new BodySlam(), new Growth());

                case 2: // Ivysaur
                    return Create(2, 100, new LeechSeed(), new RazorLeaf(), new Growth(), new MegaDrain());

                case 3: // Venusaur
                    return Create(3, 100, new Growth(), new LeechSeed(), new SolarBeam(), new SleepPowder());

                case 4: // Charmander
                    return Create(4, 100, new SeismicToss(), new Flamethrower(), new Dig(), new BodySlam());

                case 5: // Charmeleon
                    return Create(5, 100, new Slash(), new Flamethrower(), new Dig(), new Submission());

                case 6: // Charizard
                    return Create(6, 100, new FireBlast(), new Fly(), new FireSpin(), new SwordsDance());

                case 7: // Squirtle
                    return Create(7, 100, new Dig(), new Surf(), new BodySlam(), new Blizzard());

                case 8: // Wartortle
                    return Create(8, 100, new SeismicToss(), new Surf(), new Toxic(), new Dig());

                case 9: // Blastoise
                    return Create(9, 100, new TailWhip(), new HydroPump(), new Withdraw(), new SkullBash());

                case 10: // Caterpie
                    return Create(10, 100, new StringShot(), new Tackle(), null, null);

                case 11: // Metapod
                    return Create(11, 100, new StringShot(), new Tackle(), null, null);

                case 12: // Butterfree
                    return Create(12, 100, new StunSpore(), new Psychic(), new MegaDrain(), new Swift());

                case 13: // Weedle
                    return Create(13, 100, new StringShot(), new PoisonSting(), null, null);

                case 14: // Kakuna
                    return Create(14, 100, new StringShot(), new PoisonSting(), null, null);

                case 15: // Beedrill
                    return Create(15, 100, new FocusEnergy(), new Twineedle(), new MegaDrain(), new HyperBeam());

                case 16: // Pidgey
                    return Create(16, 100, new Tackle(), new Fly(), new SandAttack(), new MirrorMove());

                case 17: // Pidgeotto
                    return Create(17, 100, new Swift(), new Fly(), new SandAttack(), new Toxic());

                case 18: // Pidgeot
                    return Create(18, 100, new SandAttack(), new MirrorMove(), new QuickAttack(), new Fly());

                case 19: // Rattata
                    return Create(19, 100, new Dig(), new SuperFang(), new BodySlam(), new Toxic());

                case 20: // Raticate
                    return Create(20, 100, new Toxic(), new HyperFang(), new QuickAttack(), new SuperFang());

                case 21: // Spearow
                    return Create(21, 100, new Swift(), new DrillPeck(), new DoubleTeam(), new Fly());

                case 22: // Fearow
                    return Create(22, 100, new Growl(), new DrillPeck(), new HyperBeam(), new MirrorMove());

                case 23: // Ekans
                    return Create(23, 100, new DoubleEdge(), new Earthquake(), new Glare(), new MegaDrain());

                case 24: // Arbok
                    return Create(24, 100, new Strength(), new Glare(), new Dig(), new Acid());

                case 25: // Pikachu
                    return Create(25, 100, new Reflect(), new Thunderbolt(), new ThunderWave(), new Swift());

                case 26: // Raichu
                    return Create(26, 100, new MegaKick(), new Thunder(), new QuickAttack(), new ThunderWave());

                case 27: // Sandshrew
                    return Create(27, 100, new SandAttack(), new Earthquake(), new RockSlide(), new Slash());

                case 28: // Sandslash
                    return Create(28, 100, new SandAttack(), new Dig(), new RockSlide(), new Strength());

                case 29: // Nidoran Female
                    return Create(29, 100, new Blizzard(), new Toxic(), new BodySlam(), new Thunderbolt());

                case 30: // Nidorina
                    return Create(30, 100, new BubbleBeam(), new Toxic(), new BodySlam(), new Thunder());

                case 31: // Nidoqueen
                    return Create(31, 100, new Earthquake(), new Toxic(), new RockSlide(), new DoubleKick());

                case 32: // Nidoran Male
                    return Create(32, 100, new Thunder(), new Blizzard(), new HornDrill(), new BodySlam());

                case 33: // Nidorino
                    return Create(33, 100, new Thunderbolt(), new IceBeam(), new BodySlam(), new HornDrill());

                case 34: // Nidoking
                    return Create(34, 100, new Bide(), new Earthquake(), new HornAttack(), new HornDrill());

                case 35: // Clefairy
                    return Create(35, 100, new Blizzard(), new ThunderWave(), new BodySlam(), new Metronome());

                case 36: // Clefable
                    return Create(36, 100, new Metronome(), new Thunder(), new Strength(), new ThunderWave());

                case 37: // Vulpix
                    return Create(37, 100, new Toxic(), new Flamethrower(), new ConfuseRay(), new Dig());

                case 38: // Ninetails
                    return Create(38, 100, new TailWhip(), new FireBlast(), new ConfuseRay(), new QuickAttack());

                case 39: // Jigglypuff
                    return Create(39, 100, new Flash(), new Sing(), new SeismicToss(), new BodySlam());

                case 40: // Wigglytuff
                    return Create(40, 100, new Strength(), new Sing(), new Disable(), new HyperBeam());

                case 41: // Zubat
                    return Create(41, 100, new Swift(), new ConfuseRay(), new Haze(), new MegaDrain());

                case 42: // Golbat
                    return Create(42, 100, new Haze(), new HyperBeam(), new Supersonic(), new MegaDrain());

                case 43: // Oddish
                    return Create(43, 100, new DoubleEdge(), new PetalDance(), new MegaDrain(), new StunSpore());

                case 44: // Gloom
                    return Create(44, 100, new StunSpore(), new PetalDance(), new MegaDrain(), new Acid());

                case 45: // Vileplume
                    return Create(45, 100, new SolarBeam(), new MegaDrain(), new Acid(), new StunSpore());

                case 46: // Paras
                    return Create(46, 100, new MegaDrain(), new Spore(), new Dig(), new Slash());

                case 47: // Parasect
                    return Create(47, 100, new MegaDrain(), new Spore(), new Growth(), new Slash());

                case 48: // Venonat
                    return Create(48, 100, new Toxic(), new Psychic(), new DoubleEdge(), new MegaDrain());

                case 49: // Venomoth
                    return Create(49, 100, new Flash(), new Psychic(), new MegaDrain(), new SleepPowder());

                case 50: // Diglett
                    return Create(50, 100, new Fissure(), new Earthquake(), new SandAttack(), new Slash());

                case 51: // Dugtrio
                    return Create(51, 100, new Growl(), new Dig(), new RockSlide(), new SandAttack());

                case 52: // Meowth
                    return Create(52, 100, new Screech(), new Slash(), new BubbleBeam(), new Thunderbolt());

                case 53: // Persian
                    return Create(53, 100, new HyperBeam(), new Thunder(), new Screech(), new Bite());

                case 54: // Psyduck
                    return Create(54, 100, new Blizzard(), new HydroPump(), new Dig(), new Disable());

                case 55: // Golduck
                    return Create(55, 100, new Disable(), new IceBeam(), new Confusion(), new BubbleBeam());

                case 56: // Mankey
                    return Create(56, 100, new Thrash(), new Submission(), new Counter(), new Dig());

                case 57: // Primeape
                    return Create(57, 100, new Thrash(), new SeismicToss(), new LowKick(), new Counter());

                case 58: // Growlithe
                    return Create(58, 100, new Dig(), new Flamethrower(), new DoubleTeam(), new BodySlam());

                case 59: // Arcanine
                    return Create(59, 100, new Leer(), new FireBlast(), new Agility(), new Dig());

                case 60: // Poliwag
                    return Create(60, 100, new HydroPump(), new Amnesia(), new Blizzard(), new Psychic());

                case 61: // Poliwhirl
                    return Create(61, 100, new Surf(), new IceBeam(), new Psychic(), new Amnesia());

                case 62: // Poliwrath
                    return Create(62, 100, new BubbleBeam(), new Amnesia(), new Submission(), new Hypnosis());

                case 63: // Abra
                    return Create(63, 100, new Psychic(), new BodySlam(), new ThunderWave(), new DoubleTeam());

                case 64: // Kadabra
                    return Create(64, 100, new Psychic(), new Reflect(), new Dig(), new Recover());

                case 65: // Alakazam
                    return Create(65, 100, new Psybeam(), new Reflect(), new HyperBeam(), new Kinesis());

                case 66: // Machop
                    return Create(66, 100, new Submission(), new FocusEnergy(), new BodySlam(), new SeismicToss());

                case 67: // Machoke
                    return Create(67, 100, new Submission(), new FocusEnergy(), new Dig(), new SeismicToss());

                case 68: // Machamp
                    return Create(68, 100, new FocusEnergy(), new LowKick(), new MegaPunch(), new Leer());

                case 69: // Bellsprout
                    return Create(69, 100, new RazorLeaf(), new DoubleEdge(), new Toxic(), new Wrap());

                case 70: // Weepinbell
                    return Create(70, 100, new RazorLeaf(), new StunSpore(), new MegaDrain(), new Growth());

                case 71: // Victreebel
                    return Create(71, 100, new RazorLeaf(), new SleepPowder(), new Acid(), new Wrap());

                case 72: // Tentacool
                    return Create(72, 100, new Surf(), new Toxic(), new Blizzard(), new MegaDrain());

                case 73: // Tentacruel
                    return Create(73, 100, new BubbleBeam(), new Toxic(), new Wrap(), new Screech());

                case 74: // Geodude
                    return Create(74, 100, new RockSlide(), new FireBlast(), new Earthquake(), new SeismicToss());

                case 75: // Graveler
                    return Create(75, 100, new RockSlide(), new Metronome(), new Earthquake(), new FireBlast());

                case 76: // Golem
                    return Create(76, 100, new RockThrow(), new Dig(), new DefenseCurl(), new FireBlast());

                case 77: // Ponyta
                    return Create(77, 100, new FireSpin(), new Toxic(), new Agility(), new HornDrill());

                case 78: // Rapidash
                    return Create(78, 100, new FireBlast(), new TailWhip(), new Stomp(), new Reflect());

                case 79: // Slowpoke
                    return Create(79, 100, new Surf(), new MegaPunch(), new Psychic(), new Disable());

                case 80: // Slowbro
                    return Create(80, 100, new Surf(), new MegaPunch(), new Psychic(), new Disable());

                case 81: // Magnemite
                    return Create(81, 100, new Thunderbolt(), new ThunderWave(), new Flash(), new Swift());

                case 82: // Magneton
                    return Create(82, 100, new ThunderWave(), new Supersonic(), new Thunder(), new Flash());

                case 83: // Farfetch'd
                    return Create(83, 100, new Slash(), new Toxic(), new SandAttack(), new Fly());

                case 84: // Doduo
                    return Create(84, 100, new DrillPeck(), new BodySlam(), new DoubleTeam(), new Reflect());

                case 85: // Dodrio
                    return Create(85, 100, new TriAttack(), new Agility(), new Fly(), new Growl());

                case 86: // Seel
                    return Create(86, 100, new Surf(), new DoubleTeam(), new Blizzard(), new BodySlam());

                case 87: // Dewgong
                    return Create(87, 100, new AuroraBeam(), new HornDrill(), new Surf(), new Headbutt());

                case 88: // Grimer
                    return Create(88, 100, new Sludge(), new AcidArmor(), new BodySlam(), new Thunderbolt());

                case 89: // Muk
                    return Create(89, 100, new Sludge(), new AcidArmor(), new FireBlast(), new Screech());

                case 90: // Shellder
                    return Create(90, 100, new Blizzard(), new Supersonic(), new Surf(), new Swift());

                case 91: // Cloyster
                    return Create(91, 100, new IceBeam(), new Supersonic(), new BubbleBeam(), new Clamp());

                case 92: // Gastly
                    return Create(92, 100, new Psychic(), new NightShade(), new Hypnosis(), new ConfuseRay());

                case 93: // Haunter
                    return Create(93, 100, new Psychic(), new Hypnosis(), new DreamEater(), new ConfuseRay());

                case 94: // Gengar
                    return Create(94, 100, new Hypnosis(), new NightShade(), new DreamEater(), new Metronome());

                case 95: // Onix
                    return Create(95, 100, new RockSlide(), new Selfdestruct(), new Earthquake(), new Fissure());

                case 96: // Drowzee
                    return Create(96, 100, new Hypnosis(), new Psychic(), new DreamEater(), new SeismicToss());

                case 97: // Hypno
                    return Create(97, 100, new Hypnosis(), new Psychic(), new PoisonGas(), new Headbutt());

                case 98: // Krabby
                    return Create(98, 100, new Surf(), new Guillotine(), new BodySlam(), new Blizzard());

                case 99: // Kingler
                    return Create(99, 100, new Crabhammer(), new Toxic(), new Strength(), new Guillotine());

                case 100: // Voltorb
                    return Create(100, 100, new Thunderbolt(), new Reflect(), new ThunderWave(), new TakeDown());

                case 101: // Electrode
                    return Create(101, 100, new Thunder(), new ThunderWave(), new Swift(), new Flash());

                case 102: // Exeggcute
                    return Create(102, 100, new LeechSeed(), new Selfdestruct(), new Toxic(), new Psychic());

                case 103: // Exeggutor
                    return Create(103, 100, new Stomp(), new SleepPowder(), new Psychic(), new SolarBeam());

                case 104: // Cubone
                    return Create(104, 100, new Bonemerang(), new FocusEnergy(), new Blizzard(), new Thrash());

                case 105: // Marowak
                    return Create(105, 100, new BoneClub(), new FocusEnergy(), new Headbutt(), new Thrash());

                case 106: // Hitmonlee
                    return Create(106, 100, new RollingKick(), new FocusEnergy(), new JumpKick(), new HiJumpKick());

                case 107: // Hitmonchan
                    return Create(107, 100, new MegaPunch(), new ThunderPunch(), new FirePunch(), new IcePunch());

                case 108: // Lickitung
                    return Create(108, 100, new BodySlam(), new Blizzard(), new Thunder(), new Earthquake());

                case 109: // Koffing
                    return Create(109, 100, new Sludge(), new Toxic(), new Thunder(), new Haze());

                case 110: // Weezing
                    return Create(110, 100, new Sludge(), new Mimic(), new Thunder(), new Haze());

                case 111: // Rhyhorn
                    return Create(111, 100, new BodySlam(), new Fissure(), new Earthquake(), new RockSlide());

                case 112: // Rhydon
                    return Create(112, 100, new HornAttack(), new Fissure(), new Earthquake(), new Thunder());

                case 113: // Chansey
                    return Create(113, 100, new EggBomb(), new SeismicToss(), new Rest(), new Metronome());

                case 114: // Tangela
                    return Create(114, 100, new StunSpore(), new SolarBeam(), new MegaDrain(), new Growth());
                
                case 115: // Kangaskhan
                    return Create(115, 100, new DizzyPunch(), new Substitute(), new RockSlide(), new Surf());
                
                case 116: // Horsea
                    return Create(116, 100, new HydroPump(), new Smokescreen(), new IceBeam(), new Toxic());
                
                case 117: // Seadra
                    return Create(117, 100, new Smokescreen(), new Surf(), new DoubleEdge(), new Toxic());
                
                case 118: // Goldeen
                    return Create(118, 100, new Surf(), new Agility(), new HornDrill(), new DoubleTeam());
                
                case 119: // Seaking
                    return Create(119, 100, new Waterfall(), new FuryAttack(), new HornDrill(), new Supersonic());
                
                case 120: // Staryu
                    return Create(120, 100, new Minimize(), new Recover(), new Surf(), new Psychic());
                
                case 121: // Starmie
                    return Create(121, 100, new BubbleBeam(), new Thunder(), new Swift(), new Minimize());
                
                case 122: // Mr. Mime
                    return Create(122, 100, new Barrier(), new HyperBeam(), new LightScreen(), new Psychic());
                
                case 123: // Scyther
                    return Create(123, 100, new FocusEnergy(), new DoubleTeam(), new HyperBeam(), new Swift());
                
                case 124: // Jynx
                    return Create(124, 100, new LovelyKiss(), new BodySlam(), new IcePunch(), new Psychic());
                
                case 125: // Electabuzz
                    return Create(125, 100, new ThunderPunch(), new Metronome(), new ThunderWave(), new Reflect());
                
                case 126: // Magmar
                    return Create(126, 100, new ConfuseRay(), new FirePunch(), new MegaPunch(), new Psychic());
                
                case 127: // Pinsir
                    return Create(127, 100, new Slash(), new SeismicToss(), new Toxic(), new Guillotine());
                
                case 128: // Tauros
                    return Create(128, 100, new Stomp(), new FireBlast(), new SkullBash(), new Bide());
                
                case 129: // Magikarp
                    return Create(129, 100, new Splash(), new Tackle(), null, null);
                
                case 130: // Gyarados
                    return Create(130, 100, new BubbleBeam(), new Leer(), new Bite(), new FireBlast());
                
                case 131: // Lapras
                    return Create(131, 100, new BubbleBeam(), new IceBeam(), new Mist(), new Sing());
                
                case 132: // Ditto
                    return Create(132, 100, new Transform(), null, null, null);
                
                case 133: // Eevee
                    return Create(133, 100, new DoubleEdge(), new QuickAttack(), new FocusEnergy(), new SandAttack());
                
                case 134: // Vaporeon
                    return Create(134, 100, new HydroPump(), new QuickAttack(), new AcidArmor(), new Haze());
                
                case 135: // Jolteon
                    return Create(135, 100, new Thunder(), new QuickAttack(), new PinMissile(), new SandAttack());
                
                case 136: // Flareon
                    return Create(136, 100, new FireBlast(), new QuickAttack(), new Smog(), new SandAttack());
                
                case 137: // Porygon
                    return Create(137, 100, new Psybeam(), new Recover(), new TriAttack(), new Conversion());
                
                case 138: // Omanyte
                    return Create(138, 100, new HydroPump(), new Toxic(), new BodySlam(), new IceBeam());
                
                case 139: // Omastar
                    return Create(139, 100, new Surf(), new Toxic(), new SpikeCannon(), new HornDrill());
                
                case 140: // Kabuto
                    return Create(140, 100, new Surf(), new DoubleTeam(), new Blizzard(), new Slash());
                
                case 141: // Kabutops
                    return Create(141, 100, new HydroPump(), new SwordsDance(), new MegaKick(), new IceBeam());
                
                case 142: // Aerodactyl
                    return Create(142, 100, new Supersonic(), new Bite(), new FireBlast(), new Fly());
                
                case 143: // Snorlax
                    return Create(143, 100, new TakeDown(), new Bide(), new Metronome(), new Rest());
                
                case 144: // Articuono
                    return Create(144, 100, new IceBeam(), new Agility(), new SkyAttack(), new Mist());
                
                case 145: // Zapdos
                    return Create(145, 100, new Thunder(), new Flash(), new SkyAttack(), new Bide());
                
                case 146: // Moltres
                    return Create(146, 100, new FireBlast(), new Reflect(), new SkyAttack(), new Agility());
                
                case 147: // Dratini
                    return Create(147, 100, new Blizzard(), new FireBlast(), new Thunderbolt(), new BodySlam());
                
                case 148: // Dragonair
                    return Create(148, 100, new BodySlam(), new Thunderbolt(), new FireBlast(), new IceBeam());
                
                case 149: // Dragonite
                    return Create(149, 100, new Thunder(), new FireBlast(), new Wrap(), new Slam());

                //=============================
                // THERE IS NO MEWTWO (No. 150)
                //=============================
                
                case 151: // Mew
                    return Create(151, 100, new Psychic(), new Metronome(), new MegaPunch(), new Flash());

                default: throw new ArgumentException("The given index " + index + " is an invalid pokemon number");
            }
        }
    }
}
