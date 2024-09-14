using UnityEngine;

public class BlasterAttackController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private LevelUpResources levelUpResources;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private ParticleSystem levelUpParticle;
    [SerializeField] private GameObject levelUpText;

    #endregion


    #region Fields

    private GameObject _bulletInstance;
    private LevelUpData _levelUpData;
    private int _currentLevel;
    private float _currentShootTime;

    #endregion


    #region Properties

    public int CurrentLevel
    {
        get => _currentLevel;
        set
        {
            _currentLevel = value;
            levelUpParticle.Play();
            levelUpText.SetActive(true);
            _levelUpData = levelUpResources.GetLevelUpData(_currentLevel);
            _currentShootTime = _levelUpData.ShootTime;
        }
    }

    #endregion


    #region Unity Methods

    private void Start()
    {
        _levelUpData = levelUpResources.GetLevelUpData(_currentLevel);
        _currentShootTime = _levelUpData.ShootTime;
    }

    
    private void Update()
    {
        SetTimeForNextShoot();
    }

    #endregion


    #region Private Methods

    private void SetTimeForNextShoot()
    {
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
            bulletController.InitializeBullet(_levelUpData.BulletScale, _levelUpData.BulletSpeed);
        }
    }

    #endregion
}
