using Bogus;
using Bogus.DataSets;
using Bogus.Hollywood.Models;
using CopaGamesLambda3.Infrastructure.Communication.Refit;
using System;
using System.Collections.Generic;

namespace CopaGamesLambda3.Tests.Utilities.Fakers
{
    public class GameResponseFaker
    {
        public static GameResponse GetRandom()
            => new GameResponse
            {
                Id =  new Internet().Url(),
                Titulo = new Movie().Title,
                Nota = new Randomizer().Double(1, 100),
                Ano = new Randomizer().Int(1980, DateTime.UtcNow.Year),
                UrlImagem = new Internet().Url()
            };

        public static IList<GameResponse> GetRandomList(int count = 8)
        {
            var games = new List<GameResponse>();

            for (int i = 0; i < count; i++)
                games.Add(GetRandom());

            return games;
        }
    }
}
