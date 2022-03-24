using System;
using UnityEngine;
using UnityEngine.UI;

    public class InsanityNumberCounter : MonoBehaviour
    {

        private int CurrentInsanity;
        const string display = "{0} Insanity";
        private Text m_Text;


        private void Start()
        {
            m_Text = GetComponent<Text>();
        }


        private void Update()
        {
            CurrentInsanity = GameObject.Find("Player").GetComponent<Insanity>().GetInsanity();
            m_Text.text = string.Format(display, CurrentInsanity);
        }
    }
