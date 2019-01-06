using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {


    Rigidbody rb;
    public bool canjump;
    public float movespeed;
    public Camera cam;
    Collider collider2;
    public float jumpheight;
    public float groundoffset;
    public bool paused;
    public GameObject pausemenu;
	// Use this for initialization
	void Start () {
        paused = false;
        rb = GetComponent<Rigidbody>();
        canjump = false;
        collider2 = GetComponent<Collider>();
        pausemenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (paused)
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0;
            //debug
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            pausemenu.SetActive(false);
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
		float verticalMovement = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;

        Vector3 yVelFix = new Vector3(0, rb.velocity.y, 0);
        rb.velocity=(moveDirection * movespeed*Time.deltaTime);
        rb.velocity += yVelFix;

        canjump = isgrounded();

        if (canjump && Input.GetKey(KeyCode.Space)) {
            rb.AddForce(new Vector3(0, jumpheight, 0));

        }

        
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            paused = !paused;
        }
    }

    bool isgrounded() {
        float half = collider2.bounds.size.y;
        return Physics.Raycast(transform.position, -Vector3.up, half + groundoffset/100);
    }
}
