using System;
using NoSurrender;
using TMPro;
using UnityEngine;

public class HeroBufferHealthController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private HeroBuffer heroBuffer;
    [SerializeField] private EnemyHeroMove enemyHeroMove;
    [SerializeField] private Animator animator;
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

    #endregion


    #region Private Methods

    private void CheckHealth()
    {
        if (maxHealth > 0) return;
        
        heroBuffer.IsDead = true;
        _blasterAttackController = enemyHeroMove.TargetTransform.GetComponentInChildren<BlasterAttackController>();
        _blasterAttackController.CurrentLevel++;
    }

    #endregion
}
