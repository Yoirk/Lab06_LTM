using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Server : Form
    {
        #region Properties

        private Socket server;
        private Thread listenThread;
        private int SoLuongClient = 0;
        private Random x = new Random();
        public string IP = "127.0.0.1";

        #endregion

        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            // Khởi chạy server thread
            listenThread = new Thread(StartServer);
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clean up the server socket
            server?.Close();
            listenThread?.Abort();
        }

        #region Fuction 

        private void StartServer()
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(IP), 12345);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipep);
            server.Listen(10);
            UpdateGameProgress("Server started, waiting for clients...");

            while (true)
            {
                // Chấp nhận kết nối client socket
                Socket clientSocket = server.Accept();
                SoLuongClient++;
                UpdateGameProgress("Client connected.");
                UpdateNumClients();
            }
        }

        private void UpdateGameProgress(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateGameProgress), message);
                return;
            }
            rtbTienTrinh.AppendText(message + Environment.NewLine);
        }

        private void UpdateNumClients()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateNumClients));
                return;
            }
            txtSoNguoi.Text = SoLuongClient.ToString();
        }

        #endregion

        #region Event

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            // Random số lượt chơi (tối thiểu là 5)
            int numRounds = x.Next(5, 11);
            txtSoLuot.Text = numRounds.ToString();

            // Random số x bí mật và hiển thị phạm vi
            int secretNumber = x.Next(1, 101);
            int lowerBound = Math.Max(1, secretNumber - 10);
            int upperBound = Math.Min(100, secretNumber + 10);
            txtSoNho.Text = lowerBound.ToString();
            txtSoLon.Text = upperBound.ToString();

            btnBatDau.Visible = false;
        }

        #endregion
    }
}
