using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjectAttributes : MonoBehaviour
{
    public bool introPushObject;
    public float brickSpeed;
    public bool pushingBrick;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pushingBrick)
        {
            gameObject.transform.position += (Vector3.right * Time.deltaTime * brickSpeed);
        }
    }
}
