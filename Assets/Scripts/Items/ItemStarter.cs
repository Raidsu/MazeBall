using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    public class ItemStarter : MonoBehaviour
    {
        private Controllers _controllers;
        public static RequiredItemsCounter _RequiredItemsCounter { get; set; }

        private Transform _camTransform;
        private Vector3 _camStartPosition;
        public static float ShakeDuration { get; set; }
        [SerializeField] private float _shakeAmount = 0.6f;

        private InputController _inputController;
        public static GameObject Player { get; set; }

        public static Data Data1 { get; private set; }


        private void OnEnable()
        {
            _RequiredItemsCounter = new RequiredItemsCounter();
            if (Camera.main.transform == null)
                throw new Exception("Camera main отсутствует");
            else
            {
                _camTransform = Camera.main.transform;
                _camStartPosition = _camTransform.position;
            }
        }

        private void Awake()
        {
            Data1 = (Data) Resources.Load<ScriptableObject>("Data/Data");            
            Player=GameObject.FindGameObjectWithTag("Player");
        }

        private void Start()
        {
            _controllers = new Controllers();
            new ItemInit(_controllers, Data1);
            _controllers.Initialization();
        }
        
       

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("BadItems") || other.CompareTag($"RequiredItems")) 
            {
                new InitItems().Init(other);
                Destroy(other.gameObject); 
            }
            else if (other.CompareTag("DeadlyItems"))
            {
                new InitItems().Init(other);
            }
            else if (other.CompareTag("EndGame"))
            {
                Debug.Log("Уровень пройден");
                //TODO загрузка следующего уровня
            }
            else throw new Exception("Нет объектов с необходимыми тегами");
        }


        private void Update()
        {
            //Тряска камеры
            if (ShakeDuration > 0)
            {
                _camTransform.localPosition = _camStartPosition + Random.insideUnitSphere * _shakeAmount;
                ShakeDuration -= Time.deltaTime;
            }
            else
            {
                ShakeDuration = 0;
                _camTransform.localPosition = _camStartPosition;
            }
            
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