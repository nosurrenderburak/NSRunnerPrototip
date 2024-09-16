using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHeroAnimationController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private GameObject parentObject;
    [SerializeField] private Renderer[] meshRenderers;
    [SerializeField] private ParticleSystem dieParticle;
    [SerializeField] private Animator animator;

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        StartCoroutine(EnabledAnimator(Random.Range(0, 2)));
    }

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


    private IEnumerator EnabledAnimator(int index)
    {
        yield return new WaitForSeconds(index.Equals(0) ? 0.1f : 0.2f);
        animator.enabled = true;
    }

    #endregion
}
