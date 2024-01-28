using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Roomba roomba;
    
    private float damageTaken = 5;
    
    void Start() {
        roomba = GameObject.Find("roombap1").GetComponent<Roomba>();
    }
    void Update() {

    }
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("roomba")) {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1));
            roomba.takeDamage(damageTaken);
            print("hit");
        }
    }
}
