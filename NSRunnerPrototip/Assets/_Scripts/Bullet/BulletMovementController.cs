using UnityEngine;

public class BulletMovementController : MonoBehaviour
{
    #region Serializable Fields

    [SerializeField] private Rigidbody rigidBody;

    #endregion


    #region Public Methods

    public void ThrowBullet(float speed)
    {
        rigidBody.velocity = Vector3.back * speed * Time.fixedDeltaTime;
    }
    

    public void ResetBulletMovement()
    {
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.centerOfMass = Vector3.zero;
    }

    #endregion
}
