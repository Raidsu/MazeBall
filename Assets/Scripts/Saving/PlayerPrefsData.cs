using UnityEngine;
using System;

namespace Items
{
    public class PlayerPrefsData : ISavingData<Saving>
    {
        public void Save(Saving data, string path = null)
        {
            PlayerPrefs.SetString("Name", data.Name);
            PlayerPrefs.SetFloat("PosX", data.Vector3Position.X);
            PlayerPrefs.SetFloat("PosY", data.Vector3Position.Y);
            PlayerPrefs.SetFloat("PosZ", data.Vector3Position.Z);
            PlayerPrefs.SetString("IsEnable", data.IsEnabled.ToString());

            
            PlayerPrefs.Save();
        }

        public Saving Load(string path = null)
        {
            var result = new Saving();

            var key = "Name";
            if (PlayerPrefs.HasKey(key))
            {
                result.Name = PlayerPrefs.GetString(key);
            }

            key = "PosX";
            if (PlayerPrefs.HasKey(key))
            {
                result.Vector3Position.X = PlayerPrefs.GetFloat(key);
            }

            key = "PosY";
            if (PlayerPrefs.HasKey(key))
            {
                result.Vector3Position.Y= PlayerPrefs.GetFloat(key);
            }

            key = "PosZ";
            if (PlayerPrefs.HasKey(key))
            {
                result.Vector3Position.Z = PlayerPrefs.GetFloat(key);
            }

            key = "IsEnable";
            if (PlayerPrefs.HasKey(key))
            {
                result.IsEnabled = Convert.ToBoolean(PlayerPrefs.GetString(key));
            }
            return result;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }

    }
}