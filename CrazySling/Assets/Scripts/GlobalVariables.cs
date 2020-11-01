public static class GlobalVariables
{
    const int MAX_LEVEL = 8;
    private static int _highestLevel = 1;
    private static int _currentLevel = 1;

    public static bool WonGameNow
    {
        get
        {
            return _highestLevel == MAX_LEVEL &&
                    _highestLevel == _currentLevel &&
                    WonCurrentLevel == true;
        }
    }
    public static bool WonCurrentLevel { get; set; }
    public static void RegisterLevel(int level)
    {

    }
    public static int HighestLevel { get { return _highestLevel; } }
    public static int CurrentLevel
    {
        get { return _currentLevel; }
        set
        {
            _currentLevel = value;
            if (_currentLevel > _highestLevel)
                _highestLevel = _currentLevel;
        }
    }
}
