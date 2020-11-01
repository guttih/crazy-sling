using UnityEngine;

public class LevelButton : MonoBehaviour
{
    private LevelController _levelController;
    void Awake()
    {
        _levelController = GameObject.FindObjectOfType<LevelController>();

    }

    // returns -1 on fail
    private int ExtractPostfixNumber(string name)
    {
        if (name == null || name.Length < 1)
            return -1;
        int i = 0;
        char c = 'X';
        bool foundNumber = false;
        for (i = 0; i < name.Length && !foundNumber; i++)
        {
            c = name[i];

            if (System.Char.IsDigit(c))
                foundNumber = true;
        }
        if (!foundNumber)
            return -1;

        if (System.Int32.TryParse(name.Substring(i - 1), out int extractedNumber))
            return extractedNumber;

        return -1;
    }
    void Start()
    {
        var level = ExtractPostfixNumber(gameObject.name);
        Debug.Log(_levelController.Values);
        if (level > _levelController.PlayerMaxlevel)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnClickLevelButton()
    {
        var level = ExtractPostfixNumber(gameObject.name);
        _levelController.LoadSpesificLevelIfAllowed(level);
    }

}
