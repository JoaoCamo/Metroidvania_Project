using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public MenuController mc;
    public Player player;
    public GameObject HUD;
    public MusicPlayer mp;

    public int playerGold;
    public bool menuOpen = true;
    public bool stage1 = false;
    public bool stage2 = false;
    public bool stage3 = false;

    private void Start()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(mc.gameObject);
            Destroy(HUD);
            Destroy(mp.gameObject);
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player.gameObject);
        DontDestroyOnLoad(mc.gameObject);
        DontDestroyOnLoad(HUD);
        DontDestroyOnLoad(mp.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void respawn()
    {
        mc.deathScreen.SetTrigger("hide");
        menuOpen = false;
        player.respawn();
        SceneManager.LoadScene("Scene1");
        mp.audioSource.clip = mp.music[1];
        mp.audioSource.Play();
    }

    public void OnSceneLoaded(Scene save, LoadSceneMode mode)
    {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }

    public void saveGame()
    {
        string save = "";
        int listHelper = player.gameObject.GetComponent<PlayerBuffController>().carriedPotions.Count;

        save += stage1.ToString() + "|";
        save += stage2.ToString() + "|";
        save += stage3.ToString() + "|";
        save += playerGold.ToString() + "|";

        save += player.hasSpeedBoots.ToString() + "|";
        save += player.armorLevel.ToString() + "|";
        save += player.gameObject.GetComponent<PlayerJump>().hasDoubleJump.ToString() + "|";
        save += player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel.ToString() + "|";

        save += mc.initialDialog.ToString() + "|";

        save += listHelper.ToString() + "|";

        if(listHelper > 0)
        {
            for(int i=0;i<listHelper;i++)
            {
                save += player.gameObject.GetComponent<PlayerBuffController>().carriedPotions[i].ToString() + "|";
            }
        }

        PlayerPrefs.SetString("SaveGame",save);
    }

    public void loadSaveGame(Scene save, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= loadSaveGame;

        if(!PlayerPrefs.HasKey("SaveGame"))
        {
            return;
        }

        string[] saveData = PlayerPrefs.GetString("SaveGame").Split("|");

        stage1 = bool.Parse(saveData[0]);
        stage2 = bool.Parse(saveData[1]);
        stage3 = bool.Parse(saveData[2]);

        playerGold = int.Parse(saveData[3]);
        player.hasSpeedBoots = bool.Parse(saveData[4]);
        if(player.hasSpeedBoots)
        {
            player.xSpeed = 2f;
        }
        player.armorLevel = int.Parse(saveData[5]);
        player.loadHealth();
        player.gameObject.GetComponent<PlayerJump>().hasDoubleJump = bool.Parse(saveData[6]);
        player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel = int.Parse(saveData[7]);

        mc.initialDialog = bool.Parse(saveData[8]);

        int listHelper = int.Parse(saveData[9]);
        if(listHelper > 0)
        {
            for(int i=0;i<listHelper;i++)
            {
                player.gameObject.GetComponent<PlayerBuffController>().carriedPotions.Add(int.Parse(saveData[9+(i+1)]));
            }
            player.gameObject.GetComponent<PlayerBuffController>().UpdatePotionAni();
        }
    }

    public void newGame()
    {
        PlayerPrefs.DeleteKey("SaveGame");
        SceneManager.LoadScene("Scene1");
        mp.audioSource.clip = mp.music[1];
        mp.audioSource.Play();
    }

    public void LoadGame()
    {
        SceneManager.sceneLoaded += loadSaveGame;
        SceneManager.LoadScene("Scene1");
        menuOpen = false;
        mp.audioSource.clip = mp.music[1];
        mp.audioSource.Play();
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        mp.audioSource.clip = mp.music[0];
        mp.audioSource.Play();
    }

    public void returnToCity()
    {
        mc.stageComplete.SetTrigger("hide");
        menuOpen = false;
        player.hitpoint = player.maxHitpoint;
        player.HealthBarChange();
        SceneManager.LoadScene("Scene1");
        mp.audioSource.clip = mp.music[1];
        mp.audioSource.Play();
    }

    public void exit()
    {
        Application.Quit();
    }
}
