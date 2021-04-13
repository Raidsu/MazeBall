using System.IO;
using UnityEngine;

namespace Items
{
    public class SaveDataRepository
    {
        private readonly ISavingData<Saving> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform==RuntimePlatform.WindowsPlayer)
            {
                _data = new PlayerPrefsData();
            }
            
            _path = Path.Combine(Application.dataPath, _folderName);
         
        }

        public void Save(GameObject player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            
            var savePlayer = new Saving()
            {
                Vector3Position = player.transform.position,
                Name = "Player",
                IsEnabled = true
            };

            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }

        public void Load(GameObject player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Vector3Position;
            player.name = newPlayer.Name;
            player.gameObject.SetActive(newPlayer.IsEnabled);

            Debug.Log(newPlayer);
        }

    }
}