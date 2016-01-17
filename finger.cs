using UnityEngine;
using System.Collections;
    // written by Jonatan Yanovsky 01/16/2016
    // rotates ai opponent's fingers to simulate rock-paper-scissors game
public class finger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    //public float turnAmount = 90.0f;
    float amount = 0f;
	// Update is called once per frame, and smoothly turns finger toward goal

    void Update () {
        
        if (amount <= degrees)
            amount = amount + 2f;
        if (amount >= degrees)
            amount = amount - 2f;


        transform.localEulerAngles = new Vector3(amount, transform.localEulerAngles.y, transform.localEulerAngles.z);
	}

    private float degrees; // end goal to rotate towards

    public float getDegrees() {
        

        return degrees;
    }

    public void setDegrees(float deg) {

        degrees = deg;
    }

}
