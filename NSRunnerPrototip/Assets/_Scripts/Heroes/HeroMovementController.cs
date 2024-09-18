using System;
using UnityEngine;
using NoSurrender;

public class HeroMovementController : MonoBehaviour
{
    [SerializeField] private TouchControllerHelper _touchControlHelper;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator katanaAnimator;
    [SerializeField] private Animator henryAnimator;

    [SerializeField] private Animator[] blasters;

    [Header("Movement")]
    //[SerializeField] private float _forwardMovementSpeed;
    [SerializeField] private float _horizontalMovementSpeed;
    [SerializeField] private float _horizontalLimit;
    private float _newPositionX;

    
    private void Update()
    {
        SetAnimation();
    }

    
    private void FixedUpdate()
    {
        //SetCharacterMovementForward();
        SetCharacterHorizontalMovement();
    }



    private void SetCharacterMovementForward()
    {
        //transform.Translate(Vector3.forward * _forwardMovementSpeed * Time.fixedDeltaTime);
    }

    
    private void SetAnimation()
    {
        animator.SetFloat(GameConsts.RIGHT,_touchControlHelper.horizontalSwipeConstant);
        animator.SetFloat(GameConsts.LEFT, -_touchControlHelper.horizontalSwipeConstant);
        if (katanaAnimator.gameObject.activeSelf)
        {
            katanaAnimator.SetFloat(GameConsts.RIGHT,_touchControlHelper.horizontalSwipeConstant);
            katanaAnimator.SetFloat(GameConsts.LEFT, -_touchControlHelper.horizontalSwipeConstant);
        }
        
        if (henryAnimator.gameObject.activeSelf)
        {
            henryAnimator.SetFloat(GameConsts.RIGHT,_touchControlHelper.horizontalSwipeConstant);
            henryAnimator.SetFloat(GameConsts.LEFT, -_touchControlHelper.horizontalSwipeConstant);
        }
        
        if (blasters.Length == 0) return;
        for (var i = 0; i < blasters.Length; i++)
        {
            blasters[i].SetFloat(GameConsts.RIGHT, _touchControlHelper.horizontalSwipeConstant);
            blasters[i].SetFloat(GameConsts.LEFT, -_touchControlHelper.horizontalSwipeConstant);
        }
    }
    
    
    private void SetCharacterHorizontalMovement()
    {
        _newPositionX = transform.position.x + _horizontalMovementSpeed * -_touchControlHelper.horizontalSwipeConstant * Time.fixedDeltaTime;
        _newPositionX = Mathf.Clamp(_newPositionX, -_horizontalLimit, _horizontalLimit);
        transform.position = new Vector3(_newPositionX, transform.position.y, transform.position.z);
    }
}