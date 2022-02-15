using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject camera;
    //public GameObject sceneManager;

    public bool changeLevel;

    public Vector4[] cameraPositionForEachScene;
    // Start is called before the first frame update
    void Start()
    {
        cameraPositionForEachScene = new Vector4[2];
        cameraPositionForEachScene[0] = new Vector4(0f, 1.97f, -22.14f, 10.47f);
    }
    
    // Update is called once per frame
    void Update()
    {
        camera.GetComponent<Transform>().position = cameraPositionForEachScene[0];
        camera.GetComponent<Camera>().orthographicSize = cameraPositionForEachScene[0].w;
        if (changeLevel)
        {
           
        }
        else
        {
            changeLevel = false;
        }
    }
}
