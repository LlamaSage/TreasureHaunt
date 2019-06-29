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
    private bool searching = false; // false if player is searching a container

    InteractableObject interactableObject;
    private float minDistance = 1.8f; // min distance from object that it can still be opened
    private float distance; // distance from openable object

    private Animator animator;  

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsSearching", searching);

        if (!searching)
        {
            // Get direction
            moveDirection.x = Input.GetAxis("LeftX_P" + player) * speed * -1;
            moveDirection.z = Input.GetAxis("LeftY_P" + player) * speed;

            // Rotate model
            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }

            // Send speed to animator
            animator.SetFloat("Speed", moveDirection.magnitude);

            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);
        }

        // Check if recently collided with an interactableObject
        if (interactableObject != null)
        {
            // Check if chest has been opened & has item
            animator.SetBool("ItemFound", interactableObject.GetItem());

            // Check if close enough to interactableObject to open it
            distance = Vector3.Distance(this.transform.position, interactableObject.transform.position);
            if (Input.GetButton("A_P" + player) && (distance < minDistance) && interactableObject.IsSearchable())
            {
                interactableObject.SetBeingOpened(true);
                searching = true;
            }
            else
            {
                interactableObject.SetBeingOpened(false);
                searching = false;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // set interactableObject player collided with
        interactableObject = hit.gameObject.GetComponent<InteractableObject>();
    }
}
