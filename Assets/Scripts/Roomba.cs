using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Roomba : MonoBehaviour
{
    public float HP = 100;
    private RoombaController roombaController;
    private MutateScript mutateController; 
    private float SPD;
    [SerializeField]
    private float XP;
    [SerializeField]
    private int level; 
    [SerializeField]
    private int levelFactor;
    [SerializeField] private Canvas Evolve;
    void Start(){
        roombaController = GetComponent<RoombaController>();
        mutateController = Evolve.GetComponent<MutateScript>();
        XP = 0;
        SPD = roombaController.moveSpeed;
    }
    void Update() {
    }
    
    public void takeDamage(float damageTaken){
        HP -= damageTaken;
        print("HP: " + HP);
    }
    public void eat(float trashValue) {
        XP += trashValue;
        if (XP >= level * levelFactor) {
            level++; 
            XP = 0;
            Evolve.enabled = true;
            mutateController.mutate(level);
        }
    }
    public float getXP() {
        return XP;
    }

}
