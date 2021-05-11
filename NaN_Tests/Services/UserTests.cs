using Moq;
using NaN.Interfaces.Repositorys;
using NaN.Interfaces.Services;
using NaN.Models;
using NaN.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaN_Tests.Services
{
    [TestFixture]
    public class UserTests
    {
        private Mock<IGameRepository> mockGameRepository;
        private IGameService gameService;

        [SetUp]
        public void SetUp()
        {
            mockGameRepository = new Mock<IGameRepository>();
            gameService = new GameService(mockGameRepository.Object);

            List<GameRank> mockGameRanks = new List<GameRank>
            {
                new GameRank
                {
                    Id = 1,
                    Id_Game = 1,
                    Name = "HERALD",
                },
                new GameRank
                {
                    Id = 2,
                    Id_Game = 1,
                    Name = "GUARDIAN",
                },
                new GameRank
                {
                    Id = 3,
                    Id_Game = 1,
                    Name = "CRUSADER",
                },
                new GameRank
                {
                    Id = 4,
                    Id_Game = 1,
                    Name = "ARCHON",
                },
                new GameRank
                {
                    Id = 5,
                    Id_Game = 1,
                    Name = "LEGEND",
                },
                new GameRank
                {
                    Id = 6,
                    Id_Game = 1,
                    Name = "ANCIENT",
                },
                new GameRank
                {
                    Id = 7,
                    Id_Game = 1,
                    Name = "DIVINE",
                },
            };

            List<GameFunction> mockGameFunctions = new List<GameFunction>
            {
                new GameFunction
                {
                    Id = 1,
                    Name = "HARD CARRY",
                    Abbreviation = "HC",
                    Id_Game = 1,
                },
                new GameFunction
                {
                    Id = 2,
                    Name = "MIDLANNER",
                    Abbreviation = "MID",
                    Id_Game = 1,
                },
                new GameFunction
                {
                    Id = 3,
                    Name = "OFFLANER",
                    Abbreviation = "OFF",
                    Id_Game = 1,
                },
                new GameFunction
                {
                    Id = 4,
                    Name = "SUPPORT",
                    Abbreviation = "SUP4",
                    Id_Game = 1,
                },
                new GameFunction
                {
                    Id = 5,
                    Name = "HARD SUPPORT",
                    Abbreviation = "SUP5",
                    Id_Game = 1,
                },
            };

            List<Game> mockGames = new List<Game>
            {
               new Game {
                    Id = 1,
                    Name = "Dota 2",
                    Functions = mockGameFunctions,
                    Ranks = mockGameRanks
                }
            };
        }

        [Test]
        public void ListAllGames()
        {

        }
    }
}
