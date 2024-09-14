using System.Collections;
using NoSurrender;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private BulletMovementController bulletMovementController;
    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private GameObject bulletBody;
    [SerializeField] private GameObject bulletExplosion;

    #endregion


    #region Fields

    private readonly WaitForSeconds _deSpawnTime = new(0.75f);
    private EnemyHero _enemyHeroInstance;
    private HeroBufferHealthController _heroBufferInstance;

    #endregion


    #region Unity Methods

    private void OnDisable()
    {
        ResetBullet();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        OnHitObstacle(other);
        OnHitEnemyHero(other);
        OnHitHeroBuffer(other);
    }

    #endregion


    #region Public Methods

    public void InitializeBullet(Vector3 scale, float speed)
    {
        transform.localScale = scale;
        bulletMovementController.ThrowBullet(speed);
    }

    
    public void KillBullet()
    {
        sphereCollider.enabled = false;
        bulletBody.SetActive(false);
        bulletExplosion.SetActive(true);
        StartCoroutine(nameof(DeSpawnBullet));
    }

    #endregion


    #region Private Methods

    private void OnHitObstacle(Collider other)
    {
        if (other.gameObject.CompareTag(GameConsts.OBSTACLE))
        {
            KillBullet();
        }
    }
    
    
    private void OnHitEnemyHero(Collider other)
    {
        if (other.gameObject.CompareTag(GameConsts.ENEMY_HERO))
        {
            _enemyHeroInstance = other.gameObject.GetComponent<EnemyHero>();
            _enemyHeroInstance.KillHero();
            KillBullet();
        }
    }


    private void OnHitHeroBuffer(Collider other)
    {
        if (other.gameObject.CompareTag(GameConsts.HERO_BUFFER))
        {
            _heroBufferInstance = other.gameObject.GetComponent<HeroBufferHealthController>();
            _heroBufferInstance.DecreaseHealth(1);
            KillBullet();
        }
    }


    private void ResetBullet()
    {
        sphereCollider.enabled = true;
        transform.localScale = Vector3.one;
        bulletBody.SetActive(true);
        bulletExplosion.SetActive(false);
        bulletMovementController.ResetBulletMovement();
    }


    private IEnumerator DeSpawnBullet()
    {
        yield return _deSpawnTime;
        ObjectPooler.Instance.DeSpawnObject(PoolType.BlasterBullet, gameObject);
    }

    #endregion
}
