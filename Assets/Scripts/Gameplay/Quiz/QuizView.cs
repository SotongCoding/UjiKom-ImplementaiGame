﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class QuizView
{
    public TextMeshProUGUI questionText;
    public Image hintImage;
    public Button[] answerButton;
    public Image timerFill;
    public TextMeshProUGUI timerText;

    public void ClearButton()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            answerButton[i].onClick.RemoveAllListeners();
        }
    }

    public void UpdateTime(float timePercent, int time)
    {
        timerFill.fillAmount = timePercent;
        timerText.text = time.ToString();
    }
}
