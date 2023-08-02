using Newtonsoft.Json;
using System;
using UnityEngine;
[System.Serializable]
public class LocalSettingsManager
{
    public LocalSettingsManager()
    {

    }

    public void Set<T>(string key, T value)
    {
        if (typeof(T) == typeof(int))
        {
            int t = Convert.ToInt32(value);
            PlayerPrefs.SetInt(key, t);
        }
        else if (typeof(T) == typeof(float))
        {
            float t = Convert.ToSingle(value);
            PlayerPrefs.SetFloat(key, t);
        }
        else if (typeof(T) == typeof(bool))
        {
            float t = Convert.ToInt32(value);
            PlayerPrefs.SetInt(key, (int)t);
        }
        else if (typeof(T) == typeof(string))
        {
            PlayerPrefs.SetString(key, value.ToString());
        }
        else if (typeof(T) == typeof(DateTime))
        {
            DateTime t = Convert.ToDateTime(value);
            PlayerPrefs.SetString(key, t.ToBinary().ToString());
        }
        else
        {
            string t = JsonConvert.SerializeObject(value);
            PlayerPrefs.SetString(key, t);
        }
        PlayerPrefs.Save();
    }

    public T Get<T>(string key)
    {
        //  PlayerPrefs.DeleteAll();
        object value = null;
        if (typeof(T) == typeof(int))
        {
            value = PlayerPrefs.GetInt(key);
        }
        else if (typeof(T) == typeof(string))
        {
            value = PlayerPrefs.GetString(key);
        }
        else if (typeof(T) == typeof(float))
        {
            value = PlayerPrefs.GetFloat(key);
        }
        else if (typeof(T) == typeof(bool))
        {
            value = PlayerPrefs.GetInt(key);
            value = Convert.ToBoolean(value);
        }
        else if (typeof(T) == typeof(DateTime))
        {
            var intValue = Convert.ToInt64(PlayerPrefs.GetString(key));
            value = DateTime.FromBinary(intValue);
        }
        else
        {
            string t = PlayerPrefs.GetString(key, string.Empty);
            return JsonConvert.DeserializeObject<T>(t);
        }
        return (T)Convert.ChangeType(value, typeof(T));
    }

    public T Get<T>(string key, T defaultValue)
    {
        T value = HasKey(key) ? Get<T>(key) : defaultValue;
        return value != null ? value : defaultValue;
    }

    public bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
    public void Clear()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Delete(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}
