using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    public float openProgress = 0.0f;
    public float openSpeed = 5.0f;
    private float maxProgress = 20.0f;
    private bool isOpen = false;
    private bool beingOpened = false;
    private bool searchable = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool isSearchable()
    {
        return searchable;
    }
    public void setBeingOpened(bool var)
    {
        if (searchable)
        {
            beingOpened = var;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (openProgress != 0)
        {
            Debug.Log("progress: " + openProgress);
        }

        if (beingOpened && searchable)
        {
            openProgress += Time.deltaTime * openSpeed;
        }
        else
        {
            openProgress = 0;
        }

        if (openProgress >= maxProgress)
        {
            isOpen = true;
            searchable = false;
        }
    }
}
