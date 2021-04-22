using System;
using System.Collections.Generic;
using System.Text;
using RockPaperScissorsDomain.Enums;

namespace RockPaperScissorsDomain.Classes
{
    public class Computer : User
    {
        public int Games { get; set; }

        public Computer()
        {
            Users = Users.Computer;
        }
    }
}
