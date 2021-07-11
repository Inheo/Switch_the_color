using System.Collections.Generic;
using UnityEngine;

public class AllParametrs
{
    public int SelectedEnemySkin = 0;
    public int Crystal = 0;
    public int BestScore = 0;

    public List<bool> OpenSkins = new List<bool> { true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };


    public void SaveAllParametrs(AllParametrs allParametrs)
    {
        string json = JsonUtility.ToJson(allParametrs);
        PlayerPrefs.SetString("allParametrs", json);
    }
}
