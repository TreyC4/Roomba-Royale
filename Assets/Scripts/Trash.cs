using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] private Roomba roomba;

    private float points = 25;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("roomba")){
            roomba.gainPoints(points);
            print("got " + points + " points");
            Destroy(gameObject);
        }
    }
}