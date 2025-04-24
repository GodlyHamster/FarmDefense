using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    public static CropManager instance;

    [SerializeField]
    private Grid grid;
    [SerializeField]
    private bool debugLand;

    [SerializeField]
    private List<Vector2Int> availabeLand = new List<Vector2Int>();
    private Dictionary<Vector2Int, Crop> plantedCrops = new Dictionary<Vector2Int, Crop>();

    private void Awake()
    {
        instance = this;
    }

    public bool PlantCrop(Vector2Int pos, CropScriptableObject cropType)
    {
        if (plantedCrops.ContainsKey(pos)) return false;
        Crop crop = new Crop(cropType);
        plantedCrops.Add(pos, crop);
        return true;
    }

    private void Update()
    {
        foreach (var crop in plantedCrops)
        {
            crop.Value.UpdateCrop();
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!debugLand) return;
        if (availabeLand.Count <= 0 || grid == null) return;
        Gizmos.color = Color.red;
        foreach (Vector2Int item in availabeLand)
        {
            Gizmos.DrawCube(grid.GetCellCenterWorld((Vector3Int)item), new Vector3(0.9f, 0.9f, 0.9f));
        }
    }
#endif
}
