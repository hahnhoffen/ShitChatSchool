using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitChat
{
    internal class UserManager
    {
        List<User> listOfUsers = new List<User>();

        public void CreateUser(string userName, string password)
        {
            listOfUsers.Add(new User(userName, password));
        }






    }
}
