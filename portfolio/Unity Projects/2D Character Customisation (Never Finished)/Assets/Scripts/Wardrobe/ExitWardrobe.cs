using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitWardrobe : MonoBehaviour
{
    public GameObject _itemManager;
    public void UnloadScene()
    {
        _itemManager.GetComponent<ItemManager>().Save();
        _itemManager.GetComponent<ItemManager>().UpdateLook = true;

        Time.timeScale = 1;
        SceneManager.UnloadScene("CharacterChanging");
    }
     public void Saveoutfit()
    {
        _itemManager.GetComponent<ItemManager>().Save();
        _itemManager.GetComponent<ItemManager>().UpdateLook = true;
    }

    void Update()
    {

    }
}