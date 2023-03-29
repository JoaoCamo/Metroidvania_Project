using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBuffController : MonoBehaviour
{
    public List<int> carriedPotions = new List<int>();
    public int selectedPotion = 1;

    public Animator animator;

    private bool strengthPotionActivated = false;
    private float strengthPotionDuration = 15f;
    private float currentTime = 0;

    private void Update()
    {
        potionSelector();
        usePotion();
        if(strengthPotionActivated)
        {
            strengthPotionCountdown();
        }
    }

    private void usePotion()
    {
        if(Input.GetKeyDown(GameManager.instance.usePotion))
        {
            if(carriedPotions.Count > 0)
            {
                if(carriedPotions[selectedPotion-1] == 0)
                {
                    healthPotion();
                    GameManager.instance.showText("+ 20", 50, Color.green, transform.position, Vector3.up * 75, 1.5f);
                    gameObject.GetComponent<Player>().audioSource.PlayOneShot(gameObject.GetComponent<Player>().playerSounds[2]);
                } else {
                    strengthPotion();
                    GameManager.instance.showText("Dano 2x", 50, Color.magenta, transform.position, Vector3.up * 75, 1.5f);
                    gameObject.GetComponent<Player>().audioSource.PlayOneShot(gameObject.GetComponent<Player>().playerSounds[3]);
                }
            }
        }
    }

    private void potionSelector()
    {
        if(Input.GetKeyDown(GameManager.instance.changePotion))
        {
            if(carriedPotions.Count > 0)
            {
                if(selectedPotion < carriedPotions.Count)
                {
                    selectedPotion ++;
                    UpdatePotionAni();
                } else if(selectedPotion == carriedPotions.Count) {
                    selectedPotion = 1;
                    UpdatePotionAni();
                }
            }
        }
    }

    public void healthPotion()
    {
        if(gameObject.GetComponent<Player>().hitpoint + 20 > gameObject.GetComponent<Player>().maxHitpoint)
        {
            gameObject.GetComponent<Player>().hitpoint = gameObject.GetComponent<Player>().maxHitpoint;
            gameObject.GetComponent<Player>().HealthBarChange();
            carriedPotions.RemoveAt((selectedPotion-1));
            if(selectedPotion > carriedPotions.Count & selectedPotion != 1)
            {
                selectedPotion--;
            }
            UpdatePotionAni();
        } else {
            gameObject.GetComponent<Player>().hitpoint += 20;
            gameObject.GetComponent<Player>().HealthBarChange();
            carriedPotions.RemoveAt((selectedPotion-1));
            if(selectedPotion > carriedPotions.Count && selectedPotion != 1)
            {
                selectedPotion--;
            }
            UpdatePotionAni();
        }
        GameManager.instance.showParticle(transform.position, 1, 5f);
    }

    public void strengthPotion()
    {
        strengthPotionActivated = true;
        gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().SwordDamage[gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel] *= 2;
        carriedPotions.RemoveAt((selectedPotion-1));
        if(selectedPotion > carriedPotions.Count && selectedPotion != 1)
        {
            selectedPotion--;
        }
        UpdatePotionAni();
        GameManager.instance.showParticle(transform.position, 2, 15f, this.transform);
    }

    public void strengthPotionCountdown()
    {
        if(currentTime < strengthPotionDuration)
        {
            currentTime += Time.deltaTime;
        } else {
            strengthPotionActivated = false;
            currentTime = 0;
            gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().SwordDamage[gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel] /= 2;
        }
    }

    public void UpdatePotionAni()
    {
        if(carriedPotions.Count > 0)
        {
            if(carriedPotions[selectedPotion-1] == 0)
            {
                animator.ResetTrigger("purple");
                animator.ResetTrigger("empty");
                animator.SetTrigger("red");
            } else {
                animator.ResetTrigger("red");
                animator.ResetTrigger("empty");
                animator.SetTrigger("purple");
            }
        } else {
            animator.ResetTrigger("purple");
            animator.ResetTrigger("red");
            animator.SetTrigger("empty");
        }
    }
}
