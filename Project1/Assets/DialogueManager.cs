using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private float textTimerForLetters;

    private int displayTextSequence;

    public Text displayText;
    public Text displayTextStartButton;
    

    public string nameText;
    public string nameTextAdded;
    private char c;
    public float textTimerDisplayRate;
    private bool startTitle;
    private float delayStartTimer;
    public float delayStart;
    private bool titleOver;
    private float titleOverTimer;
    public float titleOverTimeSet;

    public string startGameTextString;
    
    // Start is called before the first frame update
    void Start()
    {
        titleOver = false;
        nameText = "uninhabited";
        nameTextAdded = "";
        displayTextSequence = -1;
        startGameTextString = "Start Game";
    }

    // Update is called once per frame
    void Update()
    {
        textTimerForLetters += Time.deltaTime;
        if (delayStartTimer < delayStart)
        {
            delayStartTimer += Time.deltaTime;
            if (delayStartTimer > delayStart)
            {
                startTitle = true;
            }
        }
        if ( startTitle && (displayTextSequence < nameText.Length - 1))
        {
            if (textTimerForLetters > textTimerDisplayRate)
            {
                displayTextSequence++;
                textTimerForLetters = 0;
                c = nameText[displayTextSequence];
                nameTextAdded += c.ToString();
            }
        }
        else
        {
            titleOverTimer += Time.deltaTime;
            if (titleOverTimer > titleOverTimeSet)
            {
                titleOver = true;
            }
            
        }
        
        
        
        
        displayText.text = nameTextAdded;

        if (titleOver)
        {
            displayTextStartButton.text = startGameTextString;
        }
        
        
    }
}
