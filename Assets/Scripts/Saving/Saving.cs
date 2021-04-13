using System;
using UnityEngine;

namespace Items
{
    [Serializable]
    public sealed class Saving
    {
        public string Name;
        public SerializeVector3 Vector3Position;
        public bool IsEnabled;
        public string[] liftableObjectsTag = new string[ItemStarter.Data1.Bad.numOfObjectsOnScene+ItemStarter.Data1.Required.numOfObjectsOnScene];
        public SerializeVector3[] liftableObjectsPosition=new SerializeVector3[ItemStarter.Data1.Bad.numOfObjectsOnScene+ItemStarter.Data1.Required.numOfObjectsOnScene];
        
        public override string ToString() => $"Name: \"{Name}\" Position: {Vector3Position} IsVisible: {IsEnabled}\n{PrintLiftableObjectsData()}";


        private string PrintLiftableObjectsData()
        {
            SaveCurentLiftableObjectsToString();
            string textToReturn = null;
            for (var i=0;i< liftableObjectsTag.Length;i++)
            {
                textToReturn += $"Name: \"{liftableObjectsTag[i]}\" Position: {liftableObjectsPosition[i]}\n";
            }

            textToReturn += $"Total objects that can be raised: {liftableObjectsTag.Length}";
            return textToReturn;
        }

        private void SaveCurentLiftableObjectsToString()
        {
            var badItems=GameObject.FindGameObjectsWithTag("BadItems");
            var requiredItems=GameObject.FindGameObjectsWithTag("RequiredItems");
            
            for (var i = 0; i < badItems.Length; i++)
            {
                liftableObjectsTag[i] = badItems[i].tag;
            }
            for (var i = 0; i < badItems.Length; i++)
            {
                liftableObjectsPosition[i] = badItems[i].transform.position;
            }
            
            
            for (var i = badItems.Length; i < liftableObjectsTag.Length; i++)
            {
                liftableObjectsTag[i] = requiredItems[i-badItems.Length].tag;
            }
            for (var  i = badItems.Length; i < liftableObjectsTag.Length; i++)
            {
                liftableObjectsPosition[i] = requiredItems[i-badItems.Length].transform.position;
            }
            
        }
        
    }


    [Serializable]
    public struct SerializeVector3
    {
        public float X;
        public float Y;
        public float Z;

        private SerializeVector3(float xValue, float yValue, float zValue)
        {
            X = xValue;
            Y = yValue;
            Z = zValue;
        }
        
        public static implicit operator Vector3(SerializeVector3 value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }
      
        public static implicit operator SerializeVector3(Vector3 value)
        {
            return new SerializeVector3(value.x, value.y, value.z);
        }
        
        public override string ToString() => $" (X = {X} Y = {Y} Z = {Z})";
    }
}