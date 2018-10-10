using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform shootDirection;
    public float bulletSpeed = 100.0f;
    public float shootInterval = 3.0f;
    private float nextShoot;

    private bool scopeIsOn;
    private Animator animator;
    private int fireToHash = Animator.StringToHash("Fire");
    //private int reloadTimeToHash = Animator.StringToHash("ReloadTime");


    private void Start()
    {
        animator = transform.GetComponentInChildren<ScopeController>().animator;
    }

    private void Update()
    {
        //To check whether scope is on
        scopeIsOn = transform.GetComponentInChildren<ScopeController>().isScoped;
        
    }

    private void FixedUpdate()
    {
        ShootBullet();
    }

    void ShootBullet()
    {
        if (scopeIsOn && Input.GetButtonDown("Fire1") && Time.time > nextShoot)
        {
            nextShoot = Time.time + shootInterval;
            GameObject bullet = Instantiate(bulletPrefab, shootDirection.position, shootDirection.rotation);
            if (bullet != null)
                bullet.transform.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed );
            StartCoroutine(StartReloadAnimation());
            StartCoroutine(DestroyBullet(bullet));
        }
    }



    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(bullet);
    }



    IEnumerator StartReloadAnimation()
    {
        yield return new WaitForSeconds(1.0f);
        animator.SetTrigger(fireToHash);
        transform.GetComponentInChildren<ScopeController>().mainCamera.fieldOfView = 
            transform.GetComponentInChildren<ScopeController>().normalFieldOfView;
        transform.GetComponentInChildren<ScopeController>().scopeOverlay.SetActive(false);
        transform.GetComponentInChildren<ScopeController>().weaponCamera.SetActive(true);
    }

}
