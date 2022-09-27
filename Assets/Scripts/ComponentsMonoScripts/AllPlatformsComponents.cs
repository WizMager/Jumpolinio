using UnityEngine;

namespace ComponentsMonoScripts
{
    public class AllPlatformsComponents : MonoBehaviour
    {
        [SerializeField] private PlatformComponents[] platformComponentsArray;

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
    }
}