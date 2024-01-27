using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Roomba : MonoBehaviour
{
    public float HP = 100;
    private RoombaController roombaController;
    private float SPD;
    [SerializeField]
    private float XP;
    [SerializeField]
    private int level; 
    [SerializeField]
    private int levelFactor;
    void Start(){
        roombaController = GetComponent<RoombaController>();
        XP = 0;
        SPD = roombaController.moveSpeed;
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
        switch (level) {
            case 1: 
                break; 
            case 2: 
                break; 
            case 3: 
                break; 
            case 4: 
                break; 
            case 5: 
                break; 
        }
    }
    public float getXP() {
        return XP;
    }
}
