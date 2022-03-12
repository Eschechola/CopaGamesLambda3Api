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

namespace CopaGamesLambda3.Tests.Services.DomainServices
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
            int itensCount = 16;
            var games = GameResponseFaker.GetRandomList(itensCount);

            _gameApiMock.Setup(x => x.GetGamesAsync())
                .ReturnsAsync(games);

            // Act
            var response = await _sut.GetGamesAsync();

            // Assert 
            response.Should()
                .HaveCount(itensCount)
                .And
                .BeAssignableTo<IList<Game>>();
        }

        [Fact(DisplayName = "GetMatchFinalists when all is different returns the correct winners")]
        public void GetMatchFinalists_WhenAllIsDiferent_ReturnsTheCorretWinners()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact(DisplayName = "GetMatchFinalists when some has the same rating and different year")]
        public void GetMatchFinalists_WhenSomeHasTheSameRatingAndDifferentYear_ReturnsTheCorretWinnersByYear()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact(DisplayName = "GetMatchFinalists when some has the same rating and year but different names")]
        public void GetMatchFinalists_WhenSomeHasTheSameRatingAndYearButDifferentNames_ReturnsTheCorretWinnersByName()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
