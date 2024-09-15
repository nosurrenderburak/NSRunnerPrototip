using System.Collections;
using NoSurrender;
using TMPro;
using UnityEngine;

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

    #endregion


    #region Public Methods

    public void DecreaseHealth(int damage)
    {
        if (heroBuffer.IsDead) return;
        
        maxHealth -= damage;
        healthText.text = maxHealth.ToString();
        animator.SetTrigger(GameConsts.HIT);

        CheckHealth();
    }
    
    
    public void KillBuffer()
    {
        bufferBody.SetActive(false);
        explosionParticle.Play();
        boxCollider.enabled = false;
        
        shakeAnimator.SetTrigger(GameConsts.SHAKE);
        heroBuffer.IsDead = true;
        StartCoroutine(nameof(DestroyBuffer));
    }

    #endregion


    #region Private Methods

    private void CheckHealth()
    {
        if (maxHealth > 0) return;
        
        bufferBody.SetActive(false);
        explosionParticle.Play();
        boxCollider.enabled = false;
        
        shakeAnimator.SetTrigger(GameConsts.SHAKE);
        heroBuffer.IsDead = true;
        _blasterAttackController = enemyHeroMove.TargetTransform.GetComponentInChildren<BlasterAttackController>();
        _blasterAttackController.CurrentLevel++;
        _blasterAttackController.SetEnabledHero(heroBuffer.HeroBufferType);

        StartCoroutine(nameof(DestroyBuffer));
    }
    
    
    private IEnumerator DestroyBuffer()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    #endregion
}
