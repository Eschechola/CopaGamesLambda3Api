using AutoMapper;
using CopaGamesLambda3.Domain.Entities;
using CopaGamesLambda3.Infrastructure.Communication.Refit;
using CopaGamesLambda3.Services;
using CopaGamesLambda3.Tests.Utilities.AutoMapper;
using CopaGamesLambda3.Tests.Utilities.Fakers;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CopaGamesLambda3.Tests.Projects.Services.DomainServices
{
    public class GameDomainServiceTests
    {
        private readonly GameDomainService _sut;

        private readonly IMapper _mapper;
        private readonly Mock<IGameApi> _gameApiMock;

        public GameDomainServiceTests()
        {
            _gameApiMock = new Mock<IGameApi>();
            _mapper = AutoMapperConfiguration.GetConfiguration();

            _sut = new GameDomainService(
                gameApi: _gameApiMock.Object,
                mapper: _mapper);
        }

        [Fact(DisplayName = "GetGamesAsync should return a list of Game with 16 elements")]
        public async Task GetGamesAsync_ShouldReturnAListOfGameDTO()
        {
            // Arrange
            var games = GameResponseFaker.GetRandomList(count: 16);

            _gameApiMock.Setup(x => x.GetGamesAsync())
                .ReturnsAsync(games);

            // Act
            var response = await _sut.GetGamesAsync();

            // Assert 
            response.Should()
                .HaveCount(16)
                .And
                .BeAssignableTo<IList<Game>>();
        }

        [Fact(DisplayName = "GetMatchFinalists when all is different returns the correct winner")]
        public void GetMatchFinalists_WhenAllIsDiferent_ReturnsTheCorretWinner()
        {
            // Arrange
            var games = GameFaker.GetRandomList(count: 7, maxRating: 90);
            var winner = GameFaker.GetRandom(minRating: 91, maxRating: 100);

            games.Add(winner);

            // Act
            var response = _sut.GetMatchFinalists(games);

            // Assert
            response.Should()
                .NotBeEmpty()
                .And
                .HaveCount(2);

            response[0].Should()
                .NotBeNull()
                .And
                .BeEquivalentTo(winner);
        }

        [Fact(DisplayName = "GetMatchFinalists when some has the same rating and different year")]
        public void GetMatchFinalists_WhenSomeHasTheSameRatingAndDifferentYear_ReturnsTheCorretWinnersByYear()
        {
            // Arrange
            var games = GameFaker.GetRandomList(count: 6, maxRating: 90);

            var winner = GameFaker.GetRandom(minRating: 91, maxRating: 100);
            var winnerAdversary = GameFaker.GetRandom(rating: winner.Rating, year: winner.Year - 1);

            games.Add(winner);
            games.Add(winnerAdversary);

            // Act
            var response = _sut.GetMatchFinalists(games);

            // Assert
            response.Should()
                .NotBeEmpty()
                .And
                .HaveCount(2);

            response[0].Should()
                .NotBeNull()
                .And
                .BeEquivalentTo(winner);
        }

        [Fact(DisplayName = "GetMatchFinalists when some has the same rating and year but different names")]
        public void GetMatchFinalists_WhenSomeHasTheSameRatingAndYearButDifferentNames_ReturnsTheCorretWinnerByName()
        {
            // Arrange
            var games = GameFaker.GetRandomList(count: 6, maxRating: 90);

            var winner = GameFaker.GetRandom(title: "a", minRating: 91, maxRating: 100);
            var winnerAdversary = GameFaker.GetRandom(title: "b", rating: winner.Rating, year: winner.Year);

            games.Add(winner);
            games.Add(winnerAdversary);

            // Act
            var response = _sut.GetMatchFinalists(games);

            // Assert
            response.Should()
                .NotBeEmpty()
                .And
                .HaveCount(2);

            response[0].Should()
                .NotBeNull()
                .And
                .BeEquivalentTo(winner);
        }
    }
}
