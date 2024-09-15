using UnityEngine;

public class EnemyHeroMove : Move
{
    [SerializeField] private bool isHeroBuffer;
    [SerializeField] private float targetDistance;
    
    private Vector3 _targetPos;
    
    public override void CheckTargetDistance()
    {
        if (!isHeroBuffer) return;
        
        if (Vector3.Distance(transform.position, TargetTransform.position) < targetDistance)
        {
            _targetPos = new Vector3(transform.position.x, transform.position.y, TargetTransform.position.z);
            CurrentTargetTransform = _targetPos;
        }
    }
}
