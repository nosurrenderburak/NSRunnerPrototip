using UnityEngine;

public class EnemyHeroMove : Move
{
    [SerializeField] private float targetDistance;
    [SerializeField] private bool isObi;
    
    private Vector3 _targetPos;
    private bool _isDistanceChecked;
    
    public override void CheckTargetDistance()
    {
        if (!isObi) return;
        
        if (Vector3.Distance(transform.position, TargetTransform.position) < (targetDistance))
        {
            if (_isDistanceChecked) return;
            _isDistanceChecked = true;
            _targetPos = TargetTransform.position;
            CurrentTargetTransform = _targetPos;
        }
    }
}
