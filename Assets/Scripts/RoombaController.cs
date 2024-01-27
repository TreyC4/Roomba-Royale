using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoombaController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 200f;
    
    public GameObject innerCircle; 

    public GameObject suction;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the circle based on input
        Vector3 moveDirection = new Vector3(0, verticalInput, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        
        innerCircle.transform.localPosition = transform.localPosition;  
        // Rotate the circle based on horizontal input
        if (horizontalInput != 0)
        {
            float rotationAmount = -horizontalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotationAmount);
        }
    
    }
    public void setSpeed(float speed) {
        moveSpeed += speed;
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("obstacle"))
    {
        // Calculate the backward direction based on the Roomba's current rotation
        Vector3 backwardDirection = -transform.up; // -transform.up gives the backward direction

        // Move the Roomba backwards
        transform.Translate(backwardDirection * moveSpeed * Time.deltaTime);
    }
    }
}
