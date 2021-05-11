using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    public class ItemSpawnerInit :  IInit
    {
        private readonly Dictionary<Transform, string> _item;

        public ItemSpawnerInit(ItemSpawner itemFactory,BadItemsData bad, RequiredItemsData required)
        {
            _item = itemFactory.CreatedItems;
            
            foreach (var item in _item)
            {
                Vector3 randomPosition;
                switch (item.Value)
                {
                    case "BadItemsMarker":
                        item.Key.gameObject.AddComponent<BadItemsMarker>();
                        randomPosition= Random.insideUnitSphere*bad.rangeFromCenterOfMaze;
                        randomPosition.y = 4f;
                        item.Key.position = randomPosition;
                        break;
                    
                    case "RequiredItemsMarker":
                        item.Key.gameObject.AddComponent<RequiredItemsMarker>();
                        randomPosition = Random.insideUnitSphere * required.rangeFromCenterOfMaze;
                        randomPosition.y = 4f;
                        item.Key.position = randomPosition;
                        break;
                    
                    default: throw new Exception("Такого компонента для назначения на предмет не существует");
                        
                }
            }
        }
        
        public void Initialization()
        {
            
        }
        
        public Dictionary<Transform, string> GetItem()
        {
           return _item;
        }
    }
}