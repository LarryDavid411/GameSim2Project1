using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickAttack : MonoBehaviour
{
    public GameObject fsmManager;
    public bool attackFromLeft;
    public bool attackingBrick;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (attackFromLeft != other.GetComponent<SpriteRenderer>().flipX )
            {
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
