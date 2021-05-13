//Server Code
using System;
using System.Net.Sockets;
using System.IO;


namespace Network_programming_tests
{
    class Server
    {
        //entry point of main method....
        [Obsolete]
        public static void Main()
        {
            //TcpListener is listening on the given port... {
            TcpListener tcpListener = new TcpListener(1234);
            tcpListener.Start();
            Console.WriteLine("Server Started");
            //Accepts a new connection...
            Socket socketForClient = tcpListener.AcceptSocket();
            //StreamWriter and StreamReader Classes for reading and writing the data to and fro.
            //The server reads the meassage sent by the Client ,converts it to upper case and sends it back to the client.
            //Lastly close all the streams.
            try
            {
                if (socketForClient.Connected)
                {
                    while (true)
                    {
                        Console.WriteLine("Client connected");
                        NetworkStream networkStream = new NetworkStream(socketForClient);
                        StreamWriter streamWriter = new StreamWriter(networkStream);
                        StreamReader streamReader = new StreamReader(networkStream);
                        string line = streamReader.ReadLine();
                        Console.WriteLine("Read:" + line);
                        line = line.ToUpper() + "!";
                        streamWriter.WriteLine(line);
                        Console.WriteLine("Wrote:" + line);
                        streamWriter.Flush();
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
