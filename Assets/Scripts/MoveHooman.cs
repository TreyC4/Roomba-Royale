
using UnityEngine;

public class MoveHooman : MonoBehaviour
{
    private float changeInterval = 1f; // Interval in seconds
    private float timer;
    private float randomX; 
    private float randomY; 
    // Start is called before the first frame update
    void Start()
    {
        timer = changeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, 
                new Vector2(randomX, randomY), Time.deltaTime);
        // Check if it's time to change the position
        if (timer <= 0f)
        {
            // Change the position
            randomX = Random.Range(-10.307f, 12.4186f); 
            randomY = Random.Range(-5.33f, 5.93f);
            

            // Reset the timer
            timer = changeInterval;
        }
    }
}
