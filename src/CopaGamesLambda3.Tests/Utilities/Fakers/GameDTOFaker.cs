using Bogus;
using Bogus.DataSets;
using Bogus.Hollywood.Models;
using CopaGamesLambda3.Application.DTOs;
using System;
using System.Collections.Generic;

namespace CopaGamesLambda3.Tests.Utilities.Fakers
{
    public static class GameDTOFaker
    {
        public static GameDTO GetRandom()
            => new GameDTO
            {
                Id = new Internet().Url(),
                Title = new Movie().Title,
                Rating = new Randomizer().Double(1, 100),
                Year = new Randomizer().Int(1980, DateTime.UtcNow.Year),
                UrlImage = new Internet().Url()
            };

        public static IList<GameDTO> GetRandomList(int count = 8)
        {
            var games = new List<GameDTO>();

            for (int i = 0; i < count; i++)
                games.Add(GetRandom());

            return games;
        }
    }
}
