namespace CordingArrayKitMoudbusRTU
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSerialport = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trbB = new System.Windows.Forms.TrackBar();
            this.trbG = new System.Windows.Forms.TrackBar();
            this.trbR = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnLEDOff = new System.Windows.Forms.Button();
            this.btnLEDOn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTOff = new System.Windows.Forms.Button();
            this.btnTOn = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTB = new System.Windows.Forms.Label();
            this.lblPB = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.pgbHumi = new System.Windows.Forms.ProgressBar();
            this.pgbTemp = new System.Windows.Forms.ProgressBar();
            this.pgbHall = new System.Windows.Forms.ProgressBar();
            this.pgbPoten = new System.Windows.Forms.ProgressBar();
            this.pgbCDS = new System.Windows.Forms.ProgressBar();
            this.btnT2Off = new System.Windows.Forms.Button();
            this.btnT2On = new System.Windows.Forms.Button();
            this.tbxHumi = new System.Windows.Forms.TextBox();
            this.tbxTemp = new System.Windows.Forms.TextBox();
            this.tbxHall = new System.Windows.Forms.TextBox();
            this.tbxPoten = new System.Windows.Forms.TextBox();
            this.tbxCDS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbxEcho = new System.Windows.Forms.TextBox();
            this.btnEcho = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tbxLCDWrite = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbR)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbxSerialport);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "통신연결";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(455, 25);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(118, 38);
            this.btnDisconnect.TabIndex = 2;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(312, 26);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(118, 38);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial port";
            // 
            // cbxSerialport
            // 
            this.cbxSerialport.FormattingEnabled = true;
            this.cbxSerialport.Location = new System.Drawing.Point(6, 35);
            this.cbxSerialport.Name = "cbxSerialport";
            this.cbxSerialport.Size = new System.Drawing.Size(287, 20);
            this.cbxSerialport.TabIndex = 0;
            this.cbxSerialport.SelectedIndexChanged += new System.EventHandler(this.cbxSerialport_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Location = new System.Drawing.Point(28, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 244);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LED Control [ On / Off ]";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.trbB);
            this.groupBox5.Controls.Add(this.trbG);
            this.groupBox5.Controls.Add(this.trbR);
            this.groupBox5.Location = new System.Drawing.Point(145, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(156, 223);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "RGB LED (9, 10, 11)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "G";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "R";
            // 
            // trbB
            // 
            this.trbB.Location = new System.Drawing.Point(6, 159);
            this.trbB.Name = "trbB";
            this.trbB.Size = new System.Drawing.Size(142, 45);
            this.trbB.TabIndex = 2;
            this.trbB.Scroll += new System.EventHandler(this.trbB_Scroll);
            // 
            // trbG
            // 
            this.trbG.Location = new System.Drawing.Point(6, 108);
            this.trbG.Name = "trbG";
            this.trbG.Size = new System.Drawing.Size(142, 45);
            this.trbG.TabIndex = 2;
            this.trbG.Scroll += new System.EventHandler(this.trbG_Scroll);
            // 
            // trbR
            // 
            this.trbR.Location = new System.Drawing.Point(6, 57);
            this.trbR.Name = "trbR";
            this.trbR.Size = new System.Drawing.Size(142, 45);
            this.trbR.TabIndex = 2;
            this.trbR.Scroll += new System.EventHandler(this.trbR_Scroll);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnLEDOff);
            this.groupBox4.Controls.Add(this.btnLEDOn);
            this.groupBox4.Location = new System.Drawing.Point(0, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(156, 223);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "LED (13)";
            // 
            // btnLEDOff
            // 
            this.btnLEDOff.Location = new System.Drawing.Point(6, 131);
            this.btnLEDOff.Name = "btnLEDOff";
            this.btnLEDOff.Size = new System.Drawing.Size(130, 38);
            this.btnLEDOff.TabIndex = 0;
            this.btnLEDOff.Text = "Off";
            this.btnLEDOff.UseVisualStyleBackColor = true;
            this.btnLEDOff.Click += new System.EventHandler(this.btnLEDOff_Click);
            // 
            // btnLEDOn
            // 
            this.btnLEDOn.Location = new System.Drawing.Point(9, 57);
            this.btnLEDOn.Name = "btnLEDOn";
            this.btnLEDOn.Size = new System.Drawing.Size(130, 38);
            this.btnLEDOn.TabIndex = 0;
            this.btnLEDOn.Text = "On";
            this.btnLEDOn.UseVisualStyleBackColor = true;
            this.btnLEDOn.Click += new System.EventHandler(this.btnLEDOn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTOff);
            this.groupBox3.Controls.Add(this.btnTOn);
            this.groupBox3.Controls.Add(this.btnCheck);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lblTB);
            this.groupBox3.Controls.Add(this.lblPB);
            this.groupBox3.Location = new System.Drawing.Point(327, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 244);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Button State";
            // 
            // btnTOff
            // 
            this.btnTOff.Location = new System.Drawing.Point(156, 183);
            this.btnTOff.Name = "btnTOff";
            this.btnTOff.Size = new System.Drawing.Size(98, 48);
            this.btnTOff.TabIndex = 6;
            this.btnTOff.Text = "Timer Off";
            this.btnTOff.UseVisualStyleBackColor = true;
            this.btnTOff.Click += new System.EventHandler(this.btnTOff_Click);
            // 
            // btnTOn
            // 
            this.btnTOn.Location = new System.Drawing.Point(15, 183);
            this.btnTOn.Name = "btnTOn";
            this.btnTOn.Size = new System.Drawing.Size(98, 48);
            this.btnTOn.TabIndex = 6;
            this.btnTOn.Text = "Timer On";
            this.btnTOn.UseVisualStyleBackColor = true;
            this.btnTOn.Click += new System.EventHandler(this.btnTOn_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(13, 129);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(243, 48);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "상태확인";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(154, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "Touch Button";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "Push Button";
            // 
            // lblTB
            // 
            this.lblTB.BackColor = System.Drawing.SystemColors.Control;
            this.lblTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTB.Location = new System.Drawing.Point(156, 48);
            this.lblTB.Name = "lblTB";
            this.lblTB.Size = new System.Drawing.Size(100, 75);
            this.lblTB.TabIndex = 2;
            // 
            // lblPB
            // 
            this.lblPB.BackColor = System.Drawing.SystemColors.Control;
            this.lblPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPB.Location = new System.Drawing.Point(13, 48);
            this.lblPB.Name = "lblPB";
            this.lblPB.Size = new System.Drawing.Size(100, 75);
            this.lblPB.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pgbHumi);
            this.groupBox6.Controls.Add(this.pgbTemp);
            this.groupBox6.Controls.Add(this.pgbHall);
            this.groupBox6.Controls.Add(this.pgbPoten);
            this.groupBox6.Controls.Add(this.pgbCDS);
            this.groupBox6.Controls.Add(this.btnT2Off);
            this.groupBox6.Controls.Add(this.btnT2On);
            this.groupBox6.Controls.Add(this.tbxHumi);
            this.groupBox6.Controls.Add(this.tbxTemp);
            this.groupBox6.Controls.Add(this.tbxHall);
            this.groupBox6.Controls.Add(this.tbxPoten);
            this.groupBox6.Controls.Add(this.tbxCDS);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Location = new System.Drawing.Point(28, 345);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(596, 211);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Analog Data";
            // 
            // pgbHumi
            // 
            this.pgbHumi.Location = new System.Drawing.Point(301, 142);
            this.pgbHumi.Name = "pgbHumi";
            this.pgbHumi.Size = new System.Drawing.Size(259, 23);
            this.pgbHumi.TabIndex = 7;
            // 
            // pgbTemp
            // 
            this.pgbTemp.Location = new System.Drawing.Point(301, 112);
            this.pgbTemp.Maximum = 40;
            this.pgbTemp.Name = "pgbTemp";
            this.pgbTemp.Size = new System.Drawing.Size(259, 23);
            this.pgbTemp.TabIndex = 7;
            // 
            // pgbHall
            // 
            this.pgbHall.Location = new System.Drawing.Point(301, 83);
            this.pgbHall.Name = "pgbHall";
            this.pgbHall.Size = new System.Drawing.Size(259, 23);
            this.pgbHall.TabIndex = 7;
            // 
            // pgbPoten
            // 
            this.pgbPoten.Location = new System.Drawing.Point(301, 51);
            this.pgbPoten.Name = "pgbPoten";
            this.pgbPoten.Size = new System.Drawing.Size(259, 23);
            this.pgbPoten.TabIndex = 7;
            // 
            // pgbCDS
            // 
            this.pgbCDS.Location = new System.Drawing.Point(300, 20);
            this.pgbCDS.Name = "pgbCDS";
            this.pgbCDS.Size = new System.Drawing.Size(259, 23);
            this.pgbCDS.TabIndex = 7;
            // 
            // btnT2Off
            // 
            this.btnT2Off.Location = new System.Drawing.Point(185, 174);
            this.btnT2Off.Name = "btnT2Off";
            this.btnT2Off.Size = new System.Drawing.Size(80, 31);
            this.btnT2Off.TabIndex = 6;
            this.btnT2Off.Text = "Timer Off";
            this.btnT2Off.UseVisualStyleBackColor = true;
            this.btnT2Off.Click += new System.EventHandler(this.btnT2Off_Click);
            // 
            // btnT2On
            // 
            this.btnT2On.Location = new System.Drawing.Point(44, 174);
            this.btnT2On.Name = "btnT2On";
            this.btnT2On.Size = new System.Drawing.Size(80, 31);
            this.btnT2On.TabIndex = 6;
            this.btnT2On.Text = "Timer On";
            this.btnT2On.UseVisualStyleBackColor = true;
            this.btnT2On.Click += new System.EventHandler(this.btnT2On_Click);
            // 
            // tbxHumi
            // 
            this.tbxHumi.Location = new System.Drawing.Point(116, 142);
            this.tbxHumi.Name = "tbxHumi";
            this.tbxHumi.Size = new System.Drawing.Size(185, 21);
            this.tbxHumi.TabIndex = 1;
            // 
            // tbxTemp
            // 
            this.tbxTemp.Location = new System.Drawing.Point(116, 113);
            this.tbxTemp.Name = "tbxTemp";
            this.tbxTemp.Size = new System.Drawing.Size(185, 21);
            this.tbxTemp.TabIndex = 1;
            // 
            // tbxHall
            // 
            this.tbxHall.Location = new System.Drawing.Point(116, 83);
            this.tbxHall.Name = "tbxHall";
            this.tbxHall.Size = new System.Drawing.Size(185, 21);
            this.tbxHall.TabIndex = 1;
            // 
            // tbxPoten
            // 
            this.tbxPoten.Location = new System.Drawing.Point(116, 51);
            this.tbxPoten.Name = "tbxPoten";
            this.tbxPoten.Size = new System.Drawing.Size(185, 21);
            this.tbxPoten.TabIndex = 1;
            // 
            // tbxCDS
            // 
            this.tbxCDS.Location = new System.Drawing.Point(116, 22);
            this.tbxCDS.Name = "tbxCDS";
            this.tbxCDS.Size = new System.Drawing.Size(185, 21);
            this.tbxCDS.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "Humi(습도) :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Temp(온도) :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Hall(자계) :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Poten(가변저항) :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "CDS(빛감지) :";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbxEcho);
            this.groupBox7.Controls.Add(this.btnEcho);
            this.groupBox7.Location = new System.Drawing.Point(631, 13);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(95, 106);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Echo Control";
            // 
            // tbxEcho
            // 
            this.tbxEcho.Font = new System.Drawing.Font("굴림", 11F);
            this.tbxEcho.Location = new System.Drawing.Point(9, 30);
            this.tbxEcho.Name = "tbxEcho";
            this.tbxEcho.Size = new System.Drawing.Size(75, 24);
            this.tbxEcho.TabIndex = 1;
            this.tbxEcho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnEcho
            // 
            this.btnEcho.Font = new System.Drawing.Font("굴림", 11F);
            this.btnEcho.Location = new System.Drawing.Point(9, 58);
            this.btnEcho.Name = "btnEcho";
            this.btnEcho.Size = new System.Drawing.Size(75, 24);
            this.btnEcho.TabIndex = 0;
            this.btnEcho.Text = "측정";
            this.btnEcho.UseVisualStyleBackColor = true;
            this.btnEcho.Click += new System.EventHandler(this.btnEcho_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tbxLCDWrite);
            this.groupBox8.Controls.Add(this.btnWrite);
            this.groupBox8.Location = new System.Drawing.Point(631, 140);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(211, 112);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "LCD Write (한글X)";
            // 
            // tbxLCDWrite
            // 
            this.tbxLCDWrite.AcceptsReturn = true;
            this.tbxLCDWrite.Font = new System.Drawing.Font("굴림", 10F);
            this.tbxLCDWrite.Location = new System.Drawing.Point(0, 20);
            this.tbxLCDWrite.MaxLength = 20;
            this.tbxLCDWrite.Multiline = true;
            this.tbxLCDWrite.Name = "tbxLCDWrite";
            this.tbxLCDWrite.Size = new System.Drawing.Size(215, 48);
            this.tbxLCDWrite.TabIndex = 1;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.textBox1);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.button3);
            this.groupBox9.Controls.Add(this.button2);
            this.groupBox9.Location = new System.Drawing.Point(630, 275);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(193, 100);
            this.groupBox9.TabIndex = 3;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Servo Control";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("굴림", 11F);
            this.textBox1.Location = new System.Drawing.Point(92, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(91, 24);
            this.textBox1.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("굴림", 11F);
            this.label12.Location = new System.Drawing.Point(8, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "현재 각도 : ";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("굴림", 11F);
            this.button3.Location = new System.Drawing.Point(108, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("굴림", 11F);
            this.button2.Location = new System.Drawing.Point(6, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnWrite
            // 
            this.btnWrite.Font = new System.Drawing.Font("굴림", 11F);
            this.btnWrite.Location = new System.Drawing.Point(65, 74);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 24);
            this.btnWrite.TabIndex = 0;
            this.btnWrite.Text = "출력";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 568);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "CordingArray Control";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbR)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSerialport;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnLEDOff;
        private System.Windows.Forms.Button btnLEDOn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trbB;
        private System.Windows.Forms.TrackBar trbG;
        private System.Windows.Forms.TrackBar trbR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTB;
        private System.Windows.Forms.Label lblPB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnTOff;
        private System.Windows.Forms.Button btnTOn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnT2Off;
        private System.Windows.Forms.Button btnT2On;
        private System.Windows.Forms.TextBox tbxHumi;
        private System.Windows.Forms.TextBox tbxTemp;
        private System.Windows.Forms.TextBox tbxHall;
        private System.Windows.Forms.TextBox tbxPoten;
        private System.Windows.Forms.TextBox tbxCDS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ProgressBar pgbHumi;
        private System.Windows.Forms.ProgressBar pgbTemp;
        private System.Windows.Forms.ProgressBar pgbHall;
        private System.Windows.Forms.ProgressBar pgbPoten;
        private System.Windows.Forms.ProgressBar pgbCDS;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox tbxEcho;
        private System.Windows.Forms.Button btnEcho;
        private System.Windows.Forms.TextBox tbxLCDWrite;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnWrite;
    }
}

