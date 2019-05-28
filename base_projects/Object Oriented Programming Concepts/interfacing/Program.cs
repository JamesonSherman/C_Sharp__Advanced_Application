using System;

namespace interfaces
{
    class Program
    {
        //interface defines methods for use and can be over written
        public interface INotifications
        {
            void showNotifications();
            string getDate();
        }

        public class Notifications: INotifications
        {
            private string sender;
            private string message;
            private string date;

            //default constructor
            public Notifications()
            {
                sender = "admin";
                message = " Hello world";
                date = " ";
            }


            public Notifications(string peram_sender, string peram_message, string peram_mydate)
            {
                this.sender = peram_sender;
                this.message = peram_message;
                this.date = peram_mydate;
            }
            //we create and give the INotifcations interface verbosity within the called class
            //via inheritance
            public void showNotifications()
            {
                Console.WriteLine("message {0} was sent by {1} at {2}", message, sender, date);
            }

            public string getDate()
            {
                return date;
            }
        }
        static void Main(string[] args)
        {
            Notifications note = new Notifications("james", "hello world", "12.06.2018");
            Notifications note1 = new Notifications("frank", "papa franku here", "12.06.2018");
            note.showNotifications();
            note1.showNotifications();
        }
    }
}
