using AutoMapper;
using CopaGamesLambda3.Domain.Entities;
using CopaGamesLambda3.Infrastructure.Communication.Refit;

namespace CopaGamesLambda3.IoC.Converters
{
    public class GameConverter : ITypeConverter<GameResponse, Game>
    {
        public Game Convert(GameResponse source, Game destination, ResolutionContext context)
        {
            return new Game(
                source.Id,
                source.Titulo,
                source.Nota,
                source.Ano,
                source.UrlImagem);
        }
    }
}
