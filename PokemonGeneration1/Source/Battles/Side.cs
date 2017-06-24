using PokemonGeneration1.Source.PokemonData;
using PokemonGeneration1.Source.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.Battles
{
    public abstract class Side
    {
        protected Selection Selection;
        protected BattlePokemon CurrentBattlePokemon;
        protected int FleeAttempts;
        


        public abstract string GetName();
        public abstract bool IsDefeated();
        public bool IsPokemonFainted() { return this.CurrentBattlePokemon.IsFainted(); }

        
        public BattlePokemon GetCurrentBattlePokemon() { return CurrentBattlePokemon; }



        public void ExecuteSelection()
        {
            Selection.Execute();
        }



        public void SetSelection(Selection selection)
        {
            this.Selection = selection;
        }



        public int GetSelectionPriority()
        {
            return Selection.GetPriority();
        }
        
    }

    public sealed class WildPokemonSide : Side
    {
        public WildPokemonSide(Pokemon pokemon) : base()
        {
            this.CurrentBattlePokemon = new BattlePokemon(pokemon);
        }


        public sealed override bool IsDefeated()
        {
            return CurrentBattlePokemon.IsFainted();
        }

        public sealed override string GetName()
        {
            return "Wild Pokemon";
        }
    }

    public class TrainerSide : Side
    {
        Trainer Trainer;

        public TrainerSide(Trainer trainer) : base()
        {
            this.Trainer = trainer;
            this.CurrentBattlePokemon = new BattlePokemon(Trainer.GetParty()[0]);
        }


        public sealed override bool IsDefeated()
        {
            List<Pokemon> party = Trainer.GetParty();
            foreach (Pokemon poke in party)
            {
                if (poke.Status != Status.Fainted) return false;
            }
            return true;
        }

        public sealed override string GetName()
        {
            return Trainer.GetName();
        }
    }
}
