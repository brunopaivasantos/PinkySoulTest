using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    enum SceneType { Game, MainMenu, HUB };

    public static GameManager Instance;
    SaveScript saveScript;
    GameData gameData;
    bool waiting;
    SceneType sceneType;
    int scene;
    private void Awake()
    {
        if (Instance == null)
        {
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

    public void Restart()
    {
        sceneType = SceneType.Game;
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
        int index = 0;
        foreach (int i in itens)
        {
            gameData.shopItemQuantity[index] = i;
            index++;
        }

        saveScript.SaveData();
    }

    public void SetHP(int hp)
    {
        gameData.HP = hp;
        saveScript.SaveData();
    }

    public void SetSpeed(float speed)
    {
        gameData.Speed = speed;
        saveScript.SaveData();
    }

    public void SetJumps(int jumps)
    {
        gameData.Jumps = jumps;
        saveScript.SaveData();
    }

    public void SetCoins(int coins)
    {
        gameData.Coins = coins;
        saveScript.SaveData();
    }

    void StopWaiting()
    {
        waiting = false;

        switch (sceneType)
        {
            case SceneType.Game:
                break;

            case SceneType.HUB:
                break;

            case SceneType.MainMenu:
                break;
        }

    }

    public void ChangeScene(int index)
    {

    }

    public void GameOver(int coins)
    {
        gameData.Coins += coins;
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
        HUB.Instance.OpenHUB();
    }
}
