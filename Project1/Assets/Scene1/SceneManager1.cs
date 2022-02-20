using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using  UnityEngine.UI;

public class SceneManager1 : MonoBehaviour
{
    public GameObject fsmManager;
    public float timeToSwitchLevel;
    public GameObject fadeObject;
    public GameObject fadeScreen;
    public bool playIntroFade;
    
    public int currentLevel;

    private float endLevelTimer;
    public GameObject SceneManagerLevel;
    public enum DisplayState
    {
        start,
        playing,
        end
    }

    public DisplayState _displayState;
    
    // Start is called before the first frame update
    void Start()
    {
        _displayState = DisplayState.start;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_displayState)
        {
            case DisplayState.start:
            {
                if (playIntroFade)
                {
                    fadeScreen.GetComponent<Animation>().Play("FadeAnim");
                    playIntroFade = false;
                }
               
                // TODO: Set up transition start
            } break;

            case DisplayState.playing:
            {
                
            } break;

            case DisplayState.end:
            {
                // TODO: Set up transition end
                fsmManager.GetComponent<FSMController>().state = FSMController.State.ActivelyMoving;
            } break;
            
        }

        if (_displayState == DisplayState.end)
        {
            endLevelTimer += Time.deltaTime;
            fadeObject.GetComponent<FadeToWhite>().fadeOut = true;
           
        }

        if (endLevelTimer > timeToSwitchLevel)
        {
            SceneManagerLevel.GetComponent<SceneManager1>().currentLevel++;
            _displayState = DisplayState.start;
            // Scene currentScene = SceneManager.GetActiveScene();
            //
            // Debug.Log(currentScene.name);
            // if (currentScene.name == "Scene1")
            // {
            //     _dis
            // }
        }
    }
}
