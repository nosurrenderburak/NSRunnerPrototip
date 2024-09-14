using UnityEngine;

namespace NoSurrender
{
    public class TouchControllerHelper : MonoBehaviour
    {
        [HideInInspector] public float horizontalSwipeConstant;
        [HideInInspector] public float verticalSwipeConstant;

        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float m_VerticalInputMultiplier, m_HorizontalInputMultiplier;
        [SerializeField] private float m_ReferenceWidth, m_ReferenceHeight;

        private int screenWidth;
        private int screenHeight;

        private Vector3? currentFrameMousePos;
        private Vector3? lastFrameMousePos;

        #region SmoothDampValues
        private readonly float smoothDampTime = 0.075f;
        private readonly float smoothDampMaxVelocity = 360f;
        private float horizontalSmoothDampReference, verticalSmoothDampReference;

        #endregion


        #region Unity Methods

        private void Start()
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;
        }


        void Update()
        {
            GetInputs();
            CalculateSwipeConstants();
        }

        #endregion


        #region Private Methods

        private void CalculateSwipeConstants()
        {
            if (lastFrameMousePos.HasValue)
            {
                CalculateSwipeConstant();
            }
            else
            {
                lastFrameMousePos = currentFrameMousePos;
                return;
            }

            lastFrameMousePos = currentFrameMousePos;
        }

        private void GetInputs()
        {
            if (Utils.IsPointerOverUIObject()) return;
            
            if (Input.GetMouseButtonDown(0))
            {
                currentFrameMousePos = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                currentFrameMousePos = Input.mousePosition;
            }
            else
            {
                currentFrameMousePos = lastFrameMousePos = null;
                horizontalSwipeConstant = 0;
                verticalSwipeConstant = 0;
                rigidbody.centerOfMass = Vector3.zero;
                rigidbody.velocity = Vector3.zero;
            }
        }

        private void CalculateSwipeConstant()
        {
            var mousePosDifferenceByPixel = currentFrameMousePos - lastFrameMousePos;
            horizontalSwipeConstant = Mathf.SmoothDamp(horizontalSwipeConstant, mousePosDifferenceByPixel.Value.x * (m_ReferenceWidth / screenWidth) * m_HorizontalInputMultiplier, ref horizontalSmoothDampReference, smoothDampTime, smoothDampMaxVelocity);
            verticalSwipeConstant = Mathf.SmoothDamp(verticalSwipeConstant, mousePosDifferenceByPixel.Value.y * (m_ReferenceHeight / screenHeight) * m_VerticalInputMultiplier, ref verticalSmoothDampReference, smoothDampTime, smoothDampMaxVelocity);
        }

        #endregion
    }
}
