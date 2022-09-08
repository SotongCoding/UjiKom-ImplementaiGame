using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuizController
{
    [SerializeField] private DatabaseController levelDataBase;
    public QuizView quizView;

    private string currentLevel;
    private string currentPack;

    List<string> allPackLevels;
    private int currentLevelIndex;

    public void IntialData(string levelId)
    {
        var selectedLevel = levelDataBase.GetLevelData(levelId).Value;

        allPackLevels = new List<string>(levelDataBase.GetPackLevels(selectedLevel.packId));
        currentLevel = levelId;
        currentLevelIndex = allPackLevels.IndexOf(levelId);

        Gameflow.Instance.onWinLevel += CheckLevel;

        InitQuiz(selectedLevel);
    }
    void InitQuiz(LevelStruct levelData)
    {
        currentLevelIndex = allPackLevels.IndexOf(levelData.levelId);
        currentLevel = levelData.levelId;
        currentPack = levelData.packId;


        //Initial UI
        // quizView.hintImage.sprite = Resources.Load<Sprite>(levelData.hint);
        quizView.ClearButton();
        quizView.questionText.text = levelData.question;

        for (int i = 0; i < quizView.answerButton.Length; i++)
        {
            var selectedButton = quizView.answerButton[i];
            selectedButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = levelData.choice[i];

            if (levelData.answer == i)
                selectedButton.onClick.AddListener(CorrectAnswer);
            else
                selectedButton.onClick.AddListener(WrongAnswer);
        }
    }

    void CheckLevel()
    {
        if (currentLevelIndex + 1 >= allPackLevels.Count)
        {
            Gameflow.Instance.ClearAllLevel();
        }
        else
        {
            InitQuiz(levelDataBase.GetLevelData(allPackLevels[currentLevelIndex + 1]).Value);
            Gameflow.Instance.StartLevel();
        }
    }



    void WrongAnswer()
    {
        Gameflow.Instance.LoseLevel();
    }
    void CorrectAnswer()
    {
        Gameflow.Instance.WinLevel();
    }
}
