using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Transform inventoryUIContainer;
    [SerializeField]
    private GameObject inventoryItemPrefab;

    private Dictionary<CropScriptableObject, InventoryItem> cropsAmount = new Dictionary<CropScriptableObject, InventoryItem>();

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
        if (!cropsAmount.ContainsKey(crop))
        {
            GameObject itemContainer = Instantiate(inventoryItemPrefab, inventoryUIContainer);
            TextMeshProUGUI text = itemContainer.GetComponentInChildren<TextMeshProUGUI>();
            try
            {
                InventoryItem inventoryItem = new InventoryItem(crop, amount, text, itemContainer);
                cropsAmount.Add(crop, inventoryItem);
            }
            catch
            {
                Destroy(itemContainer);
            }
            return;
        }

        cropsAmount[crop].AddAmount(amount);
    }
}

public class InventoryItem
{
    private CropScriptableObject crop;
    private int amount;
    private TextMeshProUGUI amountText;
    private GameObject linkedObject;

    public InventoryItem(CropScriptableObject crop, int amount, TextMeshProUGUI amountText, GameObject linkedObject)
    {
        this.crop = crop;
        this.amount = amount;
        this.amountText = amountText;
        this.linkedObject = linkedObject;

        SetVisuals();
    }

    private void SetVisuals()
    {
        linkedObject.GetComponentInChildren<RawImage>().texture = crop.itemSprite.texture;
        amountText.text = amount.ToString();
    }

    public void AddAmount(int amount)
    {
        this.amount += amount;
        amountText.text = this.amount.ToString();
    }
}
