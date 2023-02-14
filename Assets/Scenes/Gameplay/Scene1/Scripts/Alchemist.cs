using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alchemist : Collidable
{
    public Animator animator;

    public Text healthPotionPriceText;
    public Text strengthPotionPriceText;

    protected override void OnCollide(Collider2D coll)
    {
        if(Input.GetKeyDown(KeyCode.E) && !GameManager.instance.menuOpen && coll.name == "Player")
        {
            updateMenu();
            animator.SetTrigger("show");
            GameManager.instance.menuOpen = true;
        }    
    }

    public void exitMenu()
    {
        animator.SetTrigger("hide");
        GameManager.instance.menuOpen = false;
    }

    public void buyHealthPotion()
    {
        if(GameManager.instance.player.gameObject.GetComponent<PlayerBuffController>().carriedPotions.Count == 3)
        {
            return;
        }
        if(GameManager.instance.playerGold >= 20)
        {
            GameManager.instance.playerGold -= 20;
            GameManager.instance.player.gameObject.GetComponent<PlayerBuffController>().carriedPotions.Add(0);
            updateMenu();
            GameManager.instance.player.gameObject.GetComponent<PlayerBuffController>().UpdatePotionAni();
        } else {
            return;
        }
    }

    public void buyStrengthPotion()
    {
        if(GameManager.instance.player.gameObject.GetComponent<PlayerBuffController>().carriedPotions.Count == 3)
        {
            return;
        }
        if(GameManager.instance.playerGold >= 50)
        {
            GameManager.instance.playerGold -= 50;
            GameManager.instance.player.gameObject.GetComponent<PlayerBuffController>().carriedPotions.Add(1);
            updateMenu();
            GameManager.instance.player.gameObject.GetComponent<PlayerBuffController>().UpdatePotionAni();
        } else {
            return;
        }
    }

    private void updateMenu()
    {
        if(GameManager.instance.player.gameObject.GetComponent<PlayerBuffController>().carriedPotions.Count == 3)
        {
            healthPotionPriceText.text = "Max";
            strengthPotionPriceText.text = "Max";
        } else {
            healthPotionPriceText.text = "20";
            strengthPotionPriceText.text = "50";
        }

    }
}
