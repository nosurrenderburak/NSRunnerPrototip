using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using NoSurrender;

[CreateAssetMenu(fileName = "HeroResources", menuName = "Resources/HeroResources")]
public class HeroResources : ScriptableObject
{
    [SerializeField] private List<Hero> heroList = new();

    private Dictionary<MoveSpeedType, int> _moveSpeedList = new()
    {
        { MoveSpeedType.Slow, 2},
        { MoveSpeedType.Normal, 3},
        { MoveSpeedType.Fast, 4},
    };

    public Hero GetHero(HeroType targetHeroType)
    {
        var hero = heroList.FirstOrDefault(x => x.HeroType.Equals(targetHeroType));
        hero.MoveSpeed = _moveSpeedList[hero.MoveSpeedType];
        return hero;
    }
}

[Serializable]
public struct Hero
{
    [SerializeField] private HeroType heroType;
    [SerializeField] private MoveSpeedType moveSpeedType;
    [SerializeField] private float health;

    private float _moveSpeed;
    
    public HeroType HeroType => heroType;
    public MoveSpeedType MoveSpeedType => moveSpeedType;
    public float Health => health;

    public float MoveSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }
}
