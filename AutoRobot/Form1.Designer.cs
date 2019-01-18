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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MainTab = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.AGVTest = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FullImageShowBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.MainTab.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(1249, 26);
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
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.MainTab);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 50);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1924, 1061);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 4;
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.pictureBox8);
            this.MainTab.Controls.Add(this.pictureBox4);
            this.MainTab.Controls.Add(this.pictureBox7);
            this.MainTab.Controls.Add(this.pictureBox3);
            this.MainTab.Controls.Add(this.pictureBox6);
            this.MainTab.Controls.Add(this.pictureBox2);
            this.MainTab.Controls.Add(this.pictureBox5);
            this.MainTab.Controls.Add(this.pictureBox1);
            this.MainTab.Controls.Add(this.FullImageShowBox);
            this.MainTab.Controls.Add(this.RobotInfo);
            this.MainTab.Controls.Add(this.ReconnectCamera);
            this.MainTab.Controls.Add(this.AGVInfo);
            this.MainTab.Controls.Add(this.ConnectAGV_Button);
            this.MainTab.Controls.Add(this.CameraInfo);
            this.MainTab.Controls.Add(this.ConnectRobot_Button);
            this.MainTab.Location = new System.Drawing.Point(4, 54);
            this.MainTab.Name = "MainTab";
            this.MainTab.Padding = new System.Windows.Forms.Padding(3);
            this.MainTab.Size = new System.Drawing.Size(1916, 1003);
            this.MainTab.TabIndex = 0;
            this.MainTab.Text = "tabPage1";
            this.MainTab.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.AGVTest);
            this.tabPage2.Controls.Add(this.Start);
            this.tabPage2.Location = new System.Drawing.Point(4, 54);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1916, 1003);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // AGVTest
            // 
            this.AGVTest.Location = new System.Drawing.Point(21, 26);
            this.AGVTest.Name = "AGVTest";
            this.AGVTest.Size = new System.Drawing.Size(427, 479);
            this.AGVTest.TabIndex = 1;
            this.AGVTest.TabStop = false;
            this.AGVTest.Text = "AGVTest";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(571, 244);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(323, 366);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(900, 244);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(323, 366);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(1229, 244);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(323, 366);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(1558, 244);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(323, 366);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(571, 616);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(323, 366);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(900, 616);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(323, 366);
            this.pictureBox6.TabIndex = 4;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(1229, 616);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(323, 366);
            this.pictureBox7.TabIndex = 4;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(1558, 616);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(323, 366);
            this.pictureBox8.TabIndex = 4;
            this.pictureBox8.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "AutoRobot";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.FullImageShowBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.MainTab.ResumeLayout(false);
            this.MainTab.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MainTab;
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
    }
}

