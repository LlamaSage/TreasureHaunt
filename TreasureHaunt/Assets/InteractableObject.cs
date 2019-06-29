using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    public float openProgress = 0.0f;
    public float openSpeed = 5.0f;
    private float maxProgress = 100.0f;
    private bool isOpen = false;
    private bool beingOpened = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setBeingOpened(bool var)
    {
        beingOpened = var;
    }

    // Update is called once per frame
    void Update()
    {
        if (openProgress != 0)
        {
            Debug.Log("progress: " + openProgress);
        }

        if (beingOpened & !isOpen)
        {
            openProgress += Time.deltaTime * openSpeed;
        }
        else
        {
            openProgress = 0;
            beingOpened = false;
        }

        if (openProgress >= maxProgress)
        {
            isOpen = true;
        }
    }
}
