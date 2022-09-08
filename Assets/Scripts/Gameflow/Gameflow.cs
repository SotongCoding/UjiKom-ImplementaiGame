using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameflow : MonoBehaviour
{
    public static Gameflow Instance;
    [SerializeField] private GameplayScene gameplayScene;

    public System.Action onStartLevel;
    public System.Action onWinLevel;
    public System.Action onLoseLevel;
    public System.Action onClearAllLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            gameplayScene.Initial();
        }
    }
    private void Start()
    {
        StartLevel();
    }
    private void OnDestroy()
    {
        Instance = null;
    }
    
    public void StartLevel(){
        Debug.Log("Start A Level");
        onStartLevel?.Invoke();
    }
    public void WinLevel()
    {
        Debug.Log("WIN A Level");
        onWinLevel?.Invoke();
    }
    public void LoseLevel()
    {
        Debug.Log("Lose A Level");
        onLoseLevel?.Invoke();
    }
    public void ClearAllLevel()
    {
        Debug.Log("Clear All Level");
        onClearAllLevel?.Invoke();
    }

}
