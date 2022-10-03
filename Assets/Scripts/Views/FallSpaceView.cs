using UnityEngine;
using UnityEngine.SceneManagement;

namespace Views
{
    public class FallSpaceView : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            SceneManager.LoadScene(0);
        }
    }
}