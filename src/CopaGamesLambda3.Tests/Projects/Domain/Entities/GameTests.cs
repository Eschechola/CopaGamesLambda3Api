using CopaGamesLambda3.Tests.Utilities.Fakers;
using FluentAssertions;
using Xunit;

namespace CopaGamesLambda3.Tests.Projects.Domain.Entities
{
    public class GameTests
    {
        [Fact(DisplayName = "IsOlderThan should return true when informed game year is greater")]
        public void IsOlderThan_WhenInformedGameYearIsGreater_ShouldReturnTrue()
        {
            // Arrange
            var game = GameFaker.GetRandom();
            var gameToCompare = GameFaker.GetRandom(year: game.Year + 1);

            // Act
            var response = game.IsOlderThan(gameToCompare);

            // Assert
            response.Should()
                .BeTrue();
        }

        [Fact(DisplayName = "IsOlderThan should return false when informed game year is smaller")]
        public void IsOlderThan_WhenInformedGameYearIsSmaller_ShouldReturnFalse()
        {
            // Arrange
            var game = GameFaker.GetRandom();
            var gameToCompare = GameFaker.GetRandom(year: game.Year - 1);

            // Act
            var response = game.IsOlderThan(gameToCompare);

            // Assert
            response.Should()
                .BeFalse();
        }

        [Fact(DisplayName = "IsAlphabeticallySmaller should return false when informed game title is alphabetically smaller")]
        public void IsAlphabeticallySmaller_WhenInformedGameTitleIsAlphabeticallySmaller_ShouldReturnFalse()
        {
            // Arrange
            var game = GameFaker.GetRandom(title: "a");
            var gameToCompare = GameFaker.GetRandom(title: "b");

            // Act
            var response = game.IsAlphabeticallySmaller(gameToCompare);

            // Assert
            response.Should()
                .BeFalse();
        }

        [Fact(DisplayName = "IsAlphabeticallySmaller should return true when informed game title is alphabetically greater")]
        public void IsAlphabeticallySmaller_WhenInformedGameTitleIsAlphabeticallyGreater_ShouldReturnTrue()
        {
            // Arrange
            var game = GameFaker.GetRandom(title: "b");
            var gameToCompare = GameFaker.GetRandom(title: "a");

            // Act
            var response = game.IsAlphabeticallySmaller(gameToCompare);

            // Assert
            response.Should()
                .BeTrue();
        }

        [Fact(DisplayName = "HasABetterHating should return true when informed game rating is smaller")]
        public void HasABetterHating_WhenInformedGameRatingIsSmaller_ShouldReturnTrue()
        {
            // Arrange
            var game = GameFaker.GetRandom(minRating: 96, maxRating: 100);
            var gameToCompare = GameFaker.GetRandom(minRating: 90, maxRating: 95);

            // Act
            var response = game.HasABetterHating(gameToCompare);

            // Assert
            response.Should()
                .BeTrue();
        }

        [Fact(DisplayName = "HasABetterHating should return false when informed game rating is greater")]
        public void HasABetterHating_WhenInformedGameRatingIsGreater_ShouldReturnFalse()
        {
            // Arrange
            var game = GameFaker.GetRandom(minRating:90, maxRating: 95);
            var gameToCompare = GameFaker.GetRandom(minRating: 96, maxRating: 100);

            // Act
            var response = game.HasABetterHating(gameToCompare);

            // Assert
            response.Should()
                .BeFalse();
        }
    }
}
