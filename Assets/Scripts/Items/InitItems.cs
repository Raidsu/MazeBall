using UnityEngine;

namespace Items
{
    internal class InitItems
    {
        public void Init(Collider obj)
        {
            if (obj.CompareTag($"RequiredItems"))
            {
                Items item = new RequiredItems();
                item.DoEffect();
            }
            else if (obj.CompareTag("BadItems"))
            {
                Items item = new BadItems();
                item.DoEffect();
            } 
            else if (obj.CompareTag("DeadlyItems"))
            {
                Items item = new DeadlyItems();
                item.DoEffect();
            } 
        }
    }
}