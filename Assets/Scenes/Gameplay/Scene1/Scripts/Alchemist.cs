using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alchemist : Collidable
{
    public Animator animator;

    public Text healthPotionPriceText;
    public Text strengthPotionPriceText;

    private AudioSource audioSource;

    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            GameManager.instance.showText("E", 40, Color.white, transform.position + new Vector3(0, 0.40f), Vector3.zero, 0f);

            if(Input.GetKeyDown(KeyCode.E) && !GameManager.instance.menuOpen)
            {
                updateMenu();
                animator.SetTrigger("show");
                GameManager.instance.menuOpen = true;
            }
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
            audioSource.Play();
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
            audioSource.Play();
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
