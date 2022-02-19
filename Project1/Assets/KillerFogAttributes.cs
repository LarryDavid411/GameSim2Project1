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
    
    public float randSet = 1;

    // Start is called before the first frame update
    void Start()
    {

   
        
        //gameObject.GetComponent<Material>().
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalFloat("randSet", randSet);
    }
}
