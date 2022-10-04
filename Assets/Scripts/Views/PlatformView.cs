using System.Collections;
using UnityEngine;

namespace Views
{
    public class PlatformView : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D platformCollider;
        
        public void DisableCollider()
        {
            StartCoroutine(TemporaryDisableCollider());
        }

        private IEnumerator TemporaryDisableCollider()
        {
            platformCollider.enabled = false;
            yield return new WaitForSeconds(0.5f);
            platformCollider.enabled = true;
        }
    }
}