using UnityEngine;
using System.Collections;
using System.IO.Ports; // Ports 

public class HandMovement : MonoBehaviour {

	int score = 0; 
	SerialPort sp = new SerialPort("/dev/cu.HC-06-DevB", 9600); // Accepts data from this serial port 
	// This data is of the form 
	// "<thumb-bend>,<index-bend>,<middle-bend>,<ring-bend>,<pinky-bend>" 

	// Use this for initialization
	void Start () {
		if (!sp.IsOpen) {

			sp.Open(); // Open the port 

		}
		sp.ReadTimeout = 250; // This is a universal value I've set across all scripts 
	}
	
	// Update is called once per frame
	void Update () {
		if (sp.IsOpen) {
			try {
				string portOutput = sp.ReadLine(); // get the string output of the serial port 
				string[] output_array = portOutput.Split(','); // 
				Debug.Log(output_array[0]); 
				Debug.Log(output_array[1]); 
				Debug.Log(output_array[2]); 
				Debug.Log(output_array[3]); 
				Debug.Log(output_array[4]);

			} catch (System.Exception) {
				// Do nothing 
			}
		}
	
	}
}
