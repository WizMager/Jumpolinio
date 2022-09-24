using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float jumpForce;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool _spriteRendererFlip;
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
        animator.SetBool("Walk", false);
        if (_controls.TouchInput.Move.phase != InputActionPhase.Performed) return;
        var axisXInputValue = _controls.TouchInput.Move.ReadValue<float>();
        animator.SetBool("Walk", true);
        animator.SetFloat("WalkDirection", axisXInputValue);
        FlipSpriteToMoveDirection(axisXInputValue);
        playerTransform.Translate( playerTransform.right * axisXInputValue * playerMoveSpeed * Time.deltaTime);
    }

    private void FlipSpriteToMoveDirection(float axisXInputValue)
    {
        if (axisXInputValue < 0)
        {
            if (_spriteRendererFlip) return;
            _spriteRendererFlip = true;
            spriteRenderer.flipX = _spriteRendererFlip;
        }
        
        if (axisXInputValue > 0)
        {
            if (!_spriteRendererFlip)return;
            _spriteRendererFlip = false;
            spriteRenderer.flipX = _spriteRendererFlip;
        } 
    }
    
    private void OnDisable()
    {
        _controls.TouchInput.Disable();
    }
}