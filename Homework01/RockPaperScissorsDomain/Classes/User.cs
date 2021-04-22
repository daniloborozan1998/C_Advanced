using System;
using System.Collections.Generic;
using System.Text;
using RockPaperScissorsDomain.Enums;

namespace RockPaperScissorsDomain.Classes
{
    public class User
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int Wins { get; set; }
        public Users Users { get; set; }
    }
}
