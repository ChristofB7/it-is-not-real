using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class talk : MonoBehaviour
{
    private TextMeshProUGUI text;
    private string[] messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private int currentText = 0;

    private void Awake()
    {
        text = FindObjectOfType<TextMeshProUGUI>();
        messageText = new string[]
        {
     
            "Can you Hear me?",
            "You are in a simulation",
            "Whatever you do stop eating the cake",
            "you have to wake up",
            "we need you",
            "..."
        };
    }
    // Start is called before the first frame update
    void Start()
    {
        TextWriter.AddWriter_Static(text, "Hello? Hello?", .1f, true, false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.anyKeyDown)
        {
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                string message = messageText[currentText];
                currentText++;
                if(currentText == messageText.Length)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                textWriterSingle = TextWriter.AddWriter_Static(text, message, .1f, true, true);
            }
                
        }
            
    }
}
