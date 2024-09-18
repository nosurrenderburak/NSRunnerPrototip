using NoSurrender;
using TMPro;
using UnityEngine;

public class GateController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private TMP_Text gateText;
    [SerializeField] private MBPHelper mbpHelper;
    [SerializeField] private int gateLevel;
    [SerializeField] private int maxGateLevel;

    #endregion

    
    #region Unity Methods

    private void OnEnable()
    {
        SetGateText();
        SetGateColor();
    }

    #endregion


    #region Public Methods

    public void IncreaseGateLevel(int level)
    {
        gateLevel += level;
        gateLevel = Mathf.Min(gateLevel, maxGateLevel);
        SetGateText();
        SetGateColor();
    }

    #endregion


    #region Private Methods

    private void SetGateText()
    {
        gateText.text = gateLevel > 0 ? $"+{gateLevel}" : $"{gateLevel}";
    }
    

    private void SetGateColor()
    {
        mbpHelper.SetMaterialPropertyBlock(gateLevel > 0 ? GameConsts.BLUE : GameConsts.RED);
    }

    #endregion
}
