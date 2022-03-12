using Bogus;
using Bogus.DataSets;
using Bogus.Hollywood.Models;
using CopaGamesLambda3.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CopaGamesLambda3.Tests.Utilities.Fakers
{
    public static class GameFaker
    {
        public static Game GetRandom()
            => new Game(
                id: new Internet().Url(),
                title: new Movie().Title,
                rating: new Randomizer().Double(1, 100),
                year: new Randomizer().Int(1980, DateTime.UtcNow.Year),
                urlImage: new Internet().Url());

        public static IList<Game> GetRandomList(int count = 8)
        {
            var games = new List<Game>();

            for(int i = 0; i < count; i++)
                games.Add(GetRandom());

            return games;
        }
    }
}
