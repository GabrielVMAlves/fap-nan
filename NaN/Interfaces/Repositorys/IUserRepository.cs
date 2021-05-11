using NaN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Interfaces.Repositorys
{
    public interface IUserRepository
    {
        LoginUser CreateLogin(string username, string password);
        List<User> ListAllUsers();
        List<User> GetUserByFunction(int gameId, int functionId);
        List<User> GetUserByRank(int gameId, int rankId);
        List<User> GetUserByGame(int gameId);
        User GetUserById(int id);
        List<User> GetUserByName(string name);
        List<User> GetUserByProfile(string profile);
        int CreateUser(User user);
        int InsertUserGame(int idGame, int idUser, string profile, int? idRank);
        void InsertUserGameFunctions(int userGameId, int functionId);
        User UpdateUser(User user);
        void DeleteUser(int id);
    }
}
