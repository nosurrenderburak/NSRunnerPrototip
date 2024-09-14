using NoSurrender;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private HeroResources heroResources;
    [SerializeField] private PoolType heroType;

    #endregion


    #region Fields

    private Hero _hero;

    #endregion


    #region Properties

    public Hero Hero => heroResources.GetHero(heroType);

    #endregion
}
