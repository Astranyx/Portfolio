using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleplayer : MonoBehaviour {

    public void SinglePlayer()
    {
        SceneManager.LoadScene("Level1");
    }
}