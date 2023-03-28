using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideDialog : Collidable
{
    public Animator animator;

    public string[] dialogs;

    private int phraseIndex;
    public Text dialogTitle;
    public Text dialogBox;

    protected override void Start()
    {
        base.Start();
        if(!GameManager.instance.mc.initialDialog)
        {
            GameManager.instance.menuOpen = true;
            animator.SetTrigger("show");
            initialPhrase();
            GameManager.instance.mc.initialDialog = true;
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            GameManager.instance.showText(GameManager.instance.interact.ToString(), 40, Color.white, transform.position + new Vector3(0, 0.40f), Vector3.zero, 0f);

            if(Input.GetKeyDown(GameManager.instance.interact) && !GameManager.instance.menuOpen && coll.name == "Player")
            {
                GameManager.instance.menuOpen = true;
                if(GameManager.instance.stage3)
                {
                    stage4Phrase();
                } else if(GameManager.instance.stage2) {
                    stage3Phrase();
                } else if(GameManager.instance.stage1) {
                    stage2Phrase();
                } else{
                    stage1Phrase();
                }
                animator.SetTrigger("show");
            }
        }
    }

    public void exitMenu()
    {
        GameManager.instance.menuOpen = false;
        animator.SetTrigger("hide");
    }

    private void initialPhrase()
    {
        dialogBox.text = dialogs[0];
    }

    private void stage1Phrase()
    {
        dialogTitle.text = "Ato 1";
        dialogBox.text = dialogs[1];
    }

    private void stage2Phrase()
    {
        dialogTitle.text = "Ato 2";
        dialogBox.text = dialogs[2];
    }

    private void stage3Phrase()
    {
        dialogTitle.text = "Ato 3";
        dialogBox.text = dialogs[3];
    }

    private void stage4Phrase()
    {
        dialogTitle.text = "Ato 4";
        dialogBox.text = dialogs[4];
    }
}
