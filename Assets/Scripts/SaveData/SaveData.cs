using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    private static SaveData instance;
    public static SaveData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SaveData();
                instance.Load();
            }
            return instance;

        }
    }

    public int playerCoin;
    public List<string> finishLevel = new List<string>();
    public List<string> unlockPack = new List<string>();
    public List<string> completePack = new List<string>();


    public void Save()
    {
        string JSON = JsonUtility.ToJson(new PlayerSaveData(playerCoin,
        finishLevel,
        unlockPack,
        completePack
        ));

        PlayerPrefs.SetString(CommonVariable.SAVED_PLAYER_DATA, JSON);
    }
    private void Load()
    {
        string JSON = PlayerPrefs.GetString(CommonVariable.SAVED_PLAYER_DATA,
        JsonUtility.ToJson(
            new PlayerSaveData(0,
            new List<string>(),
            new List<string>() { "A" },
            new List<string>())));

        var data = JsonUtility.FromJson<PlayerSaveData>(JSON);

        playerCoin = data.playerCoin;
        finishLevel = data.finishLevel;
        unlockPack = data.unlockPack;
        completePack = data.completePack;
    }

    public bool IsLevelClear(string levelId)
    {
        return finishLevel.Contains(levelId);
    }

    public bool IsPackUnlock(string packId)
    {
        return unlockPack.Contains(packId);
    }

    public void AddUnlockPack(string packId)
    {
        if (!unlockPack.Contains(packId))
        {
            unlockPack.Add(packId);
            Save();
        }
    }

    public void AddLevelClear(string currentLevelId)
    {
        if (!finishLevel.Contains(currentLevelId))
        {
            finishLevel.Add(currentLevelId);
            Save();
        }
    }

    [System.Serializable]
    struct PlayerSaveData
    {
        public int playerCoin;
        public List<string> finishLevel;
        public List<string> unlockPack;
        public List<string> completePack;

        public PlayerSaveData(int playerCoin, List<string> finishLevel, List<string> unlockPack, List<string> completePack)
        {
            this.playerCoin = playerCoin;
            this.finishLevel = finishLevel;
            this.unlockPack = unlockPack;
            this.completePack = completePack;
        }
    }
}
