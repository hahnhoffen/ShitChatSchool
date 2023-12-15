using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShitChat
{
    public class MessageManager
    {
        //Hämta currentUSer från Login??  currentUser = login.GetLoginnUser() 
        public User currentUser;

        public static string path = "Conversation";

        public void SetUser(User user)
        {
            this.currentUser = user;
        }


        public void CreateNewMessage(string message, User writer, User reciever)
        {
            
            Conversation conversation = writer.conversations.FirstOrDefault(c => c.Friend == reciever);

            if (conversation == null)
            {
               
                conversation = new Conversation(reciever);
                writer.conversations.Add(conversation);
            }

           
            conversation.messages.Add(new Message(message, writer, reciever));

           
            Conversation recipientConversation = reciever.conversations.FirstOrDefault(c => c.Friend == writer);

            if (recipientConversation == null)
            {
                recipientConversation = new Conversation(writer);
                reciever.conversations.Add(recipientConversation);
            }

            recipientConversation.messages.Add(new Message(message, writer, reciever));
        }



       //public void ReplyToConversation(string message, User writer, User reciever)
       //{
       //    Message newMessage = new Message(message, writer, reciever);
       //    foreach (Conversation con in writer.conversations)
       //    {
       //        if (con.User == reciever)
       //        {
       //            con.messages.Add(newMessage);
       //        }
       //        else
       //        {
       //            CreateNewMessage(message, writer, reciever);
       //        }
       //    }
       //}


        public void ExportToJson(string fileName, string location)
        {
            string file = System.IO.Path.Combine(location, fileName);
            try
            {
                System.IO.File.Create(file).Close();
                using (StreamWriter sw = new StreamWriter(file))
                {
                    foreach (Conversation conversation in currentUser.conversations)
                    {
                        sw.WriteLine(conversation.GetJson());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
