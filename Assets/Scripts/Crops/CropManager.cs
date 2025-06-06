using System;
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
    private GameObject cropPrefab;

    [SerializeField]
    private List<Vector2Int> availabeLand = new List<Vector2Int>();
    private Dictionary<Vector2Int, Crop> plantedCrops = new Dictionary<Vector2Int, Crop>();
    public Dictionary<Vector2Int, Crop> PlantedCrops {  get { return plantedCrops; } }

    public static event Action OnFarmUpdated;
    //public static event Action<Item, int> OnCropHarvested;

    private void Awake()
    {
        instance = this;
    }

    public bool IsPlotOccupied(Vector2Int pos)
    {
        if (!availabeLand.Contains(pos) || plantedCrops.ContainsKey(pos)) return true;
        return false;
    }

    public bool PlantCrop(Vector2Int pos, CropScriptableObject cropType)
    {
        if (!availabeLand.Contains(pos)) return false;
        if (plantedCrops.ContainsKey(pos)) return false;
        GameObject cropObject = Instantiate(cropPrefab, grid.GetCellCenterWorld((Vector3Int)pos), Quaternion.identity);
        Crop crop = new Crop(cropType, cropObject);
        plantedCrops.Add(pos, crop);
        OnFarmUpdated.Invoke();
        return true;
    }

    public void WaterCrop(Vector2Int pos, float hydrationValue)
    {
        if (!plantedCrops.ContainsKey(pos)) return;
        plantedCrops[pos].WaterCrop(hydrationValue);
    }

    public void HarvestCrop(Vector2Int pos)
    {
        if (!plantedCrops.ContainsKey(pos)) return;
        if (plantedCrops[pos].harvestable)
        {
            Crop harvestedCrop = plantedCrops[pos];

            ItemDropManager.instance.HandleLootTableDrop(harvestedCrop.cropType.lootTable, (Vector3Int)pos);
            Destroy(harvestedCrop.linkedObject);
            plantedCrops.Remove(pos);
            OnFarmUpdated.Invoke();
        }
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
