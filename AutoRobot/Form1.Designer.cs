namespace AutoRobot
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Start = new System.Windows.Forms.Button();
            this.ReconnectCamera = new System.Windows.Forms.Button();
            this.FullImageShowBox = new System.Windows.Forms.PictureBox();
            this.CameraInfo = new System.Windows.Forms.TextBox();
            this.AGVInfo = new System.Windows.Forms.TextBox();
            this.RobotInfo = new System.Windows.Forms.TextBox();
            this.ConnectAGV_Button = new System.Windows.Forms.Button();
            this.ConnectRobot_Button = new System.Windows.Forms.Button();
            this.Maintab = new System.Windows.Forms.TabControl();
            this.tabpage1 = new System.Windows.Forms.TabPage();
            this.Manual_Button = new System.Windows.Forms.Button();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BacktoMain = new System.Windows.Forms.Button();
            this.AGVTest = new System.Windows.Forms.GroupBox();
            this.AGVMoveLM1 = new System.Windows.Forms.Button();
            this.AGVMoveLM2 = new System.Windows.Forms.Button();
            this.AGVMoveLM3 = new System.Windows.Forms.Button();
            this.AGVMoveLM4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FullImageShowBox)).BeginInit();
            this.Maintab.SuspendLayout();
            this.tabpage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.AGVTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(472, 26);
            this.Start.Margin = new System.Windows.Forms.Padding(4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(155, 72);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // ReconnectCamera
            // 
            this.ReconnectCamera.Location = new System.Drawing.Point(314, 9);
            this.ReconnectCamera.Margin = new System.Windows.Forms.Padding(4);
            this.ReconnectCamera.Name = "ReconnectCamera";
            this.ReconnectCamera.Size = new System.Drawing.Size(222, 41);
            this.ReconnectCamera.TabIndex = 0;
            this.ReconnectCamera.Text = "Connect Camera";
            this.ReconnectCamera.UseVisualStyleBackColor = true;
            this.ReconnectCamera.Click += new System.EventHandler(this.ReconnectCamera_Click);
            // 
            // FullImageShowBox
            // 
            this.FullImageShowBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FullImageShowBox.Location = new System.Drawing.Point(18, 244);
            this.FullImageShowBox.Margin = new System.Windows.Forms.Padding(4);
            this.FullImageShowBox.Name = "FullImageShowBox";
            this.FullImageShowBox.Size = new System.Drawing.Size(518, 745);
            this.FullImageShowBox.TabIndex = 2;
            this.FullImageShowBox.TabStop = false;
            // 
            // CameraInfo
            // 
            this.CameraInfo.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CameraInfo.Location = new System.Drawing.Point(18, 9);
            this.CameraInfo.Margin = new System.Windows.Forms.Padding(4);
            this.CameraInfo.Name = "CameraInfo";
            this.CameraInfo.Size = new System.Drawing.Size(288, 38);
            this.CameraInfo.TabIndex = 3;
            // 
            // AGVInfo
            // 
            this.AGVInfo.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AGVInfo.Location = new System.Drawing.Point(18, 60);
            this.AGVInfo.Margin = new System.Windows.Forms.Padding(4);
            this.AGVInfo.Name = "AGVInfo";
            this.AGVInfo.Size = new System.Drawing.Size(288, 38);
            this.AGVInfo.TabIndex = 3;
            // 
            // RobotInfo
            // 
            this.RobotInfo.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RobotInfo.Location = new System.Drawing.Point(18, 106);
            this.RobotInfo.Margin = new System.Windows.Forms.Padding(4);
            this.RobotInfo.Name = "RobotInfo";
            this.RobotInfo.Size = new System.Drawing.Size(288, 38);
            this.RobotInfo.TabIndex = 3;
            // 
            // ConnectAGV_Button
            // 
            this.ConnectAGV_Button.Location = new System.Drawing.Point(314, 60);
            this.ConnectAGV_Button.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectAGV_Button.Name = "ConnectAGV_Button";
            this.ConnectAGV_Button.Size = new System.Drawing.Size(222, 41);
            this.ConnectAGV_Button.TabIndex = 0;
            this.ConnectAGV_Button.Text = "Connect AGV";
            this.ConnectAGV_Button.UseVisualStyleBackColor = true;
            this.ConnectAGV_Button.Click += new System.EventHandler(this.ConnectAGV_Button_Click);
            // 
            // ConnectRobot_Button
            // 
            this.ConnectRobot_Button.Location = new System.Drawing.Point(314, 106);
            this.ConnectRobot_Button.Margin = new System.Windows.Forms.Padding(4);
            this.ConnectRobot_Button.Name = "ConnectRobot_Button";
            this.ConnectRobot_Button.Size = new System.Drawing.Size(222, 41);
            this.ConnectRobot_Button.TabIndex = 0;
            this.ConnectRobot_Button.Text = "Connect Robot";
            this.ConnectRobot_Button.UseVisualStyleBackColor = true;
            this.ConnectRobot_Button.Click += new System.EventHandler(this.ConnectRobot_Button_Click);
            // 
            // Maintab
            // 
            this.Maintab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.Maintab.Controls.Add(this.tabpage1);
            this.Maintab.Controls.Add(this.tabPage2);
            this.Maintab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Maintab.ItemSize = new System.Drawing.Size(0, 1);
            this.Maintab.Location = new System.Drawing.Point(0, 0);
            this.Maintab.Name = "Maintab";
            this.Maintab.SelectedIndex = 0;
            this.Maintab.Size = new System.Drawing.Size(1924, 1061);
            this.Maintab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.Maintab.TabIndex = 4;
            // 
            // tabpage1
            // 
            this.tabpage1.Controls.Add(this.Manual_Button);
            this.tabpage1.Controls.Add(this.pictureBox8);
            this.tabpage1.Controls.Add(this.pictureBox4);
            this.tabpage1.Controls.Add(this.pictureBox7);
            this.tabpage1.Controls.Add(this.pictureBox3);
            this.tabpage1.Controls.Add(this.pictureBox6);
            this.tabpage1.Controls.Add(this.pictureBox2);
            this.tabpage1.Controls.Add(this.pictureBox5);
            this.tabpage1.Controls.Add(this.pictureBox1);
            this.tabpage1.Controls.Add(this.FullImageShowBox);
            this.tabpage1.Controls.Add(this.RobotInfo);
            this.tabpage1.Controls.Add(this.ReconnectCamera);
            this.tabpage1.Controls.Add(this.AGVInfo);
            this.tabpage1.Controls.Add(this.ConnectAGV_Button);
            this.tabpage1.Controls.Add(this.CameraInfo);
            this.tabpage1.Controls.Add(this.ConnectRobot_Button);
            this.tabpage1.Location = new System.Drawing.Point(4, 5);
            this.tabpage1.Name = "tabpage1";
            this.tabpage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabpage1.Size = new System.Drawing.Size(1916, 1052);
            this.tabpage1.TabIndex = 0;
            this.tabpage1.Text = "tabPage1";
            this.tabpage1.UseVisualStyleBackColor = true;
            // 
            // Manual_Button
            // 
            this.Manual_Button.Location = new System.Drawing.Point(1716, 9);
            this.Manual_Button.Name = "Manual_Button";
            this.Manual_Button.Size = new System.Drawing.Size(165, 38);
            this.Manual_Button.TabIndex = 5;
            this.Manual_Button.Text = "Manual Test";
            this.Manual_Button.UseVisualStyleBackColor = true;
            this.Manual_Button.Click += new System.EventHandler(this.Manual_Button_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox8.Location = new System.Drawing.Point(1558, 616);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(323, 366);
            this.pictureBox8.TabIndex = 4;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(1558, 244);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(323, 366);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7.Location = new System.Drawing.Point(1229, 616);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(323, 366);
            this.pictureBox7.TabIndex = 4;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(1229, 244);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(323, 366);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox6.Location = new System.Drawing.Point(900, 616);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(323, 366);
            this.pictureBox6.TabIndex = 4;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(900, 244);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(323, 366);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(571, 616);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(323, 366);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(571, 244);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(323, 366);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BacktoMain);
            this.tabPage2.Controls.Add(this.AGVTest);
            this.tabPage2.Controls.Add(this.Start);
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1916, 1052);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BacktoMain
            // 
            this.BacktoMain.Location = new System.Drawing.Point(1711, 26);
            this.BacktoMain.Name = "BacktoMain";
            this.BacktoMain.Size = new System.Drawing.Size(172, 46);
            this.BacktoMain.TabIndex = 2;
            this.BacktoMain.Text = "Back";
            this.BacktoMain.UseVisualStyleBackColor = true;
            this.BacktoMain.Click += new System.EventHandler(this.BacktoMain_Click);
            // 
            // AGVTest
            // 
            this.AGVTest.Controls.Add(this.AGVMoveLM4);
            this.AGVTest.Controls.Add(this.AGVMoveLM3);
            this.AGVTest.Controls.Add(this.AGVMoveLM2);
            this.AGVTest.Controls.Add(this.AGVMoveLM1);
            this.AGVTest.Location = new System.Drawing.Point(21, 26);
            this.AGVTest.Name = "AGVTest";
            this.AGVTest.Size = new System.Drawing.Size(427, 479);
            this.AGVTest.TabIndex = 1;
            this.AGVTest.TabStop = false;
            this.AGVTest.Text = "AGVTest";
            // 
            // AGVMoveLM1
            // 
            this.AGVMoveLM1.Location = new System.Drawing.Point(45, 214);
            this.AGVMoveLM1.Name = "AGVMoveLM1";
            this.AGVMoveLM1.Size = new System.Drawing.Size(144, 104);
            this.AGVMoveLM1.TabIndex = 3;
            this.AGVMoveLM1.Text = "MovetoLM1";
            this.AGVMoveLM1.UseVisualStyleBackColor = true;
            this.AGVMoveLM1.Click += new System.EventHandler(this.AGVMoveLM1_Click);
            // 
            // AGVMoveLM2
            // 
            this.AGVMoveLM2.Location = new System.Drawing.Point(235, 214);
            this.AGVMoveLM2.Name = "AGVMoveLM2";
            this.AGVMoveLM2.Size = new System.Drawing.Size(144, 104);
            this.AGVMoveLM2.TabIndex = 3;
            this.AGVMoveLM2.Text = "MovetoLM2";
            this.AGVMoveLM2.UseVisualStyleBackColor = true;
            // 
            // AGVMoveLM3
            // 
            this.AGVMoveLM3.Location = new System.Drawing.Point(45, 347);
            this.AGVMoveLM3.Name = "AGVMoveLM3";
            this.AGVMoveLM3.Size = new System.Drawing.Size(144, 104);
            this.AGVMoveLM3.TabIndex = 3;
            this.AGVMoveLM3.Text = "MovetoLM3";
            this.AGVMoveLM3.UseVisualStyleBackColor = true;
            // 
            // AGVMoveLM4
            // 
            this.AGVMoveLM4.Location = new System.Drawing.Point(235, 347);
            this.AGVMoveLM4.Name = "AGVMoveLM4";
            this.AGVMoveLM4.Size = new System.Drawing.Size(144, 104);
            this.AGVMoveLM4.TabIndex = 3;
            this.AGVMoveLM4.Text = "MovetoLM4";
            this.AGVMoveLM4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.Maintab);
            this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "AutoRobot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.FullImageShowBox)).EndInit();
            this.Maintab.ResumeLayout(false);
            this.tabpage1.ResumeLayout(false);
            this.tabpage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.AGVTest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button ReconnectCamera;
        private System.Windows.Forms.PictureBox FullImageShowBox;
        private System.Windows.Forms.TextBox CameraInfo;
        private System.Windows.Forms.TextBox AGVInfo;
        private System.Windows.Forms.TextBox RobotInfo;
        private System.Windows.Forms.Button ConnectAGV_Button;
        private System.Windows.Forms.Button ConnectRobot_Button;
        private System.Windows.Forms.TabControl Maintab;
        private System.Windows.Forms.TabPage tabpage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox AGVTest;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button Manual_Button;
        private System.Windows.Forms.Button BacktoMain;
        private System.Windows.Forms.Button AGVMoveLM4;
        private System.Windows.Forms.Button AGVMoveLM3;
        private System.Windows.Forms.Button AGVMoveLM2;
        private System.Windows.Forms.Button AGVMoveLM1;
    }
}

