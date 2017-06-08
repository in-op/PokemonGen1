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
                {
                    move = new Counter(true);
                }
                else
                {
                    move = CreateMove(rando);
                }
            }
            return move;
        }
        public static Move CreateMove(int moveIndex)
        {
            Move move = null;

            switch (moveIndex)
            {
                case 1:
                    move = new Pound();
                    break;
                case 2:
                    move = new KarateChop();
                    break;
                case 3:
                    move = new DoubleSlap();
                    break;
                case 4:
                    move = new CometPunch();
                    break;
                case 5:
                    move = new MegaPunch();
                    break;
                case 6:
                    move = new PayDay();
                    break;
                case 7:
                    move = new FirePunch();
                    break;
                case 8:
                    move = new IcePunch();
                    break;
                case 9:
                    move = new ThunderPunch();
                    break;
                case 10:
                    move = new Scratch();
                    break;
                case 11:
                    move = new ViceGrip();
                    break;
                case 12:
                    move = new Guillotine();
                    break;
                case 13:
                    move = new RazorWind();
                    break;
                case 14:
                    move = new SwordsDance();
                    break;
                case 15:
                    move = new Cut();
                    break;
                case 16:
                    move = new Gust();
                    break;
                case 17:
                    move = new WingAttack();
                    break;

                case 19:
                    move = new Fly();
                    break;
                case 20:
                    move = new Bind();
                    break;

                case 22:
                    move = new VineWhip();
                    break;
                case 23:
                    move = new Stomp();
                    break;
                case 24:
                    move = new DoubleKick();
                    break;
                case 25:
                    move = new MegaKick();
                    break;
                case 26:
                    move = new JumpKick();
                    break;
                case 27:
                    move = new RollingKick();
                    break;
                case 28:
                    move = new SandAttack();
                    break;
                case 29:
                    move = new Headbutt();
                    break;
                case 30:
                    move = new HornAttack();
                    break;
                case 31:
                    move = new FuryAttack();
                    break;
                case 32:
                    move = new HornDrill();
                    break;
                case 33:
                    move = new Tackle();
                    break;
                case 34:
                    move = new BodySlam();
                    break;
                case 35:
                    move = new Wrap();
                    break;
                case 36:
                    move = new TakeDown();
                    break;
                case 37:
                    move = new Thrash();
                    break;
                case 38:
                    move = new DoubleEdge();
                    break;
                case 39:
                    move = new TailWhip();
                    break;
                case 40:
                    move = new PoisonSting();
                    break;
                case 41:
                    move = new Twineedle();
                    break;
                case 42:
                    move = new PinMissile();
                    break;
                case 43:
                    move = new Leer();
                    break;
                case 44:
                    move = new Bite();
                    break;
                case 45:
                    move = new Growl();
                    break;

                case 47:
                    move = new Sing();
                    break;
                case 48:
                    move = new Supersonic();
                    break;
                case 49:
                    move = new SonicBoom();
                    break;
                case 50:
                    move = new Disable();
                    break;
                case 51:
                    move = new Acid();
                    break;
                case 52:
                    move = new Ember();
                    break;
                case 53:
                    move = new Flamethrower();
                    break;
                case 54:
                    move = new Mist();
                    break;
                case 55:
                    move = new WaterGun();
                    break;
                case 56:
                    move = new HydroPump();
                    break;
                case 57:
                    move = new Surf();
                    break;
                case 58:
                    move = new IceBeam();
                    break;
                case 59:
                    move = new Blizzard();
                    break;
                case 60:
                    move = new Psybeam();
                    break;
                case 61:
                    move = new BubbleBeam();
                    break;
                case 62:
                    move = new AuroraBeam();
                    break;
                case 63:
                    move = new HyperBeam();
                    break;
                case 64:
                    move = new Peck();
                    break;
                case 65:
                    move = new DrillPeck();
                    break;
                case 66:
                    move = new Submission();
                    break;
                case 67:
                    move = new LowKick();
                    break;
                case 68:
                    move = new Counter();
                    break;
                case 69:
                    move = new SeismicToss();
                    break;
                case 70:
                    move = new Strength();
                    break;
                case 71:
                    move = new Absorb();
                    break;
                case 72:
                    move = new MegaDrain();
                    break;
                case 73:
                    move = new LeechSeed();
                    break;
                case 74:
                    move = new Growth();
                    break;
                case 75:
                    move = new RazorLeaf();
                    break;
                case 76:
                    move = new SolarBeam();
                    break;
                case 77:
                    move = new PoisonPowder();
                    break;
                case 78:
                    move = new StunSpore();
                    break;
                case 79:
                    move = new SleepPowder();
                    break;
                case 80:
                    move = new PetalDance();
                    break;
                case 81:
                    move = new StringShot();
                    break;
                case 82:
                    move = new DragonRage();
                    break;
                case 83:
                    move = new FireSpin();
                    break;
                case 84:
                    move = new ThunderShock();
                    break;
                case 85:
                    move = new Thunderbolt();
                    break;
                case 86:
                    move = new ThunderWave();
                    break;
                case 87:
                    move = new Thunder();
                    break;
                case 88:
                    move = new RockThrow();
                    break;
                case 89:
                    move = new Earthquake();
                    break;
                case 90:
                    move = new Fissure();
                    break;
                case 91:
                    move = new Dig();
                    break;
                case 92:
                    move = new Toxic();
                    break;
                case 93:
                    move = new Confusion();
                    break;
                case 94:
                    move = new Psychic();
                    break;
                case 95:
                    move = new Hypnosis();
                    break;
                case 96:
                    move = new Meditate();
                    break;
                case 97:
                    move = new Agility();
                    break;
                case 98:
                    move = new QuickAttack();
                    break;
                case 99:
                    move = new Rage();
                    break;

                case 101:
                    move = new NightShade();
                    break;
                case 102:
                    move = new Mimic();
                    break;
                case 103:
                    move = new Screech();
                    break;
                case 104:
                    move = new DoubleTeam();
                    break;
                case 105:
                    move = new Recover();
                    break;
                case 106:
                    move = new Harden();
                    break;
                case 107:
                    move = new Minimize();
                    break;
                case 108:
                    move = new Smokescreen();
                    break;
                case 109:
                    move = new ConfuseRay();
                    break;
                case 110:
                    move = new Withdraw();
                    break;
                case 111:
                    move = new DefenseCurl();
                    break;
                case 112:
                    move = new Barrier();
                    break;
                case 113:
                    move = new LightScreen();
                    break;
                case 114:
                    move = new Haze();
                    break;
                case 115:
                    move = new Reflect();
                    break;
                case 116:
                    move = new FocusEnergy();
                    break;
                case 117:
                    move = new Bide();
                    break;
                case 118:
                    move = new Metronome();
                    break;
                case 119:
                    move = new MirrorMove();
                    break;
                case 120:
                    move = new Selfdestruct();
                    break;
                case 121:
                    move = new EggBomb();
                    break;
                case 122:
                    move = new Lick();
                    break;
                case 123:
                    move = new Smog();
                    break;
                case 124:
                    move = new Sludge();
                    break;
                case 125:
                    move = new BoneClub();
                    break;
                case 126:
                    move = new FireBlast();
                    break;
                case 127:
                    move = new Waterfall();
                    break;
                case 128:
                    move = new Clamp();
                    break;
                case 129:
                    move = new Swift();
                    break;
                case 130:
                    move = new SkullBash();
                    break;
                case 131:
                    move = new SpikeCannon();
                    break;
                case 132:
                    move = new Constrict();
                    break;
                case 133:
                    move = new Amnesia();
                    break;
                case 134:
                    move = new Kinesis();
                    break;
                case 135:
                    move = new SoftBoiled();
                    break;
                case 136:
                    move = new HiJumpKick();
                    break;
                case 137:
                    move = new Glare();
                    break;
                case 138:
                    move = new DreamEater();
                    break;
                case 139:
                    move = new PoisonGas();
                    break;
                case 140:
                    move = new Barrage();
                    break;
                case 141:
                    move = new LeechLife();
                    break;
                case 142:
                    move = new LovelyKiss();
                    break;
                case 143:
                    move = new SkyAttack();
                    break;
                case 144:
                    move = new Transform();
                    break;
                case 145:
                    move = new Bubble();
                    break;
                case 146:
                    move = new DizzyPunch();
                    break;
                case 147:
                    move = new Spore();
                    break;
                case 148:
                    move = new Flash();
                    break;
                case 149:
                    move = new Psywave();
                    break;
                case 150:
                    move = new Splash();
                    break;
                case 151:
                    move = new AcidArmor();
                    break;
                case 152:
                    move = new Crabhammer();
                    break;
                case 153:
                    move = new Explosion();
                    break;
                case 154:
                    move = new FurySwipes();
                    break;
                case 155:
                    move = new Bonemerang();
                    break;
                case 156:
                    move = new Rest();
                    break;
                case 157:
                    move = new RockSlide();
                    break;
                case 158:
                    move = new HyperFang();
                    break;
                case 159:
                    move = new Sharpen();
                    break;
                case 160:
                    move = new Conversion();
                    break;
                case 161:
                    move = new TriAttack();
                    break;
                case 162:
                    move = new SuperFang();
                    break;
                case 163:
                    move = new Slash();
                    break;
                case 164:
                    move = new Substitute();
                    break;
                case 165:
                    move = new Struggle();
                    break;
            }

            return move;
        }
    }
}
