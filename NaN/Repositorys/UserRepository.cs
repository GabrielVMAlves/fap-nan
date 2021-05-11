using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using NaN.Interfaces.Repositorys;
using NaN.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Transactions;
using NaN.Models.Entity;

namespace NaN.Repositorys
{
    public class UserRepository : IUserRepository
    {
        IDbConnection _db;
        private string connectionString;

        public UserRepository(IConfiguration config)
        {
            connectionString = config["MySqlConnections:MySqlConnectionString"];
        } 
        public LoginUser CreateLogin(string username, string password)
        {
            throw new NotImplementedException();
        }

        public int CreateUser(User user)
        {
            try
            {
                using (_db = new MySqlConnection(connectionString))
                {

                    var parametersUser = new { UserName = user.Name, Contact = user.Contact};
                    
                    _db.Query("INSERT INTO user(name, contact) VALUES(@UserName, @Contact)", parametersUser);

                    int userId = _db.Query<int>("SELECT id FROM user ORDER BY id DESC LIMIT 1").Single();

                    return userId;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                using (var transaction = new TransactionScope())
                {
                    using (_db = new MySqlConnection(connectionString))
                    {
                        var paramDeleteUser = new { UserId = id };
                        List<int> userGameList = _db.Query<int>("SELECT id FROM nan_db.user_game WHERE id_user = @UserId", paramDeleteUser).ToList();

                        foreach (int userGameId in userGameList)
                        {
                            var paramDeleteUserGameFunction = new { UserGameId = userGameId };
                            _db.Query("DELETE FROM nan_db.user_game_function WHERE id = @UserId", paramDeleteUserGameFunction);
                        }

                        _db.Query("DELETE FROM nan_db.user_game WHERE id_user = @UserId", paramDeleteUser);

                        _db.Query("DELETE FROM nan_db.user WHERE id = @UserId", paramDeleteUser);
                        transaction.Complete();
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<User> GetUserByFunction(int gameId, int functionId)
        {
            try
            {
                using (_db = new MySqlConnection(connectionString))
                {
                    var param = new { GameId = gameId, };
                    List<User> users = _db.Query<User>("SELECT U.id, U.name, U.contact, UG.id_game AS Game_Id FROM nan_db.user U JOIN nan_db.user_game UG on U.id = UG.id_user WHERE UG.id_game = @GameId", param).ToList();
                    string whereCondition = "WHERE U.id = @Id and UGF.id_game_function = @FunctionId";


                    foreach (User user in users)
                    {
                        var parameters = new { Id = user.Id, FunctionId = functionId };
                        user.Game_User = FillUserEntity(whereCondition, parameters);
                    }

                    users = users.Where(x => x.Game_User.Count > 0).ToList();

                    return users;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<User> GetUserByGame(int gameId)
        {
            try
            {
                using (_db = new MySqlConnection(connectionString))
                {
                    var param = new { GameId = gameId, };
                    List<User> users = _db.Query<User>("SELECT U.id, U.name, U.contact, UG.id_game AS Game_Id FROM nan_db.user U JOIN nan_db.user_game UG on U.id = UG.id_user WHERE UG.id_game = @GameId", param).ToList();
                    string whereCondition = "WHERE U.id = @Id";


                    foreach (User user in users)
                    {
                        var parameters = new { Id = user.Id };
                        user.Game_User = FillUserEntity(whereCondition, parameters);
                    }

                    users = users.Where(x => x.Game_User.Count > 0).ToList();

                    return users;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                using (_db = new MySqlConnection(connectionString))
                {
                    var parameters = new { Id = id};
                    User user = _db.Query<User>("SELECT id, name, contact FROM nan_db.user WHERE id = @Id", parameters).Single();
                    string whereCondition = "WHERE U.id = @Id";

                    user.Game_User = FillUserEntity(whereCondition, parameters);

                    return user;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<User> GetUserByName(string name)
        {
            try
            {
                using (_db = new MySqlConnection(connectionString))
                {
                    var parameterUser = new { Username = name };
                    List<User> users = _db.Query<User>("SELECT id, name, contact FROM nan_db.user WHERE name = @Username", parameterUser).ToList();
                    string whereCondition = "WHERE U.id = @Id";


                    foreach (User user in users)
                    {
                        var parameters = new { Id = user.Id };
                        user.Game_User = FillUserEntity(whereCondition, parameters);
                    }

                    users = users.Where(x => x.Game_User.Count > 0).ToList();

                    return users;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<User> GetUserByProfile(string profile)
        {
            try
            {
                using (_db = new MySqlConnection(connectionString))
                {
                    List<User> users = _db.Query<User>("SELECT id, name, contact FROM nan_db.user").ToList();
                    string whereCondition = "WHERE U.id = @Id and UG.user_profile = @Profile";


                    foreach (User user in users)
                    {
                        var parameters = new { Id = user.Id, Profile = profile };
                        user.Game_User = FillUserEntity(whereCondition, parameters);
                    }

                    users = users.Where(x => x.Game_User.Count > 0).ToList();

                    return users;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<User> GetUserByRank(int gameId, int rankId)
        {
            try
            {
                using (_db = new MySqlConnection(connectionString))
                {
                    var param = new { GameId = gameId, };
                    List<User> users = _db.Query<User>("SELECT U.id, U.name, U.contact, UG.id_game AS Game_Id FROM nan_db.user U JOIN nan_db.user_game UG on U.id = UG.id_user WHERE UG.id_game = @GameId", param).ToList();
                    string whereCondition = "WHERE U.id = @Id and GR.id = @RankId";


                    foreach (User user in users)
                    {
                        var parameters = new { Id = user.Id, RankId = rankId };
                        user.Game_User = FillUserEntity(whereCondition, parameters);
                    }

                    users = users.Where(x => x.Game_User.Count > 0).ToList();

                    return users;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<User> ListAllUsers()
        {
            try
            {
                using (_db = new MySqlConnection(connectionString))
                {
                    List<User> users = _db.Query<User>("SELECT id, name, contact from nan_db.user").ToList();
                    string whereCondition = "WHERE U.id = @Id";


                    foreach (User user in users)
                    {
                        var parameters = new { Id = user.Id };
                        user.Game_User = FillUserEntity(whereCondition, parameters);
                    }

                    return users;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User UpdateUser(User user)
        {
            try
            {
                using (var transaction = new TransactionScope())
                {
                    using (_db = new MySqlConnection(connectionString))
                    {
                        var paramsUpdateUser = new { Name = user.Name, Contact = user.Contact, UserId = user.Id };
                        int userId = _db.Query<int>("pr_Update_User", paramsUpdateUser, null, true, null, CommandType.StoredProcedure).Single();

                        var paramListUserGameId = new { UserId = user.Id };
                        List<int> userGameList = _db.Query<int>("SELECT id from nan_db.user_game WHERE id_user = @UserId", paramListUserGameId).ToList();

                        foreach(int userGameId in userGameList)
                        {
                            var paramDeleteUserGameFunction = new { UserGameId = userGameId };
                            _db.Query("DELETE from nan_db.user_game_function WHERE id = @UserGameId", paramDeleteUserGameFunction);
                        }

                        _db.Query("DELETE from nan_db.user_game WHERE id_user = @UserId", paramListUserGameId);
                        transaction.Complete();
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int InsertUserGame(int idGame, int idUser, string profile, int? idRank)
        {
            try
            {
                using (_db = new MySqlConnection(connectionString))
                {
                    var parameters = new { IdUser = idUser, IdGame = idGame , Profile = profile, IdRank = idRank};

                    _db.Execute("INSERT INTO user_game(id_user, id_game, user_rank, user_profile) VALUES(@IdUser, @IdGame, @IdRank, @Profile)", parameters);

                    int idUserGame = _db.Query<int>("SELECT id FROM user_game ORDER BY id DESC LIMIT 1").Single();
                    return idUserGame;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void InsertUserGameFunctions(int userGameId, int functionId)
        {
            try
            {
                using (_db = new MySqlConnection(connectionString))
                {
                        var parameters = new { IdUserGame = userGameId, IdGameFunction = functionId };
                        _db.Execute("INSERT INTO user_game_function(id_user_game, id_game_function) VALUES(@IdUserGame, @IdGameFunction)", parameters);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private List<Game_User> FillUserEntity(string whereCondition, object parameters)
        {
            string query = @$"SELECT U.id
                                        ,UG.id AS User_Game_Id, UG.user_rank AS Rank_Id, UG.id_game AS Game_Id, UG.user_profile AS User_Profile
                                        , GR.name AS Rank_Name
                                        , G.name AS Game_Name
                                        , UGF.id_game_function AS Function_Id
                                        , GF.name AS Function_Name, GF.abbreviation AS Function_Abbreviation
                                        FROM nan_db.user U
                                        JOIN nan_db.user_game UG on U.id = UG.id_user
                                        JOIN nan_db.game_rank GR on UG.user_rank = GR.id
                                        JOIN nan_db.game G on UG.id_game = G.id
                                        JOIN nan_db.user_game_function UGF on id_user_game = UG.id
                                        JOIN nan_db.game_function GF on GF.id = UGF.id_game_function
                                        {whereCondition}";

            return _db.Query<Game_User>(query, parameters).ToList();
        }

        private List<User> SelectUserWithGameId(string whereCondition, object parameters)
        {
            List<User> users = _db.Query<User>("SELECT U.id, U.name, U.contact, UG.id_game AS Game_Id FROM nan_db.user U JOIN nan_db.user_game UG on U.id = UG.id_user WHERE UG.id_game = @GameId", parameters).ToList();

            return users;
        }
    }
}
