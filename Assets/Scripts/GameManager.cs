using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    SaveScript saveScript;
    GameData gameData;
    bool waiting;
    Enums.SceneType sceneType;
    int scene;
    bool changingScene;
    private void Awake()
    {
        if (Instance == null)
        {
            sceneType = Enums.SceneType.MainMenu;
            Instance = this;
            saveScript = this.GetComponent<SaveScript>();
            gameData = this.GetComponent<GameData>();
            saveScript.LoadData();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Play()
    {
        changingScene = true;
        sceneType = Enums.SceneType.Game;
        ScreenTransition.Instance.FadeOut();
    }

    public void Restart()
    {
        changingScene = true;
        sceneType = Enums.SceneType.Game;
        ScreenTransition.Instance.FadeOut();
    }

    private void OnEnable()
    {
        ScreenTransition.OnComplete += StopWaiting;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        ScreenTransition.OnComplete -= StopWaiting;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }

    public List<int> GetShopItensQuantity()
    {
        return gameData.shopItemQuantity;
    }

    public (int, float, int) GetUpgradeItensQuantity()
    {
        return (gameData.HP, gameData.Speed, gameData.Jumps);
    }

    public void SetShopItemQuantity(List<int> itens)
    {
        for(int i = 0; i < itens.Count; i++)
        {
            gameData.shopItemQuantity[i] = itens[i];
        }
      

        saveScript.SaveData();
    }

    public void SetHP(int hp)
    {
        gameData.HP = hp;
        saveScript.SaveData();
    }

    public int GetHP()
    {
        return gameData.HP;
    }

    public void SetSpeed(float speed)
    {
        gameData.Speed = speed;
        saveScript.SaveData();
    }
    public float GetSpeed()
    {
        return gameData.Speed;
    }

    public void SetJumps(int jumps)
    {
        gameData.Jumps = jumps;
        saveScript.SaveData();
    }

    public int GetJumps()
    {
        return gameData.Jumps;
    }
    public void SetCoins(int coins)
    {
        gameData.Coins = coins;
        saveScript.SaveData();
    }
    public int GetCoins()
    {
        return gameData.Coins;
    }
    public float GetMusicVolume()
    {
        return gameData.Music;
    }

    public float GetSFXVolume()
    {
        return gameData.Sfx;
    }

    public void SetMusicVolume(float volume)
    {
        gameData.Music = volume;
    }

    public void SetSFXVolume(float volume)
    {
        gameData.Sfx = volume;
    }

    public void Save()
    {
        saveScript.SaveData();
    }
    void StopWaiting()
    {
        waiting = false;
        if (!changingScene) return;
        switch (sceneType)
        {
            case Enums.SceneType.Game:
                SceneManager.LoadScene("Game");
                break;

            case Enums.SceneType.HUB:
                SceneManager.LoadScene("HUB");
                break;

            case Enums.SceneType.MainMenu:
                SceneManager.LoadScene("MainMenu");

                break;
        }


        Time.timeScale = 1;
        changingScene = false;
    }

    public void ChangeScene(int index)
    {

    }

    public void GameOver(int coins)
    {
        Time.timeScale = 0;
        gameData.Coins = coins;
        saveScript.SaveData();
        Menu.Instance.OpenPopUp();
    }
    IEnumerator WaitScreenTransition()
    {
        waiting = true;
        ScreenTransition.Instance.FadeOut();

        yield return new WaitUntil(() => !waiting);


    }

    public void OpenHUB()
    {
        changingScene = true;
        sceneType = Enums.SceneType.HUB;
        ScreenTransition.Instance.FadeOut();
    }

    public void MainMenu()
    {
        changingScene = true;
        sceneType = Enums.SceneType.MainMenu;
        ScreenTransition.Instance.FadeOut();
    }
}
