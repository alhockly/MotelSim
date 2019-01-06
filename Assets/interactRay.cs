using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script so that the player can click or press E on an object make it do a thing
//Every object that the player can interact with must implement the IInteractive interface and have the Interactive tag


public class interactRay : MonoBehaviour {
    public Camera cam;
    public float reach;
    public bool showprompt;
    public string prompttext;
  

	// Use this for initialization
	void Start () {
        showprompt = false;
        

    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(cam.transform.position, cam.transform.forward,Color.red,0,true);

        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out hit, reach)) {

            GameObject hitobj = hit.collider.gameObject;

            if (hitobj.tag.Equals("Interactive"))                 
            {
                showprompt = true;
               
                
                    prompttext = hitobj.GetComponent<IInteractive>().prompt();
                    if (Input.GetKey(KeyCode.E) || Input.GetMouseButtonDown(0))
                    {
                        hitobj.GetComponent<IInteractive>().useractivate();
                    }
                

            }
            else {
                showprompt = false;
            }


        }
        else {
            showprompt = false;
        }
      
    }
}
