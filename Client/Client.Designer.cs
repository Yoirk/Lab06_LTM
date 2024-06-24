namespace Client
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbSoDuDoan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtSoDuDoan = new System.Windows.Forms.TextBox();
            this.rtbThongBao = new System.Windows.Forms.RichTextBox();
            this.btnGui = new System.Windows.Forms.Button();
            this.btnTuDong = new System.Windows.Forms.Button();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên người chơi :";
            // 
            // lbSoDuDoan
            // 
            this.lbSoDuDoan.AutoSize = true;
            this.lbSoDuDoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoDuDoan.Location = new System.Drawing.Point(16, 85);
            this.lbSoDuDoan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSoDuDoan.Name = "lbSoDuDoan";
            this.lbSoDuDoan.Size = new System.Drawing.Size(103, 20);
            this.lbSoDuDoan.TabIndex = 0;
            this.lbSoDuDoan.Text = "Số dự đoán :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 206);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thông báo :";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(159, 34);
            this.txtTen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(537, 22);
            this.txtTen.TabIndex = 1;
            // 
            // txtSoDuDoan
            // 
            this.txtSoDuDoan.Location = new System.Drawing.Point(159, 84);
            this.txtSoDuDoan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSoDuDoan.Name = "txtSoDuDoan";
            this.txtSoDuDoan.Size = new System.Drawing.Size(537, 22);
            this.txtSoDuDoan.TabIndex = 1;
            // 
            // rtbThongBao
            // 
            this.rtbThongBao.Location = new System.Drawing.Point(20, 229);
            this.rtbThongBao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbThongBao.Name = "rtbThongBao";
            this.rtbThongBao.Size = new System.Drawing.Size(676, 477);
            this.rtbThongBao.TabIndex = 2;
            this.rtbThongBao.Text = "";
            // 
            // btnGui
            // 
            this.btnGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGui.Location = new System.Drawing.Point(20, 138);
            this.btnGui.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(159, 53);
            this.btnGui.TabIndex = 3;
            this.btnGui.Text = "Gửi";
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // btnTuDong
            // 
            this.btnTuDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuDong.Location = new System.Drawing.Point(204, 138);
            this.btnTuDong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTuDong.Name = "btnTuDong";
            this.btnTuDong.Size = new System.Drawing.Size(159, 53);
            this.btnTuDong.TabIndex = 3;
            this.btnTuDong.Text = "Tự động chơi";
            this.btnTuDong.UseVisualStyleBackColor = true;
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKetNoi.Location = new System.Drawing.Point(539, 138);
            this.btnKetNoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(159, 53);
            this.btnKetNoi.TabIndex = 3;
            this.btnKetNoi.Text = "Kết nối server";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 721);
            this.Controls.Add(this.btnKetNoi);
            this.Controls.Add(this.btnTuDong);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.rtbThongBao);
            this.Controls.Add(this.txtSoDuDoan);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbSoDuDoan);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Client";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSoDuDoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtSoDuDoan;
        private System.Windows.Forms.RichTextBox rtbThongBao;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.Button btnTuDong;
        private System.Windows.Forms.Button btnKetNoi;
    }
}

