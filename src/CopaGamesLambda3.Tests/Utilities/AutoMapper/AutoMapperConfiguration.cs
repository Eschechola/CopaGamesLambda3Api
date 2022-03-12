using AutoMapper;
using CopaGamesLambda3.Application.DTOs;
using CopaGamesLambda3.Domain.Entities;
using CopaGamesLambda3.Infrastructure.Communication.Refit;
using CopaGamesLambda3.IoC.Converters;

namespace CopaGamesLambda3.Tests.Utilities.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper GetConfiguration()
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GameResponse, Game>()
                    .ConvertUsing<GameConverter>();

                cfg.CreateMap<Game, GameDTO>()
                    .ReverseMap();
            });

            return autoMapperConfig.CreateMapper();
        }
    }
}
