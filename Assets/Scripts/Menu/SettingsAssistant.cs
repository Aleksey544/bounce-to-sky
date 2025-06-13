public class SettingsAssistant
{
    private static LocalSettingsManager _settingsManager = new LocalSettingsManager();
    private static LocalSettingsManager localSettingsManager => _settingsManager;

    private const string COINS = "COINS";
    private const string BOUGHT_SKIN = "BOUGHT_SKIN";
    private const string SELECTED_SKIN = "SELECTED_SKIN";
    private const string BEST_SCORE = "BEST_SCORE";
    private const string IS_SOUNDS_PLAYING = "IS_SOUNDS_PLAYING";
    private const string IS_MUSIC_PLAYING = "IS_MUSIC_PLAYING";

    public static void DeletePrefByKey(string key)
    {
        _settingsManager.Delete(key);
    }

    public static void DeleteAllPrefs()
    {
        _settingsManager.Clear();
    }

    public static int Coins
    {
        get { return _settingsManager.Get(COINS, 0); }
        set { _settingsManager.Set(COINS, value); }
    }      
    
    public static int BestScore
    {
        get { return _settingsManager.Get(BEST_SCORE, 0); }
        set { _settingsManager.Set(BEST_SCORE, value); }
    }   
    
    public static string SelectedSkin
    {
        get { return _settingsManager.Get(SELECTED_SKIN, "SoccerballSkin"); }
        set { _settingsManager.Set(SELECTED_SKIN, value); }
    }

    public static bool BoughtSkin(string skinName)
    {
        return _settingsManager.Get($"{BOUGHT_SKIN}{skinName}", false);
    }   
    
    public static void SetBoughtSkin(string skinName) 
    {
        _settingsManager.Set($"{BOUGHT_SKIN}{skinName}", true);
    }

    public static bool IsSoundsPlaying
    {
        get { return _settingsManager.Get(IS_SOUNDS_PLAYING, true); }
        set { _settingsManager.Set(IS_SOUNDS_PLAYING, value); }
    }    
    
    public static bool IsMusicPlaying
    {
        get { return _settingsManager.Get(IS_MUSIC_PLAYING, true); }
        set { _settingsManager.Set(IS_MUSIC_PLAYING, value); }
    }

    internal static float Get(string key, float defaultValue)
    {
        return _settingsManager.Get(key, defaultValue);
    }

    internal static bool Get(string key, bool defaultValue)
    {
        return _settingsManager.Get(key, defaultValue);
    }

    internal static void Set(string key, float val)
    {
        _settingsManager.Set(key, val);
    }
    internal static void Set(string key, bool val)
    {
        _settingsManager.Set(key, val);
    }
}