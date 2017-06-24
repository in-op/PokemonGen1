using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonGeneration1.Source.PokemonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGeneration1.Source.PokemonData.Tests
{
    [TestClass()]
    public class PokemonInitializationTests
    {
        [TestMethod()]
        public void ExpGroupEdgeCases()
        {
            ExperienceGroup noPokemon = PokemonInitialization.ExpGroup(0);
            ExperienceGroup bulbasaur = PokemonInitialization.ExpGroup(1);
            ExperienceGroup mewtwo = PokemonInitialization.ExpGroup(150);
            ExperienceGroup mew = PokemonInitialization.ExpGroup(151);

            Assert.AreEqual(ExperienceGroup.Fast, noPokemon);
            Assert.AreEqual(ExperienceGroup.MediumSlow, bulbasaur);
            Assert.AreEqual(ExperienceGroup.Slow, mewtwo);
            Assert.AreEqual(ExperienceGroup.MediumSlow, mew);
        }
    }
}