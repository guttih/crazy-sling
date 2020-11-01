using UnityEngine;

public class WinMenuButtons : MonoBehaviour
{
    private LevelController _levelController;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DestroyDublicatedObject(gameObject);
    }

    public void LoadMainMenu()
    {
        _levelController.LoadMainMenu();
    }

    private void DestroyDublicatedObject(GameObject gameobject)
    {
        var name = gameObject.name;
        if (GameObject.Find(name)
                 && GameObject.Find(name) != this.gameObject)
        {
            Debug.Log($"Destroying duplicated gameobject named: {name}.");
            Destroy(GameObject.Find(name));
        }
        _levelController = GameObject.FindObjectOfType<LevelController>();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT !");
        Application.Quit();
    }

}
