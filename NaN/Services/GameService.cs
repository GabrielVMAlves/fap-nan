using NaN.Interfaces.Repositorys;
using NaN.Interfaces.Services;
using NaN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Services
{
    public class GameService : IGameService
    {
        private IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Game CreateGame(Game game)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGame(int id)
        {
            throw new NotImplementedException();
        }

        public Game GetGameById(int id)
        {
            throw new NotImplementedException();
        }

        public Game GetGameByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Game> ListAllGames()
        {
            List<Game> result = _gameRepository.ListAllGames();
            
            foreach(Game item in result)
            {
                item.Ranks = _gameRepository.ListGameRank(item.Id);
                item.Functions = _gameRepository.ListGameFunction(item.Id);
            }

            return result;
        }

        public bool SugestGame(Game game)
        {
            throw new NotImplementedException();
        }

        public Game UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
