using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterLaunch : MonoBehaviour
{

    Rigidbody Myrb;
    float Pop;
    bool IsGrounded = true;
    float Uppop;
    string sceneName;

    // Use this for initialization
    void Start()
    {
        Myrb = GetComponent<Rigidbody>();
        Pop = 500f;
        Uppop = 200f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            sceneName =SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (IsGrounded == true))
        {
            Myrb.AddForce(transform.forward * Pop);
            Myrb.AddForce(transform.up * Uppop);
            IsGrounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            IsGrounded = true;
        }
    }
}



 