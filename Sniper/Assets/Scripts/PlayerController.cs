using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private float horizontal = 0f;
    private float vertical = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("horizontal is " + horizontal);
        //Debug.Log("Vertical is " + vertical);
        horizontal += Input.GetAxis("Mouse X");
        vertical -= Input.GetAxis("Mouse Y");
        //transform.eulerAngles = new Vector3(0, horizontal * speed, 0.0f);

        //Debug.Log("horizontal is " + horizontal);
        //Debug.Log("Vertical is " + vertical);
        //transform.eulerAngles = new Vector3(horizontal, vertical, 0.0f);
        RifleMoveWithMouse();
      
        //transform.GetChild(0).LookAt(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));



        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Camera.main.transform.position.z));
    }

    void RifleMoveWithMouse()
    {
        //if(horizontal >-3 && horizontal < 3 &&
        //    vertical >= 0 && vertical <=75)
        if (horizontal < -3)
            horizontal = -3;
        if (horizontal > 3)
            horizontal = 3;
        if (vertical > 0)
            vertical = 0;
        if (vertical <= -4)
            vertical = -4;
        transform.eulerAngles = new Vector3(vertical * speed, horizontal * speed, 0.0f);
        //transform.Rotate(horizontal, vertical, 0.0f);
        //Debug.Log("horizontal is " + horizontal);
         Debug.Log("Vertical is " + vertical);

    
        

    }
}
