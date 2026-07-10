using Modbus.Device;
using Modbus.Extensions.Enron;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CordingArrayKitMoudbusRTU
{

    public partial class Form1 : Form
    {
        SerialPort _port;
        ModbusSerialMaster _master;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 시리얼 가상 포트 검색해서 콤보박스에 추가
            string[] portlist = SerialPort.GetPortNames();
            foreach (string port in portlist)
            {
                cbxSerialport.Items.Add(port);
            }

        }

        private void cbxSerialport_SelectedIndexChanged(object sender, EventArgs e)
        {
            string portName = cbxSerialport.SelectedItem.ToString();
            _port = new SerialPort(portName, 9600); //port 번호 : com?, 속도 9600
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _port.DataBits = 8;
                _port.StopBits = StopBits.One;
                _port.Parity = Parity.None;
                _port.ReadTimeout = 2000;
                _port.WriteTimeout = 2000;
                _port.Open();

                _master = ModbusSerialMaster.CreateRtu(_port);
                btnConnect.Text = "Connected";
                btnDisconnect.Text = "Disconnect";
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("시리얼 장치 연결 필요(" + ex.Message.ToString() + ")");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _port.Close();
            btnConnect.Text = "Connect";
            btnDisconnect.Text = "Disconnected";
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            Close();
        }

        private void btnLEDOn_Click(object sender, EventArgs e)
        {
            if (_port.IsOpen)
            {
                // WriteSingleCoil 국번 1 어드래스 0(아두이노에서는 1), on:true
                _master.WriteSingleCoil(1, 1, true);
            }
        }

        private void btnLEDOff_Click(object sender, EventArgs e)
        {
            if (_port.IsOpen)
            {
                // WriteSingleCoil 국번 1 어드래스 0(아두이노에서는 1), off:false
                _master.WriteSingleCoil(1, 1, false);
            }
        }

        private void trbR_Scroll(object sender, EventArgs e)
        {
            if (_port.IsOpen)
            {
                int Rvalue = trbR.Value;
                _master.WriteSingleRegister(1, 5, (ushort)Rvalue);
            }
        }

        private void trbG_Scroll(object sender, EventArgs e)
        {
            if (_port.IsOpen)
            {
                int Gvalue = trbG.Value;
                _master.WriteSingleRegister(1, 6, (ushort)Gvalue);
            }
        }

        private void trbB_Scroll(object sender, EventArgs e)
        {
            if (_port.IsOpen)
            {
                int Bvalue = trbB.Value;
                _master.WriteSingleRegister(1, 7, (ushort)Bvalue);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (_port.IsOpen)
            {
                var btn_temp = _master.ReadInputs(1, 3, 2);
                // btn_temp[0] 푸쉬버튼의 상태값
                if (btn_temp[0])
                {
                    lblPB.BackColor = Color.DarkRed;
                }
                else
                {
                    lblPB.BackColor = Color.BlueViolet;
                }

                if (btn_temp[1])
                {

                    lblTB.BackColor = Color.DarkRed;
                }
                else
                {
                    lblTB.BackColor = Color.BlueViolet;
                }

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_port.IsOpen)
            {
                var btn_temp = _master.ReadInputs(1, 3, 2);
                // btn_temp[0] 푸쉬버튼의 상태값
                if (btn_temp[0])
                {
                    lblPB.BackColor = Color.DarkRed;
                }
                else
                {
                    lblPB.BackColor = Color.BlueViolet;
                }

                if (btn_temp[1])
                {

                    lblTB.BackColor = Color.DarkRed;
                }
                else
                {
                    lblTB.BackColor = Color.BlueViolet;
                }
            }
        }

        private void btnTOn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnTOff_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void btnT2On_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void btnT2Off_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (_port.IsOpen)
            {
                var Analogdata = _master.ReadHoldingRegisters(1, 0, 5);
                tbxTemp.Text = (Analogdata[0] * 0.01f).ToString("N2");
                pgbTemp.Value = Convert.ToInt16(Analogdata[0] * 0.01f);
                tbxHumi.Text = (Analogdata[1] * 0.01f).ToString("N2");
                pgbHumi.Value = Convert.ToInt16(Analogdata[1] * 0.01f);
                tbxCDS.Text = (Analogdata[2]).ToString("N2");
                pgbCDS.Value = Convert.ToInt16(Analogdata[2]);
                tbxPoten.Text = (Analogdata[3]).ToString("N2");
                pgbPoten.Value = Convert.ToInt16(Analogdata[3]);
                tbxHall.Text = (Analogdata[4]).ToString("N2");
                pgbHall.Value = Convert.ToInt16(Analogdata[4]);

                var Micdata = _master.ReadHoldingRegisters(1, 32, 1);
                tbxMic.Text = (Micdata[0]).ToString("N2");
                pgbMic.Value = Convert.ToInt16(Micdata[0]);
            }
        }

        private void btnEcho_Click(object sender, EventArgs e)
        {
            if (_port.IsOpen)
            {
                var Echodata = _master.ReadHoldingRegisters(1, 8, 1);
                tbxEcho.Text = Echodata[0].ToString() + "cm";
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (_port.IsOpen)
            {
                string[] lines = tbxLCDWrite.Lines;
                string firstLine = (lines.Length > 0) ? lines[0] : "";
                string secondLine = (lines.Length > 1) ? lines[1] : "";

                // 15자 칸 크기에 맞게 뒤에 빈 공백(" ")을 채워주는 작업 (LCD 잔상 제거용)
                firstLine = firstLine.PadRight(10, ' ');
                secondLine = secondLine.PadRight(10, ' ');

                // --- ⭐️ 핵심: 문자열(string)을 모드버스용 숫자 배열(ushort[])로 변환 ---
                ushort[] firstData = new ushort[10];
                ushort[] secondData = new ushort[10];

                for (int i = 0; i < 10; i++)
                {
                    firstData[i] = (ushort)firstLine[i];   // 글자 한 칸을 아스키코드 숫자로 변환
                    secondData[i] = (ushort)secondLine[i];
                }

                // --- 🚀 모드버스 전송 (첫 줄은 9번방부터, 둘째 줄은 30번방부터) ---
                // 국번 1, 시작주소 9, 데이터 배열(10칸짜리) 전송
                _master.WriteMultipleRegisters(1, 9, firstData);

                // 데이터가 겹치지 않게 둘째 줄은 30번 주소부터 전송
                _master.WriteMultipleRegisters(1, 20, secondData);
            }
        }

        private void btnServoP_Click(object sender, EventArgs e)
        {
            if (_port.IsOpen)
            {
                try
                {
                    // 1. 현재 텍스트박스에 써있는 숫자를 읽어옵니다. (비어있으면 0으로 시작)
                    int currentAngle = 0;
                    if (!string.IsNullOrEmpty(tbxServo.Text))
                    {
                        int.TryParse(tbxServo.Text, out currentAngle);
                    }

                    // 2. 최대값인 200보다 작을 때만 값을 5씩 증가시킵니다. (원하는 단위로 변경 가능)
                    if (currentAngle < 200)
                    {
                        currentAngle += 10;

                        // 혹시라도 200을 넘어가면 200으로 안전하게 고정
                        if (currentAngle > 200) currentAngle = 200;

                        // 3. UI 텍스트박스 글자 업데이트
                        tbxServo.Text = currentAngle.ToString();

                        // 4. 모드버스 31번 레지스터에 데이터 전송
                        _master.WriteSingleRegister(1, 31, (ushort)currentAngle);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("서보 제어 오류: " + ex.Message);
                }
            }
        }

        private void btnServoM_Click(object sender, EventArgs e)
        {
            if (_port.IsOpen)
            {
                try
                {
                    // 1. 현재 텍스트박스에 써있는 숫자를 읽어옵니다.
                    int currentAngle = 0;
                    if (!string.IsNullOrEmpty(tbxServo.Text))
                    {
                        int.TryParse(tbxServo.Text, out currentAngle);
                    }

                    // 2. 최소값인 0보다 클 때만 값을 5씩 감소시킵니다.
                    if (currentAngle > 0)
                    {
                        currentAngle -= 10;

                        // 혹시라도 0보다 작아지면 0으로 안전하게 고정
                        if (currentAngle < 0) currentAngle = 0;

                        // 3. UI 텍스트박스 글자 업데이트
                        tbxServo.Text = currentAngle.ToString();

                        // 4. 모드버스 31번 레지스터에 데이터 전송
                        _master.WriteSingleRegister(1, 31, (ushort)currentAngle);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("서보 제어 오류: " + ex.Message);
                }
            }
        }
    }
}
