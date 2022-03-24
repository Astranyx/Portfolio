using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    float speed;
    Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;       
        speed = 35f;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.rotation = cam.transform.rotation;
    }
}
