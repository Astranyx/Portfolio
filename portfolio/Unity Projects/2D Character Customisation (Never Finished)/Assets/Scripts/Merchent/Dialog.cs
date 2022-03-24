using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialog : MonoBehaviour
{
    //Must Define all the things :>
    public GameObject DialogBox;                                                                                                                        
    public GameObject Textbox;                                                                                                                          
    public GameObject Choice1;                                                                                                                          
    public GameObject Choice2;                                                                                                                          
    //Getting the Dialog Box to appear.                                                                                                                 
    public void OnTriggerEnter2D(Collider2D collision)                                                                                                  
    {                                                                                                                                                   
                                                                                                                                 
     Time.timeScale = 0;                                                                                                                                     
     DialogBox.SetActive(true);                                                                                                                              
    }                                                                                                                                                       
 //if first option is picked this code will run                                                                                                          
       public void ChoiceOption1 ()
       {
        
        Textbox.GetComponent<TextMeshProUGUI>().text = "Take Your Time!" ;
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
        DialogBox.SetActive(false);
       }
//If Second option is picked this code will run
public void ChoiceOption2()
        {
        
        Textbox.GetComponent<TextMeshProUGUI>().text = "Would you like to purchase a new look?";
        DialogBox.SetActive(false);
        Time.timeScale = 1;
        }

}
