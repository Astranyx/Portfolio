using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float mouseSens, cameraX, cameraY;

    public Vector3 rotation { get; private set; }

    void Start()
    {
        mouseSens = 1;
    }

    void Update()
    {
        cameraX += mouseSens * Input.GetAxis("Mouse X");
        cameraY -= mouseSens * Input.GetAxis("Mouse Y");
        cameraY = cameraY < -90 ? -90 : cameraY;
        cameraY = cameraY > 90 ? 90 : cameraY;

        rotation = new Vector3(0, cameraX, 0);

        transform.eulerAngles = new Vector3(cameraY, cameraX, 0);
    }
}