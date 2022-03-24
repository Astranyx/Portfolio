using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TRIGGERED : MonoBehaviour
{

    GameObject obj;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.CompareTag("add50insanity"))
        {
            obj.GetComponent<Insanity>().IncreaseInsanity(50);
        }
        else if (this.CompareTag("setinsanity0"))
        {
            obj.GetComponent<Insanity>().SetInsanityZero();
        }
        else if (this.CompareTag("minus20ins"))
        {
            obj.GetComponent<Insanity>().DecreaseInsanity(25);
        }
        else if (this.CompareTag("End"))
        {
            obj.GetComponent<Insanity>().Gameend();
        }
        else
        {
            Debug.Log("Unknown collider type. This should not remove or add insanity. What am I meant to do?");
        }
    }

    void Start()
    {
        obj = GameObject.Find("Player");
    }

    void Update()
    {
    }


}
