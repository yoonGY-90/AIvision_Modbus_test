#include <Arduino.h>
#include <ModbusRTU.h> 
#include <LiquidCrystal_I2C.h>

ModbusRTU slave; 

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
#define NOTE_F6  1397
#define Touch 7
#define Echopin 4
#define TrigPin 5

bool isEchoMeasured = false;
int currentScreen = 0; // 0: 기본, 1: 펀치, 2: 초음파, 3: 마리오
const int buzzerPin = 6; 

void playMarioTheme(); 
void showDefaultScreen();
void showEcho();
void playTone(int note, int duration);

void setup() {
  Serial.begin(9600);
  
  slave.begin(&Serial);
  slave.slave(1); 

  pinMode(LED, OUTPUT);
  pinMode(BT, INPUT);
  pinMode(RLED, OUTPUT);
  pinMode(GLED, OUTPUT);
  pinMode(BLED, OUTPUT);
  pinMode(Touch, INPUT);
  pinMode(Echopin, INPUT);
  pinMode(TrigPin, OUTPUT);
  pinMode(buzzerPin, OUTPUT); 

  slave.addCoil(0);    
  slave.addIsts(0);    
  slave.addHreg(0);    
  slave.addHreg(4);    
  slave.addHreg(5);    

  LCD.init();
  LCD.backlight();
  showDefaultScreen();
}

void loop() {
  slave.task();

  // ① 입력 처리
  bool isPressed = digitalRead(BT);
  slave.Ists(0, isPressed);

  int PotenPv = analogRead(Poten_);
  int tempPotenPv = map(PotenPv, 0, 1023, 0, 255);
  slave.Hreg(0, tempPotenPv);

  // -------------------------------------------------------------
  // ② LCD 화면 출력 주도권 로직 (중괄호 완전 정돈)
  // -------------------------------------------------------------
  if (isPressed) {
    // 1순위: 버튼이 눌렸을 때 (Punch! 화면)
    digitalWrite(LED, HIGH);
    if (currentScreen != 1) {
      LCD.clear();
      LCD.setCursor(0,0);
      LCD.print("Punch!");
      LCD.setCursor(0,1);
      LCD.print("@^_^--------@");
      currentScreen = 1;
    }
  } 
  else if (tempPotenPv >= 255) {
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
  // ③ 출력 제어 및 외부 기능 (모드버스 제어 포함)
  // -------------------------------------------------------------
  analogWrite(RLED, slave.Hreg(4));
  analogWrite(GLED, slave.Hreg(5));
  
  // 가변저항 값이 255일 때는 초음파 모드이므로 BLED 동작을 분리하거나 유지 가능
  analogWrite(BLED, slave.Hreg(0));

  // 터치센서 및 마리오 음악 가동
  playMarioTheme();

  delay(10); 
}

void playTone(int note, int duration) {
  digitalWrite(9, random(2));
  digitalWrite(10, random(2));
  digitalWrite(11, random(2));

  if (random(2) == 1) {
    LCD.backlight();   
  } else {
    LCD.noBacklight(); 
  }

  if (note == 0) {
    noTone(buzzerPin); 
  } else {
    tone(buzzerPin, note, duration); 
  }
  delay(duration * 1.30); 

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

    // 마리오 메인 테마 멜로디 연주
    playTone(NOTE_E7, 80); playTone(NOTE_E7, 80); playTone(0, 80); playTone(NOTE_E7, 80);
    playTone(0, 80); playTone(NOTE_C7, 80); playTone(NOTE_E7, 80); playTone(0, 80);
    playTone(NOTE_G7, 80); playTone(0, 240); playTone(NOTE_G6, 80); playTone(0, 240);
    
    playTone(NOTE_C7, 80); playTone(0, 160); playTone(NOTE_G6, 80); playTone(0, 160);
    playTone(NOTE_E6, 80); playTone(0, 160); playTone(NOTE_A6, 80); playTone(0, 80);
    playTone(NOTE_B6, 80); playTone(0, 80); playTone(NOTE_AS6, 80); playTone(NOTE_A6, 80);
    playTone(0, 80);
    
    playTone(NOTE_G6, 100); playTone(NOTE_E7, 100); playTone(NOTE_G7, 100); playTone(NOTE_A7, 80);
    playTone(0, 80); playTone(NOTE_F7, 80); playTone(NOTE_G7, 80); playTone(0, 80);
    playTone(NOTE_E7, 80); playTone(0, 80); playTone(NOTE_C7, 80); playTone(NOTE_D7, 80);
    playTone(NOTE_B6, 80); playTone(0, 160);

    noTone(buzzerPin); 
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