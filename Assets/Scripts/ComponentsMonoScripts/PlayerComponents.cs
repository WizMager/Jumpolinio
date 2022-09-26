using UnityEngine;

namespace ComponentsMonoScripts
{
    public class PlayerComponents : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private BoxCollider2D playerCollider;
        [SerializeField] private Rigidbody2D playerRigidbody;
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer player;
        [SerializeField] private Transform shootPosition;

        public Transform GetTransform => playerTransform;
        public BoxCollider2D GetCollider => playerCollider;
        public Rigidbody2D GetRigidbody => playerRigidbody;
        public Animator GetAnimator => animator;
        public SpriteRenderer GetPlayer => player;
        public Transform GetShootPosition => shootPosition;
    }
}