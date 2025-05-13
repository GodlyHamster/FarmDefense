using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [SerializeField]
    private Transform inventoryUIContainer;
    [SerializeField]
    private GameObject inventoryItemPrefab;

    private Dictionary<Item, int> items = new Dictionary<Item, int>();

    private void OnEnable()
    {
        CropManager.OnCropHarvested += AddItem;
    }

    private void OnDisable()
    {
        CropManager.OnCropHarvested -= AddItem;
    }

    private void Awake()
    {
        instance = this;
    }

    public void AddItem(Item item, int amount)
    {
        if (items.ContainsKey(item)) {
            items[item] += amount;
            return;
        }
        items.Add(item, amount);
    }

    public bool RemoveAmount(Item item, int amount)
    {
        if (items.ContainsKey(item) && items[item] >= amount)
        {
            items[item] -= amount;
            return true;
        }
        return false;
    }

#if UNITY_EDITOR
    [ContextMenu("Debug inventory")]
    public void DebugInventory()
    {
        foreach (KeyValuePair<Item, int> item in items)
        {
            Debug.Log($"{item.Key.name}: {item.Value}");
        }
    }
#endif
}
