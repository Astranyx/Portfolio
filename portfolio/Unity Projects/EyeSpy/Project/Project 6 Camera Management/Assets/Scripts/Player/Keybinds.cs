using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keybinds : MonoBehaviour
{

    public GameObject Player;
    public GameObject Playercamera;
    public GameObject Wallcamera;
    public GameObject Objective;
    public GameObject Goal;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            Playercamera.SetActive(!Playercamera.activeInHierarchy);
            Wallcamera.SetActive(!Wallcamera.activeInHierarchy);
            Goal.SetActive(!Goal.activeInHierarchy);
            

        }
        if (Input.GetKeyDown(KeyCode.P) && (Objective.GetComponent<MeshRenderer>().enabled == false))
        {
            Objective.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("toggle");
        }
        else if (Input.GetKeyDown(KeyCode.P) && (Objective.GetComponent<MeshRenderer>().enabled == true))
        {
            Objective.GetComponent<MeshRenderer>().enabled = false;

        }
    }
}