using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    [SerializeField] GameObject table; 
    private Color tempColor; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("roomba")) {
            tempColor = table.GetComponent<Renderer>().material.GetColor("_Color");
            table.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 0, 0, 0.4f));
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("roomba")) {
            table.GetComponent<Renderer>().material.SetColor("_Color", tempColor);
        }
    }
}
