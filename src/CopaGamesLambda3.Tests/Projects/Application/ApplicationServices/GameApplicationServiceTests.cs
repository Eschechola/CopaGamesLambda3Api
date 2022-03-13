using AutoMapper;
using CopaGamesLambda3.Application.DTOs;
using CopaGamesLambda3.Application.Services;
using CopaGamesLambda3.Domain.Entities;
using CopaGamesLambda3.Services.Interfaces;
using CopaGamesLambda3.Tests.Utilities.AutoMapper;
using CopaGamesLambda3.Tests.Utilities.Fakers;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CopaGamesLambda3.Tests.Projects.Application.ApplicationServices
{
    public class GameApplicationServiceTests
    {
        private readonly GameApplicationService _sut;

        private readonly IMapper _mapper;
        private readonly Mock<IGameDomainService> _gameDomainServiceMock;

        public GameApplicationServiceTests()
        {
            _mapper = AutoMapperConfiguration.GetConfiguration();
            _gameDomainServiceMock = new Mock<IGameDomainService>();

            _sut = new GameApplicationService(
                gameDomainService: _gameDomainServiceMock.Object,
                mapper: _mapper);
        }

        [Fact]
        public async Task GetGamesAsync_WhenAllIsOk_ReturnAListOfGameDTO()
        {
            //Arrange
            var games = GameFaker.GetRandomList(count: 16);
            var expectedGames = _mapper.Map<IList<GameDTO>>(games);

            _gameDomainServiceMock.Setup(x => x.GetGamesAsync())
                .ReturnsAsync(games);

            //Act
            var response = await _sut.GetGamesAsync();

            //Assert
            response.Should()
                .NotBeNull()
                .And
                .NotBeEmpty()
                .And
                .BeEquivalentTo(expectedGames)
                .And
                .HaveCount(16);
        }

        [Fact]
        public void GetMatchFInalists_WhenAllIsOk_ReturnTwoFinalists()
        {
            //Arrange
            var gamesToMatches = GameDTOFaker.GetRandomList(count: 8);
            var winners = GameFaker.GetRandomList(count: 2);
            var expectedWinners = _mapper.Map<IList<GameDTO>>(winners);

            _gameDomainServiceMock.Setup(x => x.GetMatchFinalists(It.IsAny<IList<Game>>()))
                .Returns(winners);

            //Act
            var response = _sut.GetMatchFinalists(gamesToMatches);

            //Assert
            response.Should()
                .NotBeNull()
                .And
                .NotBeEmpty()
                .And
                .BeEquivalentTo(expectedWinners)
                .And
                .HaveCount(2);
        }
    }
}
