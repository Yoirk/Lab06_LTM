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
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên người chơi :";
            // 
            // lbSoDuDoan
            // 
            this.lbSoDuDoan.AutoSize = true;
            this.lbSoDuDoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoDuDoan.Location = new System.Drawing.Point(12, 69);
            this.lbSoDuDoan.Name = "lbSoDuDoan";
            this.lbSoDuDoan.Size = new System.Drawing.Size(82, 16);
            this.lbSoDuDoan.TabIndex = 0;
            this.lbSoDuDoan.Text = "Số dự đoán :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thông báo :";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(119, 28);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(404, 20);
            this.txtTen.TabIndex = 1;
            // 
            // txtSoDuDoan
            // 
            this.txtSoDuDoan.Location = new System.Drawing.Point(119, 68);
            this.txtSoDuDoan.Name = "txtSoDuDoan";
            this.txtSoDuDoan.Size = new System.Drawing.Size(404, 20);
            this.txtSoDuDoan.TabIndex = 1;
            // 
            // rtbThongBao
            // 
            this.rtbThongBao.Location = new System.Drawing.Point(15, 186);
            this.rtbThongBao.Name = "rtbThongBao";
            this.rtbThongBao.Size = new System.Drawing.Size(508, 388);
            this.rtbThongBao.TabIndex = 2;
            this.rtbThongBao.Text = "";
            // 
            // btnGui
            // 
            this.btnGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGui.Location = new System.Drawing.Point(15, 112);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(119, 43);
            this.btnGui.TabIndex = 3;
            this.btnGui.Text = "Gửi";
            this.btnGui.UseVisualStyleBackColor = true;
            // 
            // btnTuDong
            // 
            this.btnTuDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuDong.Location = new System.Drawing.Point(153, 112);
            this.btnTuDong.Name = "btnTuDong";
            this.btnTuDong.Size = new System.Drawing.Size(119, 43);
            this.btnTuDong.TabIndex = 3;
            this.btnTuDong.Text = "Tự động chơi";
            this.btnTuDong.UseVisualStyleBackColor = true;
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKetNoi.Location = new System.Drawing.Point(404, 112);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(119, 43);
            this.btnKetNoi.TabIndex = 3;
            this.btnKetNoi.Text = "Kết nối server";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 586);
            this.Controls.Add(this.btnKetNoi);
            this.Controls.Add(this.btnTuDong);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.rtbThongBao);
            this.Controls.Add(this.txtSoDuDoan);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbSoDuDoan);
            this.Controls.Add(this.label1);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
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

