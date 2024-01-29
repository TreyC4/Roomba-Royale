
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu() {
        SceneManager.LoadScene("StartMenu"); 
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
