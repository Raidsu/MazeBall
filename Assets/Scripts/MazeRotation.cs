using UnityEngine;

    [RequireComponent(typeof(Rigidbody))]
    public class MazeRotation : MonoBehaviour
    {
        [SerializeField] [Range(0f, 1f)] private float rotationSmooth;
        [SerializeField] [Range(1f, 80f)] private float rotationMultiplier;
        
        private static bool isInvert = false;
        private static float effectMultiplier = 1;

        public static void SetEffectMultiplier()
        {
            effectMultiplier *= 2;
        }

        public static void InvertInput()
        {
            isInvert = !isInvert;
        }

        private Rigidbody _rb;
        private Vector3 _moveVector;


        private void Awake()
        {
            isInvert = false;
            _rb = GetComponent<Rigidbody>();
            _rb.constraints = RigidbodyConstraints.FreezePosition;
            _rb.isKinematic = true;
            _rb.useGravity = false;
        }

        private void Update()
        {
            if (!isInvert)
            {
                _moveVector.z = -Input.GetAxis("Horizontal");
                _moveVector.x = Input.GetAxis("Vertical");    
            }
            else
            {
                _moveVector.z = Input.GetAxis("Horizontal");
                _moveVector.x = -Input.GetAxis("Vertical");
            }
            
            _moveVector.y = 0;
        }

        private void FixedUpdate()
        {
            _moveVector *= rotationMultiplier*effectMultiplier;

            _rb.rotation = Quaternion.Slerp(_rb.rotation,
                Quaternion.Euler(_moveVector.x, 0f, _moveVector.z),
                rotationSmooth);
        }
    }

