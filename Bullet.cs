using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Enemy enemyScript;

    public float speed = 10;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemyScript = other.GetComponent<Enemy>();
            enemyScript.DamageDone();
            Destroy(this.gameObject);
        }
    }
}
