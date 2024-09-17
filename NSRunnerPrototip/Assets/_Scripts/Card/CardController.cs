using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CardController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    #region Serializable Fields

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform targetTransform;
    [SerializeField] private RectTransform handTransform;
    [SerializeField] private BlasterAttackController blasterAttackController;
    [SerializeField] private bool handSequenceActive;

    #endregion
    
    
    #region Fields
    
    private Sequence _handSequence;
    private Vector3 _currentPosition;

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        StartCoroutine(nameof(PlayHand));
    }

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
        canvasGroup.alpha = 0f;
        _handSequence.Kill();
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


    private IEnumerator PlayHand()
    {
        yield return new WaitForSeconds(7f);
        PlayHandSequence();
    }


    private void PlayHandSequence()
    {
        if (!handSequenceActive) return;
        
        _handSequence = DOTween.Sequence();
        _handSequence.Append(canvasGroup.DOFade(1, 0.75f));
        _handSequence.Append(handTransform.DOLocalMove(targetTransform.localPosition, 0.5f));
        _handSequence.Append(handTransform.DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.OutBack).SetDelay(0.5f));
        _handSequence.Append(canvasGroup.DOFade(0, 0.3f));
        _handSequence.SetLoops(-1, LoopType.Restart).SetDelay(0.5f);
    }

    #endregion
}
