#include <Arduino.h>
#include <ModbusRTU.h> 
#include <LiquidCrystal_I2C.h>

ModbusRTU slave; // 슬레이브 객체 생성

LiquidCrystal_I2C LCD(0X27, 16, 2);

#define LED 13
#define BT 8
#define Poten_ A0
#define RLED 9
#define GLED 10
#define BLED 11
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
#define Touch 7
#define Echopin 4
#define TrigPin 5

bool isEchoMeasured = false;
int currentScreen = 0; // 0: 기본, 1: 펀치, 2: 초음파, 3: 마리오
const int buzzerPin = 6; // 6번 핀에 부저가 연결됨

void playMarioTheme(); // 부저 연주 함수 이름 변경 (중복 회피)
void showDefaultScreen();
void showEcho();
void playTone(int note, int duration);

void setup() {
  // 1. 시리얼 통신 시작 (아두이노 우노는 Serial을 컴퓨터와의 통신에 씁니다)
  Serial.begin(9600);
  
  // 2. 슬레이브 ID 설정 및 시리얼 연결
  slave.begin(&Serial);
  slave.slave(1); // 슬레이브 국번을 1번으로 지정

  // 3. 핀 모드 설정
  pinMode(LED, OUTPUT);
  pinMode(BT, INPUT);
  pinMode(RLED, OUTPUT);
  pinMode(GLED, OUTPUT);
  pinMode(BLED, OUTPUT);
  pinMode(Touch, INPUT);
  pinMode(Echopin, INPUT);
  pinMode(TrigPin, OUTPUT);
  pinMode(buzzerPin, OUTPUT); // 부저 핀을 출력으로 설정

  // 4. 모드버스 주소(방) 개설하기
  slave.addCoil(0);    // Coils 0번 (QModBus 주소: 0) -> 13번 LED용
  slave.addIsts(0);    // Discrete Input 0번 (QModBus 주소: 10001 또는 0) -> 버튼용
  slave.addHreg(0);    // Holding Register 0번 (QModBus 주소: 40001 또는 0) -> 가변저항용
  slave.addHreg(4);    // Holding Register 4번 (QModBus 주소: 40005 또는 4) -> RLED용
  slave.addHreg(5);    // Holding Register 5번 (QModBus 주소: 40006 또는 5) -> GLED용

  // LCD setup
  LCD.init();
  LCD.backlight();
  showDefaultScreen();
}

void loop() {
  // 모드버스 통신 가동 (PC 명령 처리)
  slave.task();

  // -------------------------------------------------------------
  // ① 입력: 아두이노 -> PC (Master)
  // -------------------------------------------------------------
  // 버튼 상태를 읽어서 Discrete Input 0번에 저장
bool isPressed = digitalRead(BT);
slave.Ists(0, isPressed);


  // 가변저항 값을 읽어서 0~255로 압축한 뒤 Holding Register 0번에 저장
  int PotenPv = analogRead(Poten_);
  int tempPotenPv = map(PotenPv, 0, 1023, 0, 255);
  slave.Hreg(0, tempPotenPv);


  // -------------------------------------------------------------
  // ② LCD 화면 출력 주도권 로직 (중괄호 완전 정돈)
  // -------------------------------------------------------------
  if (isPressed) {
    // 1순위: 버튼이 눌렸을 때 (Punch! 화면)
     digitalWrite(LED, HIGH);
     LCD.clear();
     LCD.setCursor(0,0);
     LCD.print("Punch!");
     LCD.setCursor(0,1);
     LCD.print("@^_^--------@");
     currentScreen = 1;
  } else if (tempPotenPv >= 255) {
    // 2순위: 가변저항이 끝까지 갔을 때 (초음파 화면 호출)
    digitalWrite(LED, LOW);
    showEcho(); 
  } 
  else {
    // 3순위: 평소 상태 (기본 화면 원상복귀)
    digitalWrite(LED, LOW);
    if (currentScreen != 0) {
      showDefaultScreen();
      currentScreen = 0;
    }
    // 초음파 센서 리셋 유도
    if (isEchoMeasured) {
      isEchoMeasured = false;
    }
  }

  // -------------------------------------------------------------
  // ② 출력: PC (Master) -> 아두이노 제어
  // -------------------------------------------------------------
  // PC가 Coils 0번에 쓴 값(true/false)으로 13번 LED 켜고 끄기
  
  // PC가 Holding Register 4번, 5번에 쓴 값(0~255)으로 R, G LED 밝기 조절
  int potenMeter = slave.Hreg(0);
// [구간 1] 0일 때는 모든 LED 끄기
if (potenMeter == 0) {
  analogWrite(BLED, 0);
  analogWrite(GLED, 0);
  analogWrite(RLED, 0);
}
// [구간 2] 1~85 구간: 1일 때 밝기 0, 85일 때 밝기 255
else if (potenMeter >= 1 && potenMeter <= 85) {
  int bBrightness = map(potenMeter, 1, 85, 0, 255); 
  analogWrite(BLED, bBrightness); 
  analogWrite(GLED, 0);        
  analogWrite(RLED, 0);        
}   
// [구간 3] 86~170 구간: 86일 때 밝기 0, 170일 때 밝기 255로 변환
else if (potenMeter >= 86 && potenMeter <= 170) {
  int gBrightness = map(potenMeter, 86, 170, 0, 255);
  analogWrite(BLED, 0);
  analogWrite(GLED, gBrightness); 
  analogWrite(RLED, 0);
}   
// [구간 4] 171~255 구간: 171일 때 밝기 0, 255일 때 밝기 255로 변환
else if (potenMeter >= 171 && potenMeter <= 255) {
  int rBrightness = map(potenMeter, 171, 255, 0, 255);
  analogWrite(BLED, 0);
  analogWrite(GLED, 0);
  analogWrite(RLED, rBrightness);
}

  playMarioTheme();

  delay(10); // 통신 안정성을 위한 아주 잠깐의 쉬는 시간

  
}

void playTone(int note, int duration) {
  // [추가] 소리가 날 때 9, 10, 11번 LED를 랜덤하게 켭니다 (HIGH 또는 LOW)
  // random(2)는 0(LOW) 또는 1(HIGH)을 무작위로 뽑아줍니다.
  digitalWrite(9, random(2));
  digitalWrite(10, random(2));
  digitalWrite(11, random(2));

  if (random(2) == 1) {
    LCD.backlight();   // 백라이트 켜기
  } else {
    LCD.noBacklight(); // 백라이트 끄기 (화면이 어두워짐)
  }

  if (note == 0) {
    noTone(buzzerPin); // 음 값이 0이면 쉼표 처리 (소리를 끔)
  } else {
    tone(buzzerPin, note, duration); // 아두이노 순정 소리내기 함수
  }
  // 음과 음이 뭉개지지 않고 딱딱 끊어져 들리도록 음 길이의 130%만큼 대기합니다.
  delay(duration * 1.30); 

  // [추가] 한 음이 끝나면 다음 음이 나오기 전에 LED를 잠시 모두 꺼서 
  // 번쩍이는 효과(Strobe)를 극대화합니다.
  digitalWrite(9, LOW);
  digitalWrite(10, LOW);
  digitalWrite(11, LOW);
  LCD.backlight();
}

void playMarioTheme() {
  if(digitalRead(Touch) == HIGH) {
    currentScreen = 3; // 마리오 화면 상태 저장
    LCD.clear();
    LCD.setCursor(0, 0);
    LCD.print("Mario Time");
    LCD.setCursor(0, 1);
    LCD.print("* * * * *");
    LCD.display();
    // 마리오 메인 테마 멜로디 연주 시작
    playTone(NOTE_E7, 80);
    playTone(NOTE_E7, 80);
    playTone(0, 80);
    playTone(NOTE_E7, 80);
    playTone(0, 80);
    playTone(NOTE_C7, 80);
    playTone(NOTE_E7, 80);
    playTone(0, 80);
    playTone(NOTE_G7, 80);
    playTone(0, 240);
    playTone(NOTE_G6, 80);
    playTone(0, 240);
    
    playTone(NOTE_C7, 80);
    playTone(0, 160);
    playTone(NOTE_G6, 80);
    playTone(0, 160);
    playTone(NOTE_E6, 80);
    playTone(0, 160);
    playTone(NOTE_A6, 80);
    playTone(0, 80);
    playTone(NOTE_B6, 80);
    playTone(0, 80);
    playTone(NOTE_AS6, 80);
    playTone(NOTE_A6, 80);
    playTone(0, 80);
    
    playTone(NOTE_G6, 100);
    playTone(NOTE_E7, 100);
    playTone(NOTE_G7, 100);
    playTone(NOTE_A7, 80);
    playTone(0, 80);
    playTone(NOTE_F7, 80);
    playTone(NOTE_G7, 80);
    playTone(0, 80);
    playTone(NOTE_E7, 80);
    playTone(0, 80);
    playTone(NOTE_C7, 80);
    playTone(NOTE_D7, 80);
    playTone(NOTE_B6, 80);
    playTone(0, 160);
    
    playTone(NOTE_C7, 80);
    playTone(0, 160);
    playTone(NOTE_G6, 80);
    playTone(0, 160);
    playTone(NOTE_E6, 80);
    playTone(0, 160);
    playTone(NOTE_A6, 80);
    playTone(0, 80);
    playTone(NOTE_B6, 80);
    playTone(0, 80);
    playTone(NOTE_AS6, 80);
    playTone(NOTE_A6, 80);
    playTone(0, 80);
    
    playTone(NOTE_G6, 100);
    playTone(NOTE_E7, 100);
    playTone(NOTE_G7, 100);
    playTone(NOTE_A7, 80);
    playTone(0, 80);
    playTone(NOTE_F7, 80);
    playTone(NOTE_G7, 80);
    playTone(0, 80);
    playTone(NOTE_E7, 80);
    playTone(0, 80);
    playTone(NOTE_C7, 80);
    playTone(NOTE_D7, 80);
    playTone(NOTE_B6, 80);
    playTone(0, 160);
    delay(300);

    noTone(buzzerPin); // 연주가 끝나면 확실하게 부저를 꺼줍니다.
    digitalWrite(9, LOW);
    digitalWrite(10, LOW);
    digitalWrite(11, LOW);

    LCD.backlight();
    showDefaultScreen();
    currentScreen = 0; // 복귀 완료
  }
 }

void showDefaultScreen() {
    LCD.clear();
    LCD.setCursor(0,0);
    LCD.print("I'm Ready");
}

void showEcho() {
 if (!isEchoMeasured) {
    float Duration, Distance;
    digitalWrite(TrigPin, HIGH);
    delayMicroseconds(10);
    digitalWrite(TrigPin, LOW);

    Duration = pulseIn(Echopin, HIGH);
    Distance = ((float)(340 * Duration) / 10000) / 2;

    LCD.clear();
    LCD.setCursor(0,0);
    LCD.print(Distance);
    LCD.setCursor(6,0);
    LCD.print("CM");

    isEchoMeasured = true;
    currentScreen = 2; // 초음파 화면 상태 고정
  }
}