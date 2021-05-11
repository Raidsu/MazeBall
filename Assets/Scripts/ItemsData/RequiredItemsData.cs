using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "RequiredItem", menuName = "Data/Items/RequiredItem")]
    public class RequiredItemsData : ScriptableObject
    {
        public GameObject prefab;
        public string tag;
        public int numOfObjectsOnScene;
        public float rangeFromCenterOfMaze;

        
     
    }
}