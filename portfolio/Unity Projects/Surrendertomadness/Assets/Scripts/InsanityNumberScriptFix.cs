using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Text))]
public class InsanityNumberScriptFix : MonoBehaviour {

    private int CurrentInsanity;
    private float CurrentTimer;
    const string display = "{0} Insanity";
    const string timerDisplay = "{0} Insanity \r\n Time until pure insanity : {1}";
    private Text m_Text;


    private void Start()
    {
        m_Text = GetComponent<Text>();
    }


    private void Update()
    {
        CurrentInsanity = GameObject.Find("Player").GetComponent<Insanity>().GetInsanity();

        if (CurrentInsanity == 100)
        {
            CurrentTimer = GameObject.Find("Player").GetComponent<Insanity>().GetTimer();
            m_Text.text = string.Format(timerDisplay, CurrentInsanity, CurrentTimer);
            Debug.Log(CurrentTimer);
        }
        else
        {
            m_Text.text = string.Format(display, CurrentInsanity);
        }
    }
}
