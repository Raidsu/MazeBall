using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    public class CameraShake : IUpdate
    {
        public static float ShakeDuration { get; set; }
        private readonly Transform _camera;
        private readonly Vector3 _camStartPosition;
        private const float ShakeAmount = 0.6f;

        internal CameraShake()
        {
            if (Camera.main.transform == null)
                throw new Exception("Camera main отсутствует");
            else
            {
                _camera = Camera.main.transform;
                _camStartPosition = _camera.position;
            }
        }


        public void Execute(float deltaTime)
        {
            
            if (ShakeDuration > 0)
            {
                _camera.localPosition = _camStartPosition + Random.insideUnitSphere * ShakeAmount;
                ShakeDuration -= Time.deltaTime;
            }
            else
            {
                ShakeDuration = 0;
                _camera.localPosition = _camStartPosition;
            }

        }
    }
}