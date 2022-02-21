using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformImage : MonoBehaviour
{
    private ColoredPlatforms coloredPlatforms;
    public Sprite[] sprites;
    private Image image;
    private float spriteCounter;
    // Start is called before the first frame update
    void Start()
    {
        coloredPlatforms = FindObjectOfType<ColoredPlatforms>();
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spriteCounter != coloredPlatforms.spriteCounter)
        {
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        spriteCounter = coloredPlatforms.spriteCounter;
        image.sprite = sprites[coloredPlatforms.spriteCounter];

    }
}
