using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [SerializeField] Transform bulletEmitter;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float bulletSpeed = 10f;

    private void Update()
    {
        fireBullet();
    }
    public void fireBullet()
    {
        GameObject bullet = Instantiate(ballPrefab, bulletEmitter.position, bulletEmitter.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletEmitter.forward * bulletSpeed;

        /* if (Input.GetKeyDown(KeyCode.Space))
         {
             GameObject bullet = Instantiate(ballPrefab, bulletEmitter.position, bulletEmitter.rotation);
             bullet.GetComponent<Rigidbody>().velocity = bulletEmitter.forward * bulletSpeed;
         }
         else if (Input.GetKeyDown(KeyCode.LeftShift))
         {

         }*/
    }
}
