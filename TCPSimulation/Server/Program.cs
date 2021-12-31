using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace Server
{
    //Processing client requests
    class DataProcessing
    {
        SaveData save = new SaveData();

        public List<TcpClient> clientList = new List<TcpClient>();

        public void addClients(TcpClient client)
        {
            clientList.Add(client);
        }

        //Retrieve messages from clients
        public void GetMessage(TcpClient tcpClient)
        {
            Console.WriteLine("Client Connected.");
            StreamReader reader = new StreamReader(tcpClient.GetStream());

            //Every incoming message will be read and recorded
            while (true)
            {
                string message = reader.ReadLine();
                Broadcast(message, tcpClient);

                string chat = message;
                Console.WriteLine(chat);

                save.writeMessage(chat);
            }
        }

        //Save data into file .txt
        class SaveData
        {
            private List<string> saveMessages = new List<string>();
            public void writeMessage(string chat)
            {
                saveMessages.Add(chat);
                File.WriteAllLines("D:/Kelas 3/smt 5/tugas/pemrograman jaringan komputer/week2/doni/TCPSimulation/TCPSimulation/Server/ChatHistory.txt", saveMessages);
            }
        }

        //Retrieve message from sender and pass to recipient 
        public void Broadcast(string message, TcpClient excludeClient)
        {
            foreach (TcpClient client in clientList)
            {

                StreamWriter sWriter = new StreamWriter(client.GetStream());

                if (client != excludeClient)
                {
                    sWriter.WriteLine(message);
                }

                sWriter.Flush();
            }
        }
    }

    //Record all incoming client data on the main function
    class Program
    {
        public static TcpListener tcpListener;

        static void Main(string[] args)
        {
            DataProcessing dataClient = new DataProcessing();

            tcpListener = new TcpListener(IPAddress.Any, 1000);
            tcpListener.Start();
            Console.WriteLine("Server Created.");

            //To check the client connected to the server
            while (true)
            {

                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                dataClient.addClients(tcpClient);

                Thread startListen = new Thread(() => dataClient.GetMessage(tcpClient));
                startListen.Start();
            }
        }
    }
}
