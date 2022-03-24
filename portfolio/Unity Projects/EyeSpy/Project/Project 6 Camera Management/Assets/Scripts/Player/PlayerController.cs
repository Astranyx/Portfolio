using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using UnityEngine.Networking;
//using UnityEngine.UI;

public class PlayerController : NetworkBehaviour
{

    private float moveSpeed;
    private const float gravity = 30f;
    private CameraController cameraController;
    private CharacterController controller;
    private Camera mainCamera;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = 5;
        cameraController = transform.GetChild(0).GetComponent<CameraController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        transform.eulerAngles = cameraController.rotation;

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            float speedMultiplier = 1;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedMultiplier *= 2;
            }

            moveDirection = moveDirection * moveSpeed * speedMultiplier;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = 10;
            }
        }
        else
        {
            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        }

        controller.Move(moveDirection * Time.deltaTime);
    }
}