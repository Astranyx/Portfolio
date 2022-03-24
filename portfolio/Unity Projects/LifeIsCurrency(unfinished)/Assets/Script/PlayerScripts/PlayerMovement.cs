using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static float moveSpeed;
    private const float gravity = 30f;
    private CameraController cameraController;
    private CharacterController controller;
    private Camera mainCamera;
    private Vector3 moveDirection;

    float speedMultiplier;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = 5;
        cameraController = transform.GetChild(0).GetComponent<CameraController>();

        
        Cursor.visible = false;

    }

    void Update()
    {
        if (PauseMenu.gameOn)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        transform.eulerAngles = cameraController.rotation;

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            speedMultiplier = 1.5f;

            moveDirection = moveDirection * moveSpeed * speedMultiplier;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = 16;
            }

        }
        else
        {
                moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        }


        controller.Move(moveDirection * Time.deltaTime);
    }
}