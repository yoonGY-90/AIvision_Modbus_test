#include <Arduino.h>
#include <Servo.h>

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

Servo myservo;
const int buzzerPin = 6; // 6번 핀에 부저가 연결됨

void button();
void playMarioTheme(); // 부저 연주 함수 이름 변경 (중복 회피)

void setup() {
  pinMode(13, OUTPUT);
  pinMode(9, OUTPUT);
  pinMode(10, OUTPUT);
  pinMode(11, OUTPUT);
  pinMode(8, INPUT);
  pinMode(7, INPUT);
  pinMode(buzzerPin, OUTPUT); // 부저 핀을 출력으로 설정
  Serial.begin(9600);
  myservo.attach(3);
  
}

void loop() {
  //시리얼버퍼에 데이터 유무 확인
  if(Serial.available()) {
  char temp=Serial.read();
  if(temp=='a')
  {
  digitalWrite(13, HIGH);
  }
  if(temp=='b')
  {
  digitalWrite(13, LOW);
  }
    if(temp=='c')
  {
  digitalWrite(9, HIGH);
  }
  if(temp=='d')
  {
  digitalWrite(9, LOW);
  }
    if(temp=='e')
  {
  digitalWrite(10, HIGH);
  }
  if(temp=='f')
  {
  digitalWrite(10, LOW);
  }
    if(temp=='g')
  {
  digitalWrite(11, HIGH);
  }
  if(temp=='h')
  {
  digitalWrite(11, LOW);
  }
  }

  button();
  playMarioTheme();
}

void button() {
  if(digitalRead(8) == HIGH) {
    myservo.write(0);
    delay(300);
    myservo.write(45);
    delay(300);
    myservo.write(90);
    delay(300);
    myservo.write(135);
    delay(300);
    myservo.write(180);
    delay(300);
  } 
}

void playTone(int note, int duration) {
  // [추가] 소리가 날 때 9, 10, 11번 LED를 랜덤하게 켭니다 (HIGH 또는 LOW)
  // random(2)는 0(LOW) 또는 1(HIGH)을 무작위로 뽑아줍니다.
  digitalWrite(9, random(2));
  digitalWrite(10, random(2));
  digitalWrite(11, random(2));
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
}

void playMarioTheme() {
  if(digitalRead(7) == HIGH) {
    
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

    noTone(buzzerPin); // 연주가 끝나면 확실하게 부저를 꺼줍니다.
    delay(2000);       // 연주 끝나고 폭풍 연타 방지를 위해 2초 쉼표

    digitalWrite(9, LOW);
    digitalWrite(10, LOW);
    digitalWrite(11, LOW);

    delay(2000);       // 2초 대기
  }
}