using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class ColoredPlatforms : MonoBehaviour
{
    public PlayerController controller;
    public LayerMask[] grounds;
    public Sprite[] sprites;
    public SpriteRenderer redRenderer,blueRenderer;
    public float swapTime = 3f;

    public int spriteCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<PlayerController>();
        StartCoroutine(SwapColors());
        

    }

    IEnumerator SwapColors()
    {
        for(; ; )
        {
            spriteCounter = (spriteCounter+1)%sprites.Length;
            bool blue = spriteCounter % 2 == 0;

            if (blue)
            {
                blueRenderer.enabled = true;
                redRenderer.enabled = false;
            }
            else
            {
                blueRenderer.enabled = false;
                redRenderer.enabled = true;

            }
            controller._groundLayer = grounds[spriteCounter];

            yield return new WaitForSeconds(swapTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
