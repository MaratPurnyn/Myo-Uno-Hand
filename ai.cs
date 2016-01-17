using UnityEngine;
using System.Collections;
    // written by Jonatan Yanovsky 01/16/2016
    // used for ai opponent decision-making rock-paper-scissors game
public class ai : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    //enum possibleChoices {"Rock", "Paper", "Scissors"};
    string choice;
    int frames;
	// Update is called once per frame
	void Update () {
	

        frames = frames + 1;
        if (frames > 100)
        {
            frames=0;
            RPS();
        }
	}
    //public GameObject F1J2;
    //F1J2 = GameObject.Find("finger_index.02.L");

    public GameObject[] finger0;
    public GameObject[] finger1;
    public GameObject[] finger2;
    public GameObject[] finger3;
    public GameObject[] finger4;

    int whichOne;


    void RPS () {
        // finger 0 = thumb, finger 4 = pinky
        
        int caseNumber = Random.Range(0,3);
        whichOne=caseNumber;


        float[] fingers=new float[5];

        switch (caseNumber)
        {
            case 0:
                //rock
                choice = "Rock";
                for (int i = 0; i < 5; i++)
                    fingers[i] = 90f; //rotate each joint 90 degrees
                Debug.Log("R\n");
                break;
            case 1:
                //paper
                choice = "Paper";
                for (int i = 0; i < 5; i++)
                    fingers[i]=0f;
                Debug.Log("P\n");

                

                break;
            case 2:
                //scissors
                choice = "Scissors";
                for (int i = 0; i < 5; i++)
                {
                    if (i!=1 && i!=2)
                    fingers[i] = 90f;
                    else
                    fingers[i]=0f;
                }
                Debug.Log("S\n");
                break;
            default:
                //?? rock
                choice = "Rock";
                for (int i = 0; i < 5; i++)
                    fingers[i] = 90f;
                Debug.Log("R_unknown\n");
                break;
        }

        //now set degrees for one finger at a time, based on tags. Sets  degrees for gameObjects

        finger0 = GameObject.FindGameObjectsWithTag("finger 0");
        finger1 = GameObject.FindGameObjectsWithTag("finger 1");
        finger2 = GameObject.FindGameObjectsWithTag("finger 2");
        finger3 = GameObject.FindGameObjectsWithTag("finger 3");
        finger4 = GameObject.FindGameObjectsWithTag("finger 4");


        foreach (GameObject joint in finger0)
        {
            joint.GetComponent<finger>().setDegrees(fingers[0]);
        }

        foreach (GameObject joint in finger1)
        {
            joint.GetComponent<finger>().setDegrees(fingers[1]);
        }

        foreach (GameObject joint in finger2)
        {
            joint.GetComponent<finger>().setDegrees(fingers[2]);
        }

        foreach (GameObject joint in finger3)
        {
            joint.GetComponent<finger>().setDegrees(fingers[3]);
        }

        foreach (GameObject joint in finger4)
        {
            joint.GetComponent<finger>().setDegrees(fingers[4]);
        }
    }

    public int getCase () {

        return whichOne;
    }

}
