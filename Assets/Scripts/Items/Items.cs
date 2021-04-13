using UnityEngine;
using static UnityEngine.Debug;

namespace Items
{
    internal abstract class Items : InitItems, IGetSetCounter
    {
        public void GetSetCounter(byte i)
        {
         switch (i)
             {
                case 0:
                    ItemStarter._RequiredItemsCounter.IncreaseCounter();
                    break;
                case 1:
                    Log($"Подобрано обязательных предметов - {ItemStarter._RequiredItemsCounter.GetCounterValue()}");
                    break;
                default: break;
            }
        }
    
        private Collider _gameObject;

            internal abstract void DoEffect();
    }
}