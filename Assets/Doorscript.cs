using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorscript : MonoBehaviour, IInteractive {
    GameObject pivot;
  

    public bool busy;
    public float rotY;
    public float turnspeed;

    public bool state;  //open/closed state 0/1
    // Use this for initialization
    void Start () {
		pivot = transform.parent.gameObject;
        state = false;
        

	}
	
    //102 degrees is open
    //0 is closed

	// Update is called once per frame
	void Update () {
        rotY = pivot.transform.rotation.y;
	}

    public string prompt() {
        return "Open";
    }


    public void useractivate() {
        if (!busy)
        {
            busy = true;
            Debug.Log("activated");
            
            if (state)
            {
                StartCoroutine(Close());
            }
            else
            {
                //start coroutine
                StartCoroutine(Open());

            }
            state = !state;
        }
    }


    IEnumerator Open()
    {
        while (pivot.transform.rotation.y < 0.8)
        {
            pivot.transform.localEulerAngles += new Vector3(0, turnspeed, 0);              
            yield return new WaitForSecondsRealtime(0.017f);                   
        }
        pivot.transform.localEulerAngles = new Vector3(0,102,0);            //actual degree value to stop at
        busy = false;
    }

    IEnumerator Close()
    {
        while (pivot.transform.rotation.y > 0)
        {
            pivot.transform.localEulerAngles += new Vector3(0, -turnspeed, 0);
            yield return new WaitForSecondsRealtime(0.017f);                     // per 1/60
        }
        pivot.transform.localEulerAngles = new Vector3(0, 0, 0);
        busy = false;
    }

}
