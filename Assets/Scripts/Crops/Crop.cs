using UnityEngine;

public class Crop
{
    public CropScriptableObject cropType;

    public bool isWatered { get; private set; }
    private float _wateredTimer;

    public Crop(CropScriptableObject cropType)
    {
        this.cropType = cropType;
    }

    public void UpdateCrop()
    {
        if (_wateredTimer < 0) return;
        _wateredTimer -= Time.deltaTime;
    }

    public void WaterCrop()
    {

    }
}
