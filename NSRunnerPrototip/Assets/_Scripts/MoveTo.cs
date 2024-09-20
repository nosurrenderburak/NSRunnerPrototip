using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    #region Serializable Fields
    
    [SerializeField] private RectTransform targetTransform;

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        Debug.LogError(GetWorldPosition(targetTransform));
        
        // UI pozisyonunu ekran koordinatlarından dünya koordinatlarına çevir
        Vector3 targetScreenPosition = new Vector3(targetTransform.position.x, targetTransform.position.y, Camera.main.nearClipPlane);
        Vector3 targetWorldPosition = Camera.main.ScreenToWorldPoint(targetScreenPosition);

        // Objenin yukseklik ayarı (z pozisyonu) için mevcut Z pozisyonunu koruyabilirsin
        targetWorldPosition.z = transform.position.z; // veya istediğin bir değeri verebilirsin

        // Objenin hareketini başlat
        transform.DOLocalMove(targetWorldPosition, 2);
    }
    
    
    private Vector3 GetWorldPosition(RectTransform uiElement)
    {
        // UI pozisyonunu ekran koordinatlarından dünya koordinatlarına çevir
        Vector3 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, uiElement.position);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, Camera.main.nearClipPlane));
        
        return worldPosition;
    }

    #endregion
}
