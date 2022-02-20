using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreenSet : MonoBehaviour
{
    public GameObject fadeScreen;

    public void FadingOut()
    {
        fadeScreen.GetComponent<Animation>().Play("FadeAnim");
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
