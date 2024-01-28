using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Roomba roomba;
    
    private float damageTaken = 5;
    
    void Start() {
    }
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("roomba")) {
            roomba.takeDamage(damageTaken);
            print("hit");
        }
    }
}
