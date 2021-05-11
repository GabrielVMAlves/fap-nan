using NaN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Interfaces.Repositorys
{
    public interface IGameRepository
    {
        List<Game> ListAllGames();
        List<GameFunction> ListGameFunction(int gameId);
        List<GameRank> ListGameRank(int gameId);
        Game GetGameById(int id);
        Game GetGameByName(string name);
        Game CreateGame(Game game);
        Game UpdateGame(Game game);
        bool SugestGame(Game game);
        bool DeleteGame(int id);
    }
}
