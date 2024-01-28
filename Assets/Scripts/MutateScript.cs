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
            roombaController.setSpeed(speed + 1f * 3f);
            Debug.Log("mutated speed");
        }
        else if (mutation == "MoreHealth") {
            roomba.HP = 1000; 
        }
        roombaModel.GetComponent<SpriteRenderer>().sprite = roombaSprites[0];
        roombaArm1.GetComponent<SpriteRenderer>().enabled = true;
        roombaArm2.GetComponent<SpriteRenderer>().enabled = true;
        {
            
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
            case 1: 
                firstMutation += "MoveSpeed"; 
                secondMutation += "MoreHealth";
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
    public void FirstMutation() {
        switch (level) {
           case 1: 
             LevelOneMutants(firstMutation);
            break;  
        }
        
        firstButton.enabled = false; 
        Evolve.enabled = false;
    }
    public void SecondMutation() {
        switch(level) {
            case 1: 
              LevelOneMutants(secondMutation);
             break; 
        }
        
        secondButton.enabled = false; 
        Evolve.enabled = false;
    }
}
