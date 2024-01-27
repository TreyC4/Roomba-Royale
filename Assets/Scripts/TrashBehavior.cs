using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashBehavior : MonoBehaviour
{
    [SerializeField] private float trashValue;

    [SerializeField] private Roomba roomba; 
    // Start is called before the first frame update
    void Start()
    {
        roomba = GameObject.Find("roombap1").GetComponent<Roomba>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("roomba")) {
            roomba.eat(trashValue);
            Destroy(gameObject);
        }
    }
}
