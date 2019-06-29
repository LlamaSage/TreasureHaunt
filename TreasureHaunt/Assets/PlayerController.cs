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
    public float speed = 6.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float rotationSpeed = 180.0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0));
        // Get direction
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
