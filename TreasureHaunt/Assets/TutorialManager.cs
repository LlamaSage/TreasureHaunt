using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialScreens;
    public AudioClip[] tutorialClips;
    public AudioSource audioManager;
    public GameObject mainMenuPanel;
    public GameObject returnFocus;
    public EventSystem evs;
    private int currentIndex = 0;


    public void NextScreen()
    {
        audioManager.Stop();
        if(currentIndex >= tutorialClips.Length-1)
        {
            tutorialScreens[currentIndex].SetActive(false);
            //tutorialScreens[0].SetActive(true);
            mainMenuPanel.SetActive(true);
            currentIndex = 0;
            this.gameObject.SetActive(false);
        }
        else
        {
            tutorialScreens[currentIndex].SetActive(false);
            currentIndex++;
            tutorialScreens[currentIndex].SetActive(true);
            audioManager.clip = tutorialClips[currentIndex];
            audioManager.Play();
        }
    }

    public void OnDisable()
    {
        evs.SetSelectedGameObject(returnFocus);
    }

    private void OnEnable()
    {
        evs.SetSelectedGameObject(null);
        tutorialScreens[0].SetActive(true);
        audioManager.clip = tutorialClips[0];
        audioManager.Play();
    }

    private void Start()
    {
        audioManager = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            NextScreen();
        }
    }
}
