using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackScene : MonoBehaviour
{
    [SerializeField] private PackController packController;
    [SerializeField] private UnityEngine.UI.Button backButton;


    private void Start()
    {
        backButton.onClick.AddListener(Back);
        packController.ShowAllPack();
    }

    public void Back()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
