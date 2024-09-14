using System;
using UnityEngine;
using NoSurrender;

public class HeroMovementController : MonoBehaviour
{
    [SerializeField] private TouchControllerHelper _touchControlHelper;
    [SerializeField] private Animator animator;

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
    }
    
    
    private void SetCharacterHorizontalMovement()
    {
        _newPositionX = transform.position.x + _horizontalMovementSpeed * -_touchControlHelper.horizontalSwipeConstant * Time.fixedDeltaTime;
        //_newPositionX = Mathf.Clamp(_newPositionX, -_horizontalLimit, _horizontalLimit);
        transform.position = new Vector3(_newPositionX, transform.position.y, transform.position.z);
    }
}