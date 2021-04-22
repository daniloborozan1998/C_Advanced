using System;
using System.Collections.Generic;
using System.Text;
using RockPaperScissorsDomain.Classes;

namespace RockPaperScissorsDomain
{
    public static class PlayerAcc
    {
        public static List<Player> Players = new List<Player>
        {
            new Player() { Username = "player2", Password = "123", FirstName = "Danilo", LastName = "Borozan" },
            new Player() { Username = "player3", Password = "123", FirstName = "Smith", LastName = "Rows" },
            new Player() { Username = "player3", Password = "123", FirstName = "Ramos", LastName = "Sergio" },
            new Player() { Username = "player4", Password = "123", FirstName = "Daria", LastName = "Dimitrioska" },
            new Player() { Username = "player5", Password = "123", FirstName = "Filip", LastName = "Dimoski" },
            new Player() { Username = "player6", Password = "123", FirstName = "Kate", LastName = "Middleton" },
            new Player() { Username = "player7", Password = "123", FirstName = "Rose", LastName = "Blacking" },
            new Player() { Username = "player1", Password = "123", FirstName = "Raymond", LastName = "Reddington" }
        };
    }
}
