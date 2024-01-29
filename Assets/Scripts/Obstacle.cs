using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Roomba roomba;
    
    private float damageTaken = 5;
    
    private Color tempColor; 
    
    private bool collided; 

    private float timer; 
    void Start() {
        roomba = GameObject.Find("roombap1").GetComponent<Roomba>();
        tempColor = roomba.GetComponent<Renderer>().material.GetColor("_Color");
    }
    void Update() {
        if (collided) {
            roomba.transform.position = Vector2.Lerp(new Vector2(roomba.transform.position.x, roomba.transform.position.y - .1f), roomba.transform.position, .4f);
            timer += Time.deltaTime; 
        }
        if (timer > .1f) {
            collided = false; 
            timer = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("roomba")) {
            collided = true;
            
            other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            roomba.takeDamage(damageTaken);
            print("hit");
        }
    } 
    private void OnCollisionExit2D(Collision2D other) {
        other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", tempColor); 
    }
}
