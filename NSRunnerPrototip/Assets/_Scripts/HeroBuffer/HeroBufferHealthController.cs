using System;
using System.Collections;
using NoSurrender;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeroBufferHealthController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private HeroBuffer heroBuffer;
    [SerializeField] private EnemyHeroMove enemyHeroMove;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator shakeAnimator;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private GameObject bufferBody;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private bool hack;
    [SerializeField] private bool randomDecrease;
    [SerializeField] private bool healthStatic;
    [SerializeField] private int maxHealth;

    #endregion


    #region Fields

    private BlasterAttackController _blasterAttackController;

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        healthText.text = maxHealth.ToString();
    }

    private void OnDisable()
    {
        bufferBody.SetActive(true);
        boxCollider.enabled = true;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Exit"))
        {
            Destroy(gameObject);
        }
    }

    #endregion


    #region Public Methods

    public void DecreaseHealth(int damage)
    {
        if (heroBuffer.IsDead) return;

        if (randomDecrease)
        {
            damage = Random.Range(3, 7);
        }
        maxHealth -= hack ? 1 : damage;
        if (healthStatic) maxHealth = Mathf.Max(5, maxHealth);
        healthText.text = maxHealth.ToString();
        animator.SetTrigger(GameConsts.HIT);
        CheckHealth();
    }
    
    
    public void KillBuffer()
    {
        bufferBody.SetActive(false);
        explosionParticle.Play();
        boxCollider.enabled = false;
        
        if (shakeAnimator != null) shakeAnimator.SetTrigger(GameConsts.SHAKE);
        heroBuffer.IsDead = true;
        StartCoroutine(nameof(DestroyBuffer));
    }

    #endregion


    #region Private Methods

    private void CheckHealth()
    {
        if (maxHealth > 0) return;
        
        UIManager.Instance.UpdateManaText(5);
        bufferBody.SetActive(false);
        explosionParticle.Play();
        boxCollider.enabled = false;
        
        if (shakeAnimator != null) shakeAnimator.SetTrigger(GameConsts.SHAKE);
        heroBuffer.IsDead = true;
        _blasterAttackController = enemyHeroMove.TargetTransform.GetComponentInChildren<BlasterAttackController>();
        _blasterAttackController.CurrentLevel++;
        //_blasterAttackController.SetEnabledHero(heroBuffer.HeroBufferType);
        
        AudioManager.Instance.PlayExplosionAudio();

        StartCoroutine(nameof(DestroyBuffer));
    }
    
    
    private IEnumerator DestroyBuffer()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    #endregion
}
