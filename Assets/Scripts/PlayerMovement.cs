using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _movementValue;

    public void OnMovement(InputValue value)
    {
        Vector2 movement = value.Get<Vector2>();
        if (movement == null) return;
        _movementValue = movement;
    }

    private void Update()
    {
        transform.position += (Vector3)_movementValue * Time.deltaTime;
    }
}
