using System;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace TestPeer_Peer
{
    class Client
    {
        TcpClient myclient;
        private NetworkStream networkStream;
        private StreamReader streamReader;
        private StreamWriter streamWriter;

        public Client()
        {
            /*IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            Console.WriteLine(ipAddress.AddressFamily.ToString());*/

            String host_Name = "localhost";
            int port_Number = 1234;
            try
            {
                myclient = new TcpClient(host_Name, port_Number);
            }
            catch
            {
                //Console.WriteLine("Failed to connect to server at {0}:{1}", host_Name, port_Number);
                Console.WriteLine("Failed to Connect to server at " + host_Name + ":" + port_Number.ToString());
                return;
            }
            //get a Network stream from the server
            networkStream = myclient.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
        }
        /*
         private void b1_Click(object sender, EventArgs e)
        {
            ta.Text = "";
            if (t1.Text == "")
            {
                MessageBox.Show("Please enter something in the textbox");
                t1.Focus();
                return;
            }
            try
            {
                string s;
                streamWriter.WriteLine(t1.Text);
                Console.WriteLine("Sending Message");
                streamWriter.Flush();
                s = streamReader.ReadLine();
                Console.WriteLine("Reading Message");
                Console.WriteLine(s);
                ta.Text = s;
            }
            catch (Exception ee)
            {
                Console.WriteLine("Exception reading from Server:" + ee.ToString());
            }
        }

        public void form1_closing(object o, CancelEventArgs ec)
        {
            //close all streams...
            streamReader.Close();
            streamWriter.Close();
            networkStream.Close();
        }
         */
    }
}
