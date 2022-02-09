using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerFogAttributes : MonoBehaviour
{
    public bool fogTriggered;
    //

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
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
