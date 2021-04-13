using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class ItemSpawner : IItemFactory
    {
        private readonly BadItemsData _badItemsData;
        private readonly RequiredItemsData _requiredItemsData;
        public readonly Dictionary<Transform,string> CreatedItems;
        
        public ItemSpawner(BadItemsData badItemsData, RequiredItemsData requiredItemsData)
        {
            _badItemsData = badItemsData;
            _requiredItemsData = requiredItemsData;
            CreatedItems = new Dictionary<Transform,string>();
            CreateItems();
        }

        public void CreateItems()
        {
            for (var i = 0; i < _requiredItemsData.numOfObjectsOnScene;i++)
            {
                var item = Object.Instantiate(_requiredItemsData.prefab, Vector3.zero, Quaternion.identity).transform;
                item.SetParent(GameObject.FindGameObjectWithTag("Maze").transform);
                
                CreatedItems.Add(item,_requiredItemsData.tag);
            }
            for (var i = 0; i < _badItemsData.numOfObjectsOnScene;i++)
            {
                var item = Object.Instantiate(_badItemsData.prefab, Vector3.zero, Quaternion.identity).transform;
                item.SetParent(GameObject.FindGameObjectWithTag("Maze").transform);
                
                CreatedItems.Add(item,_badItemsData.tag);
            }

        }

        
    }
}