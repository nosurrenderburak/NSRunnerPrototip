using System.Collections;
using System.Collections.Generic;
using NoSurrender;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private BulletMovementController bulletMovementController;
    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private GameObject bulletExplosion;
    [SerializeField] private List<GameObject> bulletVisuals;

    #endregion


    #region Fields

    private readonly WaitForSeconds _deSpawnTime = new(0.75f);
    private EnemyHero _enemyHeroInstance;
    private GameObject _bulletBody;
    private HeroBufferHealthController _heroBufferInstance;
    private GateController _gateInstance;
    private RomanIvanovHealthController _romanIvanov;
    private int _attackDamage;

    #endregion


    #region Unity Methods
    
    private void OnTriggerEnter(Collider other)
    {
        OnHitObstacle(other);
        OnHitEnemyHero(other);
        OnHitHeroBuffer(other);
        OnHitBoss(other);
        OnHitGate(other);
    }

    #endregion


    #region Public Methods

    public void InitializeBullet(Vector3 scale, int level, float speed, int damage, bool bulletVoiceActive)
    {
        transform.localScale = scale;
        bulletMovementController.ThrowBullet(speed);
        _bulletBody = bulletVisuals[level];
        _bulletBody.SetActive(true);
        _attackDamage = damage;
        if (bulletVoiceActive)
            AudioManager.Instance.PlayBulletAudio();
    }

    
    public void KillBullet()
    {
        sphereCollider.enabled = false;
        _bulletBody.SetActive(false);
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
            _heroBufferInstance.DecreaseHealth(_attackDamage);
            KillBullet();
        }
    }


    private void OnHitGate(Collider other)
    {
        if (other.gameObject.CompareTag(GameConsts.GATE))
        {
            _gateInstance = other.gameObject.GetComponent<GateController>();
            _gateInstance.IncreaseGateLevel(1);
            KillBullet();
        }
    }


    private void OnHitBoss(Collider other)
    {
        if (other.gameObject.CompareTag(GameConsts.BOSS))
        {
            _romanIvanov = other.gameObject.GetComponent<RomanIvanovHealthController>();
            _romanIvanov.OnHit(1);
            KillBullet();
        }
    }


    private void ResetBullet()
    {
        sphereCollider.enabled = true;
        transform.localScale = Vector3.one;
        _bulletBody.SetActive(true);
        bulletExplosion.SetActive(false);
        bulletMovementController.ResetBulletMovement();
    }


    private IEnumerator DeSpawnBullet()
    {
        yield return _deSpawnTime;
        ObjectPooler.Instance.DeSpawnObject(PoolType.BlasterBullet, gameObject);
        ResetBullet();
        for (var i = 0; i < bulletVisuals.Count; i++)
        {
            bulletVisuals[i].SetActive(false);
        }
    }

    #endregion
}
