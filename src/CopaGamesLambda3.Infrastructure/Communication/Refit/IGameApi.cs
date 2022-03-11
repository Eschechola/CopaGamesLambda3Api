using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaGamesLambda3.Infrastructure.Communication.Refit
{
    public interface IGameApi
    {
        [Get("/Competidores?copa=games")]
        Task<IList<GameResponse>> GetGamesAsync();
    }
}
