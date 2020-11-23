using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace DesignPatterns_GOF_Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new Chatroom();

            var markus = new User("Markus", mediator);
            var steven = new User("Steven", mediator);

            markus.Send("Grüezi");
            steven.Send("Servus");
            Console.ReadKey();
        }
    }

    interface IChatRoomMediator
    {
        void ShowMessage(User user, string message);
    }

    class Chatroom : IChatRoomMediator
    {
        public void ShowMessage(User user, string message)
        {
            Console.WriteLine($"{DateTime.Now.ToString("MMMM dd, H:mm")} [{user.GetName()}]:{message}");
        }
    }

    class User
    {
        private string mName;
        private IChatRoomMediator mChatRoom;

        public User(string name, IChatRoomMediator chatroom)
        {
            mChatRoom = chatroom;
            mName = name;
        }

        public string GetName()
        {
            return mName;
        }

        public void Send(string message)
        {
            mChatRoom.ShowMessage(this, message);
        }
    }
}
