using System;
using System.Collections.Generic;
using System.Text;
using RockPaperScissorsDomain.Enums;

namespace RockPaperScissorsDomain.Classes
{
    public class Unsolved:User
    {
        public int Draw { get; set; }

        public Unsolved()
        {
            Users = Users.Unsolved;
        }

    }
}
