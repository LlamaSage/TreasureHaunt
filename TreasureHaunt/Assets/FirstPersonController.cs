using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * First person player control.
 */

public class FirstPersonController : MonoBehaviour
{
    CharacterController characterController;
    public float speed;
    public float boost;
    public float boostLimit;
    public float rotationSpeed;
    private int player = 1;
    private float rotation;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation
        rotation = Input.GetAxis("LeftX_P" + player) * rotationSpeed;
        transform.Rotate(Vector3.up * rotation * Time.deltaTime);

        // Movement
        moveDirection = this.transform.forward * Input.GetAxis("LeftY_P" + player) * speed * -1;
        if (Mathf.Abs(rotation) > boostLimit)
        {
            moveDirection *= boost;
        }
        characterController.Move(moveDirection * Time.deltaTime);
    }


}
