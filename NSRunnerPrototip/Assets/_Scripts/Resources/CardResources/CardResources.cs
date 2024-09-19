using UnityEngine;
using System;
using System.Collections.Generic;
using NoSurrender;
using System.Linq;

[CreateAssetMenu(fileName = "CardResources", menuName = "Resources/CardResources")]
public class CardResources : ScriptableObject
{
    [SerializeField] private List<Card> cardList = new();
    
    public Card GetCard(HeroType heroType) => cardList.FirstOrDefault(card => card.HeroType.Equals(heroType));
}


[Serializable]
public struct Card
{
    [SerializeField] private HeroType heroType;
    [SerializeField] private Sprite cardSprite;
    [SerializeField] private string cardName;
    [SerializeField] private int manaCost;
    
    
    public HeroType HeroType => heroType;
    public Sprite CardSprite => cardSprite;
    public string CardName => cardName;
    public int ManaCost => manaCost;
}
