using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public Image[] images;
    public Sprite[] achievementsSprites;
    public Text[] achievementsTexts;

    private bool achievement1;
    private bool achievement2;
    private bool achievement3;
    
    private void Start()
    {
        updateMenu();
    }

    public void updateMenu()
    {
        if(!PlayerPrefs.HasKey("Achievements"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("Achievements").Split("|");

        if (bool.Parse(data[0]))
        {
            images[0].sprite = achievementsSprites[0];
            achievementsTexts[0].text = "Caçador de Vampiros\nCompletou o Ato 3";
        }
        if (bool.Parse(data[1]))
        {
            images[1].sprite = achievementsSprites[1];
            achievementsTexts[1].text = "Final 1\nEscolheu se juntar aos vampiros";
        }
        if (bool.Parse(data[2]))
        {
            images[2].sprite = achievementsSprites[2];
            achievementsTexts[2].text = "Final 2\nDerrotou o lorde dos vampiros";
        }
    }
}
