using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName="Crop",menuName="ScriptableObjects/Crops",order=0)]
public class CropScriptableObject : Item
{
    public List<GrowthStage> growthStages;
    [Range(0.5f, 2f)]
    public float dehydrationMult = 1f;
    public LootTable lootTable;
}
