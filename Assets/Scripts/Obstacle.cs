using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Roomba roomba;

    private float damageTaken = 5;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("roomba")){
            roomba.takeDamage(damageTaken);
            print("hit");
        }
    }
}
