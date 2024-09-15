using NoSurrender;
using UnityEngine;


public class HeroBufferAttackController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem attackParticle;
    [SerializeField] private float attackRange;

    #endregion
    
    
    #region Fields

    private Collider[] _colliders;

    #endregion


    #region Unity Methods

    private void FixedUpdate()
    {
        CheckAttackZone();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


    public void StopAttackAnimation()
    {
        animator.SetBool(GameConsts.ATTACK, false);
    }


    public void KillEnemies()
    {
        foreach (var enemy in _colliders)
        {
            enemy.GetComponent<EnemyHero>().KillHero();
        }
    }


    public void PlayAttackParticle()
    {
        attackParticle.Play();
    }

    #endregion


    #region Private Methods

    private void CheckAttackZone()
    {
        _colliders = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        if (_colliders.Length > 0)
        {
            animator.SetBool(GameConsts.ATTACK, true);
        }
    }

    #endregion
}
