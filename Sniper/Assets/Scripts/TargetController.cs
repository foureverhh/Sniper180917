using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

    //public GameObject capsuleTarget;
    //public GameObject sphereTarget;
    public Transform capsule;
    public Transform sphere;
    public float capsuleThrust;
    public float sphereThrust;

    private void Update()
    {
        //Instantiate(capsuleTarget,capsule.position,capsule.rotation);
        //Instantiate(capsuleTarget,sphere.position, sphere.rotation);
    }
    private void FixedUpdate()
    {
        //CapsuleMovment();
        //SphereMovement();
    }

    void CapsuleMovment()
    {
        Vector3 movement = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(0, 3.0f), Random.Range(0, 3.0f));
        //capsuleTarget.GetComponent<Rigidbody>().AddForce(movement * capsuleThrust * Time.fixedDeltaTime);
        transform.GetChild(0).GetComponent<Rigidbody>().AddForce(movement * capsuleThrust * Time.fixedDeltaTime);
        Debug.Log("transform.GetChild(0) is: "+ transform.GetChild(0).name);
    }

    void SphereMovement()
    {
        Vector3 movement = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(0, 3.0f), Random.Range(0, 3.0f));
        //sphereTarget.GetComponent<Rigidbody>().AddForce(movement * sphereThrust * Time.fixedDeltaTime);
        transform.GetChild(1).GetComponent<Rigidbody>().AddForce(movement * sphereThrust * Time.fixedDeltaTime);
    }
}
