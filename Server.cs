using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Server : Form
    {
        #region Properties

        private Socket server;
        public Socket client;
        private Thread listenThread;
        private int SoLuongClient = 0;
        private int SoLuotChoi;
        private Random x = new Random();
        public string IP = "127.0.0.1";
        public List<Socket> clientSockets = new List<Socket>();
        public List<string> DSUser = new List<string>();
        private List<int> randomNumbers;
        private int lowerBound;
        private int upperBound;
        private bool haveWinner = false;
        private System.Timers.Timer listenTimer;
        private byte[] bufferServer = new byte[1024];

        #endregion

        public Server()
        {
            InitializeComponent();
            InitializeTimer(); // Cứ 0.5s thì listen một lần
        }

        private void InitializeTimer()
        {
            listenTimer = new System.Timers.Timer(500); // thời gian chờ giữa các lần gọi hàm Listen (1000ms = 1 giây)
            listenTimer.Elapsed += OnTimedEvent;
            listenTimer.AutoReset = true;
            listenTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Listen();
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
                client = server.Accept();
                clientSockets.Add(client);
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.IsBackground = true;
                clientThread.Start();
            }
        }

        public void HandleClient(Socket client)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int received = client.Receive(buffer);
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

        public void Broadcast(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            List<Socket> tempClientSockets = new List<Socket>(clientSockets);

            foreach (Socket clientSocket in tempClientSockets)
            {
                try
                {
                    if (clientSocket.Connected)
                    {
                        clientSocket.Send(data);
                    }
                }
                catch 
                {

                }
            }
        }

        public void Listen()
        {
            List<Socket> tempClientSockets = new List<Socket>(clientSockets);
            foreach (Socket clientSocket in tempClientSockets)
            {
                if (clientSocket.Poll(10, SelectMode.SelectRead) && clientSocket.Available == 0)
                {
                    // Client has disconnected
                    clientSocket.Close();
                    clientSockets.Remove(clientSocket);
                    continue;
                }

                if (clientSocket.Available > 0)
                {
                    int bytesRead = clientSocket.Receive(bufferServer);
                    if (bytesRead > 0)
                    {
                        string receivedData = Encoding.UTF8.GetString(bufferServer, 0, bytesRead);
                        ProcessReceivedData(receivedData);
                    }
                }
            }
        }

        public void ProcessReceivedData(string data)
        {
            string[] parts = data.Split('/');
            if (parts.Length == 2)
            {
                string username = parts[0];
                string numberStr = parts[1];
                int number;

                if (Int32.TryParse(numberStr, out number))
                {
                    if (number == randomNumbers[0])
                    {
                        string successMessage = $"Người chơi '{username}' đoán đúng";
                        UpdateGameProgress(successMessage);

                        SoLuotChoi--;

                        // Update the text box containing the number of remaining attempts
                        UpdateSoLuotChoiTextBox(SoLuotChoi);

                        // Broadcast the result to all clients
                        Broadcast(successMessage);
                    }
                }
                else
                {
                    string invalidNumberMessage = "Invalid number format received.";
                    UpdateGameProgress(invalidNumberMessage);
                    Broadcast(invalidNumberMessage);
                }
            }
        }

        private void UpdateSoLuotChoiTextBox(int value)
        {
            if (txtSoLuot.InvokeRequired)
            {
                txtSoLuot.Invoke(new Action<int>(UpdateSoLuotChoiTextBox), value);
            }
            else
            {
                txtSoLuot.Text = value.ToString();
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

        private void UpdateLow()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateLow));
                return;
            }
            txtSoNho.Text = lowerBound.ToString();
        }

        private void UpdateHigh()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateHigh));
                return;
            }
            txtSoLon.Text = upperBound.ToString();
        }

        private void CreateRandom()
        {
            randomNumbers.Clear();
            int randomNumber = x.Next(1, 101); // Random từ 1 tới 100
            randomNumbers.Add(randomNumber);

            // Cập nhật phạm vi
            lowerBound = randomNumber - 5;
            upperBound = randomNumber + 10;

            // Cập nhật UI
            UpdateLow();
            UpdateHigh();

            // Broadcast tới tất cả client
            string rangeMessage = $"{lowerBound}/{upperBound}/{SoLuotChoi}";
            string range = $"Phạm vi dự đoán từ {lowerBound} đến {upperBound}";
            UpdateGameProgress(range);
            Broadcast(rangeMessage);
            SoLuotChoi--;
            Countdown();
        }
        
        private void Countdown()
        {
            Thread count = new Thread(() =>
            {
                for (int i = 10; i > 0; i--)
                {
                    Thread.Sleep(1000);
                }
                UpdateSoLuotChoiTextBox(SoLuotChoi);
                if (SoLuotChoi == 0)
                {
                    MessageBox.Show("Hết game");
                    string content = rtbTienTrinh.Text;

                    // Gửi dữ liệu lên ctxt.io và nhận lại URL chia sẻ
                    Task.Run(async () =>
                    {
                        string url = await UploadToCtxtIO(content);

                    });

                    this.Close();
                }
                else
                {
                    CreateRandom();
                }
            });
            count.IsBackground = true;
            count.Start();
        }
        async Task<string> UploadToCtxtIO(string text)
        {
            using (var client = new HttpClient())
            {
                var url = "https://ctxt.io/submit";
                var data = new StringContent(text, Encoding.UTF8, "text/plain");

                var response = await client.PostAsync(url, data);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result; // Trả về URL của văn bản đã được chia sẻ
                }
                else
                {
                    return null; // Xử lý lỗi nếu cần
                }
            }
        }
        #endregion

        #region Event

        private void btnBatDau_Click(object sender, EventArgs e)
        {

            if (SoLuongClient < 2) // Kiểm tra xem có từ 2 người chơi trở lên hay chưa 
            {
                MessageBox.Show("Chưa thể bắt đầu trò chơi", "Thông báo");
            }
            else
            {
                if (txtSoLuot.Text == "")
                {
                    MessageBox.Show("Nhập số lượt chơi");
                }
                else
                {
                    if (Int32.Parse(txtSoLuot.Text) < 5)
                    {
                        MessageBox.Show("Số lượt chơi tối thiểu là 3");
                    }
                    else
                    {
                        SoLuotChoi = Int32.Parse(txtSoLuot.Text);
                        randomNumbers = new List<int>();

                        CreateRandom();
                    }
                }
            }  
        }

        #endregion
    }
}
