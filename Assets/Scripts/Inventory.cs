using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<CropScriptableObject, int> cropsAmount = new Dictionary<CropScriptableObject, int>();

    private void OnEnable()
    {
        CropManager.OnCropHarvested += AddItem;
    }

    private void OnDisable()
    {
        CropManager.OnCropHarvested -= AddItem;
    }

    public void AddItem(CropScriptableObject crop, int amount)
    {
        Debug.Log($"Added {amount} to {crop.name}");
        if (!cropsAmount.ContainsKey(crop))
        {
            cropsAmount.Add(crop, amount);
            return;
        }

        cropsAmount[crop] += amount;
    }
}
