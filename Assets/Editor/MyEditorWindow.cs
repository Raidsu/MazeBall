using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class MyEditorWindow : EditorWindow
{
    public static GameObject _badItemPrefab;
    public static GameObject _requiredItemPrefab;
    private int _numOfBad;
    private int _numOfRequired;
    private int _rangeFromCenter;
    
    private void OnGUI()
    {
        GUILayout.Label("Префабы объектов:", EditorStyles.boldLabel);
        _badItemPrefab = (GameObject)EditorGUILayout.ObjectField("Плохие предметы:",_badItemPrefab,typeof(GameObject),true);
        _numOfBad = Convert.ToInt32(GUILayout.TextField(_numOfBad.ToString()));
 
        _requiredItemPrefab = (GameObject)EditorGUILayout.ObjectField("Необходимые предметы:",_requiredItemPrefab,typeof(GameObject),true);
        _numOfRequired = Convert.ToInt32(GUILayout.TextField(_numOfRequired.ToString()));        
        
        GUILayout.Label("Максимальное расстояние от центра лабиринта для ращмещения:");
        _rangeFromCenter = Convert.ToInt32(GUILayout.TextField(_rangeFromCenter.ToString()));
        
        GUILayout.Label("Размещение префабов:", EditorStyles.boldLabel);
        
        if (GUILayout.Button("Разместить объекты"))
        {
            for (var i = 0; i < _numOfRequired;i++)
            {
                var item = Instantiate(_requiredItemPrefab, Vector3.zero, Quaternion.identity).transform;
                item.SetParent(GameObject.FindGameObjectWithTag("Maze").transform);
                item.position = GetRandomPosition();
            }
            
            for (var i = 0; i < _numOfBad;i++)
            {
                var item = Instantiate(_badItemPrefab, Vector3.zero, Quaternion.identity).transform;
                item.SetParent(GameObject.FindGameObjectWithTag("Maze").transform);
                item.position = GetRandomPosition();
            }
        }
        
        GUILayout.Label("Удалить сгенерированное:", EditorStyles.boldLabel);

        if (GUILayout.Button("Удалить"))
        {
            var parentObject = GameObject.FindGameObjectWithTag("Maze").GetComponentsInChildren<Transform>();
            for (var v=1;v<parentObject.Length;v++)
            {
                DestroyImmediate(parentObject[v].gameObject);
            }
        }

    }

    private Vector3 GetRandomPosition()
    {
        var randomPosition= Random.insideUnitSphere*_rangeFromCenter;
        randomPosition.y = 4f;
        return randomPosition;
    }
}