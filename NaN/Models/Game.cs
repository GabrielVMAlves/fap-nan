using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaN.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GameFunction> Functions { get; set; }
        public List<GameRank> Ranks { get; set; }
    }
}
