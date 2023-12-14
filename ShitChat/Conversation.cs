using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShitChat
{
    public class Conversation
    {
        public List<Message> messages = new List<Message>();
        public User Friend { get; set; }
        public int ConversationId { get; set; }
        public static int ConversationNextId = 1;

        public Conversation(User friend)
        {
            this.ConversationId = ConversationNextId++;
            this.Friend = friend;
        }

        public string GetJson()
        {
            string jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }
    }
}
