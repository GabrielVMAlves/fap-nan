using NaN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Interfaces.Services
{
    public interface ILoginService
    {
        bool Login(string username, string password);
    }
}
