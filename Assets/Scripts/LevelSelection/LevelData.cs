using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] private LevelDataUI levelUI;
    private string levelId;

    public void Initial(string levelId)
    {
        this.levelId = levelId;
        bool IsLevelClear = false;//SaveData.Instacnce.IsLevelClear(packId);

        levelUI.SetInfo(levelId, IsLevelClear);
        levelUI.SetButtonEvent(SelectLevel);
    }

    void SelectLevel()
    {
        Debug.Log("SelectLevel : " + levelId);
        PlayerPrefs.SetString(CommonVariable.SAVED_SELECTED_LEVEL, levelId);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");

    }
}
