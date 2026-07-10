#include <Arduino.h>           // 아두이노 기본 기능(디지털/아날로그 입출력 등)을 쓰기 위한 필수 헤더 파일 포함
#include "DHT.h"               // 온습도 센서(DHT11)를 쉽게 제어하기 위한 온습도 라이브러리 파일 포함
#include <ModbusRTU.h>         // 모드버스(Modbus RTU) 통신 규격을 쓰기 위한 모드버스 라이브러리 파일 포함
#include <LiquidCrystal_I2C.h> // I2C 통신 방식의 LCD 화면을 제어하기 위한 LCD 라이브러리 파일 포함

#define DHTPIN 12        // 온습도 센서(DHT11)의 데이터 신호선을 아두이노 12번 디지털 핀으로 지정
#define DHTTYPE DHT11    // 사용하는 온습도 센서의 종류를 구형인 'DHT11' 타입으로 최종 설정
#define debug 0          // 디버그 모드 활성화 변수 (1이면 컴퓨터 화면 출력, 0이면 PC 모드버스 통신 수행)
#define touchbutton 7    // 터치 센서 모듈의 신호선을 아두이노 7번 디지털 핀으로 지정
#define button 8         // 일반 푸시 버튼 스위치의 신호선을 아두이노 8번 디지털 핀으로 지정
#define LED 13           // 아두이노 보드 자체에 내장된 칩 LED가 연결된 13번 디지털 핀으로 지정
#define R_LED 9          // 3색(RGB) LED 중 빨간색(Red) 제어선을 PWM 아날로그 출력이 가능한 9번 핀으로 지정
#define G_LED 10         // 3색(RGB) LED 중 초록색(Green) 제어선을 PWM 아날로그 출력이 가능한 10번 핀으로 지정
#define B_LED 11         // 3색(RGB) LED 중 파란색(Blue) 제어선을 PWM 아날로그 출력이 가능한 11번 핀으로 지정
#define NOTE_E6  1319
#define NOTE_G6  1568
#define NOTE_A6  1760
#define NOTE_AS6 1865
#define NOTE_B6  1976
#define NOTE_C7  2093
#define NOTE_D7  2349
#define NOTE_E7  2637
#define NOTE_F7  2794
#define NOTE_G7  3136
#define NOTE_A7  3520
#define NOTE_C6  1047
#define NOTE_D6  1175
#define NOTE_E6  1319
#define NOTE_F6  1397
#define NOTE_G6  1568
#define NOTE_A6  1760
#define NOTE_B6  1976
#define Echopin 4
#define TrigPin 5

ModbusRTU slave;                    // 모드버스 슬레이브(종속 장치) 역할을 수행할 통신 객체 'slave' 생성
DHT dht(DHTPIN, DHTTYPE);           // 12번 핀과 DHT11 타입을 연결하여 온습도 센서를 제어할 객체 'dht' 생성
LiquidCrystal_I2C LCD(0X27, 16, 2); // I2C 주소 0x27를 가지고 가로 16칸, 세로 2줄짜리인 LCD 객체 'LCD' 생성

const int buzzerPin = 6; 
bool touchButtonState = false; // 터치 버튼이 눌렸는지 켜짐(true)/꺼짐(false) 상태를 기억할 변수 선언
bool ButtonState = false;      // 일반 버튼이 눌렸는지 켜짐(true)/꺼짐(false) 상태를 기억할 변수 선언
uint16_t humi = 0;             // 측정된 습도 값을 소수점 없이 저장하기 위한 2바이트 크기의 정수형 변수 선언
uint16_t temp = 0;             // 측정된 온도 값을 소수점 없이 저장하기 위한 2바이트 크기의 정수형 변수 선언
uint16_t cds = 0;              // 측정된 조도(밝기) 센서 값을 저장하기 위한 2바이트 크기의 정수형 변수 선언
uint16_t poten = 0;            // 측정된 가변저항(다이얼) 값을 저장하기 위한 2바이트 크기의 정수형 변수 선언
uint16_t hall = 0;             // 측정된 자석(홀 모듈) 센서 값을 저장하기 위한 2바이트 크기의 정수형 변수 선언

unsigned long lastTempHumiTime = 0; // delay() 대신 온습도 센서를 1초 주기로 체크하기 위해 이전 시간을 저장할 변수
unsigned long lastCdsTime = 0;      // delay() 대신 조도 센서를 0.5초 주기로 체크하기 위해 이전 시간을 저장할 변수
unsigned long lastPotenTime = 0;    // delay() 대신 가변저항을 0.5초 주기로 체크하기 위해 이전 시간을 저장할 변수
unsigned long lastHallTime = 0;     // delay() 대신 홀 센서를 0.5초 주기로 체크하기 위해 이전 시간을 저장할 변수
unsigned long lastLCDTime = 0;      // delay() 대신 LCD 화면을 0.5초 주기로 갱신하기 위해 이전 시간을 저장할 변수

void SensorReading();     // 아두이노에 연결된 모든 버튼과 센서 값을 읽어오는 함수가 존재함을 미리 컴퓨터에 알림
void LED_Action();        // PC나 외부 마스터의 명령을 받아 LED들을 제어하는 함수가 존재함을 미리 컴퓨터에 알림
void SerialPrint();       // debug가 1일 때 컴퓨터 시리얼 모니터 창에 센서 값을 출력하는 함수가 존재함을 알림
void LCD_Display();       // LCD 화면에 실시간 온도와 습도를 깔끔하게 띄워주는 함수가 존재함을 미리 컴퓨터에 알림
void playTone(int note, int duration);
void playbuzzer();
void showEcho();

void setup() { // 아두이노가 켜지거나 리셋될 때 딱 한 번만 실행되는 설정 구역
  Serial.begin(9600); // 컴퓨터 또는 외부 장치와 데이터를 주고받을 속도를 9600bps(보레이트)로 설정하여 통신 시작
  if (!debug) {       // 만약 debug 모드가 0(통신 모드)이라면 실행
    slave.begin(&Serial); // 모드버스 슬레이브 통신 선로를 컴퓨터와 연결된 Serial 포트로 지정하여 구동
    slave.slave(1);       // 모드버스 네트워크 내에서 이 아두이노 장치의 고유 국번(ID)을 1번으로 지정
  } // if (!debug) 조건문 종료

  slave.addCoil(1);    // 마스터가 ON/OFF할 수 있는 1번 Coil(비트 형태 창고) 개설 -> 13번 내장 LED용
  slave.addIsts(3);    // 마스터가 읽어갈 수 있는 3번 Discrete Input(입력용 비트 창고) 개설 -> 일반 버튼 상태 전송용
  slave.addIsts(4);    // 마스터가 읽어갈 수 있는 4번 Discrete Input(입력용 비트 창고) 개설 -> 터치 버튼 상태 전송용

  slave.addHreg(0);    // 마스터가 조회할 수 있는 0번 Holding Register(2바이트 정수 창고) 개설 -> 온도 데이터용
  slave.addHreg(1);    // 마스터가 조회할 수 있는 1번 Holding Register(2바이트 정수 창고) 개설 -> 습도 데이터용
  slave.addHreg(2);    // 마스터가 조회할 수 있는 2번 Holding Register(2바이트 정수 창고) 개설 -> 조도(CDS) 데이터용
  slave.addHreg(3);    // 마스터가 조회할 수 있는 3번 Holding Register(2바이트 정수 창고) 개설 -> 가변저항 데이터용
  slave.addHreg(4);    // 마스터가 조회할 수 있는 4번 Holding Register(2바이트 정수 창고) 개설 -> 자기장(Hall) 데이터용
  slave.addHreg(5);    // 마스터가 ON/OFF할 수 있는 5번 Holding Register(2바이트 정수 창고) 개설 -> R LED 제어용
  slave.addHreg(6);    // 마스터가 ON/OFF할 수 있는 6번 Holding Register(2바이트 정수 창고) 개설 -> G LED 제어용
  slave.addHreg(7);    // 마스터가 ON/OFF할 수 있는 7번 Holding Register(2바이트 정수 창고) 개설 -> B LED 제어용
  slave.addHreg(8);    // 에코 데이터용



  slave.Hreg(0, 1);    // 통신 연결 전 테스트용으로 0번 데이터 창고(온도)의 초기값을 숫자 1로 임시 저장
  slave.Hreg(1, 2);    // 통신 연결 전 테스트용으로 1번 데이터 창고(습도)의 초기값을 숫자 2로 임시 저장
  slave.Hreg(2, 100);    // 통신 연결 전 테스트용으로 2번 데이터 창고(조도)의 초기값을 숫자 3로 임시 저장
  slave.Hreg(3, 4);    // 통신 연결 전 테스트용으로 3번 데이터 창고(가변저항)의 초기값을 숫자 4로 임시 저장
  slave.Hreg(4, 5);    // 통신 연결 전 테스트용으로 4번 데이터 창고(홀센서)의 초기값을 숫자 5로 임시 저장
  slave.Hreg(8, 0);

  pinMode(touchbutton, INPUT); // 7번 디지털 핀을 터치센서의 신호전압을 받아들이는 '입력 모드'로 설정
  pinMode(button, INPUT);      // 8번 디지털 핀을 스위치의 켜짐/꺼짐 신호를 받아들이는 '입력 모드'로 설정
  pinMode(LED, OUTPUT);        // 13번 디지털 핀을 내장 LED에 전기를 내보낼 수 있는 '출력 모드'로 설정
  pinMode(R_LED, OUTPUT);      // 9번 디지털 핀을 RGB 모듈의 빨간색 불을 제어할 전기를 내보내는 '출력 모드'로 설정
  pinMode(G_LED, OUTPUT);      // 10번 디지털 핀을 RGB 모듈의 초록색 불을 제어할 전기를 내보내는 '출력 모드'로 설정
  pinMode(B_LED, OUTPUT);      // 11번 디지털 핀을 RGB 모듈의 파란색 불을 제어할 전기를 내보내는 '출력 모드'로 설정
  pinMode(buzzerPin, OUTPUT); // 부저 핀을 출력으로 설정
  pinMode(Echopin, INPUT);
  pinMode(TrigPin, OUTPUT);

  dht.begin(); // 온습도 센서(DHT11)의 내부 소자 및 읽기 알고리즘 가동 시작

  LCD.init();                  // 아두이노와 연결된 I2C LCD 디스플레이의 내부 칩셋 시스템 작동 시작
  LCD.backlight();             // 어두운 곳에서도 LCD 글자가 잘 보이도록 배경 불빛(백라이트)을 화사하게 켬
  LCD.clear();                 // LCD 화면에 혹시 남아있을지 모르는 지저분한 잔상이나 글자들을 깨끗하게 지움
  LCD.print("Initializing..."); // 아두이노가 잘 켜졌다는 것을 보여주기 위해 LCD에 "Initializing..." 문구 출력
} // setup() 함수 종료

void loop() { // setup이 끝난 뒤, 아두이노가 꺼질 때까지 무한히 전속력으로 반복 실행되는 핵심 구역
  if (!debug) { // 만약 debug 값이 0(통신 전용 모드) 상태라면 실행
    slave.task(); // 모드버스 마스터(PC 프로그램 등)로부터 들어온 데이터 요구나 제어 명령이 있는지 수시로 감시 및 응답
  } // if (!debug) 조건문 종료
  
  SensorReading();  // 센서들과 버튼의 상태를 실시간으로 스캔해서 모드버스 저장 창고에 업데이트하는 함수 실행
  LED_Action();     // 모드버스 창고(Coil)에 담긴 마스터의 지시값에 따라 물리적인 LED 핀들을 켜고 끄는 함수 실행
  LCD_Display();    // 아두이노가 계산한 온습도 결과 값을 사람이 볼 수 있게 0.5초마다 LCD 화면에 띄우는 함수 실행
  showEcho();

  if (debug) {      // 만약 debug 값이 1(컴퓨터 모니터링 모드) 상태라면 실행
    SerialPrint();  // 컴퓨터 시리얼 모니터 검은색 창에 센서 값들을 실시간으로 문자열 형태로 인쇄 출력
  } // if (debug) 조건문 종료

    if (slave.Hreg(2) < 20) { // 조도 센서 비율 값이 설정해 둔 임계치인 20% 미만으로 떨어져 어두워졌을 때 실행
        playbuzzer();                // 지정된 비프음 경고 멜로디를 연주함
      }
} // loop() 함수 종료

void SensorReading() { // 모든 센서의 전압 신호를 파악하고 가공하여 모드버스 통신 창고에 배정하는 함수 정의
  ButtonState = digitalRead(button);           // 8번 핀 스위치 전압(HIGH/LOW)을 읽어서 ButtonState 변수에 대입
  touchButtonState = digitalRead(touchbutton); // 7번 핀 터치센서 전압(HIGH/LOW)을 읽어서 touchButtonState 변수에 대입
 
  slave.Ists(3, ButtonState);      // 마스터가 언제든 가져갈 수 있게 일반 버튼 상태를 모드버스 입력 3번 방에 박아둠
  slave.Ists(4, touchButtonState); // 마스터가 언제든 가져갈 수 있게 터치 버튼 상태를 모드버스 입력 4번 방에 박아둠
 
  unsigned long currentTime = millis(); // 아두이노 보드가 켜진 순간부터 몇 밀리초(1/1000초)가 흘렀는지 현재 시간 측정

  // [온습도 센서 제어용 타이머] 현재 시간에서 마지막 온습도 측정한 시간을 뺀 값이 1000ms(1초) 이상이 되면 실행
  if (currentTime - lastTempHumiTime >= 3000) { 
    // 정밀한 소수점 온도를 읽어온 뒤 소수점 유실을 막기 위해 100을 곱하고 강제로 정수(uint16_t)로 형변환하여 대입
    temp = (uint16_t)(dht.readTemperature() * 100.f);
    // 정밀한 소수점 습도를 읽어온 뒤 소수점 유실을 막기 위해 100을 곱하고 강제로 정수(uint16_t)로 형변환하여 대입
    humi = (uint16_t)(dht.readHumidity() * 100.f);
    
    if (!isnan(temp) && !isnan(humi)) { // 센서 고장이나 선 끊어짐 등으로 인해 읽어온 값에 에러(NaN)가 없다면 실행
      slave.Hreg(0, temp); // 100배 튀겨진 정수형 온도 값을 모드버스 Holding Register 0번 방에 최신 값으로 저장
      slave.Hreg(1, humi); // 100배 튀겨진 정수형 습도 값을 모드버스 Holding Register 1번 방에 최신 값으로 저장
    } // if (!isnan...) 조건문 종료
    lastTempHumiTime = currentTime; // 다음 1초 주기를 다시 계산하기 위해 마지막 실행 시간을 현재 시간으로 갱신
  } // 온습도 타이머 조건문 종료

  // [조도 센서 제어용 타이머] 현재 시간과 마지막 조도 측정한 시간의 간격이 500ms(0.5초) 이상이 되면 실행
  if (currentTime - lastCdsTime >= 500) { 
    cds = (uint16_t)(analogRead(A1));          // A1번 아날로그 핀에서 조도 센서 전압(0~1023 값)을 읽어와 대입
    uint16_t cds1 = map(cds, 50, 1000, 0, 100); // 50~1000 사이의 아날로그 신호를 PC에서 보기 좋게 0~100% 비율로 변환
    slave.Hreg(2, cds1);                       // 비율 변환된 조도(%) 값을 모드버스 Holding Register 2번 방에 저장
    lastCdsTime = currentTime;                 // 다음 0.5초 주기를 다시 계산하기 위해 조도 실행 시간 갱신
  } // 조도 타이머 조건문 종료

  // [가변저항 제어용 타이머] 현재 시간과 마지막 가변저항 측정한 시간의 간격이 500ms(0.5초) 이상이 되면 실행
  if (currentTime - lastPotenTime >= 500) { 
    poten = (uint16_t)(analogRead(A0));            // A0번 아날로그 핀에서 회전 다이얼 전압(0~1023 값)을 읽어와 대입
    uint16_t poten1 = map(poten, 0, 1023, 0, 100); // 0~1023 사이의 저항 각도 신호를 0~100% 비율 수치로 깔끔하게 압축 변환
    slave.Hreg(3, poten1);                         // 변환된 가변저항(%) 값을 모드버스 Holding Register 3번 방에 저장
    lastPotenTime = currentTime;                   // 다음 0.5초 주기를 다시 계산하기 위해 가변저항 실행 시간 갱신
  } // 가변저항 타이머 조건문 종료

  // [홀 센서 제어용 타이머] 현재 시간과 마지막 홀 센서 측정한 시간의 간격이 500ms(0.5초) 이상이 되면 실행
  if (currentTime - lastHallTime >= 500) { 
    hall = (uint16_t)(analogRead(A2));           // A2번 아날로그 핀에서 자기장 센서 전압(0~1023 값)을 읽어와 대입
    uint16_t hall1 = map(hall, 100, 400, 0, 100); // 자석 세기 신호(100~400 범위)를 표준 0~100% 비율 데이터로 찌그러뜨려 변환
    slave.Hreg(4, hall1);                        // 변환된 홀 센서(%) 값을 모드버스 Holding Register 4번 방에 저장
    lastHallTime = currentTime;                  // 다음 0.5초 주기를 다시 계산하기 위해 홀 센서 실행 시간 갱신
  } // 홀 센서 타이머 조건문 종료
} // SensorReading() 함수 종료

void LCD_Display() { // 사람이 눈으로 센서 데이터를 볼 수 있도록 부드럽게 LCD 화면을 제어 및 갱신하는 함수 정의
  unsigned long currentTime = millis(); // 현재 아두이노 구동 시간을 다시 밀리초 단위로 파악
  if (currentTime - lastLCDTime >= 500) { // 화면이 너무 파르르 떨리며 깜빡이지 않게 딱 500ms(0.5초) 마다 진입
    
    // 통신 전송용으로 100을 곱해 정수로 만들었던 데이터를 화면에 찍기 위해 다시 100.0으로 나누어 정밀한 소수점 형태로 복구
    float actual_temp = temp / 100.0; // 예: 정수 2530 -> 소수점 25.3 변환
    float actual_humi = humi / 100.0; // 예: 정수 9500 -> 소수점 95.0 변환

    LCD.clear(); // 매번 새로운 온습도 값을 고정 자리에 깔끔하게 덮어쓰기 위해 이전 텍스트 화면을 리셋 지움
    
    LCD.setCursor(0, 0);       // 글자를 인쇄하기 위해 글자 출력 커서를 LCD의 1층(첫 번째 줄) 맨 왼쪽(0번째 칸)으로 배치
    LCD.print("Temp: ");       // 화면 커서 자리에 "Temp: "라는 온도 안내 영어 문자열 인쇄
    LCD.print(actual_temp, 1); // 복구된 소수점 온도를 소수점 아래 '첫째자리'까지만 정밀하게 이어서 출력
    LCD.print(" C");           // 수치 오른쪽에 온도 단위인 섭씨 기호 뒤쪽 " C" 글자 인쇄

    LCD.setCursor(0, 1);       // 글자를 인쇄하기 위해 글자 출력 커서를 LCD의 2층(두 번째 줄) 맨 왼쪽(0번째 칸)으로 배치
    LCD.print("Humi: ");       // 화면 커서 자리에 "Humi: "라는 습도 안내 영어 문자열 인쇄
    LCD.print(actual_humi, 1); // 복구된 소수점 습도를 소수점 아래 '첫째자리'까지만 정밀하게 이어서 출력
    LCD.print(" %");           // 수치 오른쪽에 습도 단위 기호인 " %" 문자열 인쇄

    lastLCDTime = currentTime; // 화면을 성공적으로 갱신했으므로 LCD 실행 타임스탬프를 현재 시간으로 갱신
  } // LCD 주기 제어 조건문 종료
} // LCD_Display() 함수 종료

void LED_Action() { // 모드버스 내부 창고에 저장된 데이터에 반응하여 아두이노 실제 LED 물리 핀을 제어하는 함수 정의
  // PC 마스터 프로그램이 1번 Coil 주소에 전기를 넣어 숫자가 0보다 큰지(true) 검사하여 13번 내장 LED 핀 작동 결정
  if (slave.Coil(1) > 0) { 
    digitalWrite(13, HIGH); // 참이면 13번 디지털 핀에 5V 최고 전압을 공급하여 물리 내장 LED를 강제로 밝게 켬
  } else { 
    digitalWrite(13, LOW);  // 거짓(0)이면 13번 디지털 핀의 전압을 0V로 차단하여 내장 LED를 완전히 끔
  } // 내장 LED 제어 조건문 종료
  
  // PC 마스터 프로그램이 5~7 데이터 레지스트리 확인 해서 그 값으로 외부 RGB 모듈 제어 결정
  int Rbright = slave.Hreg(5);  
  analogWrite(R_LED, Rbright); // 빨간색 LED 핀에 Rbright 값에 따른 아날로그 신호(255)를 주어 켬
  int Gbright = slave.Hreg(6);
  analogWrite(G_LED, Gbright); 
  int Bbright = slave.Hreg(7);
  analogWrite(B_LED, Bbright); 
} // LED_Action() 함수 종료

void SerialPrint() { // 컴퓨터와 연결된 아두이노 시리얼 모니터 창에 실시간 소통 확인용 데이터 라인을 뿌려주는 함수 정의
  Serial.print(F("Humidity: "));  // 컴퓨터 화면에 "Humidity: " 라는 안내 텍스트 출력 (F문법은 메모리 절약 꼼수)
  Serial.print(humi);             // 이어서 변수에 담긴 100배 압축된 습도 정수 수치 출력 (예: 9500)
  Serial.print(F("%  Temperature: ")); // 이어서 문장 중간에 구별용 단위 공백 및 온도 안내 영문 텍스트 출력
  Serial.print(temp);             // 이어서 변수에 담긴 100배 압축된 온도 정수 수치 출력 (예: 2530)
  Serial.println(F("°C "));       // 온도의 섭씨 기호를 끝에 찍고 개행(줄바꿈)을 수행하여 다음 문장 준비
  Serial.print("CDS:");           // 줄 바뀐 상태에서 "CDS:" 라는 텍스트 화면에 인쇄
  Serial.println(cds);            // 이어서 조도 수치(0~100 사이)를 출력한 뒤 다음 문장을 위해 엔터(줄바꿈) 처리
  Serial.print("가변저항:");       // 한글로 "가변저항:" 문구를 시리얼 창에 출력
  Serial.println(poten);          // 이어서 가변저항 수치(0~100 사이)를 출력한 뒤 엔터(줄바꿈) 처리
  Serial.print("Hall:");          // 영어로 자석 감지 "Hall:" 문구를 출력
  Serial.println(hall);           // 이어서 홀 센서 값(0~100 사이)을 찍어주고 줄바꿈 처리
  Serial.print("ButtonState:");   // 모드버스 응답 연결 확인용으로 "ButtonState:" 문구 인쇄
  Serial.println(slave.Ists(3));  // 실제 모드버스 3번 주소 창고에 들어간 버튼의 최종 디지털 값(0 또는 1) 확인 출력 및 줄바꿈
  Serial.print("TouchButtonState:"); // 통신 연동 확인용으로 "TouchButtonState:" 문구 인쇄
  Serial.println(slave.Ists(4));  // 실제 모드버스 4번 주소 창고에 들어간 터치센서의 최종 디지털 값(0 또는 1) 확인 출력 및 줄바꿈
  delay(1000);                    // 컴퓨터 시리얼 모니터의 글자가 너무 총알처럼 올라가면 눈 아프니까 강제로 1초(1000ms) 대기휴식
} // SerialPrint() 함수 종료

void playTone(int note, int duration) {
  if (note == 0) {
    noTone(buzzerPin); // 음 값이 0이면 쉼표 처리 (소리를 끔)
  } else {
    tone(buzzerPin, note, duration); // 아두이노 순정 소리내기 함수
  }
  // 음과 음이 뭉개지지 않고 딱딱 끊어져 들리도록 음 길이의 130%만큼 대기합니다.
  delay(duration * 1.30); 
}

void playbuzzer() {
  {
    playTone(NOTE_E7, 80);
    playTone(0, 80);
    playTone(NOTE_E7, 80);
    playTone(0, 80);
    playTone(NOTE_E7, 80);
    playTone(0, 80);
    playTone(NOTE_E7, 80);
    playTone(0, 80);
  }    
    noTone(buzzerPin); // 연주가 끝나면 확실하게 부저를 꺼줍니다.
}

void showEcho() {
  {
    float Duration, Distance;
    digitalWrite(TrigPin, HIGH);
    delayMicroseconds(10);
    digitalWrite(TrigPin, LOW);

    Duration = pulseIn(Echopin, HIGH);
    Distance = ((float)(340 * Duration) / 10000) / 2;

    slave.Hreg(8, Distance);

  }
}