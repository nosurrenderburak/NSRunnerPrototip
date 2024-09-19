using NoSurrender;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CardControllerV2 : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private CardResources cardResources;
    [SerializeField] private HeroType heroType;
    [SerializeField] private Image heroImage;
    [SerializeField] private TMP_Text manaText;
    [SerializeField] private TMP_Text cardNameText;

    #endregion


    #region Fields

    private Card _cardInstance;

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        GetCard();
        InitializeCard();
    }

    #endregion

    

    #region Private Methods

    private void InitializeCard()
    {
        heroImage.sprite = _cardInstance.CardSprite;
        manaText.text = _cardInstance.ManaCost.ToString();
        cardNameText.text = _cardInstance.CardName;
    }
    
    
    private void GetCard()
    {
        _cardInstance = cardResources.GetCard(heroType);
    }

    #endregion
}
