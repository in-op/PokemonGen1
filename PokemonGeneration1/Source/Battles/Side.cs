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

        public abstract string Name { get; }
        public abstract List<Pokemon> Party { get; }
        

        
        public abstract bool IsDefeated();
        public bool IsPokemonFainted() { return CurrentBattlePokemon.IsFainted(); }

        
        public BattlePokemon GetCurrentBattlePokemon() { return CurrentBattlePokemon; }



        public void ExecuteSelection()
        {
            Selection.Execute();
        }



        public void SetSelection(Selection selection)
        {
            Selection = selection;
        }



        public int GetSelectionPriority()
        {
            return Selection.Priority;
        }
        
    }




    public sealed class WildPokemonSide : Side
    {
        private Pokemon pokemon;

        public WildPokemonSide(Pokemon pokemon) : base()
        {
            CurrentBattlePokemon = new BattlePokemon(pokemon);
            this.pokemon = pokemon;
        }


        public sealed override bool IsDefeated()
        {
            return CurrentBattlePokemon.IsFainted();
        }


        public sealed override string Name
            =>  "Wild Pokemon";

        public sealed override List<Pokemon> Party
            => new List<Pokemon>() { pokemon };
    }





    public class TrainerSide : Side
    {
        Trainer Trainer;

        public TrainerSide(Trainer trainer) : base()
        {
            Trainer = trainer;
            CurrentBattlePokemon = new BattlePokemon(Trainer.Party()[0]);
        }


        public sealed override bool IsDefeated()
        {
            foreach (Pokemon poke in Trainer.Party())
                if (poke.Status != Status.Fainted)
                    return false;
            return true;
        }


        public sealed override string Name
            => Trainer.Name;

        public sealed override List<Pokemon> Party
            => Trainer.Party();
    }




}
