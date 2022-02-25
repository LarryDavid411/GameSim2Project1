using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //public GameObject gameManager;
    private AudioSource typingAudio;
    private float textTimerForLetters;
    public GameObject levelSelector;

    public int currentLevel; 
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
    
    public enum MenuState
    {
        DelayStart,
        StartTitle,
        DelayPhase2,
        DisplayAll
    }

    public MenuState menuState;
    // Start is called before the first frame update
    void Start()
    {
        menuState = MenuState.DelayStart;
        titleOver = false;
        nameText = "uninhabited";
        nameTextAdded = "";
        displayTextSequence = -1;
        startGameTextString = "Click to Start Game";
        typingAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        typingAudio.Play();
        if (currentLevel == 0)
        {
            switch (menuState)
            {
                case MenuState.DelayStart:
                {
                    delayStartTimer += Time.deltaTime;
                    if (delayStartTimer > delayStart)
                    {
                        delayStartTimer = 0;
                        menuState = MenuState.StartTitle;
                    }
                } break;

                case MenuState.StartTitle:
                {
                    textTimerForLetters += Time.deltaTime;
                    if (displayTextSequence < nameText.Length - 1)
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
                        menuState = MenuState.DelayPhase2;
                    }
                } break;

                case MenuState.DelayPhase2:
                {   
                    delayStartTimer += Time.deltaTime;
                    if (delayStartTimer > delayStart)
                    {
                        delayStartTimer = 0;
                        menuState = MenuState.DisplayAll;
                    }
                } break;
                
                case MenuState.DisplayAll:
                {
                    displayTextStartButton.text = startGameTextString;
                    levelSelector.SetActive(true);
                } break;
            }
            displayText.text = nameTextAdded;
        }
    }
}
