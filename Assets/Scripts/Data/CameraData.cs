using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/CameraData", fileName = "CameraData")]
    public class CameraData : ScriptableObject
    {
        public GameObject cameraPrefab;
        public float cameraAxisZPosition;
    }
}