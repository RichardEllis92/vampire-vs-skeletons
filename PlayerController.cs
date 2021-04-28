using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 velocity;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PlayerVelocity(Vector3 playerVelocity)
    {
        velocity = playerVelocity;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    public void PlayerLookAt(Vector3 lookPoint)
    {
        Vector3 correctedLookPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(correctedLookPoint);
    }
}
