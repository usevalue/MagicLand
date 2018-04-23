//LED
const int ledPin = 13; //red cord with silver marks
int ledState = LOW;             // ledState used to set the LED
unsigned long previousMillis = 0;  // will store last time LED was updated
const long interval = 2000;        // interval at which to blink (ms)

//VIBRATION SENSOR SWITCH
const int vibPad = 8;     //reading vibration sensor, red cord without marks
//int vibState;             //holds our vibState

void setup() {
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);  //initialize digital pin as output (LED)
  pinMode(vibPad, INPUT_PULLUP);
}

void loop() {
  // vibState = digitalRead(vibPad);
  unsigned long currentMillis = millis();

  //circuit is set HIGH intially, going LOW when closed
  if (digitalRead(vibPad) == LOW) {
    Serial.write ((byte)0);
    Serial.flush();
    Serial.println(0);
    delay(20);
    ledState = HIGH;
  };

  if (currentMillis - previousMillis >= interval) {
    // save last time of LED blink
    previousMillis = currentMillis;
    // if the LED is on, turn it off after interval:
    if (ledState == HIGH) {
      ledState = LOW;
    } else {
      ledState = LOW;
    }
  }

  digitalWrite(ledPin, ledState);

  //if (digitalRead(vibPad) == HIGH) {
  // digitalWrite(led, LOW);   // turn the LED on (HIGH is the voltage level)
  // Serial.write (1);
  // Serial.flush();
  // delay(20);
  // }
}
