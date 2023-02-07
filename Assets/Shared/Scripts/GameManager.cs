using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public MenuController mc;
    public Player player;

    private void Awake()
    {
        instance = this;
    }

    public void HealthBarChange()
    {
        float ratio = (float)player.hitpoint / (float)player.maxHitpoint;
        mc.healthBar.localScale = new Vector3(ratio, 1, 1);
    }
}
