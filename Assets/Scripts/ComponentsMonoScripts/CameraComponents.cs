using UnityEngine;

namespace ComponentsMonoScripts
{
    public class CameraComponents : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Camera cameraComponent;

        public Transform GetTransform => cameraTransform;
        public Camera GetCamera => cameraComponent;
    }
}