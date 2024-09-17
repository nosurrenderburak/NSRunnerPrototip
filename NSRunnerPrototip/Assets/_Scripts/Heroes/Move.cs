using NoSurrender;
using UnityEngine;
using UnityEngine.AI;


public abstract class Move : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private bool isBuffer;

    #endregion
    
    
    #region Fields

    private Transform _targetTransform;
    private Vector3 _currentTargetTransform;
    private float _currentSpeed;

    #endregion


    #region Properties

    public Transform TargetTransform => _targetTransform;
    public Vector3 CurrentTargetTransform
    {
        get { return _currentTargetTransform; }
        set { _currentTargetTransform = value; }
    }
    
    #endregion


    #region Fields

    private Vector3 _bufferTargetPos;

    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        StopMoving(false);
        FindTarget();
        _bufferTargetPos = new Vector3(transform.position.x, transform.position.y, _targetTransform.position.z + 20f);
        _currentTargetTransform = _bufferTargetPos;
    }


    private void Update()
    {
        MoveToTarget();
        CheckTargetDistance();
    }

    #endregion


    #region Abstract Methods

    public abstract void CheckTargetDistance();

    #endregion


    #region Public Methods

    public void StopMoving(bool isStopped)
    {
        if (agent.enabled)
            agent.isStopped = isStopped;
    }

    #endregion


    #region Private Methods

    private void MoveToTarget()
    {
        if (_targetTransform == null) return;

        if (agent.enabled)
        {
            if (!agent.isStopped)
                agent.SetDestination(isBuffer ? _bufferTargetPos : _currentTargetTransform);
        }
    }

    
    private void FindTarget()
    {
        if (_targetTransform != null) return;
        
        _targetTransform = GameObject.FindGameObjectWithTag(GameConsts.HERO).transform;
    }

    #endregion
}
