using System.Collections.Generic;
using UnityEngine;
using System;
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
    private const string IS_GAME_SCENE_RESTARTED = "IS_GAME_SCENE_RESTARTED";

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

    //// public static string lastSelectedGarageCarVIN
    //// {
    ////     get { return _settingsManager.Get(LAST_SELECTED_GARAGE_CAR_VIN, ""); }
    ////     set { _settingsManager.Set(LAST_SELECTED_GARAGE_CAR_VIN, value); }
    //// }

    //public static float TuningEditorRotateSpeed
    //{
    //    get { return _settingsManager.Get(TUNING_EDITOR_ROTATE_SPEED, 0.5f); }
    //    set { _settingsManager.Set(TUNING_EDITOR_ROTATE_SPEED, value); }
    //}


    //public static List<ComunityData> CommunityGroups
    //{
    //    get { return _settingsManager.Get(COMMUNITY_GROUPS, new List<ComunityData>()); }
    //    set { _settingsManager.Set<List<ComunityData>>(COMMUNITY_GROUPS, value); }
    //}

    //public static int Holidays
    //{
    //    get { return _settingsManager.Get(HOLIDAYS_NEW, 0); }
    //    set { _settingsManager.Set<int>(HOLIDAYS_NEW, value); }
    //}
    //public static bool IsTradingActive
    //{
    //    get { return _settingsManager.Get(IS_TRADING_ACTIVE, true); }
    //    set { _settingsManager.Set<bool>(IS_TRADING_ACTIVE, value); }
    //}

    //public static bool activeLocalBackups
    //{
    //    get { return _settingsManager.Get(ACTIVE_LOCAL_BACKUPS, true); }
    //    set { _settingsManager.Set<bool>(ACTIVE_LOCAL_BACKUPS, value); }
    //}

    //public static float CamInterfaceTransparency
    //{
    //    get { return _settingsManager.Get(CAM_INTERFACE_TRANSPARENCY, 1f); }
    //    set { _settingsManager.Set(CAM_INTERFACE_TRANSPARENCY, value); }
    //}
    //public static float CamLensMM
    //{
    //    get { return _settingsManager.Get(CAM_LENS_MM, 35f); }
    //    set { _settingsManager.Set(CAM_LENS_MM, value); }
    //}



    //public static float CamJoysticSensMove
    //{
    //    get { return _settingsManager.Get(CAM_JOYSTIC_SENS_MOVE, 0.5f); }
    //    set { _settingsManager.Set(CAM_JOYSTIC_SENS_MOVE, value); }
    //}

    //public static float CamJoysticSensRotate
    //{
    //    get { return _settingsManager.Get(CAM_JOYSTIC_SENS_ROTATE, 0.5f); }
    //    set { _settingsManager.Set(CAM_JOYSTIC_SENS_ROTATE, value); }
    //}

    //public static float CamJoysticSensExtra
    //{
    //    get { return _settingsManager.Get(CAM_JOYSTIC_SENS_EXTRA, 0.5f); }
    //    set { _settingsManager.Set(CAM_JOYSTIC_SENS_EXTRA, value); }
    //}


    //public static string myKickReason
    //{
    //    get { return _settingsManager.Get(MY_KICK_REASON, "..."); }
    //    set { _settingsManager.Set<string>(MY_KICK_REASON, value); }
    //}

    //public static void AddRecentlyPlayedWithUser(string playerID)
    //{
    //    if (string.IsNullOrEmpty(playerID))
    //        return;

    //    List<string> temp = RecentlyPlayedWith;
    //    if (!temp.Contains(playerID))
    //    {
    //        temp.Add(playerID);
    //    }
    //    RecentlyPlayedWith = temp;
    //}


    //public static List<string> RecentlyPlayedWith
    //{
    //    get { return _settingsManager.Get(RECENTLY_PLAYED_WITH, new List<string>()); }
    //    set { _settingsManager.Set<List<string>>(RECENTLY_PLAYED_WITH, value); }
    //}

    ////   private const string PLAYER_NICK = "PLAYER_NICK";
    ////    private const string PLAYER_CLUB = "PLAYER_CLUB";


    //public static CarData GetCarData(string VIN)
    //{
    //    return _settingsManager.Get<CarData>(VIN, null);
    //}

    //public static void SetCarData(string VIN, CarData data)
    //{
    //    _settingsManager.Set<CarData>(VIN, data);
    //}


    //public static List<SimpleCarData> SimpleGarageCarsList
    //{
    //    get { return _settingsManager.Get(GARAGE_CARS_LIST, new List<SimpleCarData>()); }
    //    set { _settingsManager.Set<List<SimpleCarData>>(GARAGE_CARS_LIST, value); }
    //}


    //public static bool isNewCarSaves
    //{
    //    get { return _settingsManager.Get(IS_NEW_CAR_SAVES, false); }
    //    set { _settingsManager.Set<bool>(IS_NEW_CAR_SAVES, value); }
    //}

    //public static bool isShowingFPS
    //{
    //    get { return _settingsManager.Get(SHOW_FPS, false); }
    //    set { _settingsManager.Set<bool>(SHOW_FPS, value); }
    //}

    //public static float AccelerometerSensetivity
    //{
    //    get { return _settingsManager.Get(ACCELEROMETER_SENS, 1.0f); }
    //    set { _settingsManager.Set<float>(ACCELEROMETER_SENS, value); }
    //}
    //public static int CurrentExclusiveNumber
    //{
    //    get { return _settingsManager.Get(CURRENT_EXCLUSIVE_NUMBER, 0); }
    //    set { _settingsManager.Set<int>(CURRENT_EXCLUSIVE_NUMBER, value); }
    //}


    //public static DateTime ExclusiveEndTime
    //{
    //    get { return _settingsManager.Get(EXCLUSIVE_END_TIME, DateTime.MinValue); }
    //    set { _settingsManager.Set(EXCLUSIVE_END_TIME, value); }
    //}

    //public static bool isAcceptedTerms
    //{
    //    get { return _settingsManager.Get(TERMS_OF_USE, false); }
    //    set { _settingsManager.Set<bool>(TERMS_OF_USE, value); }
    //}

    //public static int SteerType
    //{
    //    get { return _settingsManager.Get(STEER_TYPE, 0); }
    //    set { _settingsManager.Set<int>(STEER_TYPE, value); }
    //}

    //public static string Photon_Nickname
    //{
    //    get { return _settingsManager.Get(PHOTON_NICKNAME, ""); }
    //    set { _settingsManager.Set<string>(PHOTON_NICKNAME, value); }
    //}


    //public static bool adsIsActive
    //{
    //    get { return _settingsManager.Get(ADS_IS_ACTIVE, true); }
    //    set { _settingsManager.Set(ADS_IS_ACTIVE, value); }
    //}

    //public static DateTime lastShowAdsTime
    //{
    //    get { return _settingsManager.Get(LAST_SHOW_AD_TIME, DateTime.MinValue); }
    //    set { _settingsManager.Set(LAST_SHOW_AD_TIME, value); }
    //}

    //public  static string[] SyncBoolKeys()
    //{
    //    return new string[]
    //    {
    //        //FIRST_SYNC      
    //        CAR_GIFT_25_LEVEL,
    //        ADS_IS_ACTIVE
    //    };
    //}

    //public static string[] SyncIntKeys()
    //{
    //    return new string[]
    //    {
    //        MONEY,GOLD,RESPECT, USER_EXPERIENCE,
    //    };
    //}
    //public static string[] SyncStringKeys()
    //{
    //    return new string[]
    //    {
    //        //CURRENT_SELECTED_CAR,
    //        FB_ID

    //    };
    //}

    //public static int CamFarDistanse
    //{
    //    get { return _settingsManager.Get(CAMERA_RANGE_DISTANSE, 600); }
    //    set { _settingsManager.Set(CAMERA_RANGE_DISTANSE, value); }
    //}

    //public static bool HasGift25LvlCar
    //{
    //    get { return _settingsManager.Get(CAR_GIFT_25_LEVEL, false); }
    //    set { _settingsManager.Set(CAR_GIFT_25_LEVEL, value); }
    //}

    //public static bool isFirstSync
    //{
    //    get { return _settingsManager.Get(FIRST_SYNC, true); }
    //    set { _settingsManager.Set(FIRST_SYNC, value); }
    //}


    //public static DateTime LastLocalSync
    //{
    //    get { return _settingsManager.Get(LAST_LOCAL_SYNC, new DateTime(0)); }
    //    set { _settingsManager.Set(LAST_LOCAL_SYNC, value); }
    //}

    //public static LastHoppingData LastHopping
    //{
    //    get { return _settingsManager.Get(LAST_HOPPING, new LastHoppingData()); }
    //    set { _settingsManager.Set(LAST_HOPPING, value); }
    //}

    //public static string nickname
    //{
    //    get { return _settingsManager.Get(PLATFORM_NICKNAME, ""); }
    //    set { _settingsManager.Set(PLATFORM_NICKNAME, value); }
    //}


    ////public string playerNick
    ////{
    ////    get { return _settingsManager.Get(PLAYER_NICK, ""); }
    ////    set { _settingsManager.Set(PLAYER_NICK, value); }
    ////}

    ////public string playerClub
    ////{
    ////    get { return _settingsManager.Get(PLAYER_CLUB, ""); }
    ////    set { _settingsManager.Set(PLAYER_CLUB, value); }
    ////}


    //public static int QualityRealtimeReflections
    //{
    //    get { return _settingsManager.Get(QUALITY_REALTIME_REFLECTIONS, 0); }
    //    set { _settingsManager.Set(QUALITY_REALTIME_REFLECTIONS, value); }
    //}

    //public static float LastSessionLengh
    //{
    //    get { return _settingsManager.Get(LAST_SESSION_LENGHT_TIME, 0f); }
    //    set { _settingsManager.Set(LAST_SESSION_LENGHT_TIME, value); }
    //}

    //public static float TotalTimeInGame
    //{
    //    get { return _settingsManager.Get(TOTAL_TIME_IN_GAME, 0f); }
    //    set { _settingsManager.Set(TOTAL_TIME_IN_GAME, value); }
    //}

    //public static int HoppingWinsCount
    //{
    //    get { return _settingsManager.Get(HOPPING_WINS_COUNT, 0); }
    //    set { _settingsManager.Set(HOPPING_WINS_COUNT, value); }
    //}

    //public static int MusicPlayerCategory
    //{
    //    get { return _settingsManager.Get(MUSIC_PLAYER_CATEGORY, 1); }
    //    set { _settingsManager.Set(MUSIC_PLAYER_CATEGORY, value); }
    //}

    //public static int HoppingLoseCount
    //{
    //    get { return _settingsManager.Get(HOPPING_LOSE_COUNT, 0); }
    //    set { _settingsManager.Set(HOPPING_LOSE_COUNT, value); }
    //}

    //public static int DanceCount
    //{
    //    get { return _settingsManager.Get(DANCE_COUNT, 0); }
    //    set { _settingsManager.Set(DANCE_COUNT, value); }
    //}

    //public static float FullDanceTime
    //{
    //    get { return _settingsManager.Get(GRAPHICS_QUALITY, 0); }
    //    set { _settingsManager.Set(GRAPHICS_QUALITY, value); }
    //}

    //public static float MidleDanceTime()
    //{
    //    return FullDanceTime / DanceCount;
    //}

    //public static bool IsConnectedToGooglePlayServices
    //{
    //    get { return _settingsManager.Get(GOOGLE_PLAY_SERVICES_FIRST_LOGIN, false); }
    //    set { _settingsManager.Set(GOOGLE_PLAY_SERVICES_FIRST_LOGIN, value); }
    //}

    //public static bool isEnabledPostEffects
    //{
    //    get { return _settingsManager.Get(IS_ENABLED_POSTEFFECTS, false); }
    //    set { _settingsManager.Set(IS_ENABLED_POSTEFFECTS, value); }
    //}



    //public static bool PlayMusicInGarage
    //{
    //    get { return _settingsManager.Get(PLAY_MUSIC_IN_GARAGE, true); }
    //    set { _settingsManager.Set(PLAY_MUSIC_IN_GARAGE, value); }
    //}


    //public static List<string> UserMusicPatches
    //{
    //    get { return _settingsManager.Get(USER_MUSIC_PATCHES, new List<string>()); }
    //    set { _settingsManager.Set<List<string>>(USER_MUSIC_PATCHES, value); }
    //}

    //public string Facebook_ID
    //{
    //    get { return _settingsManager.Get(FB_ID, ""); }
    //    set { _settingsManager.Set<string>(FB_ID, value); }
    //}



    //public static int Experience
    //{
    //    get { return _settingsManager.Get(USER_EXPERIENCE, 0); }
    //    set { _settingsManager.Set<int>(USER_EXPERIENCE, value); }
    //}


    //public static int CurrentSlectedCarNumber
    //{
    //    get { return _settingsManager.Get(CURRENT_SELECTED_CAR, 0); }
    //    set { _settingsManager.Set<int>(CURRENT_SELECTED_CAR, value); }
    //}

    //// public static int Gold
    //// {
    ////     get { return _settingsManager.Get(GOLD, 0); }
    //// }



    //// public static int Respect
    //// {
    ////     get { return _settingsManager.Get(RESPECT, 1); }
    ////     set { _settingsManager.Set<int>(RESPECT, value); }
    //// }

    //// public static int Money
    //// {
    ////     get { return _settingsManager.Get(MONEY, 5000); }
    //// }

    //public static bool isEnabledSounds
    //{
    //    get { return _settingsManager.Get(IS_ENABLED_SOUNDS, true); }
    //    set { _settingsManager.Set(IS_ENABLED_SOUNDS, value); }
    //}

    //public static bool isEnabledMusic
    //{
    //    get { return _settingsManager.Get(IS_ENABLED_MUSIC, true); }
    //    set { _settingsManager.Set(IS_ENABLED_MUSIC, value); }
    //}

    //public static bool isEnabledSparks
    //{
    //    get { return _settingsManager.Get(IS_ENABLED_SPARKS, true); }
    //    set { _settingsManager.Set(IS_ENABLED_SPARKS, value); }
    //}

    //public static List<CarData> GarageCars
    //{
    //    get { return _settingsManager.Get(GARAGE_CARS, new List<CarData>()); }
    //    set { _settingsManager.Set<List<CarData>>(GARAGE_CARS, value); }
    //}

    //public static CarData TuningCopy
    //{
    //    get { return _settingsManager.Get(TUNING_COPY_CAR, new CarData()); }
    //    set { _settingsManager.Set<CarData>(TUNING_COPY_CAR, value); }
    //}
    //public static int GraphicsQuality
    //{
    //    get { return _settingsManager.Get(GRAPHICS_QUALITY, 0); }
    //    set { _settingsManager.Set(GRAPHICS_QUALITY, value); }
    //}

    //public static PlayerModel FBPlayerData
    //{
    //    get { return _settingsManager.Get(FB_PLAYER_DATA, new PlayerModel()); }
    //    set { _settingsManager.Set<PlayerModel>(FB_PLAYER_DATA, value); }
    //}

    //public static int QualityVSync
    //{
    //    get { return _settingsManager.Get(QUALITY_VSYNC, 0); }
    //    set { _settingsManager.Set<int>(QUALITY_VSYNC, value); }
    //}




    //public static int QualityAntialiasing
    //{
    //    get { return _settingsManager.Get(QUALITY_ANTIALIASING, 0); }
    //    set { _settingsManager.Set<int>(QUALITY_ANTIALIASING, value); }
    //}

    //public static int QualityTextures
    //{
    //    get { return _settingsManager.Get(QUALITY_TEXTURES, 0); }
    //    set { _settingsManager.Set<int>(QUALITY_TEXTURES, value); }
    //}

    //public static int QualityShadows
    //{
    //    get { return _settingsManager.Get(QUALITY_SHADOWS, 0); }
    //    set { _settingsManager.Set<int>(QUALITY_SHADOWS, value); }
    //}

    //public static int QualityShadowsResolution
    //{
    //    get { return _settingsManager.Get(QUALITY_SHADOWS_RESOLUTION, 0); }
    //    set { _settingsManager.Set<int>(QUALITY_SHADOWS_RESOLUTION, value); }
    //}

    //public static bool sfx
    //{
    //    get { return _settingsManager.Get(SFX, true); }
    //    set { _settingsManager.Set<bool>(SFX, value); }
    //}
    //public static bool hydraulicSound
    //{
    //    get { return _settingsManager.Get(HYDRAULIC_SOUND, true); }
    //    set { _settingsManager.Set<bool>(HYDRAULIC_SOUND, value); }
    //}


    //public static DateTime LastLaunchTime
    //{
    //    get { return _settingsManager.Get(LAST_LAUNCH_TIME, DateTime.Now); }
    //    set { _settingsManager.Set<DateTime>(LAST_LAUNCH_TIME, value); }
    //}

    //public static int PlayDaysCount
    //{
    //    get { return _settingsManager.Get(PLAY_DAYS_COUNT, 0); }
    //    set { _settingsManager.Set<int>(PLAY_DAYS_COUNT, value); }
    //}

    //public static bool FirstPrize
    //{
    //    get { return _settingsManager.Get(FIRST_PRIZE, true); }
    //    set { _settingsManager.Set<bool>(FIRST_PRIZE, value); }
    //}


    //public static bool RateUsShowed
    //{
    //    get { return _settingsManager.Get(RATE_US_SHOWED, false); }
    //    set { _settingsManager.Set<bool>(RATE_US_SHOWED, value); }
    //}

    ////public List<string> ListRimsUIDs
    ////{
    ////    get { return _settingsManager.Get(RIMS_UIDS_LIST, new List<string>()); }
    ////    set { _settingsManager.Set<List<string>>(RIMS_UIDS_LIST, value); }
    ////}

    //public static List<RimData> AllRims
    //{
    //    get { return _settingsManager.Get(ALL_RIMS, new List<RimData>()); }
    //    set { _settingsManager.Set<List<RimData>>(ALL_RIMS, value); }
    //}



    //public static List<AccGrpData> AllAccGroups
    //{
    //    get { return _settingsManager.Get(ALL_ACCESSOR_GROUPS, new List<AccGrpData>()); }
    //    set { _settingsManager.Set<List<AccGrpData>>(ALL_ACCESSOR_GROUPS, value); }
    //}

    //public static string MyRoomName
    //{
    //    get { return _settingsManager.Get(MY_ROOM_NAME, "Room" + UnityEngine.Random.Range(0, 10000)); }
    //    set { _settingsManager.Set<string>(MY_ROOM_NAME, value); }
    //}

    //public static int LastClubNotifyMessageID
    //{
    //    get { return _settingsManager.Get(NOTIFY_CLUB_MESSAGE_ID, 0); }
    //    set { _settingsManager.Set<int>(NOTIFY_CLUB_MESSAGE_ID, value); }
    //}
    //public static int LastNotifyMessageID
    //{
    //    get { return _settingsManager.Get(NOTIFY_MESSAGE_ID, 0); }
    //    set { _settingsManager.Set<int>(NOTIFY_MESSAGE_ID, value); }
    //}

    //public static  bool IsOpenedLocation(string locationID)
    //{
    //    return _settingsManager.Get(string.Format("IS_OPENED_LOCATION_{0}", locationID), false);
    //}

    //public static void SetOpenedLocation(string locationID)
    //{
    //    _settingsManager.Set(string.Format("IS_OPENED_LOCATION_{0}", locationID), true);
    //}


    //public static bool IsOpenedCar(string carID)
    //{
    //    return _settingsManager.Get(string.Format("IS_OPENED_CAR_{0}", carID), false);
    //}

    //public static void SetOpenedCar(string carID)
    //{
    //    _settingsManager.Set(string.Format("IS_OPENED_CAR_{0}", carID), true);
    //}

    //private const string ACHIEVEMENT = "ACHIEVEMENT";

    //public static UserAchievement GetAchievement(string achievementID)
    //{
    //    return _settingsManager.Get(string.Format("ACHIEVEMENT_{0}", achievementID), new UserAchievement());
    //}

    //public static void SetAchievement(string achievementID, UserAchievement achievement)
    //{
    //    _settingsManager.Set(string.Format("ACHIEVEMENT_{0}", achievementID), achievement);
    //}

    //public static void SaveCarBuild(string carGarageID, CarTuningData tuning)
    //{
    //    _settingsManager.Set(string.Format("CAR_TUNING_BUILD_{0}", carGarageID), tuning);
    //}

    //public static void RemoveRimByUID(string rimID)
    //{
    //    List<RimData> lst = AllRims;
    //    lst.RemoveAll(f => f.GID.Equals(rimID));
    //    AllRims = lst;
    //}

    ////public void SetRimsPartsList(string uid, List<RimsPartData> rimsPartsList)
    ////{
    ////    List<RimData> lst = AllRims;
    ////    if (lst.FirstOrDefault(f => f.uID.Equals(uid)) == null)
    ////    {
    ////        lst.Add(uid);
    ////        ListRimsUIDs = lst;
    ////    }        

    ////    _settingsManager.Set(string.Format("RIMS_PARTS_LIST_{0}", rimID), rimsPartsList);
    ////}



    //public static List<RimsPartData> GetRimsPartsList(string rimID)
    //{
    //    return _settingsManager.Get<List<RimsPartData>>(string.Format("RIMS_PARTS_LIST_{0}", rimID), new List<RimsPartData>());
    //}

    //public static CarTuningData LoadCarBuild(string carGarageID)
    //{
    //    return _settingsManager.Get<CarTuningData>(string.Format("CAR_TUNING_BUILD_{0}", carGarageID), null);
    //}


    //public static void ClaimAchievement(string achievementID)
    //{
    //    UserAchievement achievement = GetAchievement(achievementID);
    //    achievement.claimed = true;
    //    SetAchievement(achievementID, achievement);
    //}

    //public static void SetProgressAchievement(string achievementID, float progress)
    //{
    //    UserAchievement achievement = GetAchievement(achievementID);
    //    achievement.progress = progress;
    //    SetAchievement(achievementID, achievement);
    //}

    //public static float GetProgressAchievement(string achievementID)
    //{
    //    UserAchievement achievement = GetAchievement(achievementID);
    //    return achievement.progress;
    //}


    //public static UIButtonSizeAndPos GetUIButtonPos(LowriderGameUIButtons buttonID)
    //{
    //    return _settingsManager.Get<UIButtonSizeAndPos>(string.Format("UI_BUTTON_POS_{0}", buttonID), null);
    //}

    //public  static void SetUIButtonPos(LowriderGameUIButtons buttonID, UIButtonSizeAndPos pos)
    //{
    //    _settingsManager.Set(string.Format("UI_BUTTON_POS_{0}", buttonID), pos);
    //}

    //public static void SetActiveUIButton(LowriderGameUIButtons buttonID, bool isActive)
    //{
    //    _settingsManager.Set($"UI_BUTTON_ACTIVE_{buttonID}", isActive);
    //}
    //public static bool GetActiveUIButton(LowriderGameUIButtons buttonID)
    //{
    //    return _settingsManager.Get<bool>($"UI_BUTTON_ACTIVE_{buttonID}", false);
    //}

    //public static void SetFloatByEnum(SettingsEnum settingsEnum, float value)
    //{
    //    switch (settingsEnum)
    //    {
    //        case SettingsEnum.NONE:
    //            break;
    //        case SettingsEnum.TUNING_EDITOR_MOVE_SPEED:
    //            TuningEditorMoveSpeed = value;
    //            break;
    //        case SettingsEnum.TUNING_EDITOR_ROTATE_SPEED:
    //            TuningEditorRotateSpeed = value;
    //            break;     
    //        default:
    //            break;
    //    }
    //}

    //public static float GetFloatByEnum(SettingsEnum settingsEnum)
    //{
    //    switch (settingsEnum)
    //    {
    //        case SettingsEnum.NONE:
    //            break;
    //        case SettingsEnum.TUNING_EDITOR_MOVE_SPEED:
    //          return  TuningEditorMoveSpeed;
    //        case SettingsEnum.TUNING_EDITOR_ROTATE_SPEED:
    //            return TuningEditorRotateSpeed;
    //        default:
    //            break;
    //    }

    //    Debug.Log($"VALUE by enum :{settingsEnum}  - not found ");
    //    return 0;
    //}

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


public enum SettingsEnum
{
    NONE = 0,
    TUNING_EDITOR_MOVE_SPEED = 1,
    TUNING_EDITOR_ROTATE_SPEED = 2,

}