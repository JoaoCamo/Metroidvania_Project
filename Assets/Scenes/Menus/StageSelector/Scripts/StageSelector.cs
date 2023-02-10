using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelector : MonoBehaviour
{
    public Animator animator;
    public List<Sprite> stageSprites;
    public Image[] stageImages;
    public Text stage2Text;
    public Text stage3Text;
    public Text stage4Text;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        updateMenu();
        GameManager.instance.menuOpen = true;
        animator.SetTrigger("show");
    }

    public void exitMenu()
    {
        GameManager.instance.menuOpen = false;
        animator.SetTrigger("hide");   
    }

    public void updateMenu()
    {
        if(GameManager.instance.stage1)
        {
            stageImages[0].sprite = stageSprites[0];
            stage2Text.text = "Pântano dos condenados";
        }
        if(GameManager.instance.stage2)
        {
            stageImages[1].sprite = stageSprites[1];
            stage3Text.text = "Cemiterio Esquecido";
        }
        if(GameManager.instance.stage3)
        {
            stageImages[2].sprite = stageSprites[2];
            stage4Text.text = "Castelo de Sangue";
        }
    }

    public void loadStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void loadStage2()
    {
        if(GameManager.instance.stage1)
        {
            SceneManager.LoadScene("Stage2");
        }
    }

    public void loadStage3()
    {
        if(GameManager.instance.stage2)
        {
            SceneManager.LoadScene("Stage3");
        }
    }

    public void loadStage4()
    {
        if(GameManager.instance.stage3)
        {
            SceneManager.LoadScene("Stage4");
        }
    }
}
