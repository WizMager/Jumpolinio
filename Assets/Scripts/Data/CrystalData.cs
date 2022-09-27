using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/CrystalData", fileName = "CrystalData")]
    public class CrystalData : ScriptableObject
    {
        public GameObject crystalPrefab;
    }
}