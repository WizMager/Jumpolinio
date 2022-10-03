using UnityEngine;
using Views;

namespace ComponentsMonoScripts
{
    public class AllPlatformsComponents : MonoBehaviour
    {
        [SerializeField] private PlatformComponents[] platformComponentsArray;
        [SerializeField] private PortalView portalView;

        public Transform[] GetCrystalSpawnPositions
        {
            get
            {
                var spawnPositions = new Transform[platformComponentsArray.Length];
                for (int i = 0; i < platformComponentsArray.Length; i++)
                {
                    spawnPositions[i] = platformComponentsArray[i].GetCrystalSpawnPosition;
                }
                return spawnPositions;
            }
        }

        public PortalView GetPortalView => portalView;
    }
}