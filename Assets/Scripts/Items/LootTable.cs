using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
[CreateAssetMenu(fileName = "LootTable", menuName = "ScriptableObjects/Loottable", order = 0)]
public class LootTable : ScriptableObject
{
    [field: SerializeField]
    public List<LootTableItem> items { get; private set; } = new List<LootTableItem>();
}

[Serializable]
public class LootTableItem
{
    public Item item;
    public int minAmount;
    public int maxAmount;
}
