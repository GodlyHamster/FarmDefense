using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [SerializeField]
    private List<StartingItem> startingItems = new List<StartingItem>();

    [SerializeField]
    private Transform inventoryUIContainer;
    [SerializeField]
    private GameObject inventoryItemPrefab;

    private Dictionary<Item, int> items = new Dictionary<Item, int>();

    public static event Action OnInventoryUpdated;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (StartingItem item in startingItems)
        {
            AddItem(item.item, item.amount);
        }
    }

    public void AddItem(Item item, int amount)
    {
        if (items.ContainsKey(item)) {
            items[item] += amount;
            OnInventoryUpdated?.Invoke();
            return;
        }
        items.Add(item, amount);
        OnInventoryUpdated?.Invoke();
    }

    public bool RemoveAmount(Item item, int amount)
    {
        if (item.isInfinite) return true;
        if (items.ContainsKey(item) && items[item] >= amount)
        {
            items[item] -= amount;
            OnInventoryUpdated?.Invoke();
            return true;
        }
        return false;
    }

    public int GetItemCount(Item item)
    {
        if (!items.ContainsKey(item)) return 0;
        return items[item];
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

[Serializable]
public class StartingItem
{
    public Item item;
    public int amount;
}
