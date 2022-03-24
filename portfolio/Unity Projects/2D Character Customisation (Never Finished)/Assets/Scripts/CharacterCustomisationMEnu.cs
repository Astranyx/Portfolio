using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CharacterCustomisationMEnu : MonoBehaviour
{
    public List<OutfitChanger> outfitChangers = new List<OutfitChanger>();

    public void RandomizeCharacter()
    {
         foreach (OutfitChanger changer in outfitChangers)
        {
            changer.Randomize();
        }
    }

    public void Submit()
    {
        ////HOW DO MAKE SAVE WITHOUT OVERWRITING START??????///
        SceneManager.LoadScene(1);
    }
}
