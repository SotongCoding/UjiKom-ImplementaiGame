using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency
{
    public static bool UnlockPack(string packId)
    {
        if (SaveData.Instance.playerCoin >= 100)
        {
            SaveData.Instance.playerCoin -= 100;
            SaveData.Instance.Save();

            return true;
        }
        return false;
    }
    public static void AddClearLevelGold()
    {
        SaveData.Instance.playerCoin += 20;
        SaveData.Instance.Save();
    }
}
