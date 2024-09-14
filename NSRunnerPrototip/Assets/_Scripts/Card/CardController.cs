using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
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
    }
    
    
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _currentPosition;
    }

    #endregion
}
