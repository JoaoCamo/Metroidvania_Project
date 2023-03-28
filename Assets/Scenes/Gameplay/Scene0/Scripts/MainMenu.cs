using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button load1;
    public Button load2;

    private void Awake()
    {
        updateMenu();
    }

    public void newGame()
    {
        GameManager.instance.newGame();
    }

    public void LoadGameSave(string saveName)
    {
        GameManager.instance.LoadGame(saveName);
    }

    public void deleteSave(string saveName)
    {
        PlayerPrefs.DeleteKey(saveName);
        updateMenu();
    }

    private void updateMenu()
    {
        if(PlayerPrefs.HasKey("SaveGame1"))
        {
            load1.interactable = true;
        } else {
            load1.interactable = false;
        }

        if(PlayerPrefs.HasKey("SaveGame2"))
        {
            load2.interactable = true;
        } else {
            load2.interactable = false;
        }
    }

    public void exitGame()
    {
        GameManager.instance.exit();
    }
}
