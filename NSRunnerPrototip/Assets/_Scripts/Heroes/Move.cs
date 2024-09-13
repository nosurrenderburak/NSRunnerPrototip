using NoSurrender;
using UnityEngine;
using UnityEngine.AI;


public class Move : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private NavMeshAgent agent;

    #endregion
    
    
    #region Fields

    private Transform _targetTransform;
    private float _currentSpeed;

    #endregion


    #region Properties

    public Transform TargetTransform => _targetTransform;

    public float CurrentSpeed
    {
        get => _currentSpeed;
        set
        {
            _currentSpeed = value;
            agent.speed = _currentSpeed;
        }
    }

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        agent.speed = 5;
        StopMoving(false);
        FindTarget();
    }


    private void Update()
    {
        MoveToTarget();
    }

    #endregion


    #region Public Methods

    public void StopMoving(bool isStopped)
    {
        agent.isStopped = isStopped;
    }

    #endregion


    #region Private Methods

    private void MoveToTarget()
    {
        if (_targetTransform == null) return;
        
        if (!agent.isStopped)
            agent.SetDestination(_targetTransform.position);
    }

    
    private void FindTarget()
    {
        if (_targetTransform != null) return;
        
        _targetTransform = GameObject.FindGameObjectWithTag(GameConsts.HERO).transform;
    }

    #endregion
}
