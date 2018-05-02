// HARDWARE
const int ledPin = 13; //red cord with silver marks
const int vibPad = 8;     //reading vibration sensor, red cord without marks
int ledState = LOW;             // ledState used to set the LED

// CLOCK - same concept as other, name and values tweaked
unsigned long lastTic = 0;
const long interval = 200; // Sampling rate
byte counter; // Counts player movement

void setup() {
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);  //initialize digital pin as output (LED)
  pinMode(vibPad, INPUT_PULLUP);
}

void loop() {
  
  unsigned long currentMillis = millis();
  
  if(counter<250) {   // Count the triggers, but don't go above the size of one byte.
      if (digitalRead(vibPad) == LOW) counter++;
  }

  if (currentMillis - lastTic >= interval){
    Serial.write (counter); // Tell Homunculous how quickly the wand is moving
    Serial.flush();
    Serial.println(0);
    if(counter>10) { // If the wand has been moving quickly
      ledState = HIGH;
    }
    else ledState = LOW;
    counter = 0;
    lastTic = currentMillis;
  }
  
  digitalWrite(ledPin, ledState);
}
