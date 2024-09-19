using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    #region Fields

    private Vector3 _mousePosition;
    private Vector3 _currentPosition;

    #endregion
    
    
    #region Unity Events

    public void OnBeginDrag(PointerEventData eventData)
    {
        _currentPosition = transform.position;
    }

    
    public void OnDrag(PointerEventData eventData)
    {
        _mousePosition = Input.mousePosition;
        _mousePosition.y = Mathf.Clamp(_mousePosition.y, 0, Screen.height / 2);
        transform.position = _mousePosition;
    }

    
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = _currentPosition;
    }

    #endregion
}
