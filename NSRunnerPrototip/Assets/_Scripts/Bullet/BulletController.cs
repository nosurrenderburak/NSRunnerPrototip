using System.Collections;
using NoSurrender;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private BulletMovementController bulletMovementController;
    [SerializeField] private GameObject bulletBody;
    [SerializeField] private GameObject bulletExplosion;

    #endregion


    #region Fields

    private readonly WaitForSeconds _deSpawnTime = new(0.75f);

    #endregion


    #region Unity Methods

    private void OnDisable()
    {
        ResetBullet();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        OnHitObstacle(other);
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


    private void ResetBullet()
    {
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
