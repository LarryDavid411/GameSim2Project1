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
                fsmManager.GetComponent<FSMController>().playerInPushTrigger = true;
                pushingBrick = true;
            }
            else
            {
                pushingBrick = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        fsmManager.GetComponent<FSMController>().playerInPushTrigger = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pushingBrick)
        {
            if (fsmManager.GetComponent<FSMController>().state == FSMController.State.PushingWhileWalking)
            {
                gameObject.transform.parent.GetComponent<PushObjectAttributes>().pushingBrick = true;
            }
            else
            {
                gameObject.transform.parent.GetComponent<PushObjectAttributes>().pushingBrick = false;
            }
            
            //gameObject.transform.parent.transform.position += (Vector3.right * Time.deltaTime * brickSpeed);
        }
        else
        {
            gameObject.transform.parent.GetComponent<PushObjectAttributes>().pushingBrick = false;
        }
        
    }
}
