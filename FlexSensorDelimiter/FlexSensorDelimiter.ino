/* Arduino Flex Sensor Bend Tracking 
*  
* Split circuit involving a 2200 ohm resistor 
* Pins mapped to fingers
* Thumb is A0  
* Index is A1 
* Middle is A2 
* Ring is A3
* Pinky is A4 
* 
*/


int thumb = A0; // The flex sensor for pin 0 
int index = A1; // The flex sensor for pin 1
int middle = A2; // The flex sensor for pin 2 
int ring = A3; // The flex sensor for pin 3 
int pinky = A4; // The flex sensor for pin 4

// 90 == all the way bent 
// 0 == not bent at all 

// SETUP 
void setup() 
{
  Serial.begin(9600); // Start the serial transmission
}

// LOOP 
void loop() 
{
  // Reading the values from the analog 
  int thumbReading = analogRead(thumb);   // Flex sensor pin 0
  int indexReading = analogRead(index);   // Flex sensor pin 1
  int middleReading = analogRead(middle); // Flex sensor pin 2
  int ringReading = analogRead(ring);     // Flex sensor pin 3 
  int pinkyReading = analogRead(pinky);   // Flex sensor pin 4
  
  //Map the values to values between 0 and 90 degrees
  int thumbMapped = map(thumbReading, 30, 180, 90, 0);
  int indexMapped = map(indexReading, 30, 180, 90, 0);
  int middleMapped = map(middleReading, 30, 180, 90, 0);
  int ringMapped = map(ringReading, 30, 180, 90, 0); 
  int pinkyMapped = map(pinkyReading, 30, 180, 90, 0); 
  

  // Print values 
  Serial.print(thumbMapped); // A0  
  Serial.print(","); //delimiter
  Serial.print(indexMapped); // A1
  Serial.print(","); //delimiter
  Serial.print(middleMapped); // A2
  Serial.print(","); //delimiter
  Serial.print(ringMapped); // A3
  Serial.print(","); // delimiter 
  Serial.print(pinkyMapped); // A4
  Serial.println(","); // End of serial stream 

  // Delay 
  delay(25); // Slow the output so we can detect flexing more continuously 
    
}




