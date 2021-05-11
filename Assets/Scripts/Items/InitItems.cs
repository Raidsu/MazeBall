
using UnityEngine;

namespace Items
{
    internal class InitItems
    {
        public void Init(Collider obj)
        {
            if (obj.gameObject.TryGetComponent(out RequiredItemsMarker requiredMarker))
            {
                Items item = new RequiredItems();
                item.DoEffect();
            }
            else if (obj.gameObject.TryGetComponent(out BadItemsMarker badMarker))
            {
                Items item = new BadItems();
                item.DoEffect();
            } 
            else if (obj.gameObject.TryGetComponent(out DeadlyItemsMarker deadlyMarker))
            {
                Items item = new DeadlyItems();
                item.DoEffect();
            } 
        }
    }
}