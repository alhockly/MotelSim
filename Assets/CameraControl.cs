using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public Camera cam;
    public GameObject player;
    PlayerControl playercontrol;
    public float minX = -60f;
    public float maxX = 60f;
    public float minY = -360f;
    public float maxY = 360f;

    public float sensitivityX = 15f;
    public float sensitivityY = 15f;

    float rotationY = 0f;
    float rotationX = 0f;
    // Use this for initialization
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        playercontrol = player.GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update() {
        if (!playercontrol.paused)
        {
            rotationY += Input.GetAxis("Mouse X") * sensitivityY;
            rotationX += Input.GetAxis("Mouse Y") * sensitivityX;
            rotationX = Mathf.Clamp(rotationX, minX, maxX);


            transform.localEulerAngles = new Vector3(0, rotationY, 0);
            cam.transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);

           
        }


	}
}
