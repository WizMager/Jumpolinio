using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private CapsuleCollider2D playerCollider;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float jumpForce;
    private Controls _controls;

    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.TouchInput.Enable();
        _controls.TouchInput.Jump.performed += OnJumpHandler;
    }

    private void OnJumpHandler(InputAction.CallbackContext obj)
    {
        if (!playerCollider.IsTouchingLayers()) return;
        playerRigidbody.AddForce(playerTransform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
       PlayerMove(); 
    }

    private void PlayerMove()
    {
        if (_controls.TouchInput.Move.phase != InputActionPhase.Performed) return;
        playerTransform.Translate( playerTransform.right * _controls.TouchInput.Move.ReadValue<float>() * playerMoveSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        _controls.TouchInput.Disable();
    }
}