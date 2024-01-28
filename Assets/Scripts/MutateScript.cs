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
    [SerializeField] private Canvas Evolve; 
    // Start is called before the first frame update
    void Start()
    {
        roombaController = GameObject.Find("roombap1").GetComponent<RoombaController>();
        roomba = GameObject.Find("roombap1").GetComponent<Roomba>();
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
        LevelOneMutants(firstMutation);
        firstButton.enabled = false; 
        Evolve.enabled = false;
    }
    public void SecondMutation() {
        LevelOneMutants(secondMutation);
        secondButton.enabled = false; 
        Evolve.enabled = false;
    }
}
