using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName="Crop",menuName="ScriptableObjects/Crops",order=0)]
public class CropScriptableObject : ScriptableObject
{
    public string cropName;
    public Sprite itemSprite;
    public List<GrowthStage> growthStages;
    [Range(0.5f, 2f)]
    public float dehydrationMult = 1f;
}
