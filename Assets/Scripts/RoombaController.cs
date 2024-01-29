using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoombaController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 200f;
    
    public GameObject innerCircle; 

    public GameObject suction;
    private Rigidbody2D rb;
    private bool dashUpgrade = false;
    private bool dashed = false; 

    private float timer; 
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
        Vector3 moveDirection = new Vector2(0, verticalInput);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        
        innerCircle.transform.localPosition = transform.localPosition;  
        // Rotate the circle based on horizontal input
        if (horizontalInput != 0)
        {
            float rotationAmount = -horizontalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotationAmount);
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("dashed");
            if (dashUpgrade & !dashed) {
                 
                dash();
                dashed = true;
                
                timer += Time.deltaTime;
        }
            
        }
        if (dashed) {
            Vector2 dashDirection = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
                                        Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad));
            
            timer += Time.deltaTime;
            transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y) + dashDirection * new Vector2(0, .1f), transform.position, .4f); 
        }
        
        if (timer > .1f) {
            dashed = false;
            timer = 0;
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
    void dash() {
        
    }
    public void upgradeDash() {
        dashUpgrade = true;
    }
}
