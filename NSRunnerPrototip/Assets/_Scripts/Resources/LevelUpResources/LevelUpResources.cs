using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "LevelUpResources", menuName = "Resources/LevelUpResources")]
public class LevelUpResources : ScriptableObject
{
    [SerializeField] private List<LevelUpData> levelUpDatas = new ();
    
    public List<LevelUpData> LevelUpDatas => levelUpDatas;
    public LevelUpData GetLevelUpData(int level) => levelUpDatas[level];
}


[Serializable]
public struct LevelUpData
{
    [SerializeField] private Vector3 bulletScale;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float shootTime;
    
    public Vector3 BulletScale => bulletScale;
    public float BulletSpeed => bulletSpeed;
    public float ShootTime => shootTime;
}
