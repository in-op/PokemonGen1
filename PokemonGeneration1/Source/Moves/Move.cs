using PokemonGeneration1.Source.Battles;
using System;

namespace PokemonGeneration1.Source.Moves
{
    public abstract class Move : IEquatable<Move>
    {
        public int Index { get; }
        public string Name { get; }
        public Type Type { get; }
        public int Priority { get; }
        public Category Category { get; }
        public int AbsoluteMaxPP { get; }

        public int CurrentPP { get; private set; }
        public int MaxPP { get; private set; }
        
        protected MoveEventArgs EventArgs;




        public abstract void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender);
        public virtual void Abort() { }
        public virtual void IfActiveDisruptThrashingMove(BattlePokemon user) { }




        public event EventHandler<MoveEventArgs> Used;
        public event EventHandler<MoveEventArgs> Failed;
        public event EventHandler<MoveEventArgs> Missed;
        public event EventHandler<MoveEventArgs> NoEffect;
        public event EventHandler<MoveEventArgs> SuperEffective;
        public event EventHandler<MoveEventArgs> NotVeryEffective;
        public event EventHandler<MoveEventArgs> CriticalHit;
        public event EventHandler<MoveEventArgs> OneHitKO;
        public event EventHandler<MoveEventArgs> PayDayTriggered;
        public event EventHandler<MoveEventArgs> SolarBeamFirstTurn;
        public event EventHandler<MoveEventArgs> RazorWindFirstTurn;
        public event EventHandler<MoveEventArgs> BidingTime;
        public event EventHandler<MoveEventArgs> BideUnleased;
        public event EventHandler<MoveEventArgs> FlyFirstTurn;
        public event EventHandler<MoveEventArgs> AttackContinues;
        public event EventHandler<MoveEventArgs> CrashDamage;
        public event EventHandler<MoveEventArgs> HurtByRecoilDamage;
        public event EventHandler<MoveEventArgs> ThrashingAbout;
        public event EventHandler<MoveEventArgs> HyperBeamRecharging;
        public event EventHandler<MoveEventArgs> SuckedHealth;
        public event EventHandler<MoveEventArgs> DugAHole;
        public event EventHandler<MoveEventArgs> SkullBashFirstTurn;
        public event EventHandler<MoveEventArgs> SkyAttackFirstTurn;
        public event EventHandler<MoveEventArgs> RegainedHealth;
        protected virtual void OnUsed()
        {
            Used?.Invoke(this, EventArgs);
        }
        protected virtual void OnMissed()
        {
            Missed?.Invoke(this, EventArgs);
        }
        protected virtual void OnFailed()
        {
            Failed?.Invoke(this, EventArgs);
        }
        protected virtual void OnNoEffect()
        {
            NoEffect?.Invoke(this, EventArgs);
        }
        protected virtual void OnSuperEffective()
        {
            SuperEffective?.Invoke(this, EventArgs);
        }
        protected virtual void OnNotVeryEffective()
        {
            NotVeryEffective?.Invoke(this, EventArgs);
        }
        protected virtual void OnCriticalHit()
        {
            CriticalHit?.Invoke(this, EventArgs);
        }
        protected virtual void OnOneHitKO()
        {
            OneHitKO?.Invoke(this, EventArgs);
        }
        protected virtual void OnPayDayTriggered()
        {
            PayDayTriggered?.Invoke(this, EventArgs);
        }
        protected virtual void OnSolarBeamFirstTurn()
        {
            SolarBeamFirstTurn?.Invoke(this, EventArgs);
        }
        protected virtual void OnRazorWindFirstTurn()
        {
            RazorWindFirstTurn?.Invoke(this, EventArgs);
        }
        protected virtual void OnBidingTime()
        {
            BidingTime?.Invoke(this, EventArgs);
        }
        protected virtual void OnBideUnleased()
        {
            BideUnleased?.Invoke(this, EventArgs);
        }
        protected virtual void OnFlyFirstTurn()
        {
            FlyFirstTurn?.Invoke(this, EventArgs);
        }
        protected virtual void OnAttackContinues()
        {
            AttackContinues?.Invoke(this, EventArgs);
        }
        protected virtual void OnCrashDamage()
        {
            CrashDamage?.Invoke(this, EventArgs);
        }
        protected virtual void OnHurtByRecoilDamage()
        {
            HurtByRecoilDamage?.Invoke(this, EventArgs);
        }
        protected virtual void OnThrashingAbout()
        {
            ThrashingAbout?.Invoke(this, EventArgs);
        }
        protected virtual void OnHyperBeamRecharging()
        {
            HyperBeamRecharging?.Invoke(this, EventArgs);
        }
        protected virtual void OnSuckedHealth()
        {
            SuckedHealth?.Invoke(this, EventArgs);
        }
        protected virtual void OnDugAHole()
        {
            DugAHole?.Invoke(this, EventArgs);
        }
        protected virtual void OnSkullBashFirstTurn()
        {
            SkullBashFirstTurn?.Invoke(this, EventArgs);
        }
        protected virtual void OnSkyAttackFirstTurn()
        {
            SkyAttackFirstTurn?.Invoke(this, EventArgs);
        }
        protected virtual void OnRegainedHealth()
        {
            RegainedHealth?.Invoke(this, EventArgs);
        }




        public void SubtractPP(int amount)
        {
            CurrentPP -= amount;
            if (CurrentPP < 0) CurrentPP = 0;
        }

        

        protected Move(
            int index,
            string name,
            Type type,
            int startingPP,
            int absoluteMaxPP,
            int priority,
            Category category)
        {
            Index = index;
            Name = name;
            Type = type;
            CurrentPP = startingPP;
            MaxPP = startingPP;
            AbsoluteMaxPP = absoluteMaxPP;
            Priority = priority;
            Category = category;
            EventArgs = new MoveEventArgs();
            EventArgs.move = this;
        }




        public sealed override bool Equals(object obj)
        {
            return (obj == null || GetType() != obj.GetType()) ?
                false : Equals((Move)obj);
        }

        public bool Equals(Move other)
        {
            if (other == null) return false;
            return Index == other.Index;
        }

        public sealed override int GetHashCode()
        {
            return Index;
        }


    }
}
