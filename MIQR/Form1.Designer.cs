﻿namespace MIQR
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.captureDisplay_pictureBox = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.captureStart_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.captureStop_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.reserveNumberDisplay_Label = new System.Windows.Forms.Label();
            this.status_Label = new System.Windows.Forms.Label();
            this.consoleDisplay_TextBox = new System.Windows.Forms.TextBox();
            this.grantStatus_Label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.reserveNumber_TextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.uuid_TextBox = new System.Windows.Forms.TextBox();
            this.authenticationSearch_Button = new System.Windows.Forms.Button();
            this.nextScan_Button = new System.Windows.Forms.Button();
            this.checkIn_Button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Day = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.captureDisplay_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Orbitron", 80.24999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-18, -21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 123);
            this.label1.TabIndex = 0;
            this.label1.Text = "MIQR";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Orbitron", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "MIKUEC QR System";
            // 
            // captureDisplay_pictureBox
            // 
            this.captureDisplay_pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.captureDisplay_pictureBox.Location = new System.Drawing.Point(346, 132);
            this.captureDisplay_pictureBox.Name = "captureDisplay_pictureBox";
            this.captureDisplay_pictureBox.Size = new System.Drawing.Size(640, 480);
            this.captureDisplay_pictureBox.TabIndex = 2;
            this.captureDisplay_pictureBox.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // captureStart_Button
            // 
            this.captureStart_Button.Location = new System.Drawing.Point(5, 189);
            this.captureStart_Button.Name = "captureStart_Button";
            this.captureStart_Button.Size = new System.Drawing.Size(313, 35);
            this.captureStart_Button.TabIndex = 3;
            this.captureStart_Button.Text = "START CAPTURE";
            this.captureStart_Button.UseVisualStyleBackColor = true;
            this.captureStart_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Orbitron", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "System Console";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // captureStop_Button
            // 
            this.captureStop_Button.Enabled = false;
            this.captureStop_Button.Location = new System.Drawing.Point(5, 246);
            this.captureStop_Button.Name = "captureStop_Button";
            this.captureStop_Button.Size = new System.Drawing.Size(313, 35);
            this.captureStop_Button.TabIndex = 5;
            this.captureStop_Button.Text = "CAPTURE STOP";
            this.captureStop_Button.UseVisualStyleBackColor = true;
            this.captureStop_Button.Click += new System.EventHandler(this.captureStop_Button_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("ロンド B スクエア", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1136, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 47);
            this.label4.TabIndex = 6;
            this.label4.Text = "席番号:";
            // 
            // reserveNumberDisplay_Label
            // 
            this.reserveNumberDisplay_Label.Font = new System.Drawing.Font("OCRA Alternate", 48F);
            this.reserveNumberDisplay_Label.ForeColor = System.Drawing.Color.White;
            this.reserveNumberDisplay_Label.Location = new System.Drawing.Point(1374, 320);
            this.reserveNumberDisplay_Label.Name = "reserveNumberDisplay_Label";
            this.reserveNumberDisplay_Label.Size = new System.Drawing.Size(433, 98);
            this.reserveNumberDisplay_Label.TabIndex = 7;
            this.reserveNumberDisplay_Label.Text = "------";
            this.reserveNumberDisplay_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // status_Label
            // 
            this.status_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.status_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.status_Label.Font = new System.Drawing.Font("Orbitron", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.status_Label.Location = new System.Drawing.Point(1074, 23);
            this.status_Label.Name = "status_Label";
            this.status_Label.Size = new System.Drawing.Size(765, 177);
            this.status_Label.TabIndex = 8;
            this.status_Label.Text = "STANDBY";
            this.status_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // consoleDisplay_TextBox
            // 
            this.consoleDisplay_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.consoleDisplay_TextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleDisplay_TextBox.ForeColor = System.Drawing.Color.Lime;
            this.consoleDisplay_TextBox.Location = new System.Drawing.Point(5, 356);
            this.consoleDisplay_TextBox.Multiline = true;
            this.consoleDisplay_TextBox.Name = "consoleDisplay_TextBox";
            this.consoleDisplay_TextBox.ReadOnly = true;
            this.consoleDisplay_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleDisplay_TextBox.Size = new System.Drawing.Size(313, 642);
            this.consoleDisplay_TextBox.TabIndex = 9;
            this.consoleDisplay_TextBox.Text = "[00:39] Auth granted";
            // 
            // grantStatus_Label
            // 
            this.grantStatus_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grantStatus_Label.Font = new System.Drawing.Font("メイリオ", 99.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.grantStatus_Label.ForeColor = System.Drawing.Color.Cyan;
            this.grantStatus_Label.Location = new System.Drawing.Point(1074, 435);
            this.grantStatus_Label.Name = "grantStatus_Label";
            this.grantStatus_Label.Size = new System.Drawing.Size(765, 177);
            this.grantStatus_Label.TabIndex = 10;
            this.grantStatus_Label.Text = "・・・";
            this.grantStatus_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Orbitron", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(525, 644);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(313, 37);
            this.label8.TabIndex = 11;
            this.label8.Text = "Manual Setting";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reserveNumber_TextBox
            // 
            this.reserveNumber_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.reserveNumber_TextBox.ForeColor = System.Drawing.Color.White;
            this.reserveNumber_TextBox.Location = new System.Drawing.Point(458, 715);
            this.reserveNumber_TextBox.Name = "reserveNumber_TextBox";
            this.reserveNumber_TextBox.Size = new System.Drawing.Size(528, 19);
            this.reserveNumber_TextBox.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("ロンド B スクエア", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(367, 715);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 18);
            this.label9.TabIndex = 13;
            this.label9.Text = "予約番号";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("ロンド B スクエア", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(367, 788);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 22);
            this.label10.TabIndex = 14;
            this.label10.Text = "UUID";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // uuid_TextBox
            // 
            this.uuid_TextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uuid_TextBox.ForeColor = System.Drawing.Color.White;
            this.uuid_TextBox.Location = new System.Drawing.Point(458, 791);
            this.uuid_TextBox.Name = "uuid_TextBox";
            this.uuid_TextBox.ReadOnly = true;
            this.uuid_TextBox.Size = new System.Drawing.Size(528, 19);
            this.uuid_TextBox.TabIndex = 15;
            // 
            // authenticationSearch_Button
            // 
            this.authenticationSearch_Button.Enabled = false;
            this.authenticationSearch_Button.Location = new System.Drawing.Point(546, 837);
            this.authenticationSearch_Button.Name = "authenticationSearch_Button";
            this.authenticationSearch_Button.Size = new System.Drawing.Size(279, 35);
            this.authenticationSearch_Button.TabIndex = 16;
            this.authenticationSearch_Button.Text = "AUTHENTICATION SEARCH";
            this.authenticationSearch_Button.UseVisualStyleBackColor = true;
            this.authenticationSearch_Button.Click += new System.EventHandler(this.authenticationSearch_Button_Click);
            // 
            // nextScan_Button
            // 
            this.nextScan_Button.Enabled = false;
            this.nextScan_Button.Location = new System.Drawing.Point(1020, 886);
            this.nextScan_Button.Name = "nextScan_Button";
            this.nextScan_Button.Size = new System.Drawing.Size(872, 35);
            this.nextScan_Button.TabIndex = 17;
            this.nextScan_Button.Text = "NEXT SCAN";
            this.nextScan_Button.UseVisualStyleBackColor = true;
            this.nextScan_Button.Click += new System.EventHandler(this.nextScan_Button_Click);
            // 
            // checkIn_Button
            // 
            this.checkIn_Button.BackColor = System.Drawing.Color.Silver;
            this.checkIn_Button.Enabled = false;
            this.checkIn_Button.Location = new System.Drawing.Point(598, 886);
            this.checkIn_Button.Name = "checkIn_Button";
            this.checkIn_Button.Size = new System.Drawing.Size(177, 35);
            this.checkIn_Button.TabIndex = 18;
            this.checkIn_Button.Text = "CHECK IN";
            this.checkIn_Button.UseVisualStyleBackColor = false;
            this.checkIn_Button.Click += new System.EventHandler(this.checkIn_Button_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Orbitron", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 37);
            this.label5.TabIndex = 19;
            this.label5.Text = "Live";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_Day
            // 
            this.comboBox_Day.FormattingEnabled = true;
            this.comboBox_Day.Location = new System.Drawing.Point(82, 310);
            this.comboBox_Day.Name = "comboBox_Day";
            this.comboBox_Day.Size = new System.Drawing.Size(235, 20);
            this.comboBox_Day.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.comboBox_Day);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkIn_Button);
            this.Controls.Add(this.nextScan_Button);
            this.Controls.Add(this.authenticationSearch_Button);
            this.Controls.Add(this.uuid_TextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.reserveNumber_TextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.grantStatus_Label);
            this.Controls.Add(this.consoleDisplay_TextBox);
            this.Controls.Add(this.status_Label);
            this.Controls.Add(this.reserveNumberDisplay_Label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.captureStop_Button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.captureStart_Button);
            this.Controls.Add(this.captureDisplay_pictureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.captureDisplay_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_Day;

        private System.Windows.Forms.Button checkIn_Button;

        private System.Windows.Forms.Button nextScan_Button;

        private System.Windows.Forms.TextBox uuid_TextBox;

        private System.Windows.Forms.Button authenticationSearch_Button;

        private System.Windows.Forms.Label status_Label;

        private System.Windows.Forms.Label grantStatus_Label;
        
        private System.Windows.Forms.Label reserveNumberDisplay_Label;

        private System.Windows.Forms.TextBox reserveNumber_TextBox;

        private System.Windows.Forms.TextBox consoleDisplay_TextBox;

        private System.Windows.Forms.PictureBox captureDisplay_pictureBox;

        private System.Windows.Forms.Button captureStop_Button;

        private System.Windows.Forms.Button captureStart_Button;

        private System.Windows.Forms.Label label10;
        
        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label3;

        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}