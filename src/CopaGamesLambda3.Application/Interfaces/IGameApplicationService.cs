using CopaGamesLambda3.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaGamesLambda3.Application.Interfaces
{
    public interface IGameApplicationService
    {
        Task<IList<GameDTO>> GetGamesAsync();
        IList<GameDTO> GetMatchFinalists(IList<GameDTO> games);
    }
}
