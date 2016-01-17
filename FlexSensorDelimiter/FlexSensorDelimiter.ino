/* Arduino Flex Sensor Bend Tracking 
*  
* Split circuit involving a 2200 ohm resistor 
* Flex sensor pin A0 
*/


int flexSensorPin = A0; // The flex sensor for pin 0 
int flexSensorPin2 = A1; // The flex sensor for pin 1
int flexSensorPin3 = A2; // The flex sensor for pin 2 

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
  int flexSensorReading = analogRead(flexSensorPin); // Flex sensor pin 
  int flexSensorReading2 = analogRead(flexSensorPin2); // Flex sensor pin 2
  int flexSensorReading3 = analogRead(flexSensorPin3); // Flex sensor pin 3
  // Serial.println(flexSensorReading); // Print out the raw reading

  //Map the values to values between 0 and 90 degrees
  int flexSensorMapped = map(flexSensorReading, 30, 180, 90, 0);
  int flexSensorMapped2 = map(flexSensorReading2, 30, 180, 90, 0);
  int flexSensorMapped3 = map(flexSensorReading3, 30, 180, 90, 0);

  // Print values 
  Serial.print(flexSensorMapped); // A0  
  Serial.print(","); //delimiter
  Serial.print(flexSensorMapped2); // A1
  Serial.print(","); //delimiter
  Serial.print(flexSensorMapped3); // A2
  Serial.println(","); //delimiter

  // Delay 
  delay(25); // Slow the output so we can detect flexing more continuously 
    
}





