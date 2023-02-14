using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void newGame()
    {
        GameManager.instance.newGame();
    }

    public void LoadGame()
    {
        GameManager.instance.LoadGame();
    }
}
