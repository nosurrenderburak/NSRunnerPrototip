using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RomanIvanovHealthController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Material healthMaterial;
    [SerializeField] private float maxHealth = 1000;

    #endregion


    #region Fields

    private readonly Color _hitColor = new (1f, 0.88f, 0.88f, 1f);
    private readonly float _sliderDuration = 0.2f;
    private float _currentHealth;

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        _currentHealth = maxHealth;
        healthText.text = _currentHealth.ToString();
    }

    #endregion


    #region Public Methods

    public void OnHit(float damageValue)
    {
        _currentHealth -= damageValue;
        healthText.text = _currentHealth.ToString();
        healthSlider.DOValue(_currentHealth / maxHealth, _sliderDuration);
        healthMaterial.DOColor(_hitColor, 0.2f).OnComplete(() =>
        {
            healthMaterial.DOColor(Color.white, 0.2f);
        });
    }

    #endregion
}
