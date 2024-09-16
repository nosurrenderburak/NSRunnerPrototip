using NoSurrender;
using UnityEngine;

public class BlasterAttackController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private LevelUpResources levelUpResources;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private ParticleSystem levelUpParticle;
    [SerializeField] private GameObject levelUpText;
    [SerializeField] private Animator blasterAnimator;
    [SerializeField] private GameObject hattori;
    [SerializeField] private GameObject henry;

    #endregion


    #region Fields

    private GameObject _bulletInstance;
    private LevelUpData _levelUpData;
    private int _currentLevel;
    private float _currentShootTime;
    private bool _isDeath;

    #endregion


    #region Properties

    public int CurrentLevel
    {
        get => _currentLevel;
        set
        {
            _currentLevel = value;

            if (_currentLevel >= levelUpResources.LevelUpDatas.Count)
            {
                _currentLevel = levelUpResources.LevelUpDatas.Count - 1;
            }
            
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


    #region Public Methods

    public void SetEnabledHero(HeroBufferType heroBufferType)
    {
        if (heroBufferType.Equals(HeroBufferType.Hattori)) {hattori.SetActive(true);}
        else if (heroBufferType.Equals(HeroBufferType.Henry)) {henry.SetActive(true);}
    }


    public void PlayLevelUpVisualSequence()
    {
        levelUpParticle.Play();
        levelUpText.SetActive(true);
    }


    public void PlayDeathAnimation()
    {
        blasterAnimator.SetTrigger(GameConsts.DIE);
        _isDeath = true;
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
            bulletController.InitializeBullet(_levelUpData.BulletScale, _currentLevel, _levelUpData.BulletSpeed);
        }
    }

    #endregion
}
