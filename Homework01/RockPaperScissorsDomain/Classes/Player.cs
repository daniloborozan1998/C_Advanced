using System;
using System.Collections.Generic;
using System.Text;
using RockPaperScissorsDomain.Enums;

namespace RockPaperScissorsDomain.Classes
{
    public class Player : User
    {
        public Player()
        {
            Users = Users.Player;
        }
    }
}
