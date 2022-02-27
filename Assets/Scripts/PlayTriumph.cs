using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTriumph : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlayTriumph();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
