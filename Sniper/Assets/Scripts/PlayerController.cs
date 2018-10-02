using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private float horizontal = 0f;
    private float vertical = 0f;

	// Update is called once per frame
	void Update () {   
        horizontal += Input.GetAxis("Mouse X");
        vertical -= Input.GetAxis("Mouse Y"); 
        RifleMoveWithMouse();
    }

    void RifleMoveWithMouse()
    {
        if (horizontal < -3)
            horizontal = -3;
        if (horizontal > 3)
            horizontal = 3;
        if (vertical > 0)
            vertical = 0;
        if (vertical <= -4)
            vertical = -4;
        transform.eulerAngles = new Vector3(vertical * speed, horizontal * speed, 0.0f);
    }
}
