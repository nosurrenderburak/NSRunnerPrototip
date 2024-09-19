using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    #region Serializable Fields

    [SerializeField] private CardControllerV2 cardController;
    
    #endregion
    
    #region Fields

    private Vector3 _mousePosition;
    private Vector3 _currentPosition;
    private readonly float _scaleDuration = 0.2f;

    #endregion
    
    
    #region Unity Events

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (cardController.Card.ManaCost > UIManager.Instance.ManaValue) return;
        _currentPosition = transform.position;
        SetScaleSmoothly(Vector3.one * 0.5f, _scaleDuration);
    }

    
    public void OnDrag(PointerEventData eventData)
    {
        if (cardController.Card.ManaCost > UIManager.Instance.ManaValue) return;
        _mousePosition = Input.mousePosition;
        _mousePosition.y = Mathf.Clamp(_mousePosition.y, 0, Screen.height / 2);
        transform.position = _mousePosition;
    }

    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (cardController.Card.ManaCost > UIManager.Instance.ManaValue) return;
        transform.position = _currentPosition;
        SetScaleSmoothly(Vector3.one, _scaleDuration);
        cardController.Hero.SetActive(true);
        UIManager.Instance.UpdateManaText(-cardController.Card.ManaCost);
    }

    #endregion


    #region Private Methods

    private void SetScaleSmoothly(Vector3 targetScale, float duration) => transform.DOScale(targetScale, duration);

    #endregion
}
