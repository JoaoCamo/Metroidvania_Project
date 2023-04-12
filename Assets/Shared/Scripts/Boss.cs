using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public bool stage1;
    public bool stage2;
    public bool stage3;

    public int bossGold;

    protected override void death()
    {
        alive = false;
        animator.SetTrigger("dead");
        enemyGoldDrop = bossGold;
        GameManager.instance.playerGold += enemyGoldDrop;

        if(stage1)
        {
            GameManager.instance.stage1 = true;
            GameManager.instance.saveAchievements(0);
        } else if(stage2) {
            GameManager.instance.stage2 = true;
            GameManager.instance.saveAchievements(1);
        } else {
            GameManager.instance.stage3 = true;
            GameManager.instance.saveAchievements(2);
        }

        GameManager.instance.menuOpen = true;
        GameManager.instance.mc.stageComplete.SetTrigger("show");
    }
}