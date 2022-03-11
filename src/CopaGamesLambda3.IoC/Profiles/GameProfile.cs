using AutoMapper;
using CopaGamesLambda3.Application.DTOs;
using CopaGamesLambda3.Domain.Entities;
using CopaGamesLambda3.Infrastructure.Communication.Refit;
using CopaGamesLambda3.IoC.Converters;

namespace CopaGamesLambda3.IoC.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameResponse, Game>()
                .ConvertUsing<GameConverter>();

            CreateMap<Game, GameDTO>()
                .ReverseMap();
        }
    }
}
