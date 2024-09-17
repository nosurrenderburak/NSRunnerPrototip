using System;
using NoSurrender;
using UnityEngine;

public class HeroBufferBlaster : MonoBehaviour
{
    #region Serializable Fields
    [SerializeField] private Animator animator;
    [SerializeField] private Animator vignetteAnimator;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Collider collider;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float positionX;

    #endregion
    
    
    #region Fields
    
    private GameObject _bulletInstance;
    private LevelUpData _levelUpData;
    private int _currentLevel;
    private float _currentShootTime;
    private int _attackDamage;
    private bool _isDeath;
    private EnemyHero _enemyHero;
    private HeroBufferHealthController _heroBuffer;

    #endregion


    #region Properties

    public LevelUpData LevelUpData
    {
        get => _levelUpData;
        set
        {
            _levelUpData = value;
        }
    }
    
    
    public int CurrentLevel
    {
        get => _currentLevel;
        set
        {
            _currentLevel = value;
        }
    }


    public int AttackDamage
    {
        get => _attackDamage;
        set
        {
            _attackDamage = value;
        }
    }

    #endregion


    #region Unity Methods
    
    
    private void OnEnable()
    {
        _isDeath = false;
        collider.enabled = true;
        transform.SetParent(parentTransform);
        transform.localPosition = new Vector3(positionX, 0, 0);
    }

    private void Update()
    {
        SetTimeForNextShoot();
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

    #endregion
    
    
    #region Private Methods

    private void SetTimeForNextShoot()
    {
        if (_isDeath) return;
        _currentShootTime -= Time.deltaTime;

        if (_currentShootTime <= 0)
        {
            Shoot();
            _currentShootTime = _levelUpData.ShootTime;;
        }
    }


    private void Shoot()
    {
        _bulletInstance = ObjectPooler.Instance.SpawnObject(PoolType.BlasterBullet, bulletSpawnPoint, bulletSpawnPoint.rotation);
        
        if (_bulletInstance.TryGetComponent(out BulletController bulletController))
        {
            bulletController.InitializeBullet(_levelUpData.BulletScale, _currentLevel, _levelUpData.BulletSpeed, _attackDamage);
        }
    }
    
    
    public void OnDie()
    {
        transform.parent = null;
        collider.enabled = false;
        _isDeath = true;
        animator.SetTrigger(GameConsts.DIE);
    }


    public void DestroyHero()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    #endregion
}
