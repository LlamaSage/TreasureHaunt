using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls player movement.
 */

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 6.0f;
    public int player; // num of player for controls - works with Project Settings > Input naming scheme
    private Vector3 moveDirection = Vector3.zero;
    private bool canMove = true; // false if player is frozen in place

    InteractableObject interactableObject;
    private float minDistance = 1.8f; // min distance from object that it can still be opened
    private float distance; // distance from openable object

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            // Get direction
            moveDirection.x = Input.GetAxis("LeftX_P" + player) * speed * -1;
            moveDirection.z = Input.GetAxis("LeftY_P" + player) * speed;

            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);
        }

        // Check if recently collided with an interactableObject
        if (interactableObject != null)
        {
            // Check if close enough to interactableObject to open it
            distance = Vector3.Distance(this.transform.position, interactableObject.transform.position);
            if (Input.GetButton("A_P" + player) && (distance < minDistance) && interactableObject.isSearchable())
            {
                interactableObject.setBeingOpened(true);
                canMove = false;
            }
            else
            {
                interactableObject.setBeingOpened(false);
                canMove = true;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // set interactableObject player collided with
        interactableObject = hit.gameObject.GetComponent<InteractableObject>();
    }
}
