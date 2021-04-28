using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public GameObject bullet;
    public float timeBetweenShots = 200;
    private float nextShotTime;

    public void Shoot()
    {
        if(Time.time > nextShotTime)
        {
            nextShotTime = Time.time + timeBetweenShots / 1000;
            GameObject newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation) as GameObject;
            Destroy(newBullet, 3);
        }
        
    }

}
 