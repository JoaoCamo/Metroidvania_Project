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
