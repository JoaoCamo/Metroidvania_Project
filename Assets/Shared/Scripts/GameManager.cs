using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public MenuController mc;
    public Player player;

    public int playerGold;

    private void Awake()
    {
        instance = this;
    }
}
