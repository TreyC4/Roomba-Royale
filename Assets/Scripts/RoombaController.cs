using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    
    public GameObject innerCircle; 

    public GameObject suction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the circle based on input
        Vector3 moveDirection = new Vector3(0, verticalInput, 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        innerCircle.transform.localPosition = transform.localPosition - new Vector3(0, 0.1f, 0); 
        suction.transform.SetLocalPositionAndRotation(transform.localPosition - new Vector3(0, 1f, 0), transform.localRotation); 
        // Rotate the circle based on horizontal input
        if (horizontalInput != 0)
        {
            float rotationAmount = -horizontalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotationAmount);
        }
    }
}
