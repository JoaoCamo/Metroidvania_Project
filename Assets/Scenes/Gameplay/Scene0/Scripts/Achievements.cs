using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public Image[] images;
    public Sprite[] achievementsSprites;
    public Text[] achievementsTexts;
    public GameObject[] buttons;

    private void Start()
    {
        updateMenu();
    }

    public void updateMenu()
    {
        firstPage();
    }

    public void firstPage()
    {
        resetAchievements();
        if(PlayerPrefs.HasKey("Achievements"))
        {
            string[] data = PlayerPrefs.GetString("Achievements").Split("|");
            if (bool.Parse(data[0]))
            {
                images[0].sprite = achievementsSprites[0];
                achievementsTexts[0].text = "Colinas Mágicas\nCompletou o Ato 1";
            }
            if (bool.Parse(data[1]))
            {
                images[1].sprite = achievementsSprites[1];
                achievementsTexts[1].text = "Pântano Retorcido\nCompletou o Ato 2";
            }
            if (bool.Parse(data[2]))
            {
                images[2].sprite = achievementsSprites[2];
                achievementsTexts[2].text = "Caçador de Vampiros\nCompletou o Ato 3";
            }
        }
        
        buttons[0].SetActive(false);
        buttons[1].SetActive(true);
    }

    public void secondPage()
    {
        resetAchievements();
        if (PlayerPrefs.HasKey("Achievements"))
        {
            string[] data = PlayerPrefs.GetString("Achievements").Split("|");
            if (bool.Parse(data[3]))
            {
                images[0].sprite = achievementsSprites[3];
                achievementsTexts[0].text = "Final 1\nEscolheu se juntar aos vampiros";
            }
            if (bool.Parse(data[4]))
            {
                images[1].sprite = achievementsSprites[4];
                achievementsTexts[1].text = "Final 2\nDerrotou o lorde dos vampiros";
            }
            if (bool.Parse(data[5]))
            {
                images[2].sprite = achievementsSprites[5];
                achievementsTexts[2].text = "Fumo Fumo\nFumo Fumo";
            }
        }
        buttons[0].SetActive(true);
        buttons[1].SetActive(false);
    }

    private void resetAchievements()
    {
        for (int i = 0; i < 3; i++)
        {
            images[i].sprite = achievementsSprites[6];
            achievementsTexts[i].text = "???";
        }
    }
}
