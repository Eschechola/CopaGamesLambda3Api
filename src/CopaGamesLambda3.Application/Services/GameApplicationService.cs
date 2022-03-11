using AutoMapper;
using CopaGamesLambda3.Application.DTOs;
using CopaGamesLambda3.Application.Interfaces;
using CopaGamesLambda3.Domain.Entities;
using CopaGamesLambda3.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaGamesLambda3.Application.Services
{
    public class GameApplicationService : IGameApplicationService
    {
        private readonly IGameDomainService _gameDomainService;
        private readonly IMapper _mapper;

        public GameApplicationService(
            IGameDomainService gameDomainService,
            IMapper mapper)
        {
            _gameDomainService = gameDomainService;
            _mapper = mapper;
        }

        public Task<IList<GameDTO>> GetGamesAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<GameDTO>> GetMatchFinalists()
        {
            var games = await _gameDomainService.GetGamesAsync();
            return _mapper.Map<IList<GameDTO>>(games);
        }

        public IList<GameDTO> GetMatchFinalists(IList<GameDTO> gamesDTO)
        {
            var games = _mapper.Map<IList<Game>>(gamesDTO);
            var matchFinalists = _gameDomainService.GetMatchFinalists(games);
            
            return _mapper.Map<IList<GameDTO>>(matchFinalists);
        }
    }
}
