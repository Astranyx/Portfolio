using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class unloadCurrentScene : MonoBehaviour
{
   
    public void UnloadScene()
    {
        Time.timeScale = 1;
        SceneManager.UnloadScene("Shop");
    }

   
    void Update()
    {
        
    }
}
