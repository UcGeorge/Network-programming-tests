using System;
using System.Net.Sockets;
using System.IO;
using System.ComponentModel;
using System.Drawing;

namespace TestPeer_Peer
{
    class Server
    {
        //entry point of main method....
        [Obsolete]
        public Server()
        {
            //TcpListener is listening on the given port... {
            TcpListener tcpListener = new TcpListener(1234);
            tcpListener.Start();

            Console.WriteLine("Waiting for others...");

            //Accepts a new connection...
            Socket socketForClient = tcpListener.AcceptSocket();

            //StreamWriter and StreamReader Classes for reading and writing the data to and fro.
            //The server reads the meassage sent by the Client ,converts it to upper case and sends it back to the client.
            //Lastly close all the streams.
            try
            {
                if (socketForClient.Connected)
                {
                    string ClientName;
                    using (NetworkStream networkStream = new NetworkStream(socketForClient))
                    using (StreamWriter streamWriter = new StreamWriter(networkStream))
                    using (StreamReader streamReader = new StreamReader(networkStream))
                    {
                        ClientName = streamReader.ReadLine();
                        Console.WriteLine("{0} connected", ClientName);
                    }
                    
                    while (true)
                    {
                        using (NetworkStream networkStream = new NetworkStream(socketForClient))
                        using (StreamWriter streamWriter = new StreamWriter(networkStream))
                        using (StreamReader streamReader = new StreamReader(networkStream))
                        {
                            string line = streamReader.ReadLine();
                            Console.WriteLine("[Message from {0}]-----------------------------------\n{1}\n-----------------------------------", ClientName, line);
                            Console.Write("Reply: ");
                            line = Console.ReadLine();
                            streamWriter.WriteLine(line);
                            streamWriter.Flush();
                        }
                    }
                }
                socketForClient.Close();
                Console.WriteLine("Exiting...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
