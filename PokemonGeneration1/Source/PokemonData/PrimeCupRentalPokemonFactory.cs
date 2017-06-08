using PokemonGeneration1.Source.Moves;
using PokemonGeneration1.Source.Moves.Reflexive;
using PokemonGeneration1.Source.Moves.Transitive.Attack.MultiTurn;
using PokemonGeneration1.Source.Moves.Transitive.Attack.OneTurnMultiHit;
using PokemonGeneration1.Source.Moves.Transitive.Attack.OneTurnOneHit;
using PokemonGeneration1.Source.Moves.Transitive.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.PokemonData
{
    public static class PrimeCupRentalPokemonFactory
    {
        public static Pokemon Generate(int index)
        {
            Pokemon poke = null;

            switch (index)
            {
                // Bulbasaur
                case 1:
                    poke = Pokemon.GeneratePreMadePokemon(1, 100, new RazorLeaf(), new LeechSeed(), new BodySlam(), new Growth());
                    break;
                // Ivysaur
                case 2:
                    poke = Pokemon.GeneratePreMadePokemon(2, 100, new LeechSeed(), new RazorLeaf(), new Growth(), new MegaDrain());
                    break;
                // Venusaur
                case 3:
                    poke = Pokemon.GeneratePreMadePokemon(3, 100, new Growth(), new LeechSeed(), new SolarBeam(), new SleepPowder());
                    break;
                // Charmander
                case 4:
                    poke = Pokemon.GeneratePreMadePokemon(4, 100, new SeismicToss(), new Flamethrower(), new Dig(), new BodySlam());
                    break;
                // Charmeleon
                case 5:
                    poke = Pokemon.GeneratePreMadePokemon(5, 100, new Slash(), new Flamethrower(), new Dig(), new Submission());
                    break;
                // Charizard
                case 6:
                    poke = Pokemon.GeneratePreMadePokemon(6, 100, new FireBlast(), new Fly(), new FireSpin(), new SwordsDance());
                    break;
                // Squirtle
                case 7:
                    poke = Pokemon.GeneratePreMadePokemon(7, 100, new Dig(), new Surf(), new BodySlam(), new Blizzard());
                    break;
                // Wartortle
                case 8:
                    poke = Pokemon.GeneratePreMadePokemon(8, 100, new SeismicToss(), new Surf(), new Toxic(), new Dig());
                    break;
                // Blastoise
                case 9:
                    poke = Pokemon.GeneratePreMadePokemon(9, 100, new TailWhip(), new HydroPump(), new Withdraw(), new SkullBash());
                    break;
                // Caterpie
                case 10:
                    poke = Pokemon.GeneratePreMadePokemon(10, 100, new StringShot(), new Tackle(), null, null);
                    break;
                // Metapod
                case 11:
                    poke = Pokemon.GeneratePreMadePokemon(11, 100, new StringShot(), new Tackle(), null, null);
                    break;
                // Butterfree
                case 12:
                    poke = Pokemon.GeneratePreMadePokemon(12, 100, new StunSpore(), new Psychic(), new MegaDrain(), new Swift());
                    break;
                // Weedle
                case 13:
                    poke = Pokemon.GeneratePreMadePokemon(13, 100, new StringShot(), new PoisonSting(), null, null);
                    break;
                // Kakuna
                case 14:
                    poke = Pokemon.GeneratePreMadePokemon(14, 100, new StringShot(), new PoisonSting(), null, null);
                    break;
                // Beedrill
                case 15:
                    poke = Pokemon.GeneratePreMadePokemon(15, 100, new FocusEnergy(), new Twineedle(), new MegaDrain(), new HyperBeam());
                    break;
                // Pidgey
                case 16:
                    poke = Pokemon.GeneratePreMadePokemon(16, 100, new Tackle(), new Fly(), new SandAttack(), new MirrorMove());
                    break;
                // Pidgeotto
                case 17:
                    poke = Pokemon.GeneratePreMadePokemon(17, 100, new Swift(), new Fly(), new SandAttack(), new Toxic());
                    break;
                // Pidgeot
                case 18:
                    poke = Pokemon.GeneratePreMadePokemon(18, 100, new SandAttack(), new MirrorMove(), new QuickAttack(), new Fly());
                    break;
                // Rattata
                case 19:
                    poke = Pokemon.GeneratePreMadePokemon(19, 100, new Dig(), new SuperFang(), new BodySlam(), new Toxic());
                    break;
                // Raticate
                case 20:
                    poke = Pokemon.GeneratePreMadePokemon(20, 100, new Toxic(), new HyperFang(), new QuickAttack(), new SuperFang());
                    break;
                // Spearow
                case 21:
                    poke = Pokemon.GeneratePreMadePokemon(21, 100, new Swift(), new DrillPeck(), new DoubleTeam(), new Fly());
                    break;
                // Fearow
                case 22:
                    poke = Pokemon.GeneratePreMadePokemon(22, 100, new Growl(), new DrillPeck(), new HyperBeam(), new MirrorMove());
                    break;
                // Ekans
                case 23:
                    poke = Pokemon.GeneratePreMadePokemon(23, 100, new DoubleEdge(), new Earthquake(), new Glare(), new MegaDrain());
                    break;
                // Arbok
                case 24:
                    poke = Pokemon.GeneratePreMadePokemon(24, 100, new Strength(), new Glare(), new Dig(), new Acid());
                    break;
                // Pikachu
                case 25:
                    poke = Pokemon.GeneratePreMadePokemon(25, 100, new Reflect(), new Thunderbolt(), new ThunderWave(), new Swift());
                    break;
                // Raichu
                case 26:
                    poke = Pokemon.GeneratePreMadePokemon(26, 100, new MegaKick(), new Thunder(), new QuickAttack(), new ThunderWave());
                    break;
                // Sandshrew
                case 27:
                    poke = Pokemon.GeneratePreMadePokemon(27, 100, new SandAttack(), new Earthquake(), new RockSlide(), new Slash());
                    break;
                // Sandslash
                case 28:
                    poke = Pokemon.GeneratePreMadePokemon(28, 100, new SandAttack(), new Dig(), new RockSlide(), new Strength());
                    break;
                // Nidoran Female
                case 29:
                    poke = Pokemon.GeneratePreMadePokemon(29, 100, new Blizzard(), new Toxic(), new BodySlam(), new Thunderbolt());
                    break;
                // Nidorina
                case 30:
                    poke = Pokemon.GeneratePreMadePokemon(30, 100, new BubbleBeam(), new Toxic(), new BodySlam(), new Thunder());
                    break;
                // Nidoqueen
                case 31:
                    poke = Pokemon.GeneratePreMadePokemon(31, 100, new Earthquake(), new Toxic(), new RockSlide(), new DoubleKick());
                    break;
                // Nidoran Male
                case 32:
                    poke = Pokemon.GeneratePreMadePokemon(32, 100, new Thunder(), new Blizzard(), new HornDrill(), new BodySlam());
                    break;
                // Nidorino
                case 33:
                    poke = Pokemon.GeneratePreMadePokemon(33, 100, new Thunderbolt(), new IceBeam(), new BodySlam(), new HornDrill());
                    break;
                // Nidoking
                case 34:
                    poke = Pokemon.GeneratePreMadePokemon(34, 100, new Bide(), new Earthquake(), new HornAttack(), new HornDrill());
                    break;
                // Clefairy
                case 35:
                    poke = Pokemon.GeneratePreMadePokemon(35, 100, new Blizzard(), new ThunderWave(), new BodySlam(), new Metronome());
                    break;
                // Clefable
                case 36:
                    poke = Pokemon.GeneratePreMadePokemon(36, 100, new Metronome(), new Thunder(), new Strength(), new ThunderWave());
                    break;
                // Vulpix
                case 37:
                    poke = Pokemon.GeneratePreMadePokemon(37, 100, new Toxic(), new Flamethrower(), new ConfuseRay(), new Dig());
                    break;
                // Ninetails
                case 38:
                    poke = Pokemon.GeneratePreMadePokemon(38, 100, new TailWhip(), new FireBlast(), new ConfuseRay(), new QuickAttack());
                    break;
                // Jigglypuff
                case 39:
                    poke = Pokemon.GeneratePreMadePokemon(39, 100, new Flash(), new Sing(), new SeismicToss(), new BodySlam());
                    break;
                // Wigglytuff
                case 40:
                    poke = Pokemon.GeneratePreMadePokemon(40, 100, new Strength(), new Sing(), new Disable(), new HyperBeam());
                    break;
                // Zubat
                case 41:
                    poke = Pokemon.GeneratePreMadePokemon(41, 100, new Swift(), new ConfuseRay(), new Haze(), new MegaDrain());
                    break;
                // Golbat
                case 42:
                    poke = Pokemon.GeneratePreMadePokemon(42, 100, new Haze(), new HyperBeam(), new Supersonic(), new MegaDrain());
                    break;
                // Oddish
                case 43:
                    poke = Pokemon.GeneratePreMadePokemon(43, 100, new DoubleEdge(), new PetalDance(), new MegaDrain(), new StunSpore());
                    break;
                // Gloom
                case 44:
                    poke = Pokemon.GeneratePreMadePokemon(44, 100, new StunSpore(), new PetalDance(), new MegaDrain(), new Acid());
                    break;
                // Vileplume
                case 45:
                    poke = Pokemon.GeneratePreMadePokemon(45, 100, new SolarBeam(), new MegaDrain(), new Acid(), new StunSpore());
                    break;
                // Paras
                case 46:
                    poke = Pokemon.GeneratePreMadePokemon(46, 100, new MegaDrain(), new Spore(), new Dig(), new Slash());
                    break;
                // Parasect
                case 47:
                    poke = Pokemon.GeneratePreMadePokemon(47, 100, new MegaDrain(), new Spore(), new Growth(), new Slash());
                    break;
                // Venonat
                case 48:
                    poke = Pokemon.GeneratePreMadePokemon(48, 100, new Toxic(), new Psychic(), new DoubleEdge(), new MegaDrain());
                    break;
                // Venomoth
                case 49:
                    poke = Pokemon.GeneratePreMadePokemon(49, 100, new Flash(), new Psychic(), new MegaDrain(), new SleepPowder());
                    break;
                // Diglett
                case 50:
                    poke = Pokemon.GeneratePreMadePokemon(50, 100, new Fissure(), new Earthquake(), new SandAttack(), new Slash());
                    break;
                // Dugtrio
                case 51:
                    poke = Pokemon.GeneratePreMadePokemon(51, 100, new Growl(), new Dig(), new RockSlide(), new SandAttack());
                    break;
                // Meowth
                case 52:
                    poke = Pokemon.GeneratePreMadePokemon(52, 100, new Screech(), new Slash(), new BubbleBeam(), new Thunderbolt());
                    break;
                // Persian
                case 53:
                    poke = Pokemon.GeneratePreMadePokemon(53, 100, new HyperBeam(), new Thunder(), new Screech(), new Bite());
                    break;
                // Psyduck
                case 54:
                    poke = Pokemon.GeneratePreMadePokemon(54, 100, new Blizzard(), new HydroPump(), new Dig(), new Disable());
                    break;
                // Golduck
                case 55:
                    poke = Pokemon.GeneratePreMadePokemon(55, 100, new Disable(), new IceBeam(), new Confusion(), new BubbleBeam());
                    break;
                // Mankey
                case 56:
                    poke = Pokemon.GeneratePreMadePokemon(56, 100, new Thrash(), new Submission(), new Counter(), new Dig());
                    break;
                // Primeape
                case 57:
                    poke = Pokemon.GeneratePreMadePokemon(57, 100, new Thrash(), new SeismicToss(), new LowKick(), new Counter());
                    break;
                // Growlithe
                case 58:
                    poke = Pokemon.GeneratePreMadePokemon(58, 100, new Dig(), new Flamethrower(), new DoubleTeam(), new BodySlam());
                    break;
                // Arcanine
                case 59:
                    poke = Pokemon.GeneratePreMadePokemon(59, 100, new Leer(), new FireBlast(), new Agility(), new Dig());
                    break;
                // Poliwag
                case 60:
                    poke = Pokemon.GeneratePreMadePokemon(60, 100, new HydroPump(), new Amnesia(), new Blizzard(), new Psychic());
                    break;
                // Poliwhirl
                case 61:
                    poke = Pokemon.GeneratePreMadePokemon(61, 100, new Surf(), new IceBeam(), new Psychic(), new Amnesia());
                    break;
                // Poliwrath
                case 62:
                    poke = Pokemon.GeneratePreMadePokemon(62, 100, new BubbleBeam(), new Amnesia(), new Submission(), new Hypnosis());
                    break;
                // Abra
                case 63:
                    poke = Pokemon.GeneratePreMadePokemon(63, 100, new Psychic(), new BodySlam(), new ThunderWave(), new DoubleTeam());
                    break;
                // Kadabra
                case 64:
                    poke = Pokemon.GeneratePreMadePokemon(64, 100, new Psychic(), new Reflect(), new Dig(), new Recover());
                    break;
                // Alakazam
                case 65:
                    poke = Pokemon.GeneratePreMadePokemon(65, 100, new Psybeam(), new Reflect(), new HyperBeam(), new Kinesis());
                    break;
                // Machop
                case 66:
                    poke = Pokemon.GeneratePreMadePokemon(66, 100, new Submission(), new FocusEnergy(), new BodySlam(), new SeismicToss());
                    break;
                // Machoke
                case 67:
                    poke = Pokemon.GeneratePreMadePokemon(67, 100, new Submission(), new FocusEnergy(), new Dig(), new SeismicToss());
                    break;
                // Machamp
                case 68:
                    poke = Pokemon.GeneratePreMadePokemon(68, 100, new FocusEnergy(), new LowKick(), new MegaPunch(), new Leer());
                    break;
                // Bellsprout
                case 69:
                    poke = Pokemon.GeneratePreMadePokemon(69, 100, new RazorLeaf(), new DoubleEdge(), new Toxic(), new Wrap());
                    break;
                // Weepinbell
                case 70:
                    poke = Pokemon.GeneratePreMadePokemon(70, 100, new RazorLeaf(), new StunSpore(), new MegaDrain(), new Growth());
                    break;
                // Victreebel
                case 71:
                    poke = Pokemon.GeneratePreMadePokemon(71, 100, new RazorLeaf(), new SleepPowder(), new Acid(), new Wrap());
                    break;
                // Tentacool
                case 72:
                    poke = Pokemon.GeneratePreMadePokemon(72, 100, new Surf(), new Toxic(), new Blizzard(), new MegaDrain());
                    break;
                // Tentacruel
                case 73:
                    poke = Pokemon.GeneratePreMadePokemon(73, 100, new BubbleBeam(), new Toxic(), new Wrap(), new Screech());
                    break;
                // Geodude
                case 74:
                    poke = Pokemon.GeneratePreMadePokemon(74, 100, new RockSlide(), new FireBlast(), new Earthquake(), new SeismicToss());
                    break;
                // Graveler
                case 75:
                    poke = Pokemon.GeneratePreMadePokemon(75, 100, new RockSlide(), new Metronome(), new Earthquake(), new FireBlast());
                    break;
                // Golem
                case 76:
                    poke = Pokemon.GeneratePreMadePokemon(76, 100, new RockThrow(), new Dig(), new DefenseCurl(), new FireBlast());
                    break;
                // Ponyta
                case 77:
                    poke = Pokemon.GeneratePreMadePokemon(77, 100, new FireSpin(), new Toxic(), new Agility(), new HornDrill());
                    break;
                // Rapidash
                case 78:
                    poke = Pokemon.GeneratePreMadePokemon(78, 100, new FireBlast(), new TailWhip(), new Stomp(), new Reflect());
                    break;
                // Slowpoke
                case 79:
                    poke = Pokemon.GeneratePreMadePokemon(79, 100, new Surf(), new MegaPunch(), new Psychic(), new Disable());
                    break;
                // Slowbro
                case 80:
                    poke = Pokemon.GeneratePreMadePokemon(80, 100, new Surf(), new MegaPunch(), new Psychic(), new Disable());
                    break;
                // Magnemite
                case 81:
                    poke = Pokemon.GeneratePreMadePokemon(81, 100, new Thunderbolt(), new ThunderWave(), new Flash(), new Swift());
                    break;
                // Magneton 
                case 82:
                    poke = Pokemon.GeneratePreMadePokemon(82, 100, new ThunderWave(), new Supersonic(), new Thunder(), new Flash());
                    break;
                // Farfetch'd
                case 83:
                    poke = Pokemon.GeneratePreMadePokemon(83, 100, new Slash(), new Toxic(), new SandAttack(), new Fly());
                    break;
                // Doduo
                case 84:
                    poke = Pokemon.GeneratePreMadePokemon(84, 100, new DrillPeck(), new BodySlam(), new DoubleTeam(), new Reflect());
                    break;
                // Dodrio
                case 85:
                    poke = Pokemon.GeneratePreMadePokemon(85, 100, new TriAttack(), new Agility(), new Fly(), new Growl());
                    break;
                // Seel
                case 86:
                    poke = Pokemon.GeneratePreMadePokemon(86, 100, new Surf(), new DoubleTeam(), new Blizzard(), new BodySlam());
                    break;
                // Dewgong
                case 87:
                    poke = Pokemon.GeneratePreMadePokemon(87, 100, new AuroraBeam(), new HornDrill(), new Surf(), new Headbutt());
                    break;
                // Grimer
                case 88:
                    poke = Pokemon.GeneratePreMadePokemon(88, 100, new Sludge(), new AcidArmor(), new BodySlam(), new Thunderbolt());
                    break;
                // Muk
                case 89:
                    poke = Pokemon.GeneratePreMadePokemon(89, 100, new Sludge(), new AcidArmor(), new FireBlast(), new Screech());
                    break;
                // Shellder
                case 90:
                    poke = Pokemon.GeneratePreMadePokemon(90, 100, new Blizzard(), new Supersonic(), new Surf(), new Swift());
                    break;
                // Cloyster
                case 91:
                    poke = Pokemon.GeneratePreMadePokemon(91, 100, new IceBeam(), new Supersonic(), new BubbleBeam(), new Clamp());
                    break;
                // Gastly
                case 92:
                    poke = Pokemon.GeneratePreMadePokemon(92, 100, new Psychic(), new NightShade(), new Hypnosis(), new ConfuseRay());
                    break;
                // Haunter
                case 93:
                    poke = Pokemon.GeneratePreMadePokemon(93, 100, new Psychic(), new Hypnosis(), new DreamEater(), new ConfuseRay());
                    break;
                // Gengar
                case 94:
                    poke = Pokemon.GeneratePreMadePokemon(94, 100, new Hypnosis(), new NightShade(), new DreamEater(), new Metronome());
                    break;
                // Onix
                case 95:
                    poke = Pokemon.GeneratePreMadePokemon(95, 100, new RockSlide(), new Selfdestruct(), new Earthquake(), new Fissure());
                    break;
                // Drowzee
                case 96:
                    poke = Pokemon.GeneratePreMadePokemon(96, 100, new Hypnosis(), new Psychic(), new DreamEater(), new SeismicToss());
                    break;
                // Hypno
                case 97:
                    poke = Pokemon.GeneratePreMadePokemon(97, 100, new Hypnosis(), new Psychic(), new PoisonGas(), new Headbutt());
                    break;
                // Krabby
                case 98:
                    poke = Pokemon.GeneratePreMadePokemon(98, 100, new Surf(), new Guillotine(), new BodySlam(), new Blizzard());
                    break;
                // Kingler
                case 99:
                    poke = Pokemon.GeneratePreMadePokemon(99, 100, new Crabhammer(), new Toxic(), new Strength(), new Guillotine());
                    break;
                // Voltorb
                case 100:
                    poke = Pokemon.GeneratePreMadePokemon(100, 100, new Thunderbolt(), new Reflect(), new ThunderWave(), new TakeDown());
                    break;
                // Electrode
                case 101:
                    poke = Pokemon.GeneratePreMadePokemon(101, 100, new Thunder(), new ThunderWave(), new Swift(), new Flash());
                    break;
                // Exeggcute
                case 102:
                    poke = Pokemon.GeneratePreMadePokemon(102, 100, new LeechSeed(), new Selfdestruct(), new Toxic(), new Psychic());
                    break;
                // Exeggutor
                case 103:
                    poke = Pokemon.GeneratePreMadePokemon(103, 100, new Stomp(), new SleepPowder(), new Psychic(), new SolarBeam());
                    break;
                // Cubone
                case 104:
                    poke = Pokemon.GeneratePreMadePokemon(104, 100, new Bonemerang(), new FocusEnergy(), new Blizzard(), new Thrash());
                    break;
                // Marowak
                case 105:
                    poke = Pokemon.GeneratePreMadePokemon(105, 100, new BoneClub(), new FocusEnergy(), new Headbutt(), new Thrash());
                    break;
                // Hitmonlee
                case 106:
                    poke = Pokemon.GeneratePreMadePokemon(106, 100, new RollingKick(), new FocusEnergy(), new JumpKick(), new HiJumpKick());
                    break;
                // Hitmonchan
                case 107:
                    poke = Pokemon.GeneratePreMadePokemon(107, 100, new MegaPunch(), new ThunderPunch(), new FirePunch(), new IcePunch());
                    break;
                // Lickitung
                case 108:
                    poke = Pokemon.GeneratePreMadePokemon(108, 100, new BodySlam(), new Blizzard(), new Thunder(), new Earthquake());
                    break;
                // Koffing
                case 109:
                    poke = Pokemon.GeneratePreMadePokemon(109, 100, new Sludge(), new Toxic(), new Thunder(), new Haze());
                    break;
                // Weezing
                case 110:
                    poke = Pokemon.GeneratePreMadePokemon(110, 100, new Sludge(), new Mimic(), new Thunder(), new Haze());
                    break;
                // Rhyhorn
                case 111:
                    poke = Pokemon.GeneratePreMadePokemon(111, 100, new BodySlam(), new Fissure(), new Earthquake(), new RockSlide());
                    break;
                // Rhydon
                case 112:
                    poke = Pokemon.GeneratePreMadePokemon(112, 100, new HornAttack(), new Fissure(), new Earthquake(), new Thunder());
                    break;
                // Chansey
                case 113:
                    poke = Pokemon.GeneratePreMadePokemon(113, 100, new EggBomb(), new SeismicToss(), new Rest(), new Metronome());
                    break;
                // Tangela
                case 114:
                    poke = Pokemon.GeneratePreMadePokemon(114, 100, new StunSpore(), new SolarBeam(), new MegaDrain(), new Growth());
                    break;
                // Kangaskhan
                case 115:
                    poke = Pokemon.GeneratePreMadePokemon(115, 100, new DizzyPunch(), new Substitute(), new RockSlide(), new Surf());
                    break;
                // Horsea
                case 116:
                    poke = Pokemon.GeneratePreMadePokemon(116, 100, new HydroPump(), new Smokescreen(), new IceBeam(), new Toxic());
                    break;
                // Seadra
                case 117:
                    poke = Pokemon.GeneratePreMadePokemon(117, 100, new Smokescreen(), new Surf(), new DoubleEdge(), new Toxic());
                    break;
                // Goldeen
                case 118:
                    poke = Pokemon.GeneratePreMadePokemon(118, 100, new Surf(), new Agility(), new HornDrill(), new DoubleTeam());
                    break;
                // Seaking
                case 119:
                    poke = Pokemon.GeneratePreMadePokemon(119, 100, new Waterfall(), new FuryAttack(), new HornDrill(), new Supersonic());
                    break;
                // Staryu
                case 120:
                    poke = Pokemon.GeneratePreMadePokemon(120, 100, new Minimize(), new Recover(), new Surf(), new Psychic());
                    break;
                // Starmie
                case 121:
                    poke = Pokemon.GeneratePreMadePokemon(121, 100, new BubbleBeam(), new Thunder(), new Swift(), new Minimize());
                    break;
                // Mr. Mime
                case 122:
                    poke = Pokemon.GeneratePreMadePokemon(122, 100, new Barrier(), new HyperBeam(), new LightScreen(), new Psychic());
                    break;
                // Scyther
                case 123:
                    poke = Pokemon.GeneratePreMadePokemon(123, 100, new FocusEnergy(), new DoubleTeam(), new HyperBeam(), new Swift());
                    break;
                // Jynx
                case 124:
                    poke = Pokemon.GeneratePreMadePokemon(124, 100, new LovelyKiss(), new BodySlam(), new IcePunch(), new Psychic());
                    break;
                // Electabuzz
                case 125:
                    poke = Pokemon.GeneratePreMadePokemon(125, 100, new ThunderPunch(), new Metronome(), new ThunderWave(), new Reflect());
                    break;
                // Magmar
                case 126:
                    poke = Pokemon.GeneratePreMadePokemon(126, 100, new ConfuseRay(), new FirePunch(), new MegaPunch(), new Psychic());
                    break;
                // Pinsir
                case 127:
                    poke = Pokemon.GeneratePreMadePokemon(127, 100, new Slash(), new SeismicToss(), new Toxic(), new Guillotine());
                    break;
                // Tauros
                case 128:
                    poke = Pokemon.GeneratePreMadePokemon(128, 100, new Stomp(), new FireBlast(), new SkullBash(), new Bide());
                    break;
                // Magikarp
                case 129:
                    poke = Pokemon.GeneratePreMadePokemon(129, 100, new Splash(), new Tackle(), null, null);
                    break;
                // Gyarados
                case 130:
                    poke = Pokemon.GeneratePreMadePokemon(130, 100, new BubbleBeam(), new Leer(), new Bite(), new FireBlast());
                    break;
                // Lapras
                case 131:
                    poke = Pokemon.GeneratePreMadePokemon(131, 100, new BubbleBeam(), new IceBeam(), new Mist(), new Sing());
                    break;
                // Ditto
                case 132:
                    poke = Pokemon.GeneratePreMadePokemon(132, 100, new Transform(), null, null, null);
                    break;
                // Eevee
                case 133:
                    poke = Pokemon.GeneratePreMadePokemon(133, 100, new DoubleEdge(), new QuickAttack(), new FocusEnergy(), new SandAttack());
                    break;
                // Vaporeon
                case 134:
                    poke = Pokemon.GeneratePreMadePokemon(134, 100, new HydroPump(), new QuickAttack(), new AcidArmor(), new Haze());
                    break;
                // Jolteon
                case 135:
                    poke = Pokemon.GeneratePreMadePokemon(135, 100, new Thunder(), new QuickAttack(), new PinMissile(), new SandAttack());
                    break;
                // Flareon
                case 136:
                    poke = Pokemon.GeneratePreMadePokemon(136, 100, new FireBlast(), new QuickAttack(), new Smog(), new SandAttack());
                    break;
                // Porygon
                case 137:
                    poke = Pokemon.GeneratePreMadePokemon(137, 100, new Psybeam(), new Recover(), new TriAttack(), new Conversion());
                    break;
                // Omanyte
                case 138:
                    poke = Pokemon.GeneratePreMadePokemon(138, 100, new HydroPump(), new Toxic(), new BodySlam(), new IceBeam());
                    break;
                // Omastar
                case 139:
                    poke = Pokemon.GeneratePreMadePokemon(139, 100, new Surf(), new Toxic(), new SpikeCannon(), new HornDrill());
                    break;
                // Kabuto
                case 140:
                    poke = Pokemon.GeneratePreMadePokemon(140, 100, new Surf(), new DoubleTeam(), new Blizzard(), new Slash());
                    break;
                // Kabutops
                case 141:
                    poke = Pokemon.GeneratePreMadePokemon(141, 100, new HydroPump(), new SwordsDance(), new MegaKick(), new IceBeam());
                    break;
                // Aerodactyl
                case 142:
                    poke = Pokemon.GeneratePreMadePokemon(142, 100, new Supersonic(), new Bite(), new FireBlast(), new Fly());
                    break;
                // Snorlax
                case 143:
                    poke = Pokemon.GeneratePreMadePokemon(143, 100, new TakeDown(), new Bide(), new Metronome(), new Rest());
                    break;
                // Articuono
                case 144:
                    poke = Pokemon.GeneratePreMadePokemon(144, 100, new IceBeam(), new Agility(), new SkyAttack(), new Mist());
                    break;
                // Zapdos
                case 145:
                    poke = Pokemon.GeneratePreMadePokemon(145, 100, new Thunder(), new Flash(), new SkyAttack(), new Bide());
                    break;
                // Moltres
                case 146:
                    poke = Pokemon.GeneratePreMadePokemon(146, 100, new FireBlast(), new Reflect(), new SkyAttack(), new Agility());
                    break;
                // Dratini
                case 147:
                    poke = Pokemon.GeneratePreMadePokemon(147, 100, new Blizzard(), new FireBlast(), new Thunderbolt(), new BodySlam());
                    break;
                // Dragonair
                case 148:
                    poke = Pokemon.GeneratePreMadePokemon(148, 100, new BodySlam(), new Thunderbolt(), new FireBlast(), new IceBeam());
                    break;
                // Dragonite
                case 149:
                    poke = Pokemon.GeneratePreMadePokemon(149, 100, new Thunder(), new FireBlast(), new Wrap(), new Slam());
                    break;
                //=============================
                // THERE IS NO MEWTWO (No. 150)
                //=============================
                // Mew
                case 151:
                    poke = Pokemon.GeneratePreMadePokemon(151, 100, new Psychic(), new Metronome(), new MegaPunch(), new Flash());
                    break;
            }

            return poke;
        }
    }
}
