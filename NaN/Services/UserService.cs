using NaN.Interfaces.Repositorys;
using NaN.Interfaces.Services;
using NaN.Models;
using NaN.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public LoginUser CreateLogin(string username, string password)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(User user)
        {
            ValidateBeforeCreate(user);

            user.Id = _userRepository.CreateUser(user);

            foreach (Game_User game in user.Game_User)
            {
                int userGameId = _userRepository.InsertUserGame(game.Game_Id, user.Id, game.User_Profile, game.Rank_Id);

                _userRepository. InsertUserGameFunctions(userGameId, game.Function_Id);
            }


            return user;
        }

        public User UpdateUser(User user)
        {
            Validate(user);

            _userRepository.UpdateUser(user);
            foreach (Game_User game in user.Game_User)
            {
                int userGameId = _userRepository.InsertUserGame(game.Game_Id, user.Id, game.User_Profile, game.Rank_Id);

                _userRepository.InsertUserGameFunctions(userGameId, game.Function_Id);
            }

            return user;
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public List<User> GetUserByFunction(int gameId, int functionId)
        {
            return _userRepository.GetUserByFunction(gameId, functionId);
        }

        public List<User> GetUserByGame(int gameId)
        {
            return _userRepository.GetUserByGame(gameId);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public List<User> GetUserByName(string name)
        {
            return _userRepository.GetUserByName(name);
        }

        public List<User> GetUserByProfile(string profile)
        {
            return _userRepository.GetUserByProfile(profile);
        }

        public List<User> GetUserByRank(int gameId, int rankId)
        {
            return _userRepository.GetUserByRank(gameId, rankId);
        }

        public List<User> ListAllUsers()
        {
            return _userRepository.ListAllUsers();
        }

        private void ValidateBeforeCreate(User user)
        {
            user.Id = 1;

            Validate(user);
        }

        private void Validate(User user)
        {
            if (user.Id <= 0 || user.Id == null)
                throw new ErrorHandling(400, "Validation Exception", "Invalid Id for User, try to reload de page an try gain!");
            if(user.Name.Length > 145)
                throw new ErrorHandling(400, "Validation Exception", "Name cannot have more than 145 characters!");
            if (user.Name.Length < 5)
                throw new ErrorHandling(400, "Validation Exception", "Name cannot have less than 5 characters!");
            if (user.Contact.Length > 125)
                throw new ErrorHandling(400, "Validation Exception", "Contact cannot have more than 125 characters!");
        }

        private void ValidateGames(Game_User game)
        {
            if (game.User_Profile.Length > 200)
                throw new ErrorHandling(400, "Validation Exception", "Profile cannot have more than 200 characters!");
            if (game.User_Profile.Length < 5)
                throw new ErrorHandling(400, "Validation Exception", "Profile cannot have less than 5 characters!");
        }
    }
}
