using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBorder : MonoBehaviour
{

    public GameObject movingObject;

    public Vector3 objectMoved;
    // Start is called before the first frame update
    void Start()
    {
        objectMoved = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (movingObject.GetComponent<PushObjectAttributes>().deltaMove.x < objectMoved.x - gameObject.transform.position.x)
        {
            
            gameObject.transform.position -= movingObject.GetComponent<PushObjectAttributes>().deltaMove; 

        }
    }
}
