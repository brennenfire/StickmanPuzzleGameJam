using System.Collections;
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
        Debug.Log("Saving Game Data");
        var json = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData", json);
        Debug.Log(json);
        Debug.Log("Saving Game Data Complete");
    }

    void LoadGame()
    {
        var json = PlayerPrefs.GetString("GameData");
        gameData = JsonUtility.FromJson<GameData>(json);
        if (gameData == null)
        {
            gameData = new GameData();
        }
        Inventory.Instance.Bind(gameData.SlotDatas);
    }
}
