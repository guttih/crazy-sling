using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelController : MonoBehaviour
{
    public static int _nextLevelNumber = 1;
    public bool hasWon { get; private set; }
    private Enemy [] _enemies;

    private void OnEnable() {
        _enemies = FindObjectsOfType<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {
        foreach(Enemy enemy in _enemies) {
            if (enemy != null) {
                hasWon = false;
                return;
            }
        }
        if (hasWon == false)
        {
            hasWon = true;
            Debug.Log("You killed all enemies");
        }

        StartCoroutine(WaitAndLoadScene());
        
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(3);
        _nextLevelNumber++;
        string nextLevelName = "Level" + _nextLevelNumber;
        SceneManager.LoadScene(nextLevelName);
    }

}
