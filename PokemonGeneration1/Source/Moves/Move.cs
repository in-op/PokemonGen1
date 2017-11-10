using PokemonGeneration1.Source.Battles;
using MonteCarloPlayer;
using System;

namespace PokemonGeneration1.Source.Moves
{
    public abstract class Move : IEquatable<Move>, Copyable<Move>
    {
        public int Index { get; }
        public string Name { get; }
        public Type Type { get; }
        public int Priority { get; }
        public Category Category { get; }
        public int AbsoluteMaxPP { get; }

        public int CurrentPP;
        public int MaxPP { get; private set; }
        
        protected MoveEventArgs EventArgs;




        public abstract void ExecuteAndUpdate(BattlePokemon user, BattlePokemon defender);
        public virtual void Abort() { }
        public virtual void IfActiveDisruptThrashingMove(BattlePokemon user) { }



        public Action<Move> Used;
        public Action<Move> Failed;
        public Action<Move> Missed;
        public Action<Move> NoEffect;
        public Action<Move> SuperEffective;
        public Action<Move> NotVeryEffective;
        public Action<Move> CriticalHit;
        public Action<Move> OneHitKO;
        public Action<Move> PayDayTriggered;
        public Action<Move> SolarBeamFirstTurn;
        public Action<Move> RazorWindFirstTurn;
        public Action<Move> BidingTime;
        public Action<Move> BideUnleased;
        public Action<Move> FlyFirstTurn;
        public Action<Move> AttackContinues;
        public Action<Move> CrashDamage;
        public Action<Move> HurtByRecoilDamage;
        public Action<Move> ThrashingAbout;
        public Action<Move> HyperBeamRecharging;
        public Action<Move> SuckedHealth;
        public Action<Move> DugAHole;
        public Action<Move> SkullBashFirstTurn;
        public Action<Move> SkyAttackFirstTurn;
        public Action<Move> RegainedHealth;
        protected void OnUsed() => Used?.Invoke(this);
        protected void OnFailed() => Failed?.Invoke(this);
        protected void OnMissed() => Missed?.Invoke(this);
        protected void OnNoEffect() => NoEffect?.Invoke(this);
        protected void OnSuperEffective() => SuperEffective?.Invoke(this);
        protected void OnNotVeryEffective() => NotVeryEffective?.Invoke(this);
        protected void OnCriticalHit() => CriticalHit?.Invoke(this);
        protected void OnOneHitKO() => OneHitKO?.Invoke(this);
        protected void OnPayDayTriggered() => PayDayTriggered?.Invoke(this);
        protected void OnSolarBeamFirstTurn() => SolarBeamFirstTurn?.Invoke(this);
        protected void OnRazorWindFirstTurn() => RazorWindFirstTurn?.Invoke(this);
        protected void OnBidingTime() => BidingTime?.Invoke(this);
        protected void OnBideUnleased() => BideUnleased?.Invoke(this);
        protected void OnFlyFirstTurn() => FlyFirstTurn?.Invoke(this);
        protected void OnAttackContinues() => AttackContinues?.Invoke(this);
        protected void OnCrashDamage() => CrashDamage?.Invoke(this);
        protected void OnHurtByRecoilDamage() => HurtByRecoilDamage?.Invoke(this);
        protected void OnThrashingAbout() => ThrashingAbout?.Invoke(this);
        protected void OnHyperBeamRecharging() => HyperBeamRecharging?.Invoke(this);
        protected void OnSuckedHealth() => SuckedHealth?.Invoke(this);
        protected void OnDugAHole() => DugAHole?.Invoke(this);
        protected void OnSkullBashFirstTurn() => SkullBashFirstTurn?.Invoke(this);
        protected void OnSkyAttackFirstTurn() => SkyAttackFirstTurn?.Invoke(this);
        protected void OnRegainedHealth() => RegainedHealth?.Invoke(this);




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
            EventArgs = new MoveEventArgs() { move = this };
        }




        public sealed override bool Equals(object obj) =>
            (obj == null || GetType() != obj.GetType()) ? false : Equals((Move)obj);

        public bool Equals(Move other) =>
            (other == null) ? false : Index == other.Index;

        public sealed override int GetHashCode() => Index;




        public Move DeepCopy()
        {
            Move copy = MoveFactory.Create(Index);
            CopyTo(copy);
            return copy;
        }

        public void CopyTo(Move other)
        {
            other.CurrentPP = CurrentPP;
            //other.MaxPP = MaxPP; // strictly necessary to be correct, but irrelevant for app
        }
    }
}
