using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitChat
{
    public class Conversation
    {
        public List<Message> messages;
        public User User { get; set; }
        public int conversationId {  get; set; }

        public static int conversationNextId = 1;
        

        public Conversation(Message message, User reciever)
        {
            this.conversationId = conversationNextId++;
            this.User = reciever;
        }
    }
}
