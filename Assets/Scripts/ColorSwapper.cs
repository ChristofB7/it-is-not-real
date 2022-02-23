using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwapper : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame updat
    bool blue = false;

    internal void ChangeColor()
    {
        if (blue)
        {
            blue = false;
            animator.SetBool("blue", false);
        }
        else
        {
            blue = true;
            animator.SetBool("blue", true);
        }

    }
}
