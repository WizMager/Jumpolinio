using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public GameObject playerPrefab;
        public Transform playerSpawn;
        public float moveSpeed;
        public float jumpForce;
    }
}