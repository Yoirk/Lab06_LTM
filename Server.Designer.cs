﻿namespace Lab6
{
    partial class Server
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
            this.rtbTienTrinh = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.txtSoNguoi = new System.Windows.Forms.TextBox();
            this.txtSoLuot = new System.Windows.Forms.TextBox();
            this.txtSoNho = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoLon = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rtbTienTrinh
            // 
            this.rtbTienTrinh.Location = new System.Drawing.Point(10, 216);
            this.rtbTienTrinh.Name = "rtbTienTrinh";
            this.rtbTienTrinh.Size = new System.Drawing.Size(701, 281);
            this.rtbTienTrinh.TabIndex = 0;
            this.rtbTienTrinh.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tiến trình trò chơi :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Phạm vi số cần tìm :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Số lượt chơi :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Số người tham gia :";
            // 
            // btnBatDau
            // 
            this.btnBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatDau.Location = new System.Drawing.Point(287, 528);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(126, 40);
            this.btnBatDau.TabIndex = 2;
            this.btnBatDau.Text = "Bắt đầu ";
            this.btnBatDau.UseVisualStyleBackColor = true;
            // 
            // txtSoNguoi
            // 
            this.txtSoNguoi.Location = new System.Drawing.Point(150, 36);
            this.txtSoNguoi.Name = "txtSoNguoi";
            this.txtSoNguoi.Size = new System.Drawing.Size(240, 20);
            this.txtSoNguoi.TabIndex = 3;
            // 
            // txtSoLuot
            // 
            this.txtSoLuot.Location = new System.Drawing.Point(150, 91);
            this.txtSoLuot.Name = "txtSoLuot";
            this.txtSoLuot.Size = new System.Drawing.Size(240, 20);
            this.txtSoLuot.TabIndex = 3;
            // 
            // txtSoNho
            // 
            this.txtSoNho.Location = new System.Drawing.Point(150, 144);
            this.txtSoNho.Name = "txtSoNho";
            this.txtSoNho.Size = new System.Drawing.Size(84, 20);
            this.txtSoNho.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(251, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "< x <";
            // 
            // txtSoLon
            // 
            this.txtSoLon.Location = new System.Drawing.Point(306, 144);
            this.txtSoLon.Name = "txtSoLon";
            this.txtSoLon.Size = new System.Drawing.Size(84, 20);
            this.txtSoLon.TabIndex = 3;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 598);
            this.Controls.Add(this.txtSoLon);
            this.Controls.Add(this.txtSoNho);
            this.Controls.Add(this.txtSoLuot);
            this.Controls.Add(this.txtSoNguoi);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbTienTrinh);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbTienTrinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.TextBox txtSoNguoi;
        private System.Windows.Forms.TextBox txtSoLuot;
        private System.Windows.Forms.TextBox txtSoNho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoLon;
    }
}

