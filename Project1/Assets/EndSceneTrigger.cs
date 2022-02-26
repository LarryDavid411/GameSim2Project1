using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneTrigger : MonoBehaviour
{
    public GameObject sceneManager;
    private AudioSource sound;

    private void Start()
    {
        sound.GetComponent<AudioSource>();
        sound.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sceneManager.GetComponent<SceneManager1>()._displayState = SceneManager1.DisplayState.end;
            sound.Play();
        }
    }
}
