using System;
using System.Collections.Generic;
using NoSurrender;
using Unity.VisualScripting;
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
    [SerializeField] private ParticleSystem[] blasterParticles;
    [SerializeField] private HeroBufferBlaster[] heroBufferBlasters;


    [SerializeField] private GameObject katanaBlaster;
    [SerializeField] private GameObject henryBlaster;
    
    [SerializeField] private List<BlasterGroup> blasterGroups = new ();

    #endregion


    #region Fields

    private GameObject _bulletInstance;
    private LevelUpData _levelUpData;
    private int _currentLevel;
    private float _currentShootTime;
    private bool _isDeath;
    private int _attackDamage;
    private int _groupIndex = -1;

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


            PlayAllBlasterParticles();
            PlayLevelUpVisualSequence();
            _levelUpData = levelUpResources.GetLevelUpData(_currentLevel);
            _currentShootTime = _levelUpData.ShootTime;
            _attackDamage = _levelUpData.Damage;
            katanaBlaster.GetComponent<HeroBufferBlaster>().CurrentLevel = CurrentLevel;
            katanaBlaster.GetComponent<HeroBufferBlaster>().LevelUpData = _levelUpData;
            SetHeroBufferBlaster();
        }
    }

    #endregion


    #region Unity Methods

    private void Start()
    {
        _levelUpData = levelUpResources.GetLevelUpData(_currentLevel);
        _currentShootTime = _levelUpData.ShootTime;
        _attackDamage = _levelUpData.Damage;
    }

    
    private void Update()
    {
       SetTimeForNextShoot();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GameConsts.GATE))
        {
            levelUpParticle.Play();
            _groupIndex++;
            for (var i = 0; i < blasterGroups.Count; i++)
            {
                blasterGroups[i].gameObject.SetActive(false);
            }
            
            blasterGroups[_groupIndex].gameObject.SetActive(true);
            blasterGroups[_groupIndex].InitializeGroup(_levelUpData, _currentLevel);
            AudioManager.Instance.PlayLevelUpAudio();
        }
    }

    #endregion


    #region Public Methods

    public void SetEnabledHero(HeroBufferType heroBufferType)
    {
        if (heroBufferType.Equals(HeroBufferType.Hattori))
        {
            katanaBlaster.SetActive(true);
            katanaBlaster.GetComponent<HeroBufferBlaster>().CurrentLevel = CurrentLevel;
            katanaBlaster.GetComponent<HeroBufferBlaster>().LevelUpData = _levelUpData;
        }
        else if (heroBufferType.Equals(HeroBufferType.Henry))
        {
            henryBlaster.SetActive(true);
            henryBlaster.GetComponent<HeroBufferBlaster>().CurrentLevel = CurrentLevel;
            henryBlaster.GetComponent<HeroBufferBlaster>().LevelUpData = _levelUpData;
        }
    }


    public void PlayLevelUpVisualSequence()
    {
        levelUpParticle.Play();
        levelUpText.SetActive(true);
        AudioManager.Instance.PlayLevelUpAudio();
    }


    public void PlayDeathAnimation()
    {
        blasterAnimator.SetTrigger(GameConsts.DIE);
        _isDeath = true;
    }

    #endregion


    #region Private Methods
    
    
    private void PlayAllBlasterParticles()
    {
        foreach (var blasterParticle in blasterParticles)
        {
            blasterParticle.Play();
        }
    }
    

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
    
    
    private void SetHeroBufferBlaster()
    {
        for (var i = 0; i < heroBufferBlasters.Length; i++)
        {
            heroBufferBlasters[i].CurrentLevel = CurrentLevel;
            heroBufferBlasters[i].LevelUpData = _levelUpData;
        }
    }


    private void Shoot()
    {
        _bulletInstance = ObjectPooler.Instance.SpawnObject(PoolType.BlasterBullet, bulletSpawnPoint, bulletSpawnPoint.rotation);
        
        if (_bulletInstance.TryGetComponent(out BulletController bulletController))
        {
            bulletController.InitializeBullet(_levelUpData.BulletScale, _currentLevel, _levelUpData.BulletSpeed, _attackDamage, true);
        }
    }

    #endregion
}
