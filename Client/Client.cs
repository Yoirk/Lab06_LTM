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
using System.Windows.Forms;
using System.Xml.Linq;

namespace Client
{
    public partial class Client : Form
    {
        #region Properties

        Socket client;
        Thread response;

        #endregion
        public Client()
        {
            InitializeComponent();
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
            try
            {
                byte[] buffer = new byte[1024];
                while (true)
                {
                    int received = client.Receive(buffer);
                    string message = Encoding.UTF8.GetString(buffer, 0, received);
                    UpdateChatBox(message);
                }
            }
            catch (Exception ex)
            {
                UpdateChatBox($"Error: {ex.Message}");
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

                    MessageBox.Show("Connected to the server!");
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
    }
}
