using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject dialogue;
    public GameObject fsmManager;
    public bool attackFromLeft;
    public bool attackingBrick;
    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "PlayerAttackObject")
        {
            
            if (attackFromLeft != player.GetComponent<SpriteRenderer>().flipX )
            {
                fsmManager.GetComponent<FSMController>().inAttackSpace = true;
                attackingBrick = true;
            }
            else
            {
                attackingBrick = false;
            }
            if ( (fsmManager.GetComponent<FSMController>().state == FSMController.State.Attacking ||
                 fsmManager.GetComponent<FSMController>().state == FSMController.State.AttackingWhileWalking) && 
                 attackingBrick)
            {
                gameObject.transform.parent.GetComponent<BrickAttributes>().brickBeingAttacked = true;
                Debug.Log("attackingInSpace");
                
            }
            else
            {
                gameObject.transform.parent.GetComponent<BrickAttributes>().brickBeingAttacked = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.transform.parent.GetComponent<BrickAttributes>().introBrick)
            {
                dialogue.GetComponent<DialogueObjects>().displayIntroBrickText = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            fsmManager.GetComponent<FSMController>().inAttackSpace = false;
            if (gameObject.transform.parent.GetComponent<BrickAttributes>().introBrick)
            {
                dialogue.GetComponent<DialogueObjects>().displayIntroBrickText = false;
            }
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
