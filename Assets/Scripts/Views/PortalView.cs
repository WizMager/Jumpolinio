using UnityEngine;
using UnityEngine.SceneManagement;

namespace Views
{
    public class PortalView : MonoBehaviour
    {
        [SerializeField] private Sprite openPortal;
        [SerializeField] private SpriteRenderer spriteRenderer;
        private bool _portalOpen;

        public void PortalOpen()
        {
            spriteRenderer.sprite = openPortal;
            _portalOpen = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!_portalOpen && col.CompareTag("Player")) return;
            SceneManager.LoadScene(0);
        }
    }
}