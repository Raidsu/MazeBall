using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    internal sealed class BadItems : Items
    {
        public event DoCameraEffect.CameraEffect Effect;

        public BadItems()
        {
            Effect += StartCameraShake;
        }
        
        internal override void DoEffect()
        {
            MazeRotation.InvertInput();
            Effect?.Invoke();
        }

        private void StartCameraShake()
        {
            CameraShake.ShakeDuration = 1f;
        }
        
    }
}