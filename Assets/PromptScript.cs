using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptScript : MonoBehaviour {

    public GameObject player;
    interactRay playerinteract;
    Text prompttext;
    // Use this for initialization
    void Start () {
		 playerinteract = player.GetComponent<interactRay>();
         prompttext = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerinteract.showprompt)
        {
            prompttext.text = playerinteract.prompttext;


        }
        else {
            prompttext.text = "";
        }
	}
}
