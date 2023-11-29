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
        User currentUser;

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
    }
}
