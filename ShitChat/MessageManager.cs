using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitChat
{
    public class MessageManager
    {

        public void CreateMessage(string message, User writer, User reciever, Conversation conversation)
        {
            conversation.listOfConversations.Add(new Message(message, writer, reciever));
        }
    }
}
