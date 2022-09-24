using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    private Transform _playerTransform;
    private float _cameraAxisZPosition;

    [Inject]
    private void Construct(Player player)
    {
        _playerTransform = player.transform;
    }

    private void Awake()
    {
        _cameraAxisZPosition = mainCamera.position.z;
    }

    private void LateUpdate()
    {
        var playerPosition = _playerTransform.position;
        mainCamera.position = new Vector3(playerPosition.x, playerPosition.y, _cameraAxisZPosition);
    }
}