using UnityEngine;
using System.Collections;
using System.IO.Ports;  

public class indexfinger : finger {

	SerialPort sp = new SerialPort("/dev/cu.HC-06-DevB", 9600); // Accepts data from this serial port 


	// Use this for initialization
	void Start () {

		if (!sp.IsOpen) { // If the erial port is not open 

			sp.Open(); // Open 

		}
		sp.ReadTimeout = 250; // Timeout for reading 

	}
	// Initial position value 
	float amount = 0f; 

	// Update is called once per frame
	void Update () {

		if (sp.IsOpen) { // Check to see if the serial port is open 
			try {
				string portOutput = sp.ReadLine(); // get the string output of the serial port 
				// Since this is the index finger, controlled by 1 
				string[] output_array = portOutput.Split(','); 
				amount = int.Parse(output_array[1]);

				transform.localEulerAngles = new Vector3(amount, transform.localEulerAngles.y, transform.localEulerAngles.z);
			} catch (System.Exception) {
				// Do nothing if there is an exception
			}

		}

	}
}
