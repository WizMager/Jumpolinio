using MonoController.ControllerScripts;
using UnityEngine;
using Zenject;

namespace MonoController
{
    public class GameMonoController : MonoBehaviour
    {
        private Controllers _controllers;

        [Inject]
        public void Construct(PlayerMove playerMove, CameraMove cameraMove, PlayerShoot playerShoot)
        {
            _controllers = new Controllers();
            _controllers.AddController(playerMove);
            _controllers.AddController(cameraMove);
            _controllers.AddController(playerShoot);
        }
        
        private void Awake()
        {
            _controllers.Awakes();
        }

        private void Start()
        {
            _controllers.Starts();
        }

        private void OnEnable()
        {
            _controllers.OnEnables();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Updates(deltaTime);
        }

        private void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            _controllers.FixedUpdates(fixedDeltaTime);
        }

        private void LateUpdate()
        {
            _controllers.LateUpdates();
        }

        private void OnDisable()
        {
            _controllers.OnDisables();
        }

        private void OnDestroy()
        {
            _controllers.OnDestroys();
        }
    }
}