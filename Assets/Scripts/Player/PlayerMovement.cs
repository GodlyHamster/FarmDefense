using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2.0f;

    [SerializeField]
    private PlayerControls controls;

    private Vector2 _movementValue;

    private void OnEnable()
    {
        controls.Movement.performed += Movement;
        controls.Movement.canceled += Movement;
    }

    private void OnDisable()
    {
        controls.Movement.performed -= Movement;
        controls.Movement.canceled -= Movement;
    }

    private void Movement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _movementValue = context.ReadValue<Vector2>();
        }
        if (context.canceled)
        {
            _movementValue = Vector2.zero;
        }
    }

    private void Update()
    {
        transform.position += (Vector3)_movementValue * movementSpeed * Time.deltaTime;
    }
}
