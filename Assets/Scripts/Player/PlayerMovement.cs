using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight;

    [SerializeField] private float groundDistance;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGround;
    Vector3 velocity;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    void Jump()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);
        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(isGround && InputManager.Instance.jumpInput)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void Movement()
    {
        Vector3 input = new Vector3(InputManager.Instance.xInput, 0, InputManager.Instance.zInput);
        Vector3 motion = input;
        characterController.Move(motion * movementSpeed * Time.deltaTime);
    }
}
