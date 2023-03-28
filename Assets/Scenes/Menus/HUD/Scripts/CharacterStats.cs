using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    private Animator animator;

    public List<Sprite> potionSprites;
    public Image[] potionImages;
    public Text health;
    public Text damage;
    public Text gold;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(GameManager.instance.inventory) && !GameManager.instance.menuOpen)
        {
            GameManager.instance.menuOpen = true;
            updateMenu();
            animator.SetTrigger("show");
        }
    }

    public void exitMenu()
    {
        GameManager.instance.menuOpen = false;
        animator.SetTrigger("hide");
    }

    private void updateMenu()
    {
        health.text = "Vida : " + GameManager.instance.player.hitpoint;
        damage.text = "Ataque : " + GameManager.instance.player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().SwordDamage[GameManager.instance.player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel];
        gold.text = "Ouro : " + GameManager.instance.playerGold;

        for(int i=0;i<3;i++)
        {
            potionImages[i].sprite = potionSprites[0];
        }

        for(int i=0;i<GameManager.instance.player.gameObject.GetComponent<PlayerBuffController>().carriedPotions.Count; i++)
        {
            if(GameManager.instance.player.gameObject.GetComponent<PlayerBuffController>().carriedPotions[i] == 0)
            {
                potionImages[i].sprite = potionSprites[1];
            } else {
                potionImages[i].sprite = potionSprites[2];
            }
        }
    }
}
