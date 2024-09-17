using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using NoSurrender;

[CreateAssetMenu(fileName = "HeroResources", menuName = "Resources/HeroResources")]
public class HeroResources : ScriptableObject
{
    [SerializeField] private List<Hero> heroList = new();

    private Dictionary<MoveSpeedType, float> _moveSpeedList = new()
    {
        { MoveSpeedType.Slow, 2.5f},
        { MoveSpeedType.Normal, 2.8f},
        { MoveSpeedType.Fast, 5},
    };

    public Hero GetHero(PoolType targetHeroType)
    {
        var hero = heroList.FirstOrDefault(x => x.HeroType.Equals(targetHeroType));
        hero.MoveSpeed = _moveSpeedList[hero.MoveSpeedType];
        return hero;
    }
}

[Serializable]
public struct Hero
{
    [SerializeField] private PoolType heroType;
    [SerializeField] private MoveSpeedType moveSpeedType;
    [SerializeField] private float health;

    private float _moveSpeed;
    
    public PoolType HeroType => heroType;
    public MoveSpeedType MoveSpeedType => moveSpeedType;
    public float Health => health;

    public float MoveSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }
}
