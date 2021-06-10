//Client Code
using System;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Drawing;

namespace TestClient
{
    class Client : Form
    {
        //Define the components...
        private Button b1;
        private TextBox t1, ta;
        TcpClient myclient;
        private NetworkStream networkStream;
        private StreamReader streamReader;
        private StreamWriter streamWriter;

        //constructor initialising...
        public Client()
        {
            InitializeComponent();
        }

        //main method...
        public static void Main()
        {
            Client df = new Client();
            df.FormBorderStyle = FormBorderStyle.Fixed3D;
            Application.Run(df);
        }

        public void InitializeComponent()
        {
            b1 = new Button();
            b1.Location = new System.Drawing.Point(170, 20);
            b1.Size = new System.Drawing.Size(80, 40);
            b1.Text = "Click Here";
            b1.Click += new System.EventHandler(b1_Click);
            b1.BackColor = System.Drawing.Color.Transparent;
            b1.ForeColor = System.Drawing.Color.Red;
            /*b1.BackgroundImage = Image.FromFile("back4.gif");*/
            b1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f,
            System.Drawing.FontStyle.Bold);
            t1 = new TextBox();
            t1.Location = new System.Drawing.Point(20, 20);
            t1.Size = new System.Drawing.Size(100, 100);
            ta = new TextBox();
            ta.Multiline = true;
            ta.ScrollBars = ScrollBars.Vertical;
            ta.AcceptsReturn = true;
            ta.AcceptsTab = true;
            ta.WordWrap = true;
            ta.Location = new System.Drawing.Point(20, 80);
            this.SuspendLayout();
            this.Text = "Socket Programming";
            this.MaximizeBox = false;
            /*this.BackgroundImage = Image.FromFile("back3.gif");*/
            this.Name = "Form1";
            this.Controls.Add(this.b1);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.ta);
            this.Closing += new CancelEventHandler(form1_closing);
            //connect to the "localhost" at the give port
            //if you have some other server name then you can use that instead of "localhost"
            String host_Name = "localhost";
            int port_Number = 1234;
            try
            {
                Console.WriteLine("Press enter co connect... ");
                Console.ReadLine();
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
        //User can enter a text in the textbox and on click of the button the message will be sent to the server..
        //then the Client waits and receives the response from the server which is displayed in the textarea..
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
    }
}
