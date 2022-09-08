using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class LevelDataUI
{
    [SerializeField] private Button selectButton;
    [SerializeField] private TextMeshProUGUI levelName;
    [SerializeField] private Image levelClearImage;
    public void SetInfo(string levelId, bool isLevelClear)
    {
        levelName.text = "Level " + levelId;
        levelClearImage.enabled = isLevelClear;
    }
    public void SetButtonEvent(System.Action selectEvent)
    {
        selectButton.onClick.AddListener(selectEvent.Invoke);
    }
}
