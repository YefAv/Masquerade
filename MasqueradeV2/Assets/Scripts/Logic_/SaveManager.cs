using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    public static void Save(MonoBehaviour x, string slot)
    {
        PlayerPrefs.SetString(slot, JsonUtility.ToJson(x));
        Debug.Log(JsonUtility.ToJson(x));
    }
    public static void Load(MonoBehaviour x, string slot)
    {
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(slot), x);
    }
    public static bool CheckSave(string slot)
    {
        return PlayerPrefs.HasKey(slot);
    }
    public static void SelectSlot_(string slot)
    {
        PlayerPrefs.SetString("slot_", slot);
    }
    public static string LoadSlot_()
    {
        return PlayerPrefs.GetString("slot_");
    }
}
