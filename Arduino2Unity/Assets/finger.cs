using UnityEngine;
using System.Collections;
using System.IO.Ports; 


public class finger : MonoBehaviour {

    public float currentPosition;
    SerialPort sp = new SerialPort("/dev/cu.usbmodem1411", 9600);


	// Use this for initialization
	void Start () {
        
        if (!sp.IsOpen) {
            
            sp.Open(); // Open the serial port 
        }
        sp.ReadTimeout = 1; 
	}

    //public float turnAmount = 90.0f
    float amount = 0f;
	// Update is called once per frame
    void Update () {

        if (sp.IsOpen)
        {
            try
            {
                amount = int.Parse(sp.ReadLine()); // Reading the value from the arduino 
                string amountString = amount.ToString();
                Debug.Log(amountString);
                
                transform.localEulerAngles = new Vector3(amount, transform.localEulerAngles.y, transform.localEulerAngles.z);
            } catch (System.Exception)
            {
                // Don't do anything
            }
        }
        // if (amount <=90)
            // amount = amount + 1f;

            
        
	}
}
