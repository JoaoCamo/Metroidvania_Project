using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blacksmith : Collidable
{
    private int[] swordPrices = {30,55,85,135,300};
    private int[] armorPrices = {35,50,80,145,250};

    public Animator animator;
    public Text swordPriceText;
    public Text armorPriceText;

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

    public void tryUpgradeSword()
    {
        if(swordPrices.Length <= GameManager.instance.player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel)
        {
            return;
        }
        if(GameManager.instance.playerGold >= swordPrices[GameManager.instance.player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel])
        {
            GameManager.instance.playerGold -= swordPrices[GameManager.instance.player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel];
            GameManager.instance.player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().upgradeSword();
            updateMenu();
            audioSource.Play();
        } else {
            return;
        }
    }

    public void tryUpgradeArmor()
    {
        if(armorPrices.Length <= GameManager.instance.player.armorLevel)
        {
            return;
        }
        if(GameManager.instance.playerGold >= armorPrices[GameManager.instance.player.armorLevel])
        {
            GameManager.instance.playerGold -= armorPrices[GameManager.instance.player.armorLevel];
            GameManager.instance.player.upgradeArmor();
            GameManager.instance.player.HealthBarChange();
            updateMenu();
            audioSource.Play();
        } else {
            return;
        }
    }

    private void updateMenu()
    {
        if((swordPrices.Length) == GameManager.instance.player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel)
        {
            swordPriceText.text = "---";
        } else {
            swordPriceText.text = swordPrices[GameManager.instance.player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel].ToString();
        }

        if(armorPrices.Length == GameManager.instance.player.armorLevel)
        {
            armorPriceText.text = "---";
        } else {
            armorPriceText.text = armorPrices[GameManager.instance.player.armorLevel].ToString();
        }
    }
}
