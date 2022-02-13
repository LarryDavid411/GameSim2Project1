using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnMouseOverlapStartGame : MonoBehaviour
{
    public Text text;
    private void OnMouseOver()
    {
        text.GetComponent<Text>().color = Color.gray;
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Scene1");
        }
    }

    private void OnMouseExit()
    {
        text.GetComponent<Text>().color = Color.black;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
