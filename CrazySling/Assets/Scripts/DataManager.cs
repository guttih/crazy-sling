using UnityEngine;

/// <summary>Manages data for persistance between levels.</summary>
 public class DataManager : MonoBehaviour 
{
    /// <summary>Static reference to the instance of our DataManager</summary>
    public static DataManager instance;

    /// <summary>The level the player is currently playing.</summary>
    public int currentLevel = 1;
    /// <summary>The highest level the player has won.</summary>
    public int playerMaxlevel;
    /// <summary>Number of levels in game.</summary>
    const int LEVELCOUNT = 3;
    
    /// <summary>Player has won all levels and has been shown the Win scene.</summary>
    public bool playerHasBeenShownWinScreen;

    public string Values { get => $"currentLevel: {currentLevel}, playerMaxlevel: {playerMaxlevel}, LEVELCOUNT: {LEVELCOUNT}, "; }
    /// <summary>Awake is called when the script instance is being loaded.</summary>
    void Awake()
    {
        // If the instance reference has not been set, yet, 
        if (instance == null)
        {
            // Set this instance as the instance reference.
            instance = this;
        }
        else if(instance != this)
        {
            // If the instance reference has already been set, and this is not the
            // the instance reference, destroy this game object.
            Destroy(gameObject);
        }

        // Do not destroy this object, when we load a new scene.
        DontDestroyOnLoad(gameObject);
    }
}