using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button load;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("SaveGame"))
        {
            load.interactable = true;
        } else {
            load.interactable = false;
        }
    }
}
