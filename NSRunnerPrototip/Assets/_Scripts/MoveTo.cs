using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private Transform obiTransform;
    [SerializeField] private Transform targetTransform;

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        obiTransform.DOMove(targetTransform.position, 1f);
    }

    #endregion
}
