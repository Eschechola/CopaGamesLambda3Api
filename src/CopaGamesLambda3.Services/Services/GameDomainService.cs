using AutoMapper;
using CopaGamesLambda3.Domain.Entities;
using CopaGamesLambda3.Infrastructure.Communication.Refit;
using CopaGamesLambda3.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaGamesLambda3.Services
{
    public class GameDomainService : IGameDomainService
    {
        private readonly IGameApi _gameApi;
        private readonly IMapper _mapper;

        public GameDomainService(
            IGameApi gameApi,
            IMapper mapper)
        {
            _gameApi = gameApi;
            _mapper = mapper;
        }

        public async Task<IList<Game>> GetGamesAsync()
        {
            var games = await _gameApi.GetGamesAsync();
            return _mapper.Map<IList<Game>>(games);
        }

        public IList<Game> GetMatchFinalists(IList<Game> games)
        {
            var fisrtPhaseWinners = GetFirstPhaseWinners(games);
            var finalists = GetEliminatoryFinalists(fisrtPhaseWinners);

            return finalists;
        }

        private IList<Game> GetEliminatoryFinalists(IList<Game> games)
        {
            var finalists = new List<Game>();
            var phases = games.Count / 2;

            var currentParticipants = new List<Game>();
            var currentParticipantsHelper = new List<Game>();
            currentParticipants.AddRange(games);

            for(int i = 0; i < phases; i++)
            {
                if(currentParticipants.Count <= 2)
                {
                    finalists = GetLastFinalists(currentParticipants);
                    return finalists;
                }

                for (int j = 0; j < currentParticipants.Count; j += 2)
                {
                    var firstOpponent = currentParticipants[j];
                    var secondOpponent = currentParticipants[j + 1];

                    var winner = GetWinner(firstOpponent, secondOpponent);
                    currentParticipantsHelper.Add(winner);
                }

                currentParticipants.Clear();
                currentParticipants.AddRange(currentParticipantsHelper);

                currentParticipantsHelper.Clear();
            }

            return finalists;
        }

        private List<Game> GetLastFinalists(IList<Game> currentFinalists)
        {
            var finalists = new List<Game>();

            var firstOpponent = currentFinalists[0];
            var secondOpponent = currentFinalists[1];

            finalists.Add(firstOpponent);
            finalists.Add(secondOpponent);

            var winner = GetWinner(firstOpponent, secondOpponent);

            if (winner.Id == secondOpponent.Id)
                finalists.Reverse();

            return finalists;
        }

        private IList<Game> GetFirstPhaseWinners(IList<Game> games)
        {
            var winners = new List<Game>();
            var matchsCount = games.Count / 2;
            var opponetCounter = games.Count - 1;

            for(int i = 0; i < matchsCount; i++)
            {
                var firtOpponent = games[i];
                var secondOpponent = games[opponetCounter];

                var winner = GetWinner(firtOpponent, secondOpponent);
                winners.Add(winner);

                opponetCounter--;
            }

            return winners;
        }

        private Game GetWinner(Game firstOpponent, Game secondOpponent)
        {
            if (secondOpponent.Rating == firstOpponent.Rating)
            {
                if (secondOpponent.Year > firstOpponent.Year)
                    return secondOpponent;

                if (firstOpponent.Year > secondOpponent.Year)
                    return firstOpponent;

                if (secondOpponent.Title.CompareTo(firstOpponent.Title) == -1)
                    return secondOpponent;
            }

            if (secondOpponent.Rating > firstOpponent.Rating)
                return secondOpponent;

            return firstOpponent;
        }
    }
}
