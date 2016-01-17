/* Arduino Flex Sensor Bend Tracking 
*  
* Split circuit involving a 2200 ohm resistor 
* Flex sensor pin A0 
*/


int flexSensorPin = A0; // The flex sensor for pin 0 
int flexSensorPin2 = A1; // The flex sensor for pin 1
int flexSensorPin3 = A2; // The flex sensor for pin 2 

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
  // Reading the values from the analog 
  int flexSensorReading = analogRead(flexSensorPin); // Flex sensor pin 
  int flexSensorReading2 = analogRead(flexSensorPin2); // Flex sensor pin 2
  int flexSensorReading3 = analogRead(flexSensorPin3); // Flex sensor pin 3
  // Serial.println(flexSensorReading); // Print out the raw reading

  //Map the values
  int flexSensorMapped
  int flexSensorMapped2
  int flexSensorMapped3

  // Print values 
  Serial.print(flexSensorReading); // A0  
  Serial.print(","); //delimiter
  Serial.print(flexSensorReading2); // A1
  Serial.print(","); //delimiter
  Serial.print(flexSensorReading3); // A2
  Serial.println(","); //delimiter

  // Delay 
  delay(25); // Slow the output so we can detect flexing more continuously 
    
}





