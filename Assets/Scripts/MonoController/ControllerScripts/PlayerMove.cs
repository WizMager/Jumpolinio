using System.Collections.Generic;
using ComponentsMonoScripts;
using Data;
using MonoController.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using Views;

namespace MonoController.ControllerScripts
{
    public class PlayerMove : IAwake, IEnable, IUpdate, IDisable
    {
        private readonly float _playerMoveSpeed;
        private readonly float _jumpForce;
        private readonly Transform _playerTransform;
        private readonly BoxCollider2D _playerCollider;
        private readonly Rigidbody2D _playerRigidbody;
        private readonly Animator _animator;
        private readonly SpriteRenderer _player;

        private Controls _controls;
        private bool _spriteRendererFlip;

        public PlayerMove(PlayerData playerData, PlayerComponents playerComponents)
        {
            _playerMoveSpeed = playerData.moveSpeed;
            _jumpForce = playerData.jumpForce;
            _playerTransform = playerComponents.GetTransform;
            _playerCollider = playerComponents.GetCollider;
            _playerRigidbody = playerComponents.GetRigidbody;
            _animator = playerComponents.GetAnimator;
            _player = playerComponents.GetPlayer;
        }
    
        public void Awake()
        {
            _controls = new Controls();
        }

        public void OnEnable()
        {
            _controls.TouchInput.Enable();
            _controls.TouchInput.Jump.performed += OnJumpHandler;
            _controls.TouchInput.Down.performed += OnDownHandler;
        }

        private void OnDownHandler(InputAction.CallbackContext obj)
        {
            if (!_playerRigidbody.IsTouchingLayers(64)) return;
            var contacts = new List<ContactPoint2D>();
            _playerRigidbody.GetContacts(contacts);
            Debug.Log(contacts.Capacity);
            foreach (var contact in contacts)
            {
                if (!contact.collider.CompareTag("Platform")) continue;
                contact.collider.GetComponentInParent<PlatformView>().DisableCollider(); 
                break;
            }
        }

        private void OnJumpHandler(InputAction.CallbackContext obj)
        {
            if (!_playerRigidbody.IsTouchingLayers(64)) return;
            _playerRigidbody.AddForce(_playerTransform.up * _jumpForce, ForceMode2D.Impulse);
        }

        public void Update(float deltaTime)
        {
            Move(deltaTime); 
        }

        private void Move(float deltaTime)
        {
            _animator.SetBool("Walk", false);
            if (_controls.TouchInput.Move.phase != InputActionPhase.Performed) return;
            var axisXInputValue = _controls.TouchInput.Move.ReadValue<float>();
            _animator.SetBool("Walk", true);
            _animator.SetFloat("WalkDirection", axisXInputValue);
            FlipSpriteToMoveDirection(axisXInputValue);
            _playerTransform.Translate( _playerTransform.right * axisXInputValue * _playerMoveSpeed * deltaTime);
        }

        private void FlipSpriteToMoveDirection(float axisXInputValue)
        {
            if (axisXInputValue < 0)
            {
                if (_spriteRendererFlip) return;
                _spriteRendererFlip = true;
                _player.flipX = _spriteRendererFlip;
            }
        
            if (axisXInputValue > 0)
            {
                if (!_spriteRendererFlip)return;
                _spriteRendererFlip = false;
                _player.flipX = _spriteRendererFlip;
            } 
        }
        public void OnDisable()
        {
            _controls.TouchInput.Disable();
        }
    }
}