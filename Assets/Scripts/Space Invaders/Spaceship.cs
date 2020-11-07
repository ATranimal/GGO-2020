using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10;
    [SerializeField] float padding = 0.2f;
    [SerializeField] GameObject mochiProjectile;
    [SerializeField] float fireRate = 0.1f;

    float xRange, yRange;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PreventOutOfBounds();

        // Hold space to shoot continuously
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Shoot", 0, fireRate);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Shoot");
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector2.right * horizontalInput * movementSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * verticalInput * movementSpeed * Time.deltaTime);
    }

    private void SetUpMoveBoundaries()
    {
        // Set range relative to the camera
        xRange = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, -10)).x - padding;
        yRange = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, -10)).y - padding;
    }

    private void PreventOutOfBounds()
    {
        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(transform.position.x, yRange);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
    }

    private void Shoot()
    {
        Instantiate(mochiProjectile, transform.position, mochiProjectile.transform.rotation);
    }
}
