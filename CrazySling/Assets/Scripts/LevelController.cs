using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class LevelController : MonoBehaviour
{
    private static int _currentLevel = 1;
    public int CurrentLevel
    {
        get => _currentLevel;
        private set
        {
            if (value > LEVELCOUNT)
            {
                DebugValues("ERROR IN CODE: You cannot set the currentlevel higher: CurrentLevel setter");
                return;
            }
            _currentLevel = value;
            if (value > _playerMaxlevel)
                _playerMaxlevel = value;
        }
    }
    private static int _playerMaxlevel = 1;
    public int PlayerMaxlevel { get => _playerMaxlevel; }
    private static bool _playerHasBeenShownWinScreen;
    public bool PlayerHasBeenShownWinScreen { get => _playerHasBeenShownWinScreen; private set =>_playerHasBeenShownWinScreen = value; }
    const int LEVELCOUNT = 8;

    public string Values { get => $"currentLevel: {_currentLevel}, playerMaxlevel: {PlayerMaxlevel}, LEVELCOUNT: {LEVELCOUNT}, HasWonLevel: {HasWonLevel}, HasWonGame: {HasWonGame}, PlayerHasBeenShownWinScreen: {PlayerHasBeenShownWinScreen} "; }
    string CurrentLevelName { get { return $"Level{CurrentLevel}"; } }
    public string CurrentLevelDisplayName { get { return $"Level {CurrentLevel}"; } }
    public bool HasWonLevel { get; private set; }
    public bool HasWonGame { get { return (HasWonLevel == true && CurrentLevel == LEVELCOUNT); } }

    public bool SceneLevelRunning { get => SceneManager.GetActiveScene().name.StartsWith("Level"); }

    private Enemy[] _enemies;

    private void Start()
    {
        var levelName = CurrentLevelDisplayName;
        TextLevel.DisplayText = levelName;
        Time.timeScale = 1;
    }
    private void DebugValues(string prefix = null)
    {
        var prefixStr = prefix == null ? "" : prefix + " : ";
        Debug.Log($"{prefixStr}LevelManagerValues {Values}");
    }
    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!this.SceneLevelRunning)
        {
            return; //We are not in a level scene
        }

        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null)
            {
                HasWonLevel = false;
                return;
            }
        }
        if (HasWonLevel == false)
        {
            HasWonLevel = true;
        }

        if (HasWonGame && PlayerHasBeenShownWinScreen == false)
        {
            PlayerHasBeenShownWinScreen = true;
            SceneManager.LoadScene("GameWon");
            return;
        }

        StartCoroutine(WaitAndLoadScene());

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuMain");
    }

    public void LoadCurrentLevel()
    {
        HasWonLevel = false;
        SceneManager.LoadScene(CurrentLevelName);
        TextLevel.DisplayText = CurrentLevelDisplayName;
    }


    public void LoadSpesificLevelIfAllowed(int levelToLoad)
    {
        CurrentLevel = levelToLoad;
        LoadCurrentLevel();
    }

    public void RestartGameAndLoadFirstLevel()
    {
        CurrentLevel = 1;
        LoadCurrentLevel();
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(3);
        CurrentLevel++;
        LoadCurrentLevel();
    }

}
