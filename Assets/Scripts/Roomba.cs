using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
    private LeaderboardScript leaderboard; 
    private int score; 

    void Start(){
        roombaController = GetComponent<RoombaController>();
        mutateController = Evolve.GetComponent<MutateScript>();
        leaderboard = GetComponent<LeaderboardScript>();
        xpScript = GameObject.Find("XP").GetComponent<XPScript>();
        XP = 0;
        SPD = roombaController.moveSpeed;
    }
    void Update() {
    }
    
    public void takeDamage(float damageTaken){
        HP -= damageTaken;
        print("HP: " + HP);
        if (HP <= 0) {
            leaderboard.AddScore("Player 1", score);
            SceneManager.LoadScene("GameEnd"); 
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        }
    }
    public void eat(int trashValue) {
        XPCap = level * levelFactor; 
        score += trashValue; 
        if (XP + trashValue > XPCap) {
            xpScript.UpdateXPBar((float)XP / XPCap);
            XP = 0;
            level++; 
            Evolve.enabled = true;
            mutateController.mutate(level);
        }
        else {
            XP += trashValue;
            xpScript.UpdateXPBar((float)XP / XPCap);
        }
        
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
    public float getLevel() {
        return level;
    }

}
