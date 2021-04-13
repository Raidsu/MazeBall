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
            GetRandomEffect(Random.Range(0, 1));
            Effect?.Invoke();
        }

        private void StartCameraShake()
        {
            ItemStarter.ShakeDuration = 1f;
        }
        
        private static void GetRandomEffect(int i)
        {
            switch (i)
            {
                case 0:
                    MazeRotation.InvertInput();
                    break;
                case 1:
                    MazeRotation.SetEffectMultiplier();
                    break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }
}