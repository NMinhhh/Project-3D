using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 input = new Vector3(InputManager.Instance.xInput, 0, InputManager.Instance.zInput);
        Vector3 motion = input;
        characterController.Move(motion * movementSpeed * Time.deltaTime);
    }
}
