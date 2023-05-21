using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody2D _characterController;
    private Transform _cameraTransform;
    private InputAction _moveAction;

    [SerializeField] private float _playerSpeed = 10f;
    [SerializeField] private float _rotationSpeed = 5f;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _characterController = GetComponent<Rigidbody2D>();
        _cameraTransform = Camera.main.transform;
        _moveAction = _playerInput.actions["Move"];
    }

    private void FixedUpdate()
    {
        MovementControl();
        RotationControl();
    }

    private void MovementControl()
    {
        Vector2 input = _moveAction.ReadValue<Vector2>();
        Vector2 move = new Vector2(0, input.y);
        move = move.x * _cameraTransform.right.normalized + move.y * _cameraTransform.up.normalized;
        _characterController.gameObject.transform.Translate(move * Time.deltaTime * _playerSpeed);
    }

    private void RotationControl()
    {
        Vector2 input = _moveAction.ReadValue<Vector2>();
        float rotationAmount = input.normalized.x;
        _characterController.gameObject.transform.Rotate(0, 0, -rotationAmount * _rotationSpeed);
    }
}
