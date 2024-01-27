using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    public void switchScene() {
        if (SceneManager.GetActiveScene().name == "FirstLevel") {
            SceneManager.LoadScene("StartMenu"); 
            SceneManager.UnloadSceneAsync("FirstLevel");
        }
        else {
            SceneManager.LoadScene("FirstLevel");
        }
    }
}
