using System.Collections;
using UnityEngine;

public class EnemyHeroAnimationController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private GameObject parentObject;
    [SerializeField] private MeshRenderer[] meshRenderers;
    [SerializeField] private ParticleSystem dieParticle;

    #endregion


    #region Public Methods

    public void OnDie()
    {
        CloseMeshRenderers();
        PlayDieParticle();
        StartCoroutine(nameof(DestroyEnemy));
    }

    #endregion


    #region Private Methods

    private void CloseMeshRenderers()
    {
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = false;
        }
    }
    
    
    private void PlayDieParticle()
    {
        if (dieParticle == null) return;
        
        dieParticle.Play();
    }


    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(parentObject);
    }

    #endregion
}
