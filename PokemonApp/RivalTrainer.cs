﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class RivalTrainer : PokemonTrainer
    {
        public int Level { get; }
        public int MoneyRewarded => (int)Math.Pow(this.Level * 8, 2);
        
        public RivalTrainer(string name, int level) : base(name)
        {
            this.Name = name;
            this.Level = level;
        }

        public void Introduction(PokemonTrainer userTrainer)
        {
            Console.WriteLine($"{this.Name}: I've been waiting to battle you ever since you took my Popokénom, {userTrainer.Name}.");
            Console.WriteLine($"{this.Name}: I was supposed to get {userTrainer.StarterPokemon}, but Grandpa gave the last one to some stranger.");
            Console.WriteLine($"{this.Name}: That's okay because {this.StarterPokemon} and I have been getting along.");
            Console.WriteLine($"{this.Name}: Prepare for battle!");
        }

        public void SetPokemons(string userStarterPokemon)
        {
            int pokemonLevel = this.Level * 10;

            // Set starter pokemon
            if (userStarterPokemon == "Bulbasaur") { this.CaptivePokemons.Add(new Pokemon("Charmander", pokemonLevel)); }
            else if (userStarterPokemon == "Charmander") { this.CaptivePokemons.Add(new Pokemon("Squirtle", pokemonLevel)); }
            else { this.CaptivePokemons.Add(new Pokemon("Bulbasaur", pokemonLevel)); }
            this.StarterPokemon = this.CaptivePokemons[0].Name;

            if (this.Level == 9)
            {
                for (int i = 0; i < 5; i++) { this.CaptivePokemons.Add(new Pokemon("Magikarp", pokemonLevel)); }
            }
            else if (this.Level > 3)
            {
                for (int i = 0; i < 2; i++) { this.CaptivePokemons.Add(new Pokemon("Magikarp", pokemonLevel)); }
                for (int i = 0; i < 3; i++)
                {
                    this.CaptivePokemons.Add(new Pokemon(GetNonMagikarpPokemon(), pokemonLevel));
                }
            }
            else if (this.Level > 0)
            {
                for (int i = 0; i < 2; i++) { this.CaptivePokemons.Add(new Pokemon(GetNonMagikarpPokemon(), pokemonLevel)); }
            }

        }

        public static string GetNonMagikarpPokemon()
        {
            string randomPokemonName = Pokemons.GetRandomPokemon();
            // Makes sure no more Magikarps are added
            while (randomPokemonName == "Magikarp")
            {
                randomPokemonName = Pokemons.GetRandomPokemon();
            }
            return randomPokemonName;
        }
    }
}
