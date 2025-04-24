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

    public void OnInteract(InputValue value)
    {
        bool isPressed = value.Get<float>() == 1 ? true : false;
        Debug.Log(isPressed);
        CropManager.instance.PlantCrop((Vector2Int)selectedTile, selectedCrop);
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
    }
}
