using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactVendor : MonoBehaviour
{
    public Animator animator;
    public Text doubleJumpPriceText;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name == "Player" && !GameManager.instance.menuOpen)
        {
            animator.SetTrigger("show");
            GameManager.instance.menuOpen = true;
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
    }
}
