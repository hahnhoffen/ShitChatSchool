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
        public string Writer;
        public string Reciever;
        public string TimeStamp;


        public Message(string messageString, string writer, string reciever, string timeStamp)
        {
            this.MessageString = messageString;
            this.Writer = writer;   
            this.Reciever = reciever;
            this.TimeStamp = timeStamp;
        }


    }
}
