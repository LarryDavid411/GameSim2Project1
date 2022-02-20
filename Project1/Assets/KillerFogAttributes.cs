using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Random = System.Random;
using Random = UnityEngine.Random;

public class KillerFogAttributes : MonoBehaviour
{
    public bool fogTriggered;

    public GameObject fsmManager;
    //
    public float RandomChangeValue;

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

        RandomChangeValue = Random.Range(1f, 4f);
        

        //gameObject.GetComponent<Material>().
    }

    // Update is called once per frame
    void Update()
    {
       // Shader.SetGlobalFloat("randSet", randSet);
       Renderer rend = GetComponent<Renderer>();
       rend.material.SetFloat("_RandSet", RandomChangeValue);
    }
}
