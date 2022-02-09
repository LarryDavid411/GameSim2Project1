using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerFogAttributes : MonoBehaviour
{
    public bool fogTriggered;

    public GameObject fsmManager;
    //

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fsmManager.GetComponent<FSMController>().state = FSMController.State.KilledByFog;
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
