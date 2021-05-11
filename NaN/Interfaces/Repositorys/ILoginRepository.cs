using NaN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Interfaces.Repositorys
{
    public interface ILoginRepository
    {
        bool Login(LoginUser user);
    }
}
