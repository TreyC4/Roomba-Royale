using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Roomba : MonoBehaviour
{
    public float HP = 100;

    private float SPD = RoombaController.moveSpeed;
    [SerializeField]
    private float XP;
    [SerializeField]
    private int level; 
    [SerializeField]
    private int levelFactor;
    void Start(){
        print("SPD: " + SPD);
        XP = 0;
    }
    void Update() {
    }
    public void takeDamage(float damageTaken){
        HP -= damageTaken;
        print("HP: " + HP);
    }
    void eat(float trashValue) {
        XP += trashValue;
        if (XP >= level * levelFactor) {
            level++; 
            XP = 0;
            mutate();
        }
    }
    void mutate() {
        
    }
    public float getXP() {
        return XP;
    }
}
