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

namespace Client
{
    public partial class Client : Form
    {
        #region Properties

        Socket client;
        Thread response;
        public string IP = "127.0.0.1";

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

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(IP), 12345);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(ipep);
                lbSoDuDoan.Visible = true;
                txtSoDuDoan.Visible = true;
                btnGui.Visible = true;
                btnTuDong.Visible = true;
                btnKetNoi.Visible = false;
            }
            catch
            {
            }
        }
    }
}
