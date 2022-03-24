using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WardrobeManager : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("CharacterChanging", LoadSceneMode.Additive);
    }
}