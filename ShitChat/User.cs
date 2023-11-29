using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ShitChat
{
    internal class User : Person
    {
        public string UserName; 
        public string Password; //Borde inte dessa två variabler ligga i User istället för Person? 

        public List<User> FriendsList = new List<User>();


        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }


        public void AddFriend(User user)
        {
            FriendsList.Add(user);
        }


        public void RemoveFriend(User user)
        {
            FriendsList.Remove(user);
        }
    }
}
