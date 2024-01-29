
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    public void switchScene() {
        SceneManager.LoadScene("MainGame");
    }
}
