using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using NoSurrender;


[CreateAssetMenu(fileName = "HeroBufferResources", menuName = "Resources/HeroBufferResources")]
public class HeroBufferResources : ScriptableObject
{
    [SerializeField] private List<HeroBufferData> heroBufferDatas = new ();

    
    public GameObject GetHeroBufferPrefab(HeroBufferType targetHeroBufferType) => heroBufferDatas
        .FirstOrDefault(x => x.HeroBufferType.Equals(targetHeroBufferType)).HeroBufferPrefab;
}

[Serializable]
public struct HeroBufferData
{
    [SerializeField] private HeroBufferType heroBufferType;
    [SerializeField] private GameObject heroBufferPrefab;
    
    public HeroBufferType HeroBufferType => heroBufferType;
    public GameObject HeroBufferPrefab => heroBufferPrefab;
}
