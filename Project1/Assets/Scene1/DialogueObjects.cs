using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueObjects : MonoBehaviour
{
    public Text textIntroBrick;
    public Text textIntroPushObject;

    public bool displayIntroBrickText;
    public bool displayPushBrickText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        displayIntroBrickText = false;
        textIntroBrick.GetComponent<Text>().color = Color.white;
        textIntroBrick.GetComponent<Text>().text = "Press Space to Attack";
        textIntroPushObject.GetComponent<Text>().color = Color.white;
        textIntroPushObject.GetComponent<Text>().text = "Press XXXX to Push";
    }

    // Update is called once per frame
    void Update()
    {

        if (displayIntroBrickText)
        {
            textIntroBrick.gameObject.SetActive(true);
        }
        else
        {
            textIntroBrick.gameObject.SetActive(false);
        }

        if (displayPushBrickText)
        {
            textIntroPushObject.gameObject.SetActive(false);
        }
        else
        {
            textIntroPushObject.gameObject.SetActive(true);
        }

    }
}
