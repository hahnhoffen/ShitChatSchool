using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitChat
{
    public class MessageManager
    {

        User currentUser;

        public static string path = "Conversation";



        public void CreateNewMessage(string message, User writer, User reciever)
        {
            Message newMessage = new Message(message, writer, reciever);
            writer.conversations.Add(new Conversation(newMessage, reciever));
            reciever.conversations.Add(new Conversation(newMessage, writer));
        }


        public void ReplyToConversation(string message, User writer, User reciever)
        {
            Message newMessage = new Message(message, writer, reciever);
            foreach (Conversation con in writer.conversations)
            {
                if (con.User == reciever)
                {
                    con.messages.Add(newMessage);
                }
                else
                {
                    CreateNewMessage(message, writer, reciever);
                }
            }
        }


      //  public void ExportToJson(string fileName, string location)
      //  {
      //      string file = System.IO.Path.Combine(location, fileName);
      //
      //      
      //      
      //      try
      //      {
      //          System.IO.File.Create(file).Close();
      //          using (StreamReader reader = new StreamReader(file))
      //          {
      //              foreach (Conversation conversation in currentUser)
      //              {
      //                  switch.WriteLine(conversation.messages.GetJson)
      //              }
      //          }
      //      
      //      }
      //      catch (Exception ex)
      //      {
      //          Console.WriteLine(ex.Message);
      //      }
      //  }

    }
}
