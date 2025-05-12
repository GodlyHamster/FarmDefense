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
        controls.Movement.performed += Movement_performed;
        controls.Movement.canceled += Movement_performed;
    }

    private void OnDisable()
    {
        controls.Movement.performed -= Movement_performed;
        controls.Movement.canceled -= Movement_performed;
    }

    private void Movement_performed(InputAction.CallbackContext context)
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

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("wahoo");
        }
    }

    private void Update()
    {
        transform.position += (Vector3)_movementValue * movementSpeed * Time.deltaTime;
    }
}
