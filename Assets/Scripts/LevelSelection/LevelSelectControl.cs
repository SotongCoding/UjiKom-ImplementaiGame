using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectControl : MonoBehaviour
{
    [SerializeField] private LevelData baseLevelPrefab;
    [SerializeField] private Transform levelPos;
    [SerializeField] private DatabaseController levelDatabase;

    private void Start()
    {
        ShowAllLevel();
    }

    public void ShowAllLevel()
    {
        var allAvaiableLevel = levelDatabase.GetPackLevels(PlayerPrefs.GetString(CommonVariable.SAVED_SELECTED_PACK));

        foreach (var item in allAvaiableLevel)
        {
            var level = Instantiate(baseLevelPrefab, levelPos);
            level.Initial(item);
        }
    }
}
