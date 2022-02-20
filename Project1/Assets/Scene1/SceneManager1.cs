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
    public GameObject fadeToBlackScreen;
    public bool playEndFade;
    public int currentLevel;

    private float endLevelTimer;

    public GameObject player;
    public bool startPlayerPosition;
    
    public GameObject SceneManagerLevel;
    public GameObject cameraManager;
    public Vector3[] playerPositionForLevelStarting;
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
        // player Start positions
        playerPositionForLevelStarting = new Vector3[2];
        playerPositionForLevelStarting[0] = new Vector3(-15.2f, 1f, 0f);
        playerPositionForLevelStarting[1] = new Vector3(58.2f, -4.91f, 0f);
        




    }

    // Update is called once per frame
    void Update()
    {
        switch (_displayState)
        {
            case DisplayState.start:
            {
                if (startPlayerPosition)
                {
                    player.GetComponent<Transform>().position = playerPositionForLevelStarting[currentLevel];
                    startPlayerPosition = false;
                }
                if (playIntroFade)
                {
                    fadeScreen.GetComponent<Animation>().Play("FadeAnim");
                    playIntroFade = false;
                }
               
                // TODO: Set up transition start
            } break;

            case DisplayState.playing:
            {
                fadeScreen.SetActive(false);
                
            } break;

            case DisplayState.end:
            {
                // TODO: Set up transition end
                fadeToBlackScreen.SetActive(true);
                startPlayerPosition = true;
                fsmManager.GetComponent<FSMController>().state = FSMController.State.ActivelyMoving;
            } break;
            
        }

        if (_displayState == DisplayState.end)
        {
            endLevelTimer += Time.deltaTime;
            fadeObject.GetComponent<FadeToWhite>().fadeOut = true;
            if (playEndFade)
            {
                fadeToBlackScreen.GetComponent<Animation>().Play("FadeToBlack");
                playEndFade = false;

            }

            
        }

        if (endLevelTimer > timeToSwitchLevel)
        {
            currentLevel++;
            endLevelTimer = 0;
            _displayState = DisplayState.start;
            playIntroFade = true;
            playEndFade = true;
            fadeToBlackScreen.SetActive(false);
            fsmManager.GetComponent<FSMController>().state = FSMController.State.Idle;
            cameraManager.GetComponent<CameraManager>().changeLevel = true;
            startPlayerPosition = true;
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
