using UnityEngine;

public class EnemyHeroMove : Move
{
    [SerializeField] private bool isHeroBuffer;
    [SerializeField] private float targetDistance;
    
    private Vector3 _targetPos;
    private bool _isDistanceChecked;
    
    public override void CheckTargetDistance()
    {
        if (!isHeroBuffer) return;
        
        if (Vector3.Distance(transform.position, TargetTransform.position) < targetDistance)
        {
            if (_isDistanceChecked) return;
            _isDistanceChecked = true;
            _targetPos = new Vector3(transform.position.x, transform.position.y, TargetTransform.position.z + 20f);
            CurrentTargetTransform = _targetPos;
        }
    }
}
