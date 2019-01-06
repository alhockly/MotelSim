using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemscripttemplate : MonoBehaviour {

    public bool busy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string prompt()
    {
        return "Turn on";
    }


    public void useractivate()
    {
        if (!busy)
        {
           
        }
    }
}
