using System;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Client
{
    class Program
    {
        //Checking for incoming messages
        public class CheckMessage
        {

            public void Check(TcpClient tcpClient)
            {
                StreamReader streamReader = new StreamReader(tcpClient.GetStream());

                //Checks are carried out continuously until when the program is run
                while (true)
                {
                    try
                    {
                        string message = streamReader.ReadLine();
                        Console.WriteLine(message);
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                        break;
                    }
                }
            }
        }

        //Record incoming messages on the main function
        static void Main(string[] args)
        {
            CheckMessage read = new CheckMessage();
            Console.WriteLine("Enter Your Name: ");
            string name = Console.ReadLine();

            //When data is entered, the data is read and shown
            try
            {
                TcpClient tcpClient = new TcpClient("126.0.0.1", 1000);
                Console.WriteLine("Connect to Server.");

                Thread thread = new Thread(() => read.Check(tcpClient));
                thread.Start();

                StreamWriter streamWriter = new StreamWriter(tcpClient.GetStream());

                while (true)
                {
                    if (tcpClient.Connected)
                    {
                        string input = Console.ReadLine();
                        streamWriter.WriteLine(name + " : " + input);
                        streamWriter.Flush();
                    }
                }

            }

            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            Console.ReadKey();

        }
    }
}