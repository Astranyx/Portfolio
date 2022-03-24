using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RampScript : MonoBehaviour
{
    public GameObject Ramp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Objective")
        {
            Ramp.SetActive(true);
        }
    }

}
