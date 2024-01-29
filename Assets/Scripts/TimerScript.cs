using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private float timeDuration = 3f * 60f;
    
    [SerializeField] private float timer; 
    [SerializeField]
    private TextMeshProUGUI firstMinute; 
    [SerializeField]
    private TextMeshProUGUI secondMinute; 
    [SerializeField] 
    private TextMeshProUGUI separator; 
    [SerializeField]
    private TextMeshProUGUI firstSecond; 
    [SerializeField]
    private TextMeshProUGUI secondSecond;
    // Start is called before the first frame update
    [SerializeField]
    private GameObject obstacleTemplate; 
    public Sprite[] spriteCollection; 
    private int spawnInterval = 1; 
    
    private Camera mainCamera; 
    private Bounds cameraBounds; 

    [SerializeField] private GameObject[] hooman;
    void Start()
    {
        mainCamera = Camera.main;

        cameraBounds = CalculateCameraBounds();
        timer = timeDuration;
        StartCoroutine(spawnTrash());
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0) {
            timer -= Time.deltaTime;
            
            UpdateTimer(timer);
            
        }
        else {
            SetTextDisplay(false);
            SceneManager.LoadScene("GameEnd"); 
        }
    }
    void resetTimer() {
        timer = timeDuration;
    }
    private void UpdateTimer(float time) {
        float minutes = Mathf.FloorToInt(time / 60); // convert the seconds into minutes 
        float seconds = Mathf.FloorToInt(time % 60); // get the remaining seconds that were not converted into minutes 
        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds); 
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString(); 
        firstSecond.text = currentTime[2].ToString(); 
        secondSecond.text = currentTime[3].ToString(); 
    }
    private void SetTextDisplay(bool enabled) {
        if (enabled) {
            firstMinute.enabled = true; 
            secondMinute.enabled = true; 
            separator.enabled = true; 
            firstSecond.enabled = true; 
            secondSecond.enabled = true; 
        }
        else {
            firstMinute.enabled = false; 
            secondMinute.enabled = false;
            separator.enabled = false; 
            firstSecond.enabled = false;
            secondSecond.enabled = false;
        }
    }
        IEnumerator spawnTrash()
    {
        while (true)
        {
            cameraBounds = CalculateCameraBounds();
            yield return new WaitForSeconds(spawnInterval);

            // Calculate random positions outside the camera's FOV
            Vector3 spawnPosition1 = GetValidSpawnPosition();
            Vector3 spawnPosition2 = GetValidSpawnPosition();

            if (spawnPosition1 != Vector3.zero && spawnPosition2 != Vector3.zero)
            {
                // Instantiate trash objects at calculated positions
                GameObject trash1 = Instantiate(obstacleTemplate, spawnPosition1, Quaternion.identity);
                GameObject trash2 = Instantiate(obstacleTemplate, spawnPosition2, Quaternion.identity);
                int spawnRate = Random.Range(0, 10);
                if (spawnRate == 0 || spawnRate == 1) {
                    GameObject guy = Instantiate(hooman[spawnRate], spawnPosition1, Quaternion.identity);
                }
                // Set random sprites to trash objects
                Sprite randomSprite1 = spriteCollection[Random.Range(0, spriteCollection.Length)];
                Sprite randomSprite2 = spriteCollection[Random.Range(0, spriteCollection.Length)];
                
                trash1.GetComponent<SpriteRenderer>().sprite = randomSprite1;
                trash2.GetComponent<SpriteRenderer>().sprite = randomSprite2;
            }
        }
    }

    Bounds CalculateCameraBounds()
    {
        float screenAspect = (float)Screen.width / Screen.height;
        float cameraHeight = mainCamera.orthographicSize * 2f;
        Bounds bounds = new Bounds(mainCamera.transform.position, new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
    Vector3 GetValidSpawnPosition()
    {
        int maxAttempts = 10;
        int attempts = 0;
        Vector3 spawnPosition = Vector3.zero;

        while (attempts < maxAttempts)
        {
            int randomInt = Random.Range(0, 1); 
            int randomOffset = 0; 
            if (randomInt == 1) {
                randomOffset = -2;
            }
            else if (randomInt == 0) {
                randomOffset = 2;
            }
            Vector3 randomPosition = new Vector3(Random.Range(cameraBounds.min.x + mainCamera.orthographicSize * randomOffset, cameraBounds.max.x + mainCamera.orthographicSize * randomOffset),
                                                Random.Range(cameraBounds.min.y + mainCamera.orthographicSize *randomOffset, cameraBounds.max.y + mainCamera.orthographicSize * randomOffset),
                                                0);

            if (!IsPositionObstructed(randomPosition))
            {
                spawnPosition = randomPosition;
                break;
            }

            attempts++;
        }

        return spawnPosition;
    }


    bool IsPositionObstructed(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
        return hit.collider != null;
    }

}
    