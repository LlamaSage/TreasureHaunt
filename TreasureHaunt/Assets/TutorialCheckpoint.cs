using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheckpoint : MonoBehaviour
{
    public AudioSource coinEffect;
    public GameObject nextCheckpoint;


    private void OnTriggerEnter(Collider other)
    {
        coinEffect.Play();
        if(nextCheckpoint != null)
        {
            nextCheckpoint.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
