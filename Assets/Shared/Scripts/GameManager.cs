using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public MenuController mc;
    public Player player;

    public int playerGold;
    public bool menuOpen = false;
    public bool stage1 = false;
    public bool stage2 = false;
    public bool stage3 = false;

    private void Awake()
    {
        instance = this;
    }
}
