using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName="Crop",menuName="ScriptableObjects/Crops",order=0)]
public class CropScriptableObject : ScriptableObject
{
    public string cropName;
    public List<GrowthStage> growthStages;
    [Range(0f, 1f)]
    public float dehydrationMult;
}
