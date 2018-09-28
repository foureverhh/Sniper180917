using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeController : MonoBehaviour {

    public Animator animator;
    private int scopedHash = Animator.StringToHash("Scoped");
    private bool isScoped = false;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = ! isScoped;
            animator.SetBool(scopedHash,isScoped);
        }
    }
}
