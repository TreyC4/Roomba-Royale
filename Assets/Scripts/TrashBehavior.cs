using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrashBehavior : MonoBehaviour
{
    [SerializeField] private int trashValue;

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
        if (other.gameObject.CompareTag("roomba") && gameObject.tag != "hooman") {
            roomba.eat(trashValue);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("roomba") && gameObject.tag == "hooman") {
            if (roomba.getLevel() > 2) {
                roomba.eat(10);
                Destroy(gameObject);
            }
            
        }
        else if (other.gameObject.CompareTag("roomba") && gameObject.tag == "furniture") {
            if (roomba.getLevel() > 3) {
                roomba.eat(40);
                Destroy(gameObject);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.transform.parent.CompareTag("roomba") && gameObject.tag != "hooman") {
            roomba.eat(trashValue);
            Destroy(gameObject);
        }
        else if (other.gameObject.transform.parent.CompareTag("roomba") && gameObject.tag == "hooman") {
            roomba.eat(trashValue);
            Destroy(gameObject);
        }
    }
}
