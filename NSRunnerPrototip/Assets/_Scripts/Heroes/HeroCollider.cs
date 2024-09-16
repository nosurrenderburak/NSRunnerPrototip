using System;
using NoSurrender;
using UnityEngine;

public class HeroCollider : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private Animator animator;
    [SerializeField] private Animator vignetteAnimator;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Collider collider;
    [SerializeField] private float positionX;
    [SerializeField] private bool _isBlaster;

    #endregion


    #region Fields

    private EnemyHero _enemyHero;
    private HeroBufferHealthController _heroBuffer;
    private Transform _parentTransform;

    #endregion


    #region Public Methods

    public void DestroyHero()
    {
        if (!_isBlaster)
        {
            gameObject.SetActive(false);
        }
    }

    #endregion
    
    
    
    #region Unity Methods

    private void OnEnable()
    {
        collider.enabled = true;
        transform.SetParent(parentTransform);
        transform.localPosition = new Vector3(positionX, 0, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(GameConsts.ENEMY_HERO))
        {
            OnDie();
            vignetteAnimator.SetTrigger(GameConsts.HIT);
            _enemyHero = other.gameObject.GetComponent<EnemyHero>();
            _enemyHero.KillHero();
        }
        
        
        if (other.gameObject.CompareTag(GameConsts.HERO_BUFFER))
        {
            OnDie();
            vignetteAnimator.SetTrigger(GameConsts.HIT);
            _heroBuffer = other.gameObject.GetComponent<HeroBufferHealthController>();
            _heroBuffer.KillBuffer();
        }
    }
    
    
    public void OnDie()
    {
        transform.parent = null;
        collider.enabled = false;
        animator.SetTrigger(GameConsts.DIE);
    }

    #endregion
}
