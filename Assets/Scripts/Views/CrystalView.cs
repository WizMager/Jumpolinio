using System;
using UnityEngine;

namespace Views
{
    public class CrystalView : MonoBehaviour
    {
        public Action<bool, Vector3> OnPlayerEnterShootRange;
        public Action<CrystalView> OnPlayerDestroyCrystal;
        [SerializeField] private float destroyTime;
        [SerializeField] private Transform crystalPosition;
        private bool _playerInside;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            OnPlayerEnterShootRange?.Invoke(true, crystalPosition.position);
            _playerInside = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            OnPlayerEnterShootRange?.Invoke(false, crystalPosition.position);
            _playerInside = false;
        }

        private void Update()
        {
            if (!_playerInside) return;
            destroyTime -= Time.deltaTime;
            if (destroyTime > 0) return;
            OnPlayerDestroyCrystal?.Invoke(this);
            Destroy(gameObject);
        }
    }
}