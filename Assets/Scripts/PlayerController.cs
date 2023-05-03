using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput; // Horizontal input from the player
    public float speed = 10.0f; // Speed of the player
    public float xRange = 10.0f; // 10 units to the left and 10 units to the right

    public GameObject projectilePrefab; // Drag the projectile prefab into this field in the inspector

    // Rate variables
    private float fireRate = 1;
    private float nextFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Move the player left and right
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Keep the player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Launch a projectile from the player
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
