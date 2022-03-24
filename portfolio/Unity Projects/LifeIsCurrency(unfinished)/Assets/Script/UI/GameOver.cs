using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    public void restart()
    {
        SceneManager.LoadScene("Hell");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
