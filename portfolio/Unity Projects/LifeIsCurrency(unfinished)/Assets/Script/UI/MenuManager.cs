using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Transform canvas;
    public Transform gameUI;

    public static int upPrice;
    int upMultiplier;

    int escPrice;

    public Text curPriceText;

    public GameObject nukebtn;
    public GameObject blinkbtn;
    public GameObject petbtn;
    public GameObject spdbtn;
    public GameObject escpButton;
    private void Start()
    {
        upPrice = 10;
        upMultiplier = 5;
        escPrice = 10000;
        curPriceText.text = "Upgrade Price \n " + upPrice;
    }

    

    //when clicked on loads the level
    public void Playgame()
    {
        SceneManager.LoadScene("Hell");
    }

    //when clicked on resumes the game
    public void Resume()
    {
        canvas.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
        PauseMenu.gameOn = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    //when clicked on loads the main menu scene 
    public void BackToMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Main Menu");
    }

    //when clicked on exits game
    public void Exit()
    {
        Application.Quit();
    }


    ////////////
    //  SHOP  //
    ////////////

    public void IncreasePrice()
    {
        PlayerStats.soulCount -= upPrice;
        upPrice += upMultiplier;
        curPriceText.text = "Upgrade Price \n " + upPrice;
    }
    
    public void atkButton()
    {      
        PlayerStats.meleeDamage += 2;
        IncreasePrice();
    }

    public void cleaveButton()
    {       
        PlayerStats.coneSizeMod += 40;
        IncreasePrice();
    }

    public void soulButton()
    {        
        PlayerStats.soulMod += 3;
        IncreasePrice();
    }

    public void speedButton()
    {
        if(PlayerStats.attackRate >= 0.4f)
        {
            PlayerStats.rateMod += 0.3f;
            IncreasePrice();
        }
        else if (PlayerStats.attackRate < 0.4f)
        {
            spdbtn.SetActive(false);
        }        
    }

    public void projectileButton()
    {
        PlayerStats.rangedSize += 40;
        PlayerStats.rangedDamage += 2;
        IncreasePrice();
    }

    public void rangeButton()
    {        
        PlayerStats.rangeDist += 0.5f;
        IncreasePrice();
    }

    public void petrButton()
    {        
        PlayerStats.canPetrify = true;
        petbtn.SetActive(false);
        IncreasePrice();       
    }

    public void blinkButton()
    {       
        PlayerStats.canBlink = true;
        blinkbtn.SetActive(false);
        IncreasePrice();        
    }

    public void nukeButton()
    {        
        PlayerStats.canNuke = true;
        nukebtn.SetActive(false);
        IncreasePrice();
        
    }

    public void chargeButton()
    {        
        PlayerStats.chargeMod -= 0.4f;
        IncreasePrice();
    }

    public void maxChargeButton()
    {        
        //increase max charge, decrease charge rate by half of the recovery upgrade
        PlayerStats.chargeMod += 0.6f;
        PlayerStats.chargeTotal += 1;
        IncreasePrice();
    }

    public void escapeButton()
    {
        PlayerStats.soulCount -= escPrice;
        SceneManager.LoadScene("Win");      
    }
    
}