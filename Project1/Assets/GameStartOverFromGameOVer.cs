using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartOverFromGameOVer : MonoBehaviour
{
    public float restartTimer;

    public float restartClock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        restartTimer += Time.deltaTime;

        if (restartTimer > restartClock)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
