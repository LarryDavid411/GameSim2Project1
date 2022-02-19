using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{

    public GameObject fsmManager;

    private bool restartGame;

    private float restartTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (fsmManager.GetComponent<FSMController>().state == FSMController.State.KilledByFog)
        {
            restartGame = true;
        }

        if (restartGame)
        {
            restartTimer += Time.deltaTime;

            if (restartTimer > 5.0f)
            {
                SceneManager.LoadScene("MainMenu");
            }

        }
    }
}
