using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public float openSpeed = 5.0f;
    public bool hasItem;
    private float openProgress = 0.0f;
    private float maxProgress = 20.0f;
    private bool beingOpened = false;
    private bool searchable = true;
    private bool isOpened = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool IsSearchable()
    {
        return searchable;
    }
    public bool GetItem()
    {
        return isOpened && hasItem;
    }
    public void SetBeingOpened(bool var)
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
            searchable = false;
            isOpened = true;
        }
    }
}
