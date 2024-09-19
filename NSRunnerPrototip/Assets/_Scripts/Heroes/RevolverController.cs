using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private LevelUpResources levelUpResources;
    [SerializeField] private BlasterAttackController blasterAttackController;
    [SerializeField] private Transform spawnPoint;

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
            _currentShootTime = levelUpResources.GetLevelUpData(_currentLevel).ShootTime;
        }
    }

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        _currentShootTime = levelUpResources.GetLevelUpData(_currentLevel).ShootTime;
    }


    private void Update()
    {
        SetTimeForNextShoot();
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
            _currentShootTime = GetLevelUpData(_currentLevel).ShootTime;;
        }
    }
    
    
    private void Shoot()
    {
        _bulletInstance = ObjectPooler.Instance.SpawnObject(PoolType.BlasterBullet, spawnPoint, spawnPoint.rotation);
        
        if (_bulletInstance.TryGetComponent(out BulletController bulletController))
        {
            bulletController.InitializeBullet(GetLevelUpData(_currentLevel).BulletScale, _currentLevel, GetLevelUpData(_currentLevel).BulletSpeed, GetLevelUpData(_currentLevel).Damage, true);
        }
    }
    
    
    private LevelUpData GetLevelUpData(int level) => levelUpResources.GetLevelUpData(level);

    #endregion
}
