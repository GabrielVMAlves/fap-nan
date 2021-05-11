using NaN.Interfaces.Repositorys;
using NaN.Interfaces.Services;
using NaN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Services
{
    public class LoginService : ILoginService
    {
        private ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public bool Login(string username, string password)
        {
            return _loginRepository.Login(LoginUserMapper(username, password));
        }

        private LoginUser LoginUserMapper(string username, string password)
        {
            return new LoginUser { Username = username, Password = password };
        }
    }
}
