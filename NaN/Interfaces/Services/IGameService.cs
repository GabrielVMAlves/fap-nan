using NaN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Interfaces.Services
{
    public interface IGameService
    {
        List<Game> ListAllGames();
        Game GetGameById(int id);
        Game GetGameByName(string name);
        Game CreateGame(Game game);
        Game UpdateGame(Game game);
        bool SugestGame(Game game);
        bool DeleteGame(int id);
    }
}
