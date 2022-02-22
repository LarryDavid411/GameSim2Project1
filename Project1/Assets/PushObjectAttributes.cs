using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjectAttributes : MonoBehaviour
{
    public bool introPushObject;
    public float brickSpeed;
    public bool pushingBrick;
    public Vector3 deltaMove;
    private Vector3 startingPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pushingBrick)
        {
            gameObject.transform.position += (Vector3.right * Time.deltaTime * brickSpeed);
            deltaMove = startingPosition - gameObject.transform.position;

        }
        
        
        
    }
}
