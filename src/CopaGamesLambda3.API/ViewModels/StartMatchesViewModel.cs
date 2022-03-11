using CopaGamesLambda3.Application.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopaGamesLambda3.API.ViewModels
{
    public class StartMatchesViewModel
    {
        [Required]
        public List<GameDTO> Games { get; set; }

        public StartMatchesViewModel()
        {
            Games = new List<GameDTO>();
        }
    }
}
