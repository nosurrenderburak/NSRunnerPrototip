using System;
using NoSurrender;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHero : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private HeroResources heroResources;
    [SerializeField] private Collider collider;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private PoolType heroType;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject manaIcon;
    [SerializeField] private bool isBackHero;

    #endregion


    #region Properties

    public PoolType HeroType => heroType;

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        /*
        if (gameObject.TryGetComponent<EnemyHeroMove>(out EnemyHeroMove enemyHeroMove))
        {
            
            enemyHeroMove.CurrentSpeed = isBackHero ? heroResources.GetHero(PoolType.RomanIvanov).MoveSpeed : heroResources.GetHero(heroType).MoveSpeed;
        }
        
        if (gameObject.TryGetComponent<RomanIvanovController>(out RomanIvanovController romanIvanovController))
        {
            romanIvanovController.CurrentSpeed = heroResources.GetHero(heroType).MoveSpeed;
        }
*/
        collider.enabled = true;
        animator.SetBool(GameConsts.DIE, false);
    }

    #endregion


    #region Public Methods

    public void KillHero()
    {
        //manaIcon.SetActive(true);
        //UIManager.Instance.UpdateManaText(1);
        collider.enabled = false;
        agent.enabled = false;
        if (gameObject.TryGetComponent<EnemyHeroMove>(out EnemyHeroMove enemyHeroMove))
        {
            enemyHeroMove.StopMoving(true);
        }
        
        if (gameObject.TryGetComponent<RomanIvanovController>(out RomanIvanovController romanIvanovController))
        {
            romanIvanovController.StopMoving(true);
        }
        animator.SetBool(GameConsts.DIE, true);
    }

    #endregion
}
