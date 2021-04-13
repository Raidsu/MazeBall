using UnityEngine;


namespace Items
{
    [CreateAssetMenu(fileName = "BadItem", menuName = "Data/Items/BadItem")]
    public class BadItemsData : ScriptableObject
    {
        public GameObject prefab;
        public GameObject parentPrefab;
        public string tag;
        public int numOfObjectsOnScene;
        public float rangeFromCenterOfMaze;
        
        
        
        
        
        
        
    }
}