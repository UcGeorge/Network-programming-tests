using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace TestPeer_Peer
{
    class Peer
    {
        TcpClient myclient;
        private NetworkStream networkStream;
        private StreamReader streamReader;
        private StreamWriter streamWriter;

        [Obsolete]
        public Peer()
        {
            string startingMessage = "[1] Host a conversation.\n[2] Join a conversation.\n[?] ";
            Console.Write(startingMessage);
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    _ = new Server();
                    break;

                case "2":
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        }
    }
}
