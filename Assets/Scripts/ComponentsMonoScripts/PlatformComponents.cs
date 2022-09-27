using UnityEngine;

namespace ComponentsMonoScripts
{
    public class PlatformComponents : MonoBehaviour
    {
        [SerializeField] private Transform crystalSpawnPosition;

        public Transform GetCrystalSpawnPosition => crystalSpawnPosition;
    }
}