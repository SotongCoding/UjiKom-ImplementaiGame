using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLevel : MonoBehaviour
{
    [SerializeField] private LevelSelectControl levelController;
    [SerializeField] private UnityEngine.UI.Button backButton;


    private void Start()
    {
        backButton.onClick.AddListener(Back);
        levelController.ShowAllLevel();
    }

    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Pack");
    }
}
