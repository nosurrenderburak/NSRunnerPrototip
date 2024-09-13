using UnityEngine;

public class MBPHelper : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private Renderer _objectRenderer;
    [SerializeField] private Color _mainColor;

    #endregion


    #region Fields

    private MaterialPropertyBlock _materialPropertyBlock;
    private const string ALBEDO_COLOR = "_Color";

    #endregion


    #region Unity Methods

    private void Awake()
    {
        _materialPropertyBlock = new MaterialPropertyBlock();
    }
    

    private void Start()
    {
        SetMaterialPropertyBlock();
    }

    #endregion


    #region Private Methods

    private void SetMaterialPropertyBlock()
    {
        _materialPropertyBlock.SetColor(ALBEDO_COLOR, _mainColor);
        _objectRenderer.SetPropertyBlock(_materialPropertyBlock);
    }

    #endregion

    
}