using UnityEngine;

public class Crop
{
    public CropScriptableObject cropType { get; private set; }
    public bool harvestable { get; private set; } = false;

    private bool _isWatered = false;
    public bool IsWatered { 
        get { return _isWatered; } 
        private set
        {
            _isWatered = value;
            UpdateCropSprite();
        }
    }

    private float _wateredTimer = 0f;
    private float _totalGrowthTime = 0f;
    private int _currentGrowthStage = 0;

    public GameObject linkedObject {get; private set;}
    private SpriteRenderer cropSpriteRenderer;

    public Crop(CropScriptableObject cropType, GameObject linkedObject)
    {
        this.cropType = cropType;
        this.linkedObject = linkedObject;
        cropSpriteRenderer = this.linkedObject.GetComponent<SpriteRenderer>();
            UpdateCropSprite();
    }

    public void UpdateCrop()
    {
        //Debug.Log($"stage: {_currentGrowthStage}/{cropType.growthStages.Count - 1}, watered: {_isWatered}");
        if (_isWatered)
        {
            _wateredTimer -= Time.deltaTime;
            _totalGrowthTime += Time.deltaTime;
            if (_wateredTimer < 0)
            {
                IsWatered = false;
            }
        }

        if (_currentGrowthStage == cropType.growthStages.Count - 1)
        {
            harvestable = true;
            return;
        }
        if (_totalGrowthTime >= cropType.growthStages[_currentGrowthStage + 1].growthTime)
        {
            _currentGrowthStage++;
            UpdateCropSprite();
        }
    }

    public void WaterCrop(float hydrationValue)
    {
        IsWatered = true;
        _wateredTimer = hydrationValue;
    }

    private void UpdateCropSprite()
    {
        cropSpriteRenderer.sprite = _isWatered ? cropType.growthStages[_currentGrowthStage].wateredCrop : cropType.growthStages[_currentGrowthStage].crop;
    }
}
