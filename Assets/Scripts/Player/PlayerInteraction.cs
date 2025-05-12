using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionOverlay;

    [SerializeField]
    private Grid grid;
    private Vector3Int _playerTile;

    private Vector3 _mouseTilePos;
    private Vector3Int selectedTile;

    [SerializeField]
    private List<EquipableItem> availableTools = new List<EquipableItem>();
    private LinkedList<EquipableItem> _toolSelection = new LinkedList<EquipableItem>();
    private LinkedListNode<EquipableItem> _selectedTool;

    [SerializeField]
    private PlayerControls controls;

    private bool isSubtoolButtonHeld = false;

    private void OnEnable()
    {
        controls.Interact.performed += Interact;
        controls.MousePosition.performed += MousePos;
        controls.ToolNext.performed += ToolNext;
        controls.ToolPrevious.performed += ToolPrevious;
        controls.ToolSubmenu.performed += ToolSubmenu;
        controls.ToolSubmenu.canceled += ToolSubmenu;
    }

    private void OnDisable()
    {
        controls.Interact.performed -= Interact;
        controls.MousePosition.performed -= MousePos;
        controls.ToolNext.performed -= ToolNext;
        controls.ToolPrevious.performed -= ToolPrevious;
        controls.ToolSubmenu.performed -= ToolSubmenu;
        controls.ToolSubmenu.canceled -= ToolSubmenu;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _selectedTool.Value.Use((Vector2Int)selectedTile, gameObject);
        }
    }

    private void MousePos(InputAction.CallbackContext context)
    {
        Vector2 mousePos = context.ReadValue<Vector2>();
        selectedTile = grid.WorldToCell(Camera.main.ScreenToWorldPoint(mousePos));
        _mouseTilePos = grid.GetCellCenterWorld(selectedTile);
    }

    private void ToolNext(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isSubtoolButtonHeld && _selectedTool.Value is SubtoolInterface)
            {
                (_selectedTool.Value as SubtoolInterface).NextSubtool();
            }
            else
            {
                _selectedTool.Value.Dequip();
                _selectedTool = _selectedTool.NextOrFirst();
                _selectedTool.Value.Equip();
            }
            ToolUIRenderer.instance.UpdateSelectedTool(_selectedTool);
        }
    }

    private void ToolPrevious(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isSubtoolButtonHeld && _selectedTool.Value is SubtoolInterface)
            {
                (_selectedTool.Value as SubtoolInterface).PreviousSubtool();
            }
            else
            {
                _selectedTool.Value.Dequip();
                _selectedTool = _selectedTool.PreviousOrLast();
                _selectedTool.Value.Equip();
            }
            ToolUIRenderer.instance.UpdateSelectedTool(_selectedTool);
        }
    }

    private void ToolSubmenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isSubtoolButtonHeld = true;
        }
        if (context.canceled)
        {
            isSubtoolButtonHeld = false;
        }
    }

    private void Start()
    {
        foreach (EquipableItem item in availableTools)
        {
            _toolSelection.AddLast(item);
        }
        _selectedTool = _toolSelection.First;
        _selectedTool.Value.Equip();
        ToolUIRenderer.instance.UpdateSelectedTool(_selectedTool);
    }

    private void Update()
    {
        _playerTile = grid.WorldToCell(transform.position);
        selectionOverlay.transform.position = _mouseTilePos;
    }
}
