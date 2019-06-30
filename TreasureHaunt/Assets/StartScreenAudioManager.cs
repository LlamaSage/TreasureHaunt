using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenAudioManager : MonoBehaviour
{
    public AudioClip[] buttonClips;
    public AudioSource audioPlayer;
    public AudioClip welcomeClip;

    public void PlaySound(int index)
    {
        if(audioPlayer.clip == welcomeClip && audioPlayer.isPlaying)
        {
            return;
        }
        if(audioPlayer.isPlaying)
        {
            audioPlayer.Stop();
        }
        audioPlayer.clip = buttonClips[index];
        audioPlayer.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
        audioPlayer.clip = welcomeClip;
    }
}
