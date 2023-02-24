using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactVendor : Collidable
{
    public Animator animator;
    public Text doubleJumpPriceText;
    public Text speedBootsPriceText;

    private AudioSource audioSource;

    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(Input.GetKeyDown(KeyCode.E) && !GameManager.instance.menuOpen && coll.name == "Player")
        {
            animator.SetTrigger("show");
            GameManager.instance.menuOpen = true;
            updateMenu();
        }    
    }

    public void exitMenu()
    {
        animator.SetTrigger("hide");
        GameManager.instance.menuOpen = false;
    }

    public void unlockDoubleJump()
    {
        if(GameManager.instance.player.gameObject.GetComponent<PlayerJump>().hasDoubleJump)
        {
            return;
        }
        if(GameManager.instance.playerGold >= 250)
        {
            GameManager.instance.playerGold -= 250;
            GameManager.instance.player.gameObject.GetComponent<PlayerJump>().hasDoubleJump = true;
            updateMenu();
            audioSource.Play();
        } else {
            return;
        }
    }

    public void unlockSpeedBoots()
    {
        if(GameManager.instance.player.hasSpeedBoots)
        {
            return;
        }
        if(GameManager.instance.playerGold >= 400)
        {
            GameManager.instance.playerGold -= 400;
            GameManager.instance.player.hasSpeedBoots = true;
            GameManager.instance.player.xSpeed = 2f;
            updateMenu();
            audioSource.Play();
        } else {
            return;
        }
    }

    private void updateMenu()
    {
        if(GameManager.instance.player.gameObject.GetComponent<PlayerJump>().hasDoubleJump)
        {
            doubleJumpPriceText.text = "---";
        }
        if(GameManager.instance.player.hasSpeedBoots)
        {
            speedBootsPriceText.text = "---";
        }
    }
}
