using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeController : MonoBehaviour {

    public Animator animator;
    private int scopedHash = Animator.StringToHash("Scoped");
    private bool isScoped = false;
   
    public Camera mainCamera;
    public float scopedFieldOfView = 15f;
    private float normalFieldOfView;

    public GameObject scopeOverlay;
    public GameObject weaponCamera;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = ! isScoped;
            animator.SetBool(scopedHash,isScoped);

            if (isScoped)
                TurnOnScope();
            else
                TurnOffScope();
        }
    }

    void TurnOnScope()
    {
        StartCoroutine(ShowScope());
    }

     IEnumerator ShowScope()
    {
        yield return new WaitForSeconds(0.15f);
        normalFieldOfView = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFieldOfView;
        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);
    }

    void TurnOffScope()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);
        mainCamera.fieldOfView = normalFieldOfView;
    }
}
