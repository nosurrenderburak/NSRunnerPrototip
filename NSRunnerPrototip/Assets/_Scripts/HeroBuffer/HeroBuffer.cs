using NoSurrender;
using UnityEngine;


public class HeroBuffer : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private HeroBufferResources heroBufferResources;
    [SerializeField] private HeroBufferType heroBufferType;
    [SerializeField] private Transform modelParent;

    #endregion


    #region Fields
    
    private bool _isDead;

    #endregion
    
    
    #region Properties

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
    }

    #endregion


    #region Private Methods

    private void SpawnHeroBuffer()
    {
        Instantiate(heroBufferResources.GetHeroBufferPrefab(heroBufferType), modelParent);
    }

    #endregion
}
