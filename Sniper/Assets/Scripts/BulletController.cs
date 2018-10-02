using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform shootDirection;
    public float bulletSpeed;
    public float shootInterval = 2.0f;
    private float nextShoot;
    private GameObject bullet;

    private void Update()
    {
        ShootBullet();
    }

    private void FixedUpdate()
    {
        if(bullet != null)
            bullet.transform.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        //bullet.transform.GetComponent<Rigidbody>().AddForce(new Vector3(shootDirection.position.x, shootDirection.position.y, 1.0f) * bulletSpeed);
        //bullet.transform.GetComponent<Rigidbody>().AddForce(shootDirection.position,x,shootDrection.y,1.0f * bulletSpeed);
        //bullet.transform.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        //bullet.transform.GetComponent<Rigidbody>().AddForce(Input.mousePosition * bulletSpeed);
        StartCoroutine(DestroyBullet(bullet));
    }
    void ShootBullet()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextShoot)
        {
            nextShoot = Time.time + shootInterval;
            createBullet();
        }
    }

    void createBullet()
    {
        bullet = Instantiate(bulletPrefab, shootDirection.position, shootDirection.rotation);
    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(bullet);
    }
}
