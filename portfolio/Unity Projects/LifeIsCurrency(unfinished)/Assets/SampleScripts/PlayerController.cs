using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private float moveSpeed;
    private const float gravity = 30f;
    private CameraController cameraController;
    private CharacterController controller;
    private Camera mainCamera;
    private Vector3 moveDirection;

    float speedMultiplier;

    int points;

    public Text score;
    public Text Win;

    MeshRenderer colour;
    public Material red;
    public Material blue;
    public Material green;
    public Material white;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveSpeed = 5;
        cameraController = transform.GetChild(0).GetComponent<CameraController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Win.text = "";
        score.text = "";
    }

    void Update()
    {
        score.text = "Coins : \n" + points.ToString() + "/3";

        if (points == 3)
        {
            StartCoroutine("End");
        }


        colour = GetComponent<MeshRenderer>();
        transform.eulerAngles = cameraController.rotation;


        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(0.5f, 0.5f, -18.5f);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            colour.material = white;
            transform.localScale = new Vector3(1f, 2f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            speedMultiplier = 1.5f;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedMultiplier = 2.5f;
            }

            moveDirection = moveDirection * moveSpeed * speedMultiplier;

            if (colour.material.name == "Red (Instance)")
            {
                if (Input.GetButton("Jump") && (Input.GetKey(KeyCode.LeftShift)))
                {
                    moveDirection.y = 11;
                }
                else if (Input.GetButton("Jump"))
                {
                    moveDirection.y = 16;
                }
            }

            if(colour.material.name == "Green (Instance)")
            {
                if (Input.GetButton("Jump"))
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }
                else
                {
                    transform.localScale = new Vector3(1f, 2f, 1f);
                }
                
            }
           
        }
        else
        {
            if (Input.GetButton("Jump") && colour.material.name == "Blue (Instance)")
            {
                moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection = moveDirection * moveSpeed * speedMultiplier;
            }
            else
            {
                moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
            }            
        }
      

        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "red")
        {
            colour.material = red;
            transform.localScale = new Vector3(1f, 2f, 1f);
        }

        if (collision.gameObject.tag == "blue")
        {
            colour.material = blue;
        }

        if (collision.gameObject.tag == "green")
        {
            colour.material = green;
            transform.localScale = new Vector3(1f, 2f, 1f);
        }    
        
        if(collision.gameObject.tag == "laser")
        {
            transform.position = new Vector3(0.5f, 0.5f, -18.5f);
        }

        if (collision.gameObject.tag == "Coin")
        {
            points += 1;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator End()
    {
        Win.text = "You Win!";
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Level1");
    }
}