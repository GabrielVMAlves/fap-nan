using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using NaN.Interfaces.Repositorys;
using NaN.Models;

namespace NaN.Repositorys
{
    public class LoginRepository : ILoginRepository
    {
        private IConfiguration _config;
        private IDbConnection _db;
        private string connectionString;
        public LoginRepository (IConfiguration config)
        {
            _config = config;
            connectionString = _config["MySqlConnections:MySqlConnectionString"];
        }

        public bool Login(LoginUser user)
        {
            try
            {
                using(_db = new MySqlConnection(connectionString))
                {
                    _db.Open();
                    var retorno = _db.QueryFirstOrDefault<LoginUser>("SELECT * FROM nan_db.login_user");

                    if (retorno == null)
                        return false;
                    _db.Close();
                }
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
