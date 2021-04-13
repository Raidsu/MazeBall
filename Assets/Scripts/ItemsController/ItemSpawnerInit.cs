using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    public class ItemSpawnerInit :  IInit
    {
        private readonly Dictionary<Transform, string> _item;
        private Vector3 randomPosition;
        
        public ItemSpawnerInit(ItemSpawner itemFactory,BadItemsData bad, RequiredItemsData required)
        {
            _item = itemFactory.CreatedItems;
            
            foreach (var item in _item)
            {
                switch (item.Value)
                {
                    case "BadItems":
                        item.Key.tag = "BadItems";
                        randomPosition= Random.insideUnitSphere*bad.rangeFromCenterOfMaze;
                        randomPosition.y = 4f;
                        item.Key.position = randomPosition;
                         
                        
                        
                        break;
                    case "RequiredItems":
                        item.Key.tag = "RequiredItems";
                        randomPosition = Random.insideUnitSphere * required.rangeFromCenterOfMaze;
                        randomPosition.y = 4f;
                        item.Key.position = randomPosition;
                        break;
                    default: throw new Exception("Такого тега для назначения на предмет не существует");
                        
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