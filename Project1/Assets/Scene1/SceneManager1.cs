using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

public class SceneManager1 : MonoBehaviour
{
    public GameObject fsmManager;
    
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
    }
}
