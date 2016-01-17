/* Arduino Flex Sensor Bend Tracking 
*  
* Split circuit involving a 2200 ohm resistor 
* Flex sensor pin A0 
*/


int flexSensorPin = A0; // The flex sensor is pin 0 

// 100 == all the way bent 
// 0 == not bent at all 

// SETUP 
void setup() 
{
  Serial.begin(9600); // Start the serial transmission 
}

// LOOP 
void loop() 
{
  int flexSensorReading = analogRead(flexSensorPin); // Flex sensor pin 

  // Serial.println(flexSensorReading); // Print out the raw reading 

  // Remap the raw flex-sensor value to a new value 
  int flex0to100 = map(flexSensorReading, 30, 180, 90, 0); 
  Serial.println(flex0to100); // Print out this new value 

  delay(25); // Slow the output so we can detect flexing more continuously 

    
}





