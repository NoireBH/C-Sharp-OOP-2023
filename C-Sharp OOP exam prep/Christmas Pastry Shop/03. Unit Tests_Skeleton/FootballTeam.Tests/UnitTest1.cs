using NUnit.Framework;
using System;
using System.Linq;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            FootballTeam footballTeam = new FootballTeam("LiverPool", 20);
            var expName = "LiverPool";
            var expCapacity = 20;
            Assert.AreEqual(expName, footballTeam.Name);
            Assert.AreEqual(expCapacity, footballTeam.Capacity);
        }

        [Test]
        public void ThrowExceptionIfNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam footballTeam = new FootballTeam("", 20);
                FootballTeam footballTeam2 = new FootballTeam(null, 20);
            });
        }

        [Test]
        public void ThrowExceptionIfCapacityIsLessThan15()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam footballTeam = new FootballTeam("LiverPool", 10);

            });
        }

        [Test]
        public void AddNewPlayerAddsAPlayerToTheTeamAndReturnsAString()
        {
            var newPlayer = new FootballPlayer("Messi", 11, "Forward");
            FootballTeam footballTeam = new FootballTeam("LiverPool", 20);
            Assert.AreEqual($"Added player {newPlayer.Name} in position {newPlayer.Position} with number {newPlayer.PlayerNumber}", footballTeam.AddNewPlayer(newPlayer));
            var player = footballTeam.Players.FirstOrDefault();
            Assert.AreEqual(newPlayer, player);

        }

        [Test]
        public void AddNewPlayerIncreasesTheCount()
        {
            var newPlayer = new FootballPlayer("Messi", 11, "Forward");
            var newPlayer2 = new FootballPlayer("Isagi", 11, "Forward");
            FootballTeam footballTeam = new FootballTeam("LiverPool", 20);
            var expectedWithoutPlayers = 0;
            Assert.AreEqual(expectedWithoutPlayers, footballTeam.Players.Count);
            footballTeam.AddNewPlayer(newPlayer);
            footballTeam.AddNewPlayer(newPlayer2);
            var expectedWithPlayers = 2;
            Assert.AreEqual(expectedWithPlayers, footballTeam.Players.Count);
        }

        [Test]
        public void AddPlayerWhenCapacityIsFull()
        {
            FootballTeam team = new FootballTeam("LiverPool", 15);

            FootballPlayer player1 = new FootballPlayer("Player1Name", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Playe2rName", 2, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Player3Name", 3, "Midfielder");
            FootballPlayer player4 = new FootballPlayer("Player4Name", 4, "Midfielder");
            FootballPlayer player5 = new FootballPlayer("Player5Name", 5, "Midfielder");
            FootballPlayer player6 = new FootballPlayer("Player6Name", 6, "Midfielder");
            FootballPlayer player7 = new FootballPlayer("Player7Name", 7, "Midfielder");
            FootballPlayer player8 = new FootballPlayer("Player8Name", 8, "Midfielder");
            FootballPlayer player9 = new FootballPlayer("Player9Name", 9, "Midfielder");
            FootballPlayer player10 = new FootballPlayer("Player10Name", 10, "Midfielder");
            FootballPlayer player11 = new FootballPlayer("Player11Name", 11, "Midfielder");
            FootballPlayer player12 = new FootballPlayer("Player12Name", 12, "Forward");
            FootballPlayer player13 = new FootballPlayer("Player13Name", 13, "Forward");
            FootballPlayer player14 = new FootballPlayer("Player14Name", 14, "Forward");
            FootballPlayer player15 = new FootballPlayer("Player15Name", 15, "Forward");
            FootballPlayer player16 = new FootballPlayer("Player16Name", 16, "Forward");

            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            team.AddNewPlayer(player4);
            team.AddNewPlayer(player5);
            team.AddNewPlayer(player6);
            team.AddNewPlayer(player7);
            team.AddNewPlayer(player8);
            team.AddNewPlayer(player9);
            team.AddNewPlayer(player10);
            team.AddNewPlayer(player11);
            team.AddNewPlayer(player12);
            team.AddNewPlayer(player13);
            team.AddNewPlayer(player14);
            team.AddNewPlayer(player15);
            var actualResult = team.AddNewPlayer(player16);

            var expectedResult = "No more positions available!";

            Assert.AreEqual(actualResult, expectedResult);
        }
        public void PickPlayerReturnsPlayerWithGivenName()
        {
            var newPlayer = new FootballPlayer("Messi", 11, "Forward");
            var newPlayer2 = new FootballPlayer("Isagi", 11, "Forward");
            FootballTeam footballTeam = new FootballTeam("LiverPool", 20);
            footballTeam.AddNewPlayer(newPlayer);
            footballTeam.AddNewPlayer(newPlayer2);

            var expected = new FootballPlayer("Isagi", 11, "Forward");
            var actual = footballTeam.PickPlayer("Isagi");

            Assert.AreEqual(expected.Name, actual.Name);
        }

        [Test]
        public void PickPlayerReturnsNullIfPlayerIsNotFound()
        {
            FootballTeam footballTeam = new FootballTeam("LiverPool", 20);

            var actual = footballTeam.PickPlayer("Leonardo");

            Assert.IsNull(actual);
        }

        [Test]
        public void PlayerScoreIncreasesTheCountOfThePlayerGoalsAndReturnsAString()
        {
            var newPlayer = new FootballPlayer("Messi", 11, "Forward");
            FootballTeam footballTeam = new FootballTeam("LiverPool", 20);
            footballTeam.AddNewPlayer(newPlayer);

            footballTeam.PlayerScore(11);

            var expectedString = "Messi scored and now has 2 for this season!";
            Assert.AreEqual(expectedString, footballTeam.PlayerScore(11));

            var expected = 2;
            var actual = footballTeam.Players.FirstOrDefault(p => p.PlayerNumber == 11).ScoredGoals;

            Assert.AreEqual(expected, actual);



        }
    }
}