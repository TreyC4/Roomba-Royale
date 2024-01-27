using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        roombaController = GetComponent<RoombaController>();
        roomba = GetComponent<Roomba>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LevelOneMutants(string mutation) {
        if (mutation == "MoveSpeed") {
            roombaController.setSpeed(speed);
        }
        else if (mutation == "MoreHealth") {
            roomba.HP = 1000; 
        }
    }
    public void mutate(int mutateLevel) {
        level = mutateLevel;
        firstButton.enabled = true;
        secondButton.enabled = true;
        switch (level) {
            case 1: 
                firstMutation = "MoveSpeed"; 
                secondMutation = "MoreHealth";
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
    void FirstMutation() {
        
    }
    void SecondMutation() {

    }
}
