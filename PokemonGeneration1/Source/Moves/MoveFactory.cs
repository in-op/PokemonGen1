using PokemonGeneration1.Source.Moves.Reflexive;
using PokemonGeneration1.Source.Moves.Transitive.Attack.MultiTurn;
using PokemonGeneration1.Source.Moves.Transitive.Attack.OneTurnMultiHit;
using PokemonGeneration1.Source.Moves.Transitive.Attack.OneTurnOneHit;
using PokemonGeneration1.Source.Moves.Transitive.Status;
using System;

namespace PokemonGeneration1.Source.Moves
{
    public static class MoveFactory
    {
        public static Move CreateRandomMoveForMetronome()
        {
            Move move = null;
            while (move == null)
            {
                int rando = new Random().Next(1, 166);
                if (rando == 68)
                    move = new Counter(true);
                else
                    move = Create(rando);
            }
            return move;
        }


        public static Move Create(int moveIndex)
        {
            switch (moveIndex)
            {
                case 1: return new Pound();
                case 2: return new KarateChop();
                case 3: return new DoubleSlap();
                case 4: return new CometPunch();
                case 5: return new MegaPunch();
                case 6: return new PayDay();
                case 7: return new FirePunch();
                case 8: return new IcePunch();
                case 9: return new ThunderPunch();
                case 10: return new Scratch();
                case 11: return new ViceGrip();
                case 12: return new Guillotine();
                case 13: return new RazorWind();
                case 14: return new SwordsDance();
                case 15: return new Cut();
                case 16: return new Gust();
                case 17: return new WingAttack();
                // case 18: move that ends battle
                case 19: return new Fly();
                case 20: return new Bind();
                // case 21: move that ends battle
                case 22: return new VineWhip();
                case 23: return new Stomp();
                case 24: return new DoubleKick();
                case 25: return new MegaKick();
                case 26: return new JumpKick();
                case 27: return new RollingKick();
                case 28: return new SandAttack();
                case 29: return new Headbutt();
                case 30: return new HornAttack();
                case 31: return new FuryAttack();
                case 32: return new HornDrill();
                case 33: return new Tackle();
                case 34: return new BodySlam();
                case 35: return new Wrap();
                case 36: return new TakeDown();
                case 37: return new Thrash();
                case 38: return new DoubleEdge();
                case 39: return new TailWhip();
                case 40: return new PoisonSting();
                case 41: return new Twineedle();
                case 42: return new PinMissile();
                case 43: return new Leer();
                case 44: return new Bite();
                case 45: return new Growl();
                // case 46: move ends battle
                case 47: return new Sing();
                case 48: return new Supersonic();
                case 49: return new SonicBoom();
                case 50: return new Disable();
                case 51: return new Acid();
                case 52: return new Ember();
                case 53: return new Flamethrower();
                case 54: return new Mist();
                case 55: return new WaterGun();
                case 56: return new HydroPump();
                case 57: return new Surf();
                case 58: return new IceBeam();
                case 59: return new Blizzard();
                case 60: return new Psybeam();
                case 61: return new BubbleBeam();
                case 62: return new AuroraBeam();
                case 63: return new HyperBeam();
                case 64: return new Peck();
                case 65: return new DrillPeck();
                case 66: return new Submission();
                case 67: return new LowKick();
                case 68: return new Counter();
                case 69: return new SeismicToss();
                case 70: return new Strength();
                case 71: return new Absorb();
                case 72: return new MegaDrain();
                case 73: return new LeechSeed();
                case 74: return new Growth();
                case 75: return new RazorLeaf();
                case 76: return new SolarBeam();
                case 77: return new PoisonPowder();
                case 78: return new StunSpore();
                case 79: return new SleepPowder();
                case 80: return new PetalDance();
                case 81: return new StringShot();
                case 82: return new DragonRage();
                case 83: return new FireSpin();
                case 84: return new ThunderShock();
                case 85: return new Thunderbolt();
                case 86: return new ThunderWave();
                case 87: return new Thunder();
                case 88: return new RockThrow();
                case 89: return new Earthquake();
                case 90: return new Fissure();
                case 91: return new Dig();
                case 92: return new Toxic();
                case 93: return new Confusion();
                case 94: return new Psychic();
                case 95: return new Hypnosis();
                case 96: return new Meditate();
                case 97: return new Agility();
                case 98: return new QuickAttack();
                case 99: return new Rage();
                // case 100: move that ends battle
                case 101: return new NightShade();
                case 102: return new Mimic();
                case 103: return new Screech();
                case 104: return new DoubleTeam();
                case 105: return new Recover();
                case 106: return new Harden();
                case 107: return new Minimize();
                case 108: return new Smokescreen();
                case 109: return new ConfuseRay();
                case 110: return new Withdraw();
                case 111: return new DefenseCurl();
                case 112: return new Barrier();
                case 113: return new LightScreen();
                case 114: return new Haze();
                case 115: return new Reflect();
                case 116: return new FocusEnergy();
                case 117: return new Bide();
                case 118: return new Metronome();
                case 119: return new MirrorMove();
                case 120: return new Selfdestruct();
                case 121: return new EggBomb();
                case 122: return new Lick();
                case 123: return new Smog();
                case 124: return new Sludge();
                case 125: return new BoneClub();
                case 126: return new FireBlast();
                case 127: return new Waterfall();
                case 128: return new Clamp();
                case 129: return new Swift();
                case 130: return new SkullBash();
                case 131: return new SpikeCannon();
                case 132: return new Constrict();
                case 133: return new Amnesia();
                case 134: return new Kinesis();
                case 135: return new SoftBoiled();
                case 136: return new HiJumpKick();
                case 137: return new Glare();
                case 138: return new DreamEater();
                case 139: return new PoisonGas();
                case 140: return new Barrage();
                case 141: return new LeechLife();
                case 142: return new LovelyKiss();
                case 143: return new SkyAttack();
                case 144: return new Transform();
                case 145: return new Bubble();
                case 146: return new DizzyPunch();
                case 147: return new Spore();
                case 148: return new Flash();
                case 149: return new Psywave();
                case 150: return new Splash();
                case 151: return new AcidArmor();
                case 152: return new Crabhammer();
                case 153: return new Explosion();
                case 154: return new FurySwipes();
                case 155: return new Bonemerang();
                case 156: return new Rest();
                case 157: return new RockSlide();
                case 158: return new HyperFang();
                case 159: return new Sharpen();
                case 160: return new Conversion();
                case 161: return new TriAttack();
                case 162: return new SuperFang();
                case 163: return new Slash();
                case 164: return new Substitute();
                case 165: return new Struggle();
                default: return null;
            }
        }
    }
}
