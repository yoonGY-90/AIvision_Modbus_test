#include <Arduino.h>
#include <ModbusRTU.h> // 헤더 파일 이름을 올바르게 수정했습니다!

ModbusRTU slave; // 슬레이브 객체 생성

#define LED 13
#define BT 8
#define Poten_ A0
#define RLED 9
#define GLED 10
#define BLED 11

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

  // 4. 모드버스 주소(방) 개설하기
  slave.addCoil(0);    // Coils 0번 (QModBus 주소: 0) -> 13번 LED용
  slave.addIsts(0);    // Discrete Input 0번 (QModBus 주소: 10001 또는 0) -> 버튼용
  
  slave.addHreg(0);    // Holding Register 0번 (QModBus 주소: 40001 또는 0) -> 가변저항용
  slave.addHreg(4);    // Holding Register 4번 (QModBus 주소: 40005 또는 4) -> RLED용
  slave.addHreg(5);    // Holding Register 5번 (QModBus 주소: 40006 또는 5) -> GLED용
}

void loop() {
  // 모드버스 통신 가동 (PC 명령 처리)
  slave.task();

  // -------------------------------------------------------------
  // ① 입력: 아두이노 -> PC (Master)
  // -------------------------------------------------------------
  // 버튼 상태를 읽어서 Discrete Input 0번에 저장
  slave.Ists(0, digitalRead(BT));
  digitalWrite(LED, slave.Ists(0));

  // 가변저항 값을 읽어서 0~255로 압축한 뒤 Holding Register 0번에 저장
  int PotenPv = analogRead(Poten_);
  int tempPotenPv = map(PotenPv, 0, 1023, 0, 255);
  slave.Hreg(0, tempPotenPv);

  // -------------------------------------------------------------
  // ② 출력: PC (Master) -> 아두이노 제어
  // -------------------------------------------------------------
  // PC가 Coils 0번에 쓴 값(true/false)으로 13번 LED 켜고 끄기
  
  // PC가 Holding Register 4번, 5번에 쓴 값(0~255)으로 R, G LED 밝기 조절
  analogWrite(RLED, slave.Hreg(4));
  analogWrite(GLED, slave.Hreg(5));

  // BLED는 가변저항 값(Hreg 0번)으로 직접 밝기 조절
  analogWrite(BLED, slave.Hreg(0));

  delay(10); // 통신 안정성을 위한 아주 잠깐의 쉬는 시간
}