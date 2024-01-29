using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    private bool extendUpgrade = false; 
    private bool extended = false;
    [SerializeField] private GameObject tongue; 
    
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
        
        if (innerCircle != null) {
            innerCircle.transform.localPosition = transform.localPosition;  
        }
        
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
            else if (extendUpgrade & !extended) {
                tongue.SetActive(true);
                extended = true;
            }
       
            
        }
        if (dashed) {
            Vector2 dashDirection = new Vector2(Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
                                        Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad));
            
            timer += Time.deltaTime;
            transform.position = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y) + dashDirection * new Vector2(0, .4f), transform.position, .4f); 
        }
        if (extended) {
            timer += Time.deltaTime;
        }
        
        if (timer > .4f) {
            dashed = false;
            extended = false;
            tongue.SetActive(false);
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
    public void upgradeExtend() {
        extendUpgrade = true;
        transform.GetChild(4).GetComponent<SpriteRenderer>().enabled = true; 
    }
}
