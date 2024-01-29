using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class MutateScript : MonoBehaviour
{
    [SerializeField] 
    private Button firstButton; 
    [SerializeField] 
    private Button secondButton; 
    private int level; 
    private RoombaController roombaController;
    private Roomba roomba; 
    private float speed; 
    private string firstMutation; 
    private string secondMutation;
    private GameObject roombaModel;
    [SerializeField] private Canvas Evolve; 
    public Sprite[] roombaSprites; 

    private GameObject roombaArm1; 
    private GameObject roombaArm2; 
    // Start is called before the first frame update
    void Start()
    {
        roombaController = GameObject.Find("roombap1").GetComponent<RoombaController>();
        roombaModel = GameObject.Find("roombap1");
        roombaArm1 = roombaModel.transform.GetChild(2).gameObject;
        roombaArm2 = roombaModel.transform.GetChild(3).gameObject; 
        roomba = roombaModel.GetComponent<Roomba>();
        Evolve.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LevelOneMutants(string mutation) {
        if (mutation == "MoveSpeed") {
            roombaController.setSpeed(speed + 1f * 1.5f);
            Debug.Log("mutated speed");
        }
        else if (mutation == "MoreHealth") {
            roomba.HP = 400; 
        }
        roombaModel.GetComponent<SpriteRenderer>().sprite = roombaSprites[0];
        roombaArm1.GetComponent<SpriteRenderer>().enabled = true;
        roombaArm2.GetComponent<SpriteRenderer>().enabled = true;
        Destroy(GameObject.Find("face"));
        {
            
        }
    }
    void LevelTwoMutants(string mutation) {
        if (mutation == "Dash") {
            roombaController.upgradeDash();
        }
        else if (mutation == "Extend") {
            roombaController.upgradeExtend();
        }
        roombaModel.GetComponent<SpriteRenderer>().sprite = roombaSprites[1];
    }
    void LevelThreeMutants(string mutation) {
        
       roombaModel.GetComponent<SpriteRenderer>().sprite = roombaSprites[2]; 
       
       
       if (mutation == "MoveSpeed") {
        roombaController.setSpeed(speed + 1f * 3f);
       }
       else if (mutation == "MoreHealth") {
        roomba.HP = 1000; 
       }
    }
    public void mutate(int mutateLevel) {
        level = mutateLevel;
        Evolve.enabled = true;
        firstMutation = "";
        secondMutation = "";
        firstButton.enabled = true;
        secondButton.enabled = true;
        switch (level) {
            case 2: 
                firstMutation += "MoveSpeed"; 
                secondMutation += "MoreHealth";
                break; 
            case 3: 
                firstMutation += "Dash"; 
                secondMutation += "Extend";
                break; 
            case 4: 
                break; 
        }
    }
    public void FirstMutation() {
        switch (level) {
           case 2: 
             LevelOneMutants(firstMutation);
            break;  
           case 3: 
             LevelTwoMutants(firstMutation); 
            break;
           case 4: 
            LevelThreeMutants("MoveSpeed");
             break;

        }
        
        firstButton.enabled = false; 
        Evolve.enabled = false;
    }
    public void SecondMutation() {
        switch(level) {
            case 2: 
              LevelOneMutants(secondMutation);
             break; 
            case 3: 
              LevelTwoMutants(secondMutation);
             break;
            case 4:
              LevelThreeMutants("MoreHealth");
             break;
        }
        
        secondButton.enabled = false; 
        Evolve.enabled = false;
    }
}
