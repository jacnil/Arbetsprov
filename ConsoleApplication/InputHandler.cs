using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.TechnicalServices;

namespace ConsoleApplication
{
    class InputHandler
    {
        public void Run() 
        {
            string relativePath = Path.GetFullPath(@"..\..\..\WebSite\App_Data\Messages.sdf");
            string connectionString = "Data Source=" + relativePath;
            DatabaseManager databaseManager = new DatabaseManager(connectionString);

            Console.Out.WriteLine("Write your message and press enter so send it to the database");
            Console.Out.WriteLine("Enter quit to quit the application");

            while (true) 
            {
                Console.Write("Enter new message: ");
                String message = Console.In.ReadLine();
                DateTime time = DateTime.Now;

                if (message.Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("(" + time + ") " + message);
                    databaseManager.WriteMessageToDatabase(time, message);
                }
            }
        }
    }
}
