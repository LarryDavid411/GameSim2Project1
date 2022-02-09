using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerFogTrigger : MonoBehaviour
{
    public GameObject fsmManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fsmManager.GetComponent<FSMController>().fogState = FSMController.FogState.Approaching;
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
