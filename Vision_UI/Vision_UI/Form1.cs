using Cognex.InSight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision_UI
{
    public partial class Form1 : Form
    {
        private CvsInSight insightCamera; // Insight 객체생성

        bool IsConnected1 = false; // 연결 상태 표현
        bool OnLineST1; // 온오프라인 상태 표현
        bool Result1TF; // 테스트 합불 표현

        public Form1()
        {
            InitializeComponent();
            insightCamera = new CvsInSight();
        }

        private void cvsInSightDisplay1_Load(object sender, EventArgs e)
        // 카메라 결과가 변경되었을 때 발생하는 이벤트 (트리거 등)
        {
            // 카메라가 연결되었을 때 
            if (IsConnected1)
            {
                // 카메라가 촬영한 데이터를 result1Set1에 할당
                Cognex.InSight.CvsResultSet resultSet1 = cvsInSightDisplay1.Results;

                // 이미지의 결과가 null이 아닐 때 
                if (resultSet1.Image != null)
                {
                    try
                    {
                        if (resultSet1.HasNewlyAcquiredImage)
                        {
                            System.Drawing.Bitmap img1 = new System.Drawing.Bitmap(cvsInSightDisplay1.GetBitmap());
                        }

                        RefreshData(); //모니터링 결과 새로고침
                    }
                    catch { }
                }
                // 변경된 데이터를 업데이트
                cvsInSightDisplay1.AcceptUpdate();
            }
        }

        private void OnLine_Click(object sender, EventArgs e)
        //온라인버튼 클릭 시
        {
            // OnLineST1 에 카메라의 온라인 상태 여부를 할당

            OnLineST1 = cvsInSightDisplay1.SoftOnline;

            // 카메라가 온라인일 때
            if (OnLineST1 == true)
            {
                OnLine.BackColor = System.Drawing.Color.Green;

                Trigger.Enabled = false; //오프라인 일 때 트리거 비활성화
            }
            // 카메라가 오프라인일 때
            else if (OnLineST1 == false)
            {
                OnLine.BackColor = System.Drawing.Color.Red;

                Trigger.Enabled = true; //오프라인 일 때 트리거 활성화
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        //Connect 버튼 클릭되었을 때
        {
            try
            {
                // 디스플레이 컨트롤과 카메라 객체 연동
                cvsInSightDisplay1.InSight = insightCamera;

                // 실제 카메라 IP 주소 및 계정 정보 입력 필요 (기본 계정: admin, 비밀번호 없음)
                cvsInSightDisplay1.Connect("192.168.3.100", "admin", "", false);

                IsConnected1 = true;

                state1.Text = "Vision On";
                state1.ForeColor = System.Drawing.Color.Green;


                cvsInSightDisplay1.ImageScale = 0.3; // 촬영중인 이미지의 배율 설정
                cvsInSightDisplay1.ShowImage = true; // 카메라가 취득한 이미지를 보여줌
                cvsInSightDisplay1.ShowGraphics = true;
                Online_Check();

            }
            catch (Exception ex)
            {
                MessageBox.Show("연결 실패: " + ex.Message);
            }
        }
        void Online_Check() // 카메라 온라인상태 체크 메서드
        {
            // 카메라가 연결되었을 때 
            if (IsConnected1)
            {
                // 카메라가 온라인 상태일 때
                if (cvsInSightDisplay1.SoftOnline)
                {
                    cvsInSightDisplay1.SoftOnline = !cvsInSightDisplay1.SoftOnline;
                    OnLine.BackColor = System.Drawing.Color.Red;
                }
                // 카메라가 오프라인 상태일 때 
                else if (!cvsInSightDisplay1.SoftOnline)
                {
                    cvsInSightDisplay1.SoftOnline = !cvsInSightDisplay1.SoftOnline;
                    OnLine.BackColor = System.Drawing.Color.Green;
                }
            }
        }
        private void ResetFormText_1() // 모니터링 결과 새로고침하는 메소드
        {
            QRRes.Text = "";
            CX1.Text = "X : ";
            CY1.Text = "Y : ";
            CA1.Text = "Angle : ";
            OKNGBox.Visible = false;
        }

        private void Trigger_Click(object sender, EventArgs e)
        {
            // TODO: 비전 트리거 활성화 로직 구현
            // 트리거 실행 후 결과값을 UI 라벨에 업데이트하는 로직이 필요합니다.

            // 아래는 결과값을 각 Label에 업데이트하는 예시입니다.
            //  UpdateResults("378.781", "451.827", "7.62497", "YEL", "OK");
            cvsInSightDisplay1.InSight.ManualAcquire(wait: true);
            // 2. ⭐️ 촬영이 끝났으니 최신 데이터를 가져와서 UI에 업데이트하라고 명령!
            RefreshData();
        }
        private void RefreshData() //모니터링 값 새로고침 할때 사용 메소드
        {
            try
            {
                // 1. 셀 데이터를 가져온 후, null인지 먼저 확인하여 방어
                var cell_X = cvsInSightDisplay1.Results.Cells["B27"];
                var cell_Y = cvsInSightDisplay1.Results.Cells["C27"];
                var cell_Angle = cvsInSightDisplay1.Results.Cells["D27"];
                var cell_QR = cvsInSightDisplay1.Results.Cells["B86"];

                // null일 경우 "0" 또는 "None" 문자로 대체하여 ToString() 에러 원천 차단
                string XY_X = cell_X != null ? cell_X.ToString() : "0";
                string XY_Y = cell_Y != null ? cell_Y.ToString() : "0";
                string angle = cell_Angle != null ? cell_Angle.ToString() : "0";
                string Result1Value = cell_QR != null ? cell_QR.ToString() : "None";

                // 읽어온 데이터(예: "POLY234<CR><LF>")가 7글자 이상일 때만 앞에서부터 7글자를 가져옵니다.
                if (Result1Value.Length >= 7)
                {
                    Result1Value = Result1Value.Substring(0, 7);
                }

                // 2. UI 업데이트 (길이 체크 포함)
                CX1.Text = "X : " + (XY_X.Length > 7 ? XY_X.Substring(0, 7) : XY_X);
                CY1.Text = "Y : " + (XY_Y.Length > 7 ? XY_Y.Substring(0, 7) : XY_Y);
                CA1.Text = "Angle : " + (angle.Length > 7 ? angle.Substring(0, 7) : angle);

                // 3. QR코드 및 판정 결과 업데이트
                QRRes.Text = Result1Value;
                OKNGBox.Visible = true;

                if (Result1Value == "POLY234")
                {
                    Result1TF = true;
                    OKNGBox.BackColor = System.Drawing.Color.Green;
                    OKNGBox.Text = "OK";
                }
                else
                {
                    Result1TF = false;
                    OKNGBox.BackColor = System.Drawing.Color.Red;
                    OKNGBox.Text = "NG";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 갱신 오류: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            state1.Text = "Vision off";
        }
    }
}
