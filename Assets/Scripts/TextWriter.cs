using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextWriter : MonoBehaviour
{

    private static TextWriter instance;

    private List<TextWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<TextWriterSingle>();
    }
    private TextWriterSingle AddWriter(TextMeshProUGUI text, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        TextWriterSingle single = new TextWriterSingle(text, textToWrite, timePerCharacter, invisibleCharacters);
        textWriterSingleList.Add(single);
        return single;
    }
    public static TextWriterSingle AddWriter_Static(TextMeshProUGUI text, string textToWrite, float timePerCharacter, bool invisibleCharacters, bool removeWritereBeforeAdd)
    {
        if (removeWritereBeforeAdd)
        {
            instance.RemoveWriter(text);
        }
        return instance.AddWriter(text, textToWrite, timePerCharacter, invisibleCharacters);
    }
    public static void RemoveWriter_Static(TextMeshProUGUI text)
    {
        instance.RemoveWriter(text);
    }
    private void RemoveWriter(TextMeshProUGUI text)
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
           if(textWriterSingleList[i].getText() == text)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
       for(int i=0; i <textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].Update();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    // Update is called once per frame



    public class TextWriterSingle {
        private TextMeshProUGUI text;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;
        private bool invisibleCharacters;

        public TextWriterSingle(TextMeshProUGUI text, string textToWrite, float timePerCharacter, bool invisibleCharacters)
        {
            this.text = text;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            characterIndex = 0;
            this.invisibleCharacters = invisibleCharacters;

        }
        public bool Update()
        {
          
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                timer += timePerCharacter;
                characterIndex++;
                string textInvis = textToWrite.Substring(0, characterIndex);

                if (invisibleCharacters)
                {
                    textInvis += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                text.text = textInvis;
                if (characterIndex >= textToWrite.Length)
                {
                    text = null;
                    return true;
                }
            }

            return false;
        
        }

        public TextMeshProUGUI getText()
        {
            return text;
        }

        public bool IsActive()
        {
            return characterIndex < textToWrite.Length;
        }

        public void WriteAllAndDestroy()
        {
            text.text = textToWrite;
            characterIndex = textToWrite.Length;
            TextWriter.RemoveWriter_Static(text);


        }
    }
}
