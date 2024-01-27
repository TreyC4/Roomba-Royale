using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    void Start() {
        if (menu.activeSelf) {
            menu.SetActive(false);
        }
    }
    [SerializeField] private GameObject menu; 

    public void open() {
        if (menu.activeSelf == false) {
            menu.SetActive(true);
        }
    }
    public void close() {
        if (menu.activeSelf) {
            menu.SetActive(false);
        }
        else {
            menu.SetActive(true);
        }
    }
}
