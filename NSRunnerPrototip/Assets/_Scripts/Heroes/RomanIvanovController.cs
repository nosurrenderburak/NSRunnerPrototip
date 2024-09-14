using NoSurrender;
using UnityEngine;

public class RomanIvanovController : Move
{
    [SerializeField] private Animator animator;
    [SerializeField] private float targetDistance;
    
    
    public override void CheckTargetDistance()
    {
        if (Vector3.Distance(transform.position, TargetTransform.position) < targetDistance)
        {
            StopMoving(true);
            animator.SetBool(GameConsts.ATTACK, true);
        }
    }
}
