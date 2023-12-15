using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitChat.UserControls
{
    public class FriendsManager
    {
        public User currentUser;

        public void ThisUser(User user) 
        { 
            this.currentUser = user; 
        }
    }
}
