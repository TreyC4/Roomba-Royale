using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
public class XPScript : MonoBehaviour
{
    public Sprite[] sprites;
    
    public UnityEngine.UI.Image xpBarImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateXPBar(float xpPercentage) {
        xpPercentage *= 100f; 
        print(xpPercentage);
        // Calculate the index of the sprite to use based on the percentage of XP
        int spriteIndex = (int)xpPercentage;

        // Set the sprite of the XP bar image
        xpBarImage.sprite = sprites[spriteIndex];
    }
    
}
