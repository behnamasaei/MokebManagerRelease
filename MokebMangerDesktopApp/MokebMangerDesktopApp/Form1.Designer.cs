namespace MokebMangerDesktopApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblAngularIp = new LinkLabel();
            lblDotnetIp = new LinkLabel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnRunDotnet = new Button();
            label5 = new Label();
            label6 = new Label();
            lblWait = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblAngularIp);
            panel1.Controls.Add(lblDotnetIp);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 325);
            panel1.Name = "panel1";
            panel1.Size = new Size(845, 254);
            panel1.TabIndex = 0;
            // 
            // lblAngularIp
            // 
            lblAngularIp.AutoSize = true;
            lblAngularIp.Font = new Font("Segoe UI", 13F);
            lblAngularIp.Location = new Point(0, 147);
            lblAngularIp.Name = "lblAngularIp";
            lblAngularIp.Size = new Size(90, 25);
            lblAngularIp.TabIndex = 6;
            lblAngularIp.TabStop = true;
            lblAngularIp.Text = "linkLabel1";
            // 
            // lblDotnetIp
            // 
            lblDotnetIp.AutoSize = true;
            lblDotnetIp.Font = new Font("Segoe UI", 13F);
            lblDotnetIp.Location = new Point(3, 72);
            lblDotnetIp.Name = "lblDotnetIp";
            lblDotnetIp.Size = new Size(90, 25);
            lblDotnetIp.TabIndex = 6;
            lblDotnetIp.TabStop = true;
            lblDotnetIp.Text = "linkLabel1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(513, 190);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(329, 21);
            label4.TabIndex = 5;
            label4.Text = "توجه فرمایید آدرس ها کامل و به درستی وارد شود.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(421, 101);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(421, 21);
            label3.TabIndex = 3;
            label3.Text = "سپس آدرس زیر را در مرورگر باز کرده و تمام تائیدیه ها داده شود:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(432, 30);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(410, 21);
            label2.TabIndex = 1;
            label2.Text = "ابتدا آدرس زیر را در مرورگر باز کرده و تمام تائیدیه ها داده شود:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(401, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(441, 21);
            label1.TabIndex = 0;
            label1.Text = "این برنامه در مرورگر های تحت شبکه با آدرس زیر در دسترس هستند:";
            // 
            // btnRunDotnet
            // 
            btnRunDotnet.Location = new Point(702, 73);
            btnRunDotnet.Name = "btnRunDotnet";
            btnRunDotnet.Size = new Size(155, 39);
            btnRunDotnet.TabIndex = 1;
            btnRunDotnet.Text = "اجرای برنامه";
            btnRunDotnet.UseVisualStyleBackColor = true;
            btnRunDotnet.Click += btnRunDotnet_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(337, 9);
            label5.Name = "label5";
            label5.Size = new Size(196, 28);
            label5.TabIndex = 3;
            label5.Text = "بسم الله الرحمن الرحیم";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(277, 37);
            label6.Name = "label6";
            label6.Size = new Size(301, 15);
            label6.TabIndex = 4;
            label6.Text = "سامانه مدیریت اسکان زائرین موکب شهدای فاوا (نسخه اولیه)";
            // 
            // lblWait
            // 
            lblWait.AutoSize = true;
            lblWait.Font = new Font("Segoe UI", 15F);
            lblWait.Location = new Point(306, 262);
            lblWait.Name = "lblWait";
            lblWait.RightToLeft = RightToLeft.Yes;
            lblWait.Size = new Size(258, 28);
            lblWait.TabIndex = 6;
            lblWait.Text = "در حال راه اندازی منظر بمانید...";
            // 
            // button1
            // 
            button1.Location = new Point(702, 184);
            button1.Name = "button1";
            button1.RightToLeft = RightToLeft.Yes;
            button1.Size = new Size(152, 37);
            button1.TabIndex = 7;
            button1.Text = "backup گیری از دیتابیس";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 591);
            Controls.Add(button1);
            Controls.Add(lblWait);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnRunDotnet);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += MainForm_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion


        private Panel panel1;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnRunDotnet;
        private Label label5;
        private Label label6;
        private LinkLabel lblAngularIp;
        private LinkLabel lblDotnetIp;
        private Label lblWait;
        private Button button1;
    }
}
