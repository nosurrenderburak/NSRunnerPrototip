using System;
using NoSurrender;
using TMPro;
using UnityEngine;
using Utilities;


public class UIManager : AutoSingleton<UIManager>
{
    #region Actions

    public Action OnManaChanged;

    #endregion
    
    
    #region Serializable Fields

    [SerializeField] private Animator manaAreaAnimator;
    [SerializeField] private TMP_Text manaText;

    #endregion


    #region Properties

    public int ManaValue => _manaValue;

    #endregion


    #region Fields

    private int _manaValue;

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        UpdateManaText(0);
    }

    #endregion


    #region Public Methods

    public void UpdateManaText(int mana)
    {
        if (mana > 0) manaAreaAnimator.SetTrigger(GameConsts.SCALE);
        
        _manaValue += mana;
        _manaValue = Mathf.Max(0, _manaValue);
        manaText.text = _manaValue.ToString();
        OnManaChanged?.Invoke();
    }

    #endregion
}
