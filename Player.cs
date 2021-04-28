using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float  moveSpeed = 5f;
    PlayerController controller;
    Rigidbody rb;
    Camera viewCamera;
    Gun gunScript;
    AudioSource audioSource;
    public GameObject deathExplosion;

    public AudioClip drop;

    [Range(1, 20)]
    public float knockbackPower = 5f;
    public int playerHealth = 3;
    void Start()
    {
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        gunScript = GetComponentInChildren<Gun>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        PlayerMovement();
        PlayerRaycasting();
        PlayerShooting();
        if (transform.position.y < -5)
            PlayerDeath();
    }

    private void PlayerShooting()
    {
        if (Input.GetMouseButton(0))
        {
            gunScript.Shoot();
        }
    }

    private void PlayerRaycasting()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            controller.PlayerLookAt(point);
        }
    }

    private void PlayerMovement()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),
                            0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.PlayerVelocity(moveVelocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 knockbackDirection = transform.position - collision.transform.position;
            rb.velocity = knockbackPower * knockbackDirection;
            audioSource.PlayOneShot(drop, 1);
            playerHealth--;

            if (playerHealth <= 0)
                PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        Instantiate(deathExplosion, transform.position, transform.rotation);
        Destroy(gameObject, 0.2f);
    }    
}
