using Execute;
using UnityEngine;

namespace Items
{
    public class InputController : IUpdate
    {
        private readonly SaveDataRepository _saveDataRepository;
        private GameObject _player;
        public InputController(GameObject player)
        {
            _saveDataRepository = new SaveDataRepository();
            _player = player;
            
        }

        public void Execute(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                _saveDataRepository.Save(_player);
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                _saveDataRepository.Load(_player);
            }
        }
    }
}