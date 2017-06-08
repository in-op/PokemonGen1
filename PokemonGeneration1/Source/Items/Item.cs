using PokemonGeneration1.Source.PokemonData;
using System;
using static PokemonGeneration1.Source.PokemonData.Status;

namespace PokemonGeneration1.Source.Items
{
    public abstract class Item : IEquatable<Item>
    {
        public string Name { get; }

        protected Item(string name)
        {
            Name = name;
        }

        public bool Equals(Item other)
        {
            if (other == null) return false;
            return Name == other.Name;
        }

        public sealed override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return Equals((Item)obj);
        }

        public static bool operator ==(Item first, Item second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Item first, Item second)
        {
            return !first.Equals(second);
        }
    }
    
    



    public abstract class Ball : Item
    {
        public abstract CaptureData Catch(Pokemon poke);

        protected CaptureData Catch(Pokemon poke, int maxN, float fModifier)
        {
            Random rng = new Random();
            float N = rng.Next(0, maxN + 1);
            float threshold = 0f;
            Status status = poke.Status;
            if (status == SLEEP || status == FREEZE) threshold = 25f;
            if (status == PARALYSIS || status == BURN || status == POISON || status == BADLYPOISONED) threshold = 15f;

            if (N < threshold) return CaptureData.Captured;

            float f = (float)Math.Floor(
                      (poke.HPStat * 255f * 4f) /
                      (poke.HP * fModifier));
            if (f < 1f) f = 1f;
            if (f > 255f) f = 255f;

            if (!(N - threshold > poke.CatchRate) &&
               (f >= rng.Next(0, 256)))
            {
                return CaptureData.Captured;
            }

            //pokemon broke free
            float d = (float) Math.Floor(
                      poke.CatchRate * 100f / maxN);
            if (d >= 256f) return CaptureData.Free3Shake;

            float s = 0f;
            if (status == SLEEP || status == FREEZE) s = 10f;
            if (status == PARALYSIS || status == BURN || status == POISON || status == BADLYPOISONED) s = 5f;
            float x = (float)Math.Floor((d * f / 255f)) + s;

            if (x < 10f) return CaptureData.FreeMissed;
            if (x < 30f) return CaptureData.Free1Shake;
            if (x < 70f) return CaptureData.Free2Shake;
            return CaptureData.Free3Shake;
        }

        protected Ball(string name) : base(name) { }
    }

    public sealed class CaptureData
    {
        public readonly bool captured;
        public readonly int shakes;

        public static readonly CaptureData Captured = new CaptureData(true, 3);
        public static readonly CaptureData FreeMissed = new CaptureData(false, 0);
        public static readonly CaptureData Free1Shake = new CaptureData(false, 1);
        public static readonly CaptureData Free2Shake = new CaptureData(false, 2);
        public static readonly CaptureData Free3Shake = new CaptureData(false, 3);
        
        private CaptureData(bool captured, int shakes)
        {
            this.captured = captured;
            this.shakes = shakes;
        }

        private CaptureData() { }
    }

    public sealed class MasterBall : Ball
    {
        public static readonly MasterBall instance = new MasterBall();

        public sealed override CaptureData Catch(Pokemon poke) => CaptureData.Captured;

        private MasterBall() : base("Master Ball") { }
    }

    public sealed class PokeBall : Ball
    {
        public static readonly PokeBall instance = new PokeBall();

        public sealed override CaptureData Catch(Pokemon poke) => Catch(poke, 255, 12f);

        private PokeBall() : base("Pokeball") { }
    }

    public sealed class GreatBall : Ball
    {
        public static readonly GreatBall instance = new GreatBall();

        public sealed override CaptureData Catch(Pokemon poke) => Catch(poke, 200, 8f);

        private GreatBall() : base("Great Ball") { }
    }

    public sealed class UltraBall : Ball
    {
        public static readonly UltraBall instance = new UltraBall();
         
        public sealed override CaptureData Catch(Pokemon poke) => Catch(poke, 150, 12f);

        private UltraBall() : base("Ultra Ball") { }
    }








    public abstract class Stone : Item
    {
        public abstract StoneAttemptData AttemptUseOn(Pokemon poke);

        protected Stone(string name) : base(name) { }
    }
    
    public sealed class StoneAttemptData
    {
        public readonly bool works;
        public readonly int evolveToIndex;

        public StoneAttemptData(bool works, int evolveToIndex)
        {
            this.works = works;
            this.evolveToIndex = evolveToIndex;
        }
    }

    public sealed class MoonStone : Stone
    {
        public static readonly MoonStone instance = new MoonStone();

        public sealed override StoneAttemptData AttemptUseOn(Pokemon poke)
        {
            int num = poke.Number;
            if (num == 30) return new StoneAttemptData(true, 31);
            if (num == 33) return new StoneAttemptData(true, 34);
            if (num == 35) return new StoneAttemptData(true, 36);
            if (num == 39) return new StoneAttemptData(true, 40);
            return new StoneAttemptData(false, 0);
        }

        private MoonStone() : base("Moon Stone") { }
    }

    public sealed class FireStone : Stone
    {
        public static readonly FireStone instance = new FireStone();

        public sealed override StoneAttemptData AttemptUseOn(Pokemon poke)
        {
            int num = poke.Number;
            if (num == 37) return new StoneAttemptData(true, 38);
            if (num == 58) return new StoneAttemptData(true, 59);
            if (num == 133) return new StoneAttemptData(true, 136);
            return new StoneAttemptData(false, 0);
        }

        private FireStone() : base("Fire Stone") { }
    }

    public sealed class WaterStone : Stone
    {
        public static readonly WaterStone instance = new WaterStone();

        public sealed override StoneAttemptData AttemptUseOn(Pokemon poke)
        {
            int num = poke.Number;
            if (num == 61) return new StoneAttemptData(true, 62);
            if (num == 90) return new StoneAttemptData(true, 91);
            if (num == 120) return new StoneAttemptData(true, 121);
            if (num == 133) return new StoneAttemptData(true, 134);
            return new StoneAttemptData(false, 0);
        }

        private WaterStone() : base("Water Stone") { }
    }

    public sealed class ThunderStone : Stone
    {
        public static readonly ThunderStone instance = new ThunderStone();

        public sealed override StoneAttemptData AttemptUseOn(Pokemon poke)
        {
            int num = poke.Number;
            if (num == 25) return new StoneAttemptData(true, 26);
            if (num == 133) return new StoneAttemptData(true, 135);
            return new StoneAttemptData(false, 0);
        }

        private ThunderStone() : base("Thunder Stone") { }
    }

    public sealed class LeafStone : Stone
    {
        public static readonly LeafStone instance = new LeafStone();

        public sealed override StoneAttemptData AttemptUseOn(Pokemon poke)
        {
            int num = poke.Number;
            if (num == 44) return new StoneAttemptData(true, 45);
            if (num == 70) return new StoneAttemptData(true, 71);
            if (num == 102) return new StoneAttemptData(true, 103);
            return new StoneAttemptData(false, 0);
        }

        private LeafStone() : base("Leaf Stone") { }
    }







    public abstract class BattleItem : Item
    {
        public abstract void UseOn(Pokemon p);

        public abstract bool CanUseOn(Pokemon p);

        protected BattleItem(string name) : base(name) { }
    }



    public abstract class Healer : BattleItem
    {
        public sealed override bool CanUseOn(Pokemon p)
        {
            return p.HP < p.HPStat;
        }

        protected Healer(string name) : base(name) { }
    }

    public sealed class Potion : Healer
    {
        public static readonly Potion instance = new Potion();

        public sealed override void UseOn(Pokemon p)
        {
            p.RestoreHP(20f);
        }

        private Potion() : base("Potion") { }
    }

    public sealed class SuperPotion : Healer
    {
        public static readonly SuperPotion instance = new SuperPotion();

        public sealed override void UseOn(Pokemon p)
        {
            p.RestoreHP(50f);
        }

        private SuperPotion() : base("Super Potion") { }
    }

    public sealed class HyperPotion : Healer
    {
        public static readonly HyperPotion instance = new HyperPotion();

        public sealed override void UseOn(Pokemon p)
        {
            p.RestoreHP(200f);
        }

        private HyperPotion() : base("Hyper Potion") { }
    }

    public sealed class MaxPotion : Healer
    {
        public static readonly MaxPotion instance = new MaxPotion();

        public sealed override void UseOn(Pokemon p)
        {
            p.RestoreHP(999999999f);
        }

        private MaxPotion() : base("Hyper Potion") { }
    }

    public sealed class FreshWater : Healer
    {
        public static readonly FreshWater instance = new FreshWater();

        public sealed override void UseOn(Pokemon p)
        {
            p.RestoreHP(50f);
        }

        private FreshWater() : base("Fresh Water") { }
    }

    public sealed class SodaPop : Healer
    {
        public static readonly SodaPop instance = new SodaPop();

        public sealed override void UseOn(Pokemon p)
        {
            p.RestoreHP(60f);
        }

        private SodaPop() : base("Soda Pop") { }
    }

    public sealed class Lemonade : Healer
    {
        public static readonly Lemonade instance = new Lemonade();

        public sealed override void UseOn(Pokemon p)
        {
            p.RestoreHP(80f);
        }

        private Lemonade() : base("Lemonade") { }
    }

    public sealed class FullRestore : BattleItem
    {
        public static readonly FullRestore instance = new FullRestore();

        public sealed override void UseOn(Pokemon p)
        {
            p.RestoreHP(999999999f);
            p.ClearStatus();
        }

        public sealed override bool CanUseOn(Pokemon p)
        {
            return p.HP < p.HPStat ||
                   p.Status != Status.NONE;
        }

        private FullRestore() : base("Full Restore") { }
    }



    public abstract class StatusHealer : BattleItem
    {
        public sealed override void UseOn(Pokemon p)
        {
            p.ClearStatus();
        }

        protected StatusHealer(string name) : base(name) { }
    }

    public sealed class Antidote : StatusHealer
    {
        public static readonly Antidote instance = new Antidote();

        public sealed override bool CanUseOn(Pokemon p)
        {
            return p.Status == POISON ||
                   p.Status == BADLYPOISONED;
        }

        private Antidote() : base("Antidote") { }
    }

    public sealed class ParalyzeHeal : StatusHealer
    {
        public static readonly ParalyzeHeal instance = new ParalyzeHeal();

        public sealed override bool CanUseOn(Pokemon p)
        {
            return p.Status == PARALYSIS;
        }

        private ParalyzeHeal() : base("Paralyze Heal") { }
    }

    public sealed class Awakening : StatusHealer
    {
        public static readonly Awakening instance = new Awakening();

        public sealed override bool CanUseOn(Pokemon p)
        {
            return p.Status == SLEEP;
        }

        private Awakening() : base("Awakening") { }
    }

    public sealed class BurnHeal : StatusHealer
    {
        public static readonly BurnHeal instance = new BurnHeal();

        public sealed override bool CanUseOn(Pokemon p)
        {
            return p.Status == BURN;
        }

        private BurnHeal() : base("Burn Heal") { }
    }

    public sealed class IceHeal : StatusHealer
    {
        public static readonly IceHeal instance = new IceHeal();

        public sealed override bool CanUseOn(Pokemon p)
        {
            return p.Status == FREEZE;
        }

        private IceHeal() : base("Ice Heal") { }
    }

    public sealed class FullHeal : StatusHealer
    {
        public static readonly FullHeal instance = new FullHeal();

        public sealed override bool CanUseOn(Pokemon p)
        {
            return p.Status != NONE;
        }

        private FullHeal() : base("Full Heal") { }
    }


}
