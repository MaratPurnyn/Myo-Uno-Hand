using UnityEngine;
using System.Collections;
using System.IO.Ports; // Ports 
using System.Collections.Generic; // Needed for Dict 
using UnityEngine.UI; // 

public class HandMovement : MonoBehaviour {

	// Set up a dictionary of values 
	Dictionary<int, string> fingers; 
	List<int> required_fingers; 

	// Text 
	public Text scoreText; // score text value 
	public Text requiredFingers; // THE FINGERS THAT TRIGGER THE GAME 
	private int score; // score 


	SerialPort sp = new SerialPort("/dev/cu.HC-06-DevB", 9600); // Accepts data from this serial port 
	// This data is of the form 
	// "<thumb-bend>,<index-bend>,<middle-bend>,<ring-bend>,<pinky-bend>" 

	// Use this for initialization
	void Start () {
		score = 0; // Initialize score to 0 
		scoreText.text = "Score " + score.ToString(); // Initialize GUI text 
		fingers = new Dictionary<int, string>(); 
		// Set up the dictionary from the start 
		fingers.Add(0, "Thumb");	
		fingers.Add(1, "Index"); 
		fingers.Add(2, "Middle"); 
		fingers.Add(3, "Ring");
		fingers.Add(4, "Pinky"); 
		required_fingers = new List<int>(); 
		// Set up the initial required_fingers 
		required_fingers.Add(0); // Add the thumb
		int rand = (int)Random.Range(1, 4);
		required_fingers.Add(rand); 

		requiredFingers.text = fingers[required_fingers[0]] + " and " + fingers[required_fingers[1]];

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

				int success = 0; 
				for(int i = 0; i < 5; i++) { 
					if(required_fingers.Contains(i)) {
						if(int.Parse(output_array[i]) < 45) { 
							break; // Hand in the wrong spot 
						} else {
							success++; 
						}
					} else {
						if(int.Parse(output_array[i]) >= 45) {
							break; // Hand in the wrong spot 
						} 
					}
				}
				if (success == 2) {
					// If you reach the end of this, then increment the score and change the text 
					this.score++; 
					this.scoreText.text = "Score: " + this.score.ToString(); 
					Debug.Log(this.scoreText.text); 
					this.required_fingers.RemoveAt(1); // Remove the last value
					this.required_fingers.Add((int)Random.Range(1, 4)); // Add the random value 
					this.requiredFingers.text = fingers[required_fingers[0]] + " and " + fingers[required_fingers[1]];
				}

			} catch (System.Exception) {
				// Do nothing 
			}
		}
	
	}
}
