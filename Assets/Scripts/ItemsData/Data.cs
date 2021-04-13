using System.IO;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/ItemsData")]
    public class Data : ScriptableObject
    {
        [SerializeField] private string _badItemsDataPath;
        [SerializeField] private string _requiredItemsDataPath;
        private RequiredItemsData _required;
        private BadItemsData _bad;
        
        public RequiredItemsData Required
        {
            get
            {
                if (_required == null)
                {
                    _required = Load<RequiredItemsData>("Data/" + _requiredItemsDataPath);
                }

                return _required;
            }
        }
    

        public BadItemsData Bad
        {
            get
            {
                if (_bad == null)
                {
                    _bad = Load<BadItemsData>("Data/" + _badItemsDataPath);
                }

                return _bad;
            }
        }
        
        
        private T Load<T>(string resourcesPath) where T : Object
        {
            return Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
        }
    }
}