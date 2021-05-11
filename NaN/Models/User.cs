using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public List<Game_User> Game_User { get; set; }
    }

    public class Game_User
    {
        public int Game_Id { get; set; }
        public string Game_Name { get; set; }
        public int User_Game_Id { get; set; }
        public int Rank_Id { get; set; }
        public string Rank_Name { get; set; }
        public int Function_Id { get; set; }
        public string Function_Name { get; set; }
        public string Function_Abbreviation { get; set; }
        public string User_Profile { get; set; }
    }
}
