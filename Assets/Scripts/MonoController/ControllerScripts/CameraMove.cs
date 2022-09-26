using ComponentsMonoScripts;
using Data;
using MonoController.Interfaces;
using UnityEngine;

namespace MonoController.ControllerScripts
{
    public class CameraMove : IAwake, ILateUpdate
    {
        private readonly Transform _mainCamera;
        private readonly Transform _playerTransform;
        private readonly float _cameraAxisZPosition;

        public CameraMove(CameraComponents cameraComponents, PlayerComponents playerComponents, CameraData cameraData)
        {
            _mainCamera = cameraComponents.GetTransform;
            _playerTransform = playerComponents.GetTransform;
            _cameraAxisZPosition = cameraData.cameraAxisZPosition;
        }

        public void Awake()
        {
            Follow();
        }

        public void LateUpdate()
        {
            Follow();
        }

        private void Follow()
        {
            var playerPosition = _playerTransform.position;
            _mainCamera.position = new Vector3(playerPosition.x, playerPosition.y, _cameraAxisZPosition);
        }
    }
}