using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameplayScene : MonoBehaviour
{
    const string SAVED_SELECTED_LEVEL = "A-1";//"selectedLevel";
    [SerializeField] private Button backButton;
    [SerializeField] private QuizController quizControl;
    [SerializeField] private Countdown questionTimer = new Countdown();

    public void Initial()
    {
        InitButton();
        //if (PlayerPrefs.HasKey(SAVED_SELECTED_LEVEL))
        // quizControl.IntialData(PlayerPrefs.GetString(SAVED_SELECTED_LEVEL));
        quizControl.IntialData(SAVED_SELECTED_LEVEL);

        questionTimer.onTimesUp += Gameflow.Instance.LoseLevel;

        Gameflow.Instance.onStartLevel += StartTimer;

        Gameflow.Instance.onLoseLevel += StopAllCoroutines;
        Gameflow.Instance.onClearAllLevel += StopAllCoroutines;
    }

    private void StartTimer()
    {
        StopAllCoroutines();
        Debug.Log("Begin Timer");
        StartCoroutine(questionTimer.StartTimerCount(quizControl.quizView.UpdateTime));
    }

    private void InitButton()
    {
        backButton.onClick.AddListener(
            () =>
            {
                UnityEngine.SceneManagement
                .SceneManager.LoadScene("LevelSelection");
            }
        );
    }

}
