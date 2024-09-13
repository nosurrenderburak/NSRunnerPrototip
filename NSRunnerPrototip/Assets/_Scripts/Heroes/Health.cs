using UnityEngine;

public abstract class Health : MonoBehaviour
{
    #region Fields

    private int _currentHealth;

    #endregion


    #region Properties

    

    #endregion


    #region Abstract Methods
    public abstract void TakeDamage();
    public abstract void Die();

    #endregion


    #region Public Methods

    public void SetHealth()
    {
        _currentHealth -= 1;
        TakeDamage();
        CheckHealth();
    }

    #endregion


    #region Private Methods

    private void CheckHealth()
    {
        if (_currentHealth <= 0) { Die(); }
    }

    #endregion
}
