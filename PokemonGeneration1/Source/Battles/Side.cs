using PokemonGeneration1.Source.PokemonData;
using PokemonGeneration1.Source.Trainers;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PokemonGeneration1.Source.Battles
{
    public abstract class Side
    {
        protected Selection Selection;
        protected int FleeAttempts;

        public abstract string Name { get; }
        public abstract List<Pokemon> Party { get; }
        public abstract bool IsDefeated { get; }

        public BattlePokemon BattlePokemon { get; }


        public int SelectionPriority => Selection.Priority;


        public void ExecuteSelection()
        {
            Selection.Execute();
        }

        public void SetSelection(Selection selection)
        {
            Selection = selection;
        }

        public bool IsPokemonFainted()
        {
            return BattlePokemon.IsFainted;
        }

        protected Side(BattlePokemon battlePokemon)
        {
            BattlePokemon = battlePokemon;
        }
    }




    public sealed class WildPokemonSide : Side
    {
        private Pokemon pokemon;


        public WildPokemonSide(Pokemon pokemon) :
            base(new BattlePokemon(pokemon))
        {
            this.pokemon = pokemon;
        }

        public sealed override bool IsDefeated
            => BattlePokemon.IsFainted;

        public sealed override string Name
            =>  "Wild Pokemon";

        public sealed override List<Pokemon> Party
            => new List<Pokemon>(1) { pokemon };
    }





    public class TrainerSide : Side
    {
        Trainer Trainer;

        public TrainerSide(Trainer trainer) :
            base(new BattlePokemon(trainer.Party()[0]))
        {
            Trainer = trainer;
        }

        
        public sealed override bool IsDefeated
            => Trainer.Party().All(p => p.Status == Status.Fainted);

        public sealed override string Name
            => Trainer.Name;

        public sealed override List<Pokemon> Party
            => Trainer.Party();
    }




}
