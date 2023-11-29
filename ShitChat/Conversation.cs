using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitChat
{
    public class Conversation
    {
        public List<Message> listOfConversations = new List<Message>();
        public string Description {  get; set; }
        public User User1 { get; set; }
        public User User2 { get; set; }


    }
}
