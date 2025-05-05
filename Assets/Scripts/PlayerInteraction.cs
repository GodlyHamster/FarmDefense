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

    public void OnInteract(InputValue value)
    {
        bool isPressed = value.Get<float>() == 1 ? true : false;

        if (!isPressed) return;

        _selectedTool.Value.Use((Vector2Int)selectedTile, gameObject);
    }

    public void OnMousePos(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();
        selectedTile = grid.WorldToCell(Camera.main.ScreenToWorldPoint(mousePos));
        _mouseTilePos = grid.GetCellCenterWorld(selectedTile);
    }

    private void Start()
    {
        foreach (EquipableItem item in availableTools)
        {
            _toolSelection.AddLast(item);
        }
        _selectedTool = _toolSelection.First;
    }

    private void Update()
    {
        _playerTile = grid.WorldToCell(transform.position);
        selectionOverlay.transform.position = _mouseTilePos;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _selectedTool = _selectedTool.PreviousOrLast();
            Debug.Log($"Selected {_selectedTool.Value.name}");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _selectedTool = _selectedTool.NextOrFirst();
            Debug.Log($"Selected {_selectedTool.Value.name}");
        }
    }
}
