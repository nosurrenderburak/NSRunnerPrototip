using UnityEngine;

public class MBPHelper : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private Renderer _objectRenderer;

    #endregion


    #region Fields

    private MaterialPropertyBlock _materialPropertyBlock;
    private const string ALBEDO_COLOR = "_Color";
    private const string BASE_COLOR = "_BaseColor";
    private readonly Color RED_COLOR = new (1f, 0.25f, 0.2f, 1f);
    private readonly Color BLUE_COLOR = new (0.2f, 0.6f, 1f, 1f);

    #endregion


    #region Unity Methods

    private void Awake()
    {
        
    }
    

    #endregion


    #region Public Methods

    public void SetMaterialPropertyBlock(string color)
    {
        _materialPropertyBlock = new MaterialPropertyBlock();
        _materialPropertyBlock.SetColor(BASE_COLOR, color == "Blue" ? BLUE_COLOR : RED_COLOR);
        _objectRenderer.SetPropertyBlock(_materialPropertyBlock);
    }

    #endregion

    
}