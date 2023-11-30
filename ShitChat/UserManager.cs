using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ShitChat
{
    public  class UserManager
    {
        RegisterWindow registerWindow;
        public User currentUser;

        public void SetUser(User user)
        {
            this.currentUser = user;
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


        internal bool LogInUser(string username, string password)
        {
            foreach (User user in registerWindow.userList)
            {
                if (user.Username == username)
                {
                    user.LogIn(username, password);
                    currentUser = user;
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }
    }
}
