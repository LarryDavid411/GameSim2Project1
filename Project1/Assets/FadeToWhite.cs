using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToWhite : MonoBehaviour
{

    public Vector4 redColor;

    public bool fadeOut;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut)
        {

            Renderer rend = GetComponent<Renderer>();
            float red = redColor.x;
            redColor.x -= Time.deltaTime / 5;
            rend.material.SetFloat("_redFade", red);
            if (redColor.x < -10)
            {
                redColor.x = 0;
                fadeOut = false;
            }
        }

    }
}

