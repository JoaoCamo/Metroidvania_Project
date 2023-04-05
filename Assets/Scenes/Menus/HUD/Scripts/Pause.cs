using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.menuOpen)
        {
            Time.timeScale = 0;
            animator.SetTrigger("show");
            GameManager.instance.menuOpen = true;
        }
    }

    public void exitMenu()
    {
        Time.timeScale = 1;
        animator.SetTrigger("hide");
        GameManager.instance.menuOpen = false;
    }
}
