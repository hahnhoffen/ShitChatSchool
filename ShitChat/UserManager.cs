using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShitChat
{
    public class UserManager
    {
        RegisterWindow registerWindow;
        public User currentUser;
        public string usersPath = "users.json";

        public UserManager()
        {

        }


        public void SetUser(User user)
        {
            this.currentUser = user;
            currentUser.friendsList.Add(new User("Example friend 1", "1234"));
            currentUser.friendsList.Add(new User("Example friend 2", "1234"));
        }


       public void SetRegisterWindow(RegisterWindow registerWindow)
       {
           this.registerWindow = registerWindow;
       }
     
     
       public void DeleteUser(string userName)
       {
           foreach (User user in registerWindow.userList)
           {
               registerWindow.userList.Remove(user);
           }
       }


        public void SaveUserListToJson()
        {
            string json = JsonConvert.SerializeObject(registerWindow.userList, Newtonsoft.Json.Formatting.Indented);
            StreamWriter sw = new StreamWriter(usersPath);
            sw.WriteLine(json);
            sw.Close();
        }
    }
}
