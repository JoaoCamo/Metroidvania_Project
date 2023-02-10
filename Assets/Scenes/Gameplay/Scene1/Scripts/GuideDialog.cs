using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideDialog : MonoBehaviour
{
    public Animator animator;

    public DialogPhrases[] dp;

    private int phraseIndex;
    public Text DialogBox;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.instance.menuOpen = true;
        animator.SetTrigger("show");
    }

    private void exitMenu()
    {
        GameManager.instance.menuOpen = false;
        animator.SetTrigger("hide");
    }

    public void phraseDisplayer()
    {

    }
}
