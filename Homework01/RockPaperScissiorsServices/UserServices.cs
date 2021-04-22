using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RockPaperScissorsDomain;
using RockPaperScissorsDomain.Classes;

namespace RockPaperScissiorsServices
{
    public class UserServices
    {
        public Player GetPlayerByUserName(string username)
        {
            return PlayerAcc.Players.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }
        

        public Player PlayerLogIn(string username)
        {
            Player student = GetPlayerByUserName(username);
            if (student == null)
            {
                Console.WriteLine("The player does not exist");
                return null;
            }

            return student;
        }
        
        public bool PasswordMatch(string password)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter password");
                string passwordInput = Console.ReadLine();
                if (password == passwordInput)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
