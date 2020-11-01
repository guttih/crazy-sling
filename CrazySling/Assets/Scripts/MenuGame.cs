using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuGame : MonoBehaviour
{
    private bool isVisible;
    
    [Tooltip("Provide name of each scene,\n you don't want this menu to appear in.")]
    [SerializeField] public List<string> DisableInScenes;
    public bool Visible { get => isVisible; set => this.showMenu(value); }
    
    void Awake()
    {
        showMenu(false);
    }

    void Start()
    {
        showMenu(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showMenu(!Visible);
        }
    }

    public List<GameObject> GetChildren(GameObject gameObject)
    {
        List<GameObject> children = new List<GameObject>();
        var parent = gameObject.transform;

        foreach (Transform child in parent)
        {
            children.Add(child.gameObject);
        }

        return children;
    }
    void EnableChildren(bool activate)
    {
        GetChildren(gameObject).ForEach(child => child.SetActive(activate));
    }

    private bool isSceneInDisableScenes(){

        return DisableInScenes.Contains(SceneManager.GetActiveScene().name);
    }
    private void showMenu(bool show)
    {
        if (show && isSceneInDisableScenes()) {
            show = false;
        }
        
        float timeScale = 1;   //time running normally
        float alpha = 0;       //hide canvas
        if (show)
        {
            timeScale = 0;     //freeze time
            alpha = 1;         //show canvas
        }

        //EnableChildren(show);
        Time.timeScale = timeScale;
        gameObject.GetComponent<CanvasGroup>().alpha = alpha;
        isVisible = show;
    }

    public void LoadScene(string sceneName)
    {
        Visible = false;
        SceneManager.LoadScene("MenuMain");
    }
    public void GameplayResume()
    {
        Visible = false;
    }

    public void GameplayPause()
    {
        Visible = true;
    }

    public void GamplayRestartLevel()
    {
        Visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
