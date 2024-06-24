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
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Client
{
    public partial class Client : Form
    {
        #region Properties

        Socket client;
        Thread response;
        private System.Timers.Timer listenTimer;
        int secretnumber = 0;
        bool isWinner = false;
        private byte[] bufferClient = new byte[1024];
        private string name;

        #endregion
        public Client()
        {
            InitializeComponent();
            InitializeTimer();
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
            ReceiveMessages();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // Trước khi kết nối tới server thành công thì ẩn đi 
            lbSoDuDoan.Visible = false;
            txtSoDuDoan.Visible = false;
            btnGui.Visible = false;
            btnTuDong.Visible = false;  
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dọn sạch socket khi đóng form
            if (client != null && client.Connected)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }

        #region Function

        private void ReceiveMessages() 
        {
            int bytesRead = client.Receive(bufferClient);
            if (bytesRead > 0)
            {
                string receivedData = Encoding.UTF8.GetString(bufferClient, 0, bytesRead);
                ProcessReceivedData(receivedData);
            }
        }

        private void ProcessReceivedData(string data)
        {
            string[] parts = data.Split('/');
            if (parts.Length == 2)
            {
                string username = parts[0];
                string number = parts[1];
                if (username == this.name)
                {
                    UpdateChatBox("Bạn đã đoán đúng");
                }
                else
                {
                    UpdateChatBox($"Người chơi ' {username} ' đoán số: {number}");
                }
            }
            else
            {
                UpdateChatBox(data);
            }
        }

        private void UpdateChatBox(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateChatBox), message);
                return;
            }
            rtbThongBao.AppendText(message + Environment.NewLine);
        }

        #endregion

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            string playerName = txtTen.Text;
            name = txtTen.Text;

            // Đóng kết nối đã tồn tại nếu nó đang được mở
            if (client != null && client.Connected)
            {
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }

            if (!string.IsNullOrEmpty(playerName) )
            {
                try
                {
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    client.Connect("127.0.0.1", 12345);

                    byte[] nameBuffer = Encoding.UTF8.GetBytes(playerName);
                    client.Send(nameBuffer);

                    response = new Thread(ReceiveMessages); // Khởi tạo thread lắng nghe thông báo từ server
                    response.IsBackground = true;
                    response.Start();

                    lbSoDuDoan.Visible = true;
                    txtSoDuDoan.Visible = true;
                    btnGui.Visible = true;
                    btnTuDong.Visible = true;
                    btnKetNoi.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền tên người chơi!", "Cảnh báo");
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (txtSoDuDoan.Text == "")
            {
                MessageBox.Show("Hãy điền số muốn dự đoán!");
            }
            else 
            {
                string dudoan= $"{txtTen.Text}/{txtSoDuDoan.Text}";
                byte[] nameBuffer = Encoding.UTF8.GetBytes(dudoan);
                client.Send(nameBuffer);
            } 
        }
    }
}
