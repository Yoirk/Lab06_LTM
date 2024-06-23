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
        private int SoLuotChoi;
        private Random x = new Random();
        public string IP = "127.0.0.1";
        private List<Socket> clientSockets = new List<Socket>();

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

            //// Trước khi trò chơi được bắt đầu thì tạm ẩn đi các đối tượng sau
            //lbSoLuotChoi.Visible = false;
            //lbPhamVi.Visible = false;
            //lbx.Visible = false;
            //txtSoLuot.Visible = false;
            //txtSoNho.Visible = false;
            //txtSoLon.Visible = false;
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dọn sạch socket sau khi đóng form
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
            UpdateGameProgress("Server đã bắt đầu, đang chờ các client...");

            while (true)
            {
                // Chấp nhận kết nối từ client
                Socket clientSocket = server.Accept();
                lock (clientSockets)
                {
                    clientSockets.Add(clientSocket);
                }
                Thread clientThread = new Thread(() => HandleClient(clientSocket));
                clientThread.IsBackground = true;
                clientThread.Start();
            }
        }

        private void HandleClient(Socket clientSocket)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int received = clientSocket.Receive(buffer);
                string clientName = Encoding.UTF8.GetString(buffer, 0, received);

                SoLuongClient++;
                UpdateGameProgress($"Client ' {clientName} ' đã kết nối.");
                UpdateNumClients();
            }
            catch (Exception ex)
            {
                UpdateGameProgress($"Error: {ex.Message}");
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

        private void StartRound()
        {

            if (SoLuotChoi > 0)
            {
                // từ số được quy định bới server mà máy sẽ random ra 1 số trong khoảng đã định 

                int secretNumber = x.Next(Int32.Parse(txtSoNho.Text.Trim()), Int32.Parse(txtSoLon.Text.Trim()));



                /*int secretNumber = x.Next(1, 101);
                int lowerBound = Math.Max(1, secretNumber - 10);
                int upperBound = Math.Min(100, secretNumber + 10);
                txtSoNho.Text = lowerBound.ToString();
                txtSoLon.Text = upperBound.ToString();*/

                string roundMessage = $"Trò chơi đã bắt đầu! Đoán số từ {txtSoNho.Text} đến {txtSoLon.Text}.";
                UpdateGameProgress(roundMessage);

                //lbSoLuotChoi.Visible = true;
                //lbPhamVi.Visible = true;
                //lbx.Visible = true;
                //txtSoLuot.Visible = true;
                //txtSoNho.Visible = true;
                //txtSoLon.Visible = true;
                btnBatDau.Visible = false;

                lock (clientSockets)
                {
                    foreach (Socket clientSocket in clientSockets)
                    {
                        if (clientSocket.Connected)
                        {
                            byte[] messageBuffer = Encoding.UTF8.GetBytes(roundMessage);
                            clientSocket.Send(messageBuffer);
                        }
                    }
                }

                Countdown(3, "Round starting in {0} seconds...");


                StartRound();
                //txtSoLuot.Text = SoLuotChoi.ToString();
            }
            else
            {
                string gameOverMessage = "Trò chơi kết thúc!";
                lock (clientSockets)
                {
                    foreach (Socket clientSocket in clientSockets)
                    {
                        if (clientSocket.Connected)
                        {
                            byte[] messageBuffer = Encoding.UTF8.GetBytes(gameOverMessage);
                            clientSocket.Send(messageBuffer);
                        }
                    }
                }
                UpdateGameProgress(gameOverMessage);
            }
        }

        private void Countdown(int seconds, string message)
        {
            for (int i = seconds; i > 0; i--)
            {
                string countdownMessage = string.Format(message, i);
                lock (clientSockets)
                {
                    foreach (Socket clientSocket in clientSockets)
                    {
                        if (clientSocket.Connected)
                        {
                            byte[] messageBuffer = Encoding.UTF8.GetBytes(countdownMessage);
                            clientSocket.Send(messageBuffer);
                        }
                    }
                }
                UpdateGameProgress(countdownMessage);
                Thread.Sleep(1000);
            }
            SoLuotChoi--;

        }

        #endregion

        #region Event

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (SoLuongClient >= 2 && SoLuongClient == Int32.Parse(txtSoNguoi.Text.Trim())) // Kiểm tra xem có từ 2 người chơi trở lên hay chưa và đủ số người chơi hay chưa 
            {

                SoLuotChoi = Int32.Parse(txtSoLuot.Text.Trim());
                // if (SoLuotChoi>=5) //số lượt chơi (tối thiểu là 5)
                StartRound();
            }
            else
            {
                MessageBox.Show("Chưa thể bắt đầu trò chơi", "Thông báo");
            }
        }

        #endregion
    }
}
