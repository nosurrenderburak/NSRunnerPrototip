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
    [SerializeField] private GameObject hero;
    [SerializeField] private Animator cardAnimator;
    [SerializeField] private Animator lineGroupAnimator;

    #endregion


    #region Properties
    public GameObject Hero => hero;
    public Card Card => _cardInstance;

    #endregion


    #region Fields

    private Card _cardInstance;

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        GetCard();
        InitializeCard();
        cardAnimator.enabled = _cardInstance.ManaCost <= UIManager.Instance.ManaValue;  
        UIManager.Instance.OnManaChanged += SetCardAnimator;
    }


    private void OnDisable()
    {
        UIManager.Instance.OnManaChanged -= SetCardAnimator;
    }

    #endregion

    

    #region Private Methods

    private void InitializeCard()
    {
        heroImage.sprite = _cardInstance.CardSprite;
        manaText.text = _cardInstance.ManaCost.ToString();
        cardNameText.text = _cardInstance.CardName;
    }


    private void SetCardAnimator()
    {
        cardAnimator.enabled = _cardInstance.ManaCost <= UIManager.Instance.ManaValue;
        lineGroupAnimator.enabled = _cardInstance.ManaCost <= UIManager.Instance.ManaValue;
    }
    
    
    private void GetCard()
    {
        _cardInstance = cardResources.GetCard(heroType);
    }

    #endregion
}
