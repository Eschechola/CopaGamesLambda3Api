using AutoMapper;
using Bogus;
using CopaGamesLambda3.API;
using CopaGamesLambda3.API.ViewModels;
using CopaGamesLambda3.Application.DTOs;
using CopaGamesLambda3.Application.Interfaces;
using CopaGamesLambda3.Tests.Projects.API.Fixtures;
using CopaGamesLambda3.Tests.Utilities.AutoMapper;
using CopaGamesLambda3.Tests.Utilities.Fakers;
using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CopaGamesLambda3.Tests.Projects.API.Controllers
{
    [Collection("Web application factory collection")]
    public class GameControllerTests
    {
        private readonly HttpClient _client;
        private readonly IMapper _mapper;
        private readonly Mock<IGameApplicationService> _gameApplicationService;

        public GameControllerTests(CustomWebApplicationFixture<Startup> factory)
        {
            _mapper = AutoMapperConfiguration.GetConfiguration();
            _gameApplicationService = new Mock<IGameApplicationService>();

            _client = factory.WithWebHostBuilder(x =>
            {
                x.ConfigureTestServices(services =>
                {
                    services.AddSingleton(s => _gameApplicationService.Object);
                    services.AddSingleton(s => _mapper);
                });
            }).CreateClient();
        }

        [Fact(DisplayName = "GetGamesAsync returns 200 with a list of games")]
        public async Task GetGamesAsync_ReturnsOk()
        {
            // Arrange
            var games = GameDTOFaker.GetRandomList(count: 16);

            _gameApplicationService.Setup(x => x.GetGamesAsync())
                .ReturnsAsync(games);

            // Act
            var response = await _client.GetAsync("/api/v1/game/get-all");
            var responseContent = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<ResultViewModel>(responseContent);
            var responseObjectDataString = JsonConvert.SerializeObject(responseObject.Data);
            var responseObjectData = JsonConvert.DeserializeObject<List<GameDTO>>(responseObjectDataString);

            // Assert
            response.StatusCode.Should()
                .Be(HttpStatusCode.OK);

            responseObject.Should()
                .NotBeNull();

            (responseObjectData as IList<GameDTO>).Should()
                .NotBeNull()
                .And
                .NotBeEmpty()
                .And
                .HaveCount(games.Count);
        }

        [Fact(DisplayName = "StartMatches returns 400 when the number of games is different from 8")]
        public async Task StartMatches_WhenNumberOfGamesIsDifferentFrom8_ReturnsBadRequest()
        {
            // Arrange
            var games = GameDTOFaker.GetRandomList(count: new Randomizer().Number(1, 7));

            var gamesBody = JsonConvert.SerializeObject(new
            {
                Games = games
            });

            var stringContent = new StringContent(gamesBody, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/v1/game/start-matches", stringContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<ResultViewModel>(responseContent);

            // Assert
            response.StatusCode.Should()
                .Be(HttpStatusCode.BadRequest);

            responseObject.Should()
                .NotBeNull();

            responseObject.Message.Should()
                .BeEquivalentTo("You need to inform 8 games to start the matches");

            responseObject.Success.Should()
                .BeFalse();
        }

        [Fact(DisplayName = "StartMatches returns 200 with a finalists list with 2 elements")]
        public async Task StartMatches_ReturnsOkWithFinalists()
        {
            // Arrange
            var games = GameDTOFaker.GetRandomList(count: 8);
            var finalists = games.OrderByDescending(x => x.Rating).Take(2).ToList();

            _gameApplicationService.Setup(x => x.GetMatchFinalists(It.IsAny<IList<GameDTO>>()))
                .Returns(finalists);

            var gamesBody = JsonConvert.SerializeObject(new
            {
                Games = games
            });

            var stringContent = new StringContent(gamesBody, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/v1/game/start-matches", stringContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            var responseObject = JsonConvert.DeserializeObject<ResultViewModel>(responseContent);
            var responseObjectDataString = JsonConvert.SerializeObject(responseObject.Data);
            var responseObjectData = JsonConvert.DeserializeObject<List<GameDTO>>(responseObjectDataString);

            // Assert
            response.StatusCode.Should()
                .Be(HttpStatusCode.OK);

            responseObject.Should()
                .NotBeNull();

            responseObject.Success.Should()
                .BeTrue();

            responseObject.Message.Should()
                .BeEquivalentTo("Successful completed matches");

            (responseObjectData as IList<GameDTO>).Should()
                .NotBeNull()
                .And
                .NotBeEmpty()
                .And
                .HaveCount(2)
                .And
                .BeEquivalentTo(finalists);
        }
    }
}
