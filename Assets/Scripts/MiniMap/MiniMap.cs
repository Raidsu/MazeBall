
using UnityEngine;

namespace Items
{
    public class MiniMap : ILateUpdate
    {
        private Transform _player;
        private Transform _camera;
        private readonly Vector3 _offset= new Vector3(0f,5f,0f);

        internal MiniMap(Transform miniMapCamera)
        {
            _camera = miniMapCamera;
            _player = Object.FindObjectOfType<PlayerMarker>().transform;
            _camera.parent = null;
            _camera.rotation=Quaternion.Euler(90f,0f,0f);
            _camera.position = _player.position + _offset;

            var minimapTexture = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

            miniMapCamera.gameObject.GetComponent<Camera>().targetTexture = minimapTexture;
        }

        public void LateExecute(float deltaTime)
        {
            var curentPlayerPosition = _player.position;
            curentPlayerPosition.y = _camera.position.y;
            _camera.position = curentPlayerPosition;
        }
    }
}
