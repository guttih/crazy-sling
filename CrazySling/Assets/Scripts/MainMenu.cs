using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private LevelController _levelController;
    void Awake()
    {
        _levelController = GameObject.FindObjectOfType<LevelController>();

    }
    public void LoadMainMenu()
    {
        _levelController.LoadMainMenu();
    }
    public void GameplayRestart()
    {
        _levelController.RestartGameAndLoadFirstLevel();
    }
    public void GameplayPlay()
    {
        _levelController.LoadCurrentLevel();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT !");
        Application.Quit();
    }

}

