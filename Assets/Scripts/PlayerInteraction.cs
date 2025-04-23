using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject selectionOverlay;

    [SerializeField]
    private Grid grid;
    private Vector3Int _playerTile;
    private Vector2 mouseNormal;

    public void OnMousePos(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        //Vector3 selectionInt = new Vector3(Mathf.RoundToInt(mouseWorldPos.x + 0.5f) - 0.5f, Mathf.RoundToInt(mouseWorldPos.y + 0.5f) - 0.5f);

        //selectionOverlay.transform.position = selectionInt;
        mouseNormal = (mouseWorldPos - transform.position).normalized;
        Debug.Log(mouseNormal);
    }

    private void Update()
    {
        _playerTile = grid.WorldToCell(transform.position);
        selectionOverlay.transform.position = grid.CellToWorld(_playerTile) + new Vector3(0.5f, 0.5f);
    }
}
