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
        GameManager.instance.menuOpen = false;
        SceneManager.LoadScene("Stage1");
        GameManager.instance.mp.audioSource.clip = GameManager.instance.mp.music[2];
        GameManager.instance.mp.audioSource.Play();
    }

    public void loadStage2()
    {
        if(GameManager.instance.stage1)
        {
            GameManager.instance.menuOpen = false;
            SceneManager.LoadScene("Stage2");
            GameManager.instance.mp.audioSource.clip = GameManager.instance.mp.music[3];
            GameManager.instance.mp.audioSource.Play();
        }
    }

    public void loadStage3()
    {
        if(GameManager.instance.stage2)
        {
            GameManager.instance.menuOpen = false;
            SceneManager.LoadScene("Stage3");
            GameManager.instance.mp.audioSource.clip = GameManager.instance.mp.music[4];
            GameManager.instance.mp.audioSource.Play();
        }
    }

    public void loadStage4()
    {
        if(GameManager.instance.stage3)
        {
            GameManager.instance.menuOpen = false;
            SceneManager.LoadScene("Stage4");
            GameManager.instance.mp.audioSource.clip = GameManager.instance.mp.music[5];
            GameManager.instance.mp.audioSource.Play();
        }
    }
}
