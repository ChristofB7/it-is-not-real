using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkTheme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager[] list = FindObjectsOfType<AudioManager>();
        for(int i = 0;i<list.Length; i++)
        {
            if (list[i].enabled)
            {
                list[i].PlayDarkTheme();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
