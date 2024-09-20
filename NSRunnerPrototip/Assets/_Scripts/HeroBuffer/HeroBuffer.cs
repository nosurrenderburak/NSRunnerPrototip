using NoSurrender;
using TMPro;
using UnityEngine;


public class HeroBuffer : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private HeroBufferResources heroBufferResources;
    [SerializeField] private HeroBufferType heroBufferType;
    [SerializeField] private Transform modelParent;
    [SerializeField] private TMP_Text manaText;
    [SerializeField] private int manaValue;

    #endregion


    #region Fields
    
    private bool _isDead;

    #endregion
    
    
    #region Properties

    public int ManaValue => manaValue;
    public HeroBufferType HeroBufferType => heroBufferType;

    public bool IsDead
    {
        get => _isDead;
        set => _isDead = value;
    }

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        SpawnHeroBuffer();
        manaText.text = manaValue.ToString();
    }

    #endregion


    #region Private Methods

    private void SpawnHeroBuffer()
    {
        Instantiate(heroBufferResources.GetHeroBufferPrefab(heroBufferType), modelParent);
    }

    #endregion
}
