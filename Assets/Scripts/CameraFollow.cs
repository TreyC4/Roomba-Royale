using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Set the camera's position to match the player's position, but keep the same z-axis position
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
