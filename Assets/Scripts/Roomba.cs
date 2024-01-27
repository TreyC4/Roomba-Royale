using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Roomba : MonoBehaviour
{
    public float HP = 100;

    private float SPD = RoombaController.moveSpeed;
    
    private float score = 0;

    void Start(){
        print("SPD: " + SPD);
        
    }
    
    public void takeDamage(float damageTaken){
        HP -= damageTaken;
        print("HP: " + HP);
    }

    public void gainPoints(float points){
        score += points;
        print("Total Points: " + score);
    }
}
