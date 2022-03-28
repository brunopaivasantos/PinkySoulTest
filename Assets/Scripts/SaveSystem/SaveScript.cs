using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[RequireComponent(typeof(GameData))]
public class SaveScript : MonoBehaviour
{

    private GameData gameData;
    private string savePath;

    void Start()
    {
        
    }

    public void SaveData()
    {
        var save = new Save()
        {
            Coins = gameData.Coins,//,
            HP = gameData.HP,
            Speed = gameData.Speed,
            Jumps = gameData.Jumps,
            shopItemQuantity = new List<int>(),
            Music = gameData.Music,
            SFX = gameData.Sfx

            //SavedString = gameData.GameString
        };

        foreach (int i in gameData.shopItemQuantity)
        {
            save.shopItemQuantity.Add(i);
        }

        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }

        Debug.Log("Data Saved");
    }

    public void LoadData()
    {
        gameData = GetComponent<GameData>();
        savePath = Application.persistentDataPath + "/gamesave.save";
        if (File.Exists(savePath))
        {
            Save save;

            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }

            gameData.Coins = save.Coins;
            gameData.HP = save.HP;
            gameData.Speed = save.Speed;
            gameData.Jumps = save.Jumps;
            gameData.Sfx = save.SFX;
            gameData.Music = save.Music;
            gameData.shopItemQuantity = new List<int>();
            foreach (int i in save.shopItemQuantity)
            {
                gameData.shopItemQuantity.Add(i);
            }

            Debug.Log("Data Loaded");
        }
        else
        {
            gameData.Coins = 0;
            gameData.HP = 1;
            gameData.Speed = 7;
            gameData.Jumps = 3;
            gameData.Sfx = 1;
            gameData.Music = 1;
            gameData.shopItemQuantity = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                gameData.shopItemQuantity.Add(0);
            }
            SaveData();
            Debug.LogWarning("New Save Created.");
        }
    }
}