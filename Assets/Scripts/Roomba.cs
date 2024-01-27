using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Roomba : MonoBehaviour
{
    public float HP = 100;
<<<<<<< HEAD
    private RoombaController roombaController;
    private MutateScript mutateController; 
    private float SPD;
    [SerializeField]
    private float XP;
    [SerializeField]
    private int level; 
    [SerializeField]
    private int levelFactor;
    void Start(){
        roombaController = GetComponent<RoombaController>();
        mutateController = GetComponent<MutateScript>();
        XP = 0;
        SPD = roombaController.moveSpeed;
    }
    void Update() {
=======

    private float SPD = RoombaController.moveSpeed;

    void Start(){
        print("SPD: " + SPD);
        
>>>>>>> parent of 5cd6377 (updated roomba class and added menu button)
    }
    
    public void takeDamage(float damageTaken){
        HP -= damageTaken;
        print("HP: " + HP);
    }
<<<<<<< HEAD
    void eat(float trashValue) {
        XP += trashValue;
        if (XP >= level * levelFactor) {
            level++; 
            XP = 0;
            mutateController.mutate(level);
        }
    }

    public float getXP() {
        return XP;
    }
=======

>>>>>>> parent of 5cd6377 (updated roomba class and added menu button)
}
