using System.Collections;
using UnityEditor.Build.Content;
using UnityEngine;

public class GamePersistence : MonoBehaviour
{
    public GameData gameData;

    void Start()
    {
        LoadGame();    
    }

    void OnDisable()
    {
        SaveGame();    
    }

    void SaveGame()
    {
        Debug.Log("SAVEEEEEEEEEEEEE");
        var json = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData", json);
        Debug.Log(json);
        Debug.Log("the save completion is done!");
    }

    void LoadGame()
    {
        var json = PlayerPrefs.GetString("GameData");
        gameData = JsonUtility.FromJson<GameData>(json);
        if(gameData == null)
        {
            gameData = new GameData();
        }
        Inventory.Instance.Bind(gameData.SlotDatas);
    }
}
