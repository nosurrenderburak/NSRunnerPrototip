using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CardController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    #region Serializable Fields

    [SerializeField] private BlasterAttackController blasterAttackController;

    #endregion
    
    
    #region Fields
    
    private Vector3 _currentPosition;

    #endregion


    #region Event Methods

    public void OnDrag(PointerEventData eventData)
    {
        var mousePosition = Input.mousePosition;
        mousePosition.y = Mathf.Clamp(mousePosition.y, 0, Screen.height / 2);
        transform.position = mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _currentPosition = transform.position;
        SetSmoothScale(Vector3.one * 0.5f, 0.2f);
    }
    
    
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _currentPosition;
        SetSmoothScale(Vector3.one, 0.2f);
        blasterAttackController.PlayLevelUpVisualSequence();
    }

    #endregion


    #region Private Methods

    private void SetSmoothScale(Vector3 targetScale, float duration)
    {
        transform.DOScale(targetScale, duration);
    }

    #endregion
}
