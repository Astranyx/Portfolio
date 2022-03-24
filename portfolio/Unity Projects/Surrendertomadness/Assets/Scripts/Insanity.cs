using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class Insanity : MonoBehaviour
{

    private int m_Insanity { get; set; }
    private float m_timeLeft { get; set; }
    private GameObject[] InsanityBlocks;
    private GameObject[] inactiveInsanityBlocks;

    private GameObject[] higherInsanityBlocks;
    private GameObject[] inactiveHigherInsanityBlocks;

    // Use this for initialization
    void Start()
    {
        SetInsanityZero();

        if (InsanityBlocks == null)
        {
            InsanityBlocks = GameObject.FindGameObjectsWithTag("Insanity50Active");
            Debug.Log(string.Format("Insanity Blocks Count = {0}", InsanityBlocks.Count()));
        }
        if (inactiveInsanityBlocks == null)
        {
            inactiveInsanityBlocks = GameObject.FindGameObjectsWithTag("Insanity50");
        }
        if (higherInsanityBlocks == null)
        {
            higherInsanityBlocks = GameObject.FindGameObjectsWithTag("Insanity75Active");
        }
        if (inactiveHigherInsanityBlocks == null)
        {
            inactiveHigherInsanityBlocks = GameObject.FindGameObjectsWithTag("Insanity75");
        }

    }


    public int GetInsanity()
    {
        return m_Insanity;
    }

    public float GetTimer()
    {
        return m_timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInsanityLevel();
    }

    public void IncreaseInsanity(int value)
    {
        if ((m_Insanity + value) > 100)
        {
            m_Insanity = 100;
        }
        else
        {
            m_Insanity += value;
        }
    }

    public void DecreaseInsanity(int value)
    {
        if ((m_Insanity - value) < 0)
        {
            m_Insanity = 0;
        }
        else
        {
            m_Insanity -= value;
        }
    }

    public void SetInsanityZero()
    {
        m_Insanity = 0;
    }

    void ResetTimer()
    {
        m_timeLeft = 10.0f;
    }

    void DeactivateInsanityBlocks()
    {
        foreach (GameObject go in InsanityBlocks)
        {
            if (go.activeSelf == true)
            {
                go.SetActive(false);
            }
        }
        foreach (GameObject aGo in inactiveInsanityBlocks)
        {
            if (aGo.activeSelf == false)
            {
                aGo.SetActive(true);
            }
        }
    }

    void DeactivateHigherInsanityBlocks()
    {
        foreach (GameObject go in higherInsanityBlocks)
        {
            if (go.activeSelf == true)
            {
                go.SetActive(false);
            }
        }
        foreach (GameObject aGo in inactiveHigherInsanityBlocks)
        {
            if (aGo.activeSelf == false)
            {
                aGo.SetActive(true);
            }
        }
    }


    public void Gameend()
    {
        SceneManager.LoadScene("Credits");
    }

    void ActivateInsanityBlocks()
    {
        foreach (GameObject go in InsanityBlocks)
        {
            go.SetActive(true);
        }
        foreach (GameObject aGo in inactiveInsanityBlocks)
        {
            aGo.SetActive(false);
        }
    }

    void ActivateHigherInsanityBlocks()
    {
        foreach (GameObject go in higherInsanityBlocks)
        {
            go.SetActive(true);
        }
        foreach (GameObject aGo in inactiveHigherInsanityBlocks)
        {
            aGo.SetActive(false);
        }
    }

    void MaxInsanityCountDown()
    {
        m_timeLeft -= Time.deltaTime;
        if (m_timeLeft < 0)
        {
            SceneManager.LoadScene("Game over");
        }
    }

    void CheckInsanityLevel()
    {
        if (m_Insanity >= 50 && m_Insanity <= 75)
        {
            DeactivateHigherInsanityBlocks();
            ActivateInsanityBlocks();
            ResetTimer();
        }

        else if (m_Insanity > 75 && m_Insanity < 100)
        {
            DeactivateInsanityBlocks();
            ActivateHigherInsanityBlocks();
            ResetTimer();
        }

        else if (m_Insanity == 100)
        {
            MaxInsanityCountDown();
        }
        else
        {
            ResetTimer();
            DeactivateInsanityBlocks();
            DeactivateHigherInsanityBlocks();
        }
    }
}