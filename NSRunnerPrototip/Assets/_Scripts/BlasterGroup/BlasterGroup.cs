using System.Collections.Generic;
using UnityEngine;

public class BlasterGroup : MonoBehaviour
{
    [SerializeField] private List<HeroBufferBlaster> blasterList = new();

    public void InitializeGroup(LevelUpData levelUpData, int currentLevel)
    {
        for (var i = 0; i < blasterList.Count; i++)
        {
            blasterList[i].LevelUpData = levelUpData;
            blasterList[i].CurrentLevel = currentLevel;
        }
    }
}
