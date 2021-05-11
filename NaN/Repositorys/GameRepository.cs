using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using NaN.Interfaces.Repositorys;
using NaN.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Repositorys
{
    public class GameRepository : IGameRepository
    {
        private IDbConnection _db;
        private string _connectionString;
        public GameRepository(IConfiguration config)
        {
            _connectionString = config["MySqlConnections:MySqlConnectionString"];
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
            try
            {
                using (_db = new MySqlConnection(_connectionString))
                {
                    List<Game> result = _db.Query<Game>("SELECT id, name FROM nan_db.game").ToList();
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<GameFunction> ListGameFunction(int gameId)
        {
            try
            {
                using (_db = new MySqlConnection(_connectionString))
                {
                    var parameters = new { GameId = gameId };
                    List<GameFunction> result = _db.Query<GameFunction>("SELECT id, name, abbreviation, id_game FROM nan_db.game_function WHERE id_game = @GameId", parameters).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<GameRank> ListGameRank(int gameId)
        {
            try
            {
                using (_db = new MySqlConnection(_connectionString))
                {
                    var parameters = new { GameId = gameId };
                    List<GameRank> result = _db.Query<GameRank>("SELECT id, name, id_game FROM nan_db.game_rank WHERE id_game = @GameId", parameters).ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
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
