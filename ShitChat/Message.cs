using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShitChat
{
    public class Message
    {
        public string MessageString { get; set; }
        public string Writer {  get; set; }
        public string Reciever { get; set; }


        public Message(string messageString, string writer, string reciever)
        {
            this.MessageString = messageString;
            this.Writer = writer;   
            this.Reciever = reciever;
        }
    }
}
