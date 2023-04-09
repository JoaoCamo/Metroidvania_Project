using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraEnding : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator =  GetComponent<Animator>();
    }

    public void extraEnding()
    {
        animator.SetTrigger("show");
        GameManager.instance.mc.extra = true;
        GameManager.instance.saveAchievements(5);
    }

    public void endingReturnToMainMenu()
    {
        GameManager.instance.returnToMainMenu();
    }
}
