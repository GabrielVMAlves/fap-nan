using NaN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Interfaces.Services
{
    public interface IUserService
    {
        LoginUser CreateLogin(string username, string password);
        List<User> ListAllUsers();
        List<User> GetUserByFunction(int gameId, int functionId);
        List<User> GetUserByRank(int gameId, int rankId);
        List<User> GetUserByGame(int gameId);
        List<User> GetUserByName(string name);
        List<User> GetUserByProfile(string profile);
        User GetUserById(int id);
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(int id);

    }
}
