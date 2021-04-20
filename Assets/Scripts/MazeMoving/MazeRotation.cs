
using Items;
using UnityEngine;


    public class MazeRotation : IUpdate, ILateUpdate
    {
        private float rotationSmooth = 0.05f;
        private float rotationMultiplier = 12f;
        
        private static bool _isInvert = false;
        private readonly Rigidbody _rb;
        private Vector3 _moveVector;


        internal MazeRotation()
        {
            _isInvert = false;
            _rb = Object.FindObjectOfType<MazeMarker>().GetComponent<Rigidbody>();
            _rb.constraints = RigidbodyConstraints.FreezePosition;
            _rb.isKinematic = true;
            _rb.useGravity = false;
        }

        
        public static void InvertInput()
        {
            _isInvert = !_isInvert;
        }

        public void Execute(float deltaTime)
        {
            if (!_isInvert)
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

        public void LateExecute(float deltaTime)
        {
            _moveVector *= rotationMultiplier;
         
            _rb.rotation = Quaternion.Slerp(_rb.rotation,
                Quaternion.Euler(_moveVector.x, 0f, _moveVector.z),
                rotationSmooth);
        }
    
}

