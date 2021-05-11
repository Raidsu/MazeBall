using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    public class ItemStarter : MonoBehaviour
    {
        private Controllers _controllers;
        private InputController _inputController;
        
        public static RequiredItemsCounter _RequiredItemsCounter { get; set; }
        public static GameObject Player { get; set; }
        private static Data Data1 { get; set; }


        private void OnEnable()
        {
            _RequiredItemsCounter = new RequiredItemsCounter();
            
        }

        private void Awake()
        {
            Data1 = (Data) Resources.Load<ScriptableObject>("Data/Data");
            Player = gameObject;
        }

        private void Start()
        {
            _controllers = new Controllers();
            new ItemInit(_controllers, Data1);
            _controllers.Initialization();
        }
        
        private void Update()
        {
            
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }
        
        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }
        
        private void OnDestroy()
        {
            _controllers.Clean();
        }
   }
}