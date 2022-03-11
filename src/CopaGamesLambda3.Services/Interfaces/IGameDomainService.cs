using CopaGamesLambda3.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaGamesLambda3.Services.Interfaces
{
    public interface IGameDomainService
    {
        Task<IList<Game>> GetGamesAsync();
        IList<Game> GetMatchFinalists(IList<Game> games);
    }
}
