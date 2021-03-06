﻿using System;
using System.Collections.Generic;

namespace PokemonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PokemonTrainer userTrainer = new PokemonTrainer(null);
            int titleMenuInput = Menu.GetUserInputIndex(new List<string> { "New Game", "Load" }, false);

            switch (titleMenuInput)
            {
                case 0:
                    userTrainer = new PokemonTrainer(GetUserName());
                    IntroduceGame(userTrainer);
                    GetStarterPokemon(userTrainer);
                    break;
                case 1:
                    userTrainer = Menu.Load();
                    break;
            }

            List<string> menuChoices = new List<string> { "Fight wild a Popokénom", "Challenge Rival", "Shop", "Save", "Quit" };
            while (true)
            {
                int userInput = Menu.GetUserInputIndex(menuChoices, false);
                switch (userInput)
                {
                    case 0:
                        Menu.FightWildPokemon(userTrainer);
                        userTrainer.HeallAllPokemons();
                        break;
                    case 1:
                        Menu.ChallengeRival(userTrainer);
                        userTrainer.HeallAllPokemons();
                        break;
                    case 2:
                        Menu.PurchaseItem(userTrainer);
                        break;
                    case 3:
                        Menu.Save(userTrainer);
                        break;
                    case 4:
                        return;
                }
            }
        }

        private static string GetUserName()
        {
            Console.WriteLine("Hi, what's your name?");
            return Console.ReadLine();
        }

        private static void IntroduceGame(PokemonTrainer userTrainer)
        {
            Console.WriteLine($"Hello there, {userTrainer.Name}! My name is not Nashkenazy, and this game might be called Popokénom.");
            Console.WriteLine("You'll notice that I put very little effort in making this game good.");
            Console.WriteLine("A Magikarp can be much stronger than Mew.");
            Console.WriteLine("In fact, it is the strongest Popokénom in this game.");
            Console.WriteLine("With that said, have fun!");
            Console.WriteLine();
        }

        private static void GetStarterPokemon(PokemonTrainer userTrainer)
        {
            Console.WriteLine("Choose your starter popokénom!");
            Console.WriteLine();

            int userInputIndex = Menu.GetUserInputIndex(Pokemons.StarterPokemons, false);
            string pokemonChosen = Pokemons.StarterPokemons[userInputIndex];

            userTrainer.StarterPokemon = pokemonChosen;
            userTrainer.CaptivePokemons.Add(new Pokemon(pokemonChosen, 1));
            Console.WriteLine($"Congratulations! {pokemonChosen} joined your party.");
        }


    }
}