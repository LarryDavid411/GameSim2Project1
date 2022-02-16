using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjectTrigger : MonoBehaviour
{

    public bool pushFromLeft;
    public bool pushingBrick;
    public GameObject fsmManager;
    public GameObject player;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PushObjectPlayerTag")
        {
            if (pushFromLeft != player.GetComponent<SpriteRenderer>().flipX)
            {
                pushingBrick = true;
            }
            else
            {
                pushingBrick = false;
            }
            
            // if ( (fsmManager.GetComponent<FSMController>().state ) )
            // {
            //     
            // }
            
        }
        
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
