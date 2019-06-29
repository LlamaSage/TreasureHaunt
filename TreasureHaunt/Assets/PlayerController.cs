using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls movement.
 * Src https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
 */

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    InteractableObject interactableObject;
    public float speed = 6.0f;
    public int player;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get direction
        moveDirection.x = Input.GetAxis("LeftX_P" + player) * speed;
        moveDirection.z = Input.GetAxis("LeftY_P" + player) * speed * -1;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Check if currently opening something
        if (interactableObject != null)
        {
            // not ideal, but needs to check every player's input
            if (Input.GetButton("A_P2") || Input.GetButton("A_P3") || Input.GetButton("A_P4"))
            {
                interactableObject.setBeingOpened(true);
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        interactableObject = hit.gameObject.GetComponent<InteractableObject>();
    }
}
