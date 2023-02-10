using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blacksmith : MonoBehaviour
{
    private int[] swordPrices = {25,45,70,110,200};
    private int[] armorPrices = {35,50,80,115,190};

    public Animator animator;
    public Text swordPriceText;
    public Text armorPriceText;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name == "Player" && !GameManager.instance.menuOpen)
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
            updateMenu();
        } else {
            return;
        }
    }

    private void updateMenu()
    {
        if((swordPrices.Length-1) == GameManager.instance.player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel)
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
