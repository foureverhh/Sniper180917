using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeController : MonoBehaviour {

    public Animator animator;
    [HideInInspector]
    public int scopedHash = Animator.StringToHash("Scoped");
    [HideInInspector]
    public bool isScoped = false;
   
    public Camera mainCamera;
    public float scopedFieldOfView = 15f;
    [HideInInspector]
    public float normalFieldOfView;

    public GameObject scopeOverlay;
    public GameObject weaponCamera;

    ReloadBehavior reloadBehavior;

    private void Start()
    {
        animator = GetComponent<Animator>();
        reloadBehavior = animator.GetBehaviour<ReloadBehavior>();
        reloadBehavior.scopeController = this;
    }

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
        Debug.Log("isScoped in ScopeController is: " + isScoped);
    }

    void TurnOnScope()
    {
        StartCoroutine(ShowScope());
    }

     IEnumerator ShowScope()
    {
        yield return new WaitForSeconds(0.15f);
        normalFieldOfView = mainCamera.fieldOfView;
        Debug.Log(normalFieldOfView);
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
