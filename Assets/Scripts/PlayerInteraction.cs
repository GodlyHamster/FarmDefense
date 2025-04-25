using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionOverlay;

    [SerializeField]
    private Grid grid;
    private Vector3Int _playerTile;

    [SerializeField]
    private CropScriptableObject selectedCrop;

    private Vector3 _mouseTilePos;
    private Vector3Int selectedTile;

    private string _selectedTool = "Seeds";

    public void OnInteract(InputValue value)
    {
        bool isPressed = value.Get<float>() == 1 ? true : false;

        if (!isPressed) return;
        if (_selectedTool == "Seeds")
        {
            CropManager.instance.PlantCrop((Vector2Int)selectedTile, selectedCrop);
        }
        if (_selectedTool == "Water")
        {
            CropManager.instance.WaterCrop((Vector2Int)selectedTile, 8f);
        }

        if (_selectedTool == "Harvest")
        {
            CropManager.instance.HarvestCrop((Vector2Int)selectedTile);
        }
    }

    public void OnMousePos(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();
        selectedTile = grid.WorldToCell(Camera.main.ScreenToWorldPoint(mousePos));
        _mouseTilePos = grid.GetCellCenterWorld(selectedTile);
    }

    private void Update()
    {
        _playerTile = grid.WorldToCell(transform.position);
        selectionOverlay.transform.position = _mouseTilePos;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectTool("Seeds");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectTool("Water");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectTool("Harvest");
        }
    }

    private void SelectTool(string tool)
    {
        _selectedTool = tool;
        Debug.Log($"Selected {tool}");
    }
}
