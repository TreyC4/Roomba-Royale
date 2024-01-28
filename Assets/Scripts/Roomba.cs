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
    private XPScript xpScript; 
    private float SPD;
    [SerializeField]
    private int XP;
    [SerializeField]
    private int level; 
    [SerializeField]
    private int levelFactor;
    [SerializeField] private Canvas Evolve;
          private int XPCap;
    void Start(){
        roombaController = GetComponent<RoombaController>();
        mutateController = Evolve.GetComponent<MutateScript>();
        xpScript = GameObject.Find("XP").GetComponent<XPScript>();
        XP = 0;
        SPD = roombaController.moveSpeed;
    }
    void Update() {
    }
    
    public void takeDamage(float damageTaken){
        HP -= damageTaken;
        print("HP: " + HP);
    }
    public void eat(int trashValue) {
        XP += trashValue;
        XPCap = level * levelFactor + 1; 
        print(XP); 
        print(XPCap);
        print((float)XP / XPCap);
        xpScript.UpdateXPBar((float)XP / XPCap);
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
