namespace Vision_UI
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cvsInSightDisplay1 = new Cognex.InSight.Controls.Display.CvsInSightDisplay();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Connect = new System.Windows.Forms.Button();
            this.OnLine = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.state1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CA1 = new System.Windows.Forms.Label();
            this.CY1 = new System.Windows.Forms.Label();
            this.CX1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.QRRes = new System.Windows.Forms.Label();
            this.OKNGBox = new System.Windows.Forms.Label();
            this.Trigger = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnWork = new System.Windows.Forms.Button();
            this.btnVision = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cvsInSightDisplay1
            // 
            this.cvsInSightDisplay1.DefaultTextScaleMode = Cognex.InSight.Controls.Display.CvsInSightDisplay.TextScaleModeType.Proportional;
            this.cvsInSightDisplay1.DialogIcon = null;
            this.cvsInSightDisplay1.Location = new System.Drawing.Point(1, 3);
            this.cvsInSightDisplay1.Name = "cvsInSightDisplay1";
            this.cvsInSightDisplay1.PreferredCropScaleMode = Cognex.InSight.Controls.Display.CvsInSightDisplayCropScaleMode.Default;
            this.cvsInSightDisplay1.Size = new System.Drawing.Size(529, 442);
            this.cvsInSightDisplay1.TabIndex = 0;
            this.cvsInSightDisplay1.Load += new System.EventHandler(this.cvsInSightDisplay1_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Connect);
            this.groupBox1.Controls.Add(this.OnLine);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.state1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect";
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(103, 28);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(105, 23);
            this.Connect.TabIndex = 1;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // OnLine
            // 
            this.OnLine.Location = new System.Drawing.Point(103, 65);
            this.OnLine.Name = "OnLine";
            this.OnLine.Size = new System.Drawing.Size(105, 23);
            this.OnLine.TabIndex = 1;
            this.OnLine.Text = "OnLine";
            this.OnLine.UseVisualStyleBackColor = true;
            this.OnLine.Click += new System.EventHandler(this.OnLine_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11F);
            this.label2.Location = new System.Drawing.Point(14, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vision Mode";
            // 
            // state1
            // 
            this.state1.AutoSize = true;
            this.state1.Font = new System.Drawing.Font("굴림", 11F);
            this.state1.Location = new System.Drawing.Point(58, 33);
            this.state1.Name = "state1";
            this.state1.Size = new System.Drawing.Size(27, 15);
            this.state1.TabIndex = 0;
            this.state1.Text = "Off";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11F);
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vision";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CA1);
            this.groupBox2.Controls.Add(this.CY1);
            this.groupBox2.Controls.Add(this.CX1);
            this.groupBox2.Location = new System.Drawing.Point(6, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Match";
            // 
            // CA1
            // 
            this.CA1.AutoSize = true;
            this.CA1.Font = new System.Drawing.Font("굴림", 11F);
            this.CA1.Location = new System.Drawing.Point(14, 77);
            this.CA1.Name = "CA1";
            this.CA1.Size = new System.Drawing.Size(58, 15);
            this.CA1.TabIndex = 0;
            this.CA1.Text = "Angle : ";
            // 
            // CY1
            // 
            this.CY1.AutoSize = true;
            this.CY1.Font = new System.Drawing.Font("굴림", 11F);
            this.CY1.Location = new System.Drawing.Point(14, 52);
            this.CY1.Name = "CY1";
            this.CY1.Size = new System.Drawing.Size(30, 15);
            this.CY1.TabIndex = 0;
            this.CY1.Text = "Y : ";
            // 
            // CX1
            // 
            this.CX1.AutoSize = true;
            this.CX1.Font = new System.Drawing.Font("굴림", 11F);
            this.CX1.Location = new System.Drawing.Point(14, 27);
            this.CX1.Name = "CX1";
            this.CX1.Size = new System.Drawing.Size(31, 15);
            this.CX1.TabIndex = 0;
            this.CX1.Text = "X : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.QRRes);
            this.groupBox3.Location = new System.Drawing.Point(6, 218);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(214, 64);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "QRCode";
            // 
            // QRRes
            // 
            this.QRRes.AutoSize = true;
            this.QRRes.Font = new System.Drawing.Font("굴림", 12F);
            this.QRRes.Location = new System.Drawing.Point(76, 30);
            this.QRRes.Name = "QRRes";
            this.QRRes.Size = new System.Drawing.Size(52, 16);
            this.QRRes.TabIndex = 0;
            this.QRRes.Text = "Result";
            // 
            // OKNGBox
            // 
            this.OKNGBox.AutoSize = true;
            this.OKNGBox.Font = new System.Drawing.Font("굴림", 20F);
            this.OKNGBox.Location = new System.Drawing.Point(49, 301);
            this.OKNGBox.Name = "OKNGBox";
            this.OKNGBox.Size = new System.Drawing.Size(119, 27);
            this.OKNGBox.TabIndex = 0;
            this.OKNGBox.Text = "OK / NG";
            // 
            // Trigger
            // 
            this.Trigger.Font = new System.Drawing.Font("굴림", 14F);
            this.Trigger.Location = new System.Drawing.Point(54, 358);
            this.Trigger.Name = "Trigger";
            this.Trigger.Size = new System.Drawing.Size(105, 39);
            this.Trigger.TabIndex = 1;
            this.Trigger.Text = "Trigger";
            this.Trigger.UseVisualStyleBackColor = true;
            this.Trigger.Click += new System.EventHandler(this.Trigger_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(536, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(233, 442);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.OKNGBox);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.Trigger);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(225, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(225, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnWork
            // 
            this.btnWork.Location = new System.Drawing.Point(685, 457);
            this.btnWork.Name = "btnWork";
            this.btnWork.Size = new System.Drawing.Size(75, 23);
            this.btnWork.TabIndex = 4;
            this.btnWork.Text = "Work";
            this.btnWork.UseVisualStyleBackColor = true;
            // 
            // btnVision
            // 
            this.btnVision.Location = new System.Drawing.Point(594, 457);
            this.btnVision.Name = "btnVision";
            this.btnVision.Size = new System.Drawing.Size(75, 23);
            this.btnVision.TabIndex = 5;
            this.btnVision.Text = "Vision";
            this.btnVision.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 492);
            this.Controls.Add(this.btnVision);
            this.Controls.Add(this.btnWork);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cvsInSightDisplay1);
            this.Name = "Form1";
            this.Text = "Vision";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.InSight.Controls.Display.CvsInSightDisplay cvsInSightDisplay1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Button OnLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label state1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label CA1;
        private System.Windows.Forms.Label CY1;
        private System.Windows.Forms.Label CX1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label QRRes;
        private System.Windows.Forms.Label OKNGBox;
        private System.Windows.Forms.Button Trigger;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnWork;
        private System.Windows.Forms.Button btnVision;
    }
}

