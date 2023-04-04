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
    public FloatingTextManager ftm;
    public ParticlesManager pm;

    public Transform currentCheckpoint;

    public int playerGold;
    public bool menuOpen = true;
    public bool stage1 = false;
    public bool stage2 = false;
    public bool stage3 = false;

    public KeyCode attack;
    public KeyCode jump;
    public KeyCode usePotion;
    public KeyCode changePotion;
    public KeyCode inventory;
    public KeyCode interact;
    public KeyCode dash;

    private void Start()
    {
        loadKeys();
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(mc.gameObject);
            Destroy(HUD);
            Destroy(mp.gameObject);
            Destroy(ftm.gameObject);
            Destroy(pm.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player.gameObject);
        DontDestroyOnLoad(mc.gameObject);
        DontDestroyOnLoad(HUD);
        DontDestroyOnLoad(mp.gameObject);
        DontDestroyOnLoad(ftm.gameObject);
        DontDestroyOnLoad(pm.gameObject);

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
        player.transform.position = GameObject.Find("Checkpoint (0)").transform.position;
        currentCheckpoint = GameObject.Find("Checkpoint (0)").transform;
        pm.clearParticles();
    }

    public void showText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        ftm.show(msg, fontSize, color, position, motion, duration);
    }

    public void showParticle(Vector3 position, int type, float duration, Transform parent = null)
    {
        pm.show(position, type, duration, parent);
    }

    public void saveGame(string saveName)
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

        PlayerPrefs.SetString(saveName,save);
    }

    public void loadSaveGame(string saveName)
    {
        if(!PlayerPrefs.HasKey(saveName))
        {
            return;
        }

        string[] saveData = PlayerPrefs.GetString(saveName).Split("|");

        stage1 = bool.Parse(saveData[0]);
        stage2 = bool.Parse(saveData[1]);
        stage3 = bool.Parse(saveData[2]);

        playerGold = int.Parse(saveData[3]);
        player.hasSpeedBoots = bool.Parse(saveData[4]);
        if(player.hasSpeedBoots)
        {
            player.xSpeed = 2f;
        }  else {
            player.xSpeed = 1.5f;
        }
        player.armorLevel = int.Parse(saveData[5]);
        player.loadHealth();
        player.gameObject.GetComponent<PlayerJump>().hasDoubleJump = bool.Parse(saveData[6]);
        player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel = int.Parse(saveData[7]);

        mc.initialDialog = bool.Parse(saveData[8]);

        player.gameObject.GetComponent<PlayerBuffController>().carriedPotions.Clear();
        int listHelper = int.Parse(saveData[9]);
        if(listHelper > 0)
        {
            for(int i=0;i<listHelper;i++)
            {
                player.gameObject.GetComponent<PlayerBuffController>().carriedPotions.Add(int.Parse(saveData[9+(i+1)]));
            }
        }
        player.gameObject.GetComponent<PlayerBuffController>().UpdatePotionAni();
    }

    public void newGameReset()
    {
        mc.initialDialog = false;
        stage1 = false;
        stage2 = false;
        stage3 = false;
        playerGold = 0;
        player.hasSpeedBoots = false;
        player.xSpeed = 1.5f;
        player.armorLevel = 0;
        player.loadHealth();
        player.gameObject.GetComponent<PlayerJump>().hasDoubleJump = false;
        player.gameObject.transform.GetChild(0).GetComponent<PlayerAttack>().swordLevel = 0;
        player.gameObject.GetComponent<PlayerBuffController>().carriedPotions.Clear();
        player.gameObject.GetComponent<PlayerBuffController>().UpdatePotionAni();
    }

    public void newGame()
    {
        newGameReset();
        loadingScreen("Scene1");
        mp.audioSource.clip = mp.music[1];
        mp.audioSource.Play();
    }

    public void LoadGame(string saveName)
    {
        loadSaveGame(saveName);
        loadingScreen("Scene1");
        menuOpen = false;
        mp.audioSource.clip = mp.music[1];
        mp.audioSource.Play();
    }

    public void returnToMainMenu()
    {
        menuOpen = true;
        loadingScreen("MainMenu");
        mp.audioSource.clip = mp.music[0];
        mp.audioSource.Play();
    }

    public void returnToCity()
    {
        mc.stageComplete.SetTrigger("hide");
        menuOpen = false;
        player.hitpoint = player.maxHitpoint;
        player.HealthBarChange();
        loadingScreen("Scene1");
        mp.audioSource.clip = mp.music[1];
        mp.audioSource.Play();
    }

    public void loadKeys()
    {
        string[] controls = PlayerPrefs.GetString("Controls").Split("|");

        attack = (KeyCode) System.Enum.Parse(typeof(KeyCode), controls[0]);
        jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), controls[1]);
        inventory = (KeyCode) System.Enum.Parse(typeof(KeyCode), controls[2]);
        interact = (KeyCode) System.Enum.Parse(typeof(KeyCode), controls[3]);
        usePotion = (KeyCode) System.Enum.Parse(typeof(KeyCode), controls[4]);
        changePotion = (KeyCode) System.Enum.Parse(typeof(KeyCode), controls[5]);
        dash = (KeyCode) System.Enum.Parse(typeof(KeyCode), controls[6]);
    }
    
    public void saveAchievements()
    {
        string save = "";
        
        save += GameManager.instance.stage3.ToString() + "|";
        save += GameManager.instance.mc.ending1.ToString() + "|";
        save += GameManager.instance.mc.ending2.ToString() + "|";
        
        PlayerPrefs.SetString("Achievements",save);
    }

    public void loadingScreen(string SceneName)
    {
        StartCoroutine(LoadSceneAsync(SceneName));
    }

    private IEnumerator LoadSceneAsync(string SceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        mc.loadingScreen.SetTrigger("show");

        while(!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            mc.progressBar.fillAmount = progressValue;

            yield return null;
        }
        
        mc.loadingScreen.SetTrigger("hide");
    }

    public void deleteData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void exit()
    {
        Application.Quit();
    }
}
