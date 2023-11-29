using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitChat
{
    internal class Message
    {
        public string MessageString;
        public User Writer;
        public User Reciever;
        public string TimeStamp;


        public Message(string messageString, User writer, User reciever, string timeStamp)
        {
            this.MessageString = messageString;
            this.Writer = writer;   
            this.Reciever = reciever;
            this.TimeStamp = timeStamp;
        }
    }
}
