using NoSurrender;
using UnityEngine;

public class HeroBuffer : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private HeroBufferType herBufferType;

    #endregion


    #region Fields

    private bool _isDead;

    #endregion
    

    #region Properties

    public HeroBufferType HerBufferType => herBufferType;

    public bool IsDead
    {
        get => _isDead;
        set => _isDead = value;
    }

    #endregion
}
