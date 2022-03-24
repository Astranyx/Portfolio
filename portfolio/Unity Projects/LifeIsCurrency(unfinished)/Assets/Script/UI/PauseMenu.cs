using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Transform canvas;
    public Transform gameUI;
    public static bool gameOn;

     void Start()
     {
        //setting canvas to be false at start
        canvas.gameObject.SetActive(false);

        gameOn = true;
     }

    // Update is called once per frame
    void Update ()
    {
        //if escape button is pressed pauses game by setting time scale to 0
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                gameUI.gameObject.SetActive(false);
                gameOn = false;
                Time.timeScale = 0;
            }
            else
            {
                //setting time scale back to 1 when escape button is pressed again
                canvas.gameObject.SetActive(false);
                gameUI.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                gameOn = true;
            }
        }
	}
}
