using System;
using NoSurrender;
using UnityEngine;

public class HeroCollider : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private Animator animator;
    [SerializeField] private Animator vignetteAnimator;
    [SerializeField] private Collider collider;
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
        _parentTransform = transform.parent;
        transform.SetParent(_parentTransform);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(GameConsts.ENEMY_HERO))
        {
            transform.parent = null;
            collider.enabled = false;
            vignetteAnimator.SetTrigger(GameConsts.HIT);
            animator.SetTrigger(GameConsts.DIE);
            _enemyHero = other.gameObject.GetComponent<EnemyHero>();
            _enemyHero.KillHero();
        }
        
        
        if (other.gameObject.CompareTag(GameConsts.HERO_BUFFER))
        {
            
            transform.parent = null;
            collider.enabled = false;
            vignetteAnimator.SetTrigger(GameConsts.HIT);
            animator.SetTrigger(GameConsts.DIE);
            _heroBuffer = other.gameObject.GetComponent<HeroBufferHealthController>();
            _heroBuffer.KillBuffer();
        }
    }

    #endregion
}
