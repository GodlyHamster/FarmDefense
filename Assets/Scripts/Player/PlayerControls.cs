using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public InputAction Movement;
    public InputAction Interact;
    public InputAction ToolNext;
    public InputAction ToolPrevious;
    public InputAction ToolSubmenu;

    public InputAction MousePosition;

    private void OnEnable()
    {
        Movement.Enable();
        Interact.Enable();
        ToolNext.Enable();
        ToolPrevious.Enable();
        ToolSubmenu.Enable();
        MousePosition.Enable();
    }

    private void OnDisable()
    {
        Movement.Disable();
        Interact.Disable();
        ToolNext.Disable();
        ToolPrevious.Disable();
        ToolSubmenu.Disable();
        MousePosition.Disable();
    }
}
