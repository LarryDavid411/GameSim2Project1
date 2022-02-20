using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyShaderTest : MonoBehaviour
{
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetFloat("_RandSet", 2f);
        
    }
}
