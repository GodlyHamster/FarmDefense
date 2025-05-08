using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolUIRenderer : MonoBehaviour
{
    public static ToolUIRenderer instance;

    [SerializeField]
    private Image selectedToolImage;
    [SerializeField]
    private Image nextToolImage;
    [SerializeField]
    private Image previousToolImage;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateSelectedTool(LinkedListNode<EquipableItem> equippedItem)
    {
        selectedToolImage.sprite = equippedItem.Value.toolSprite;
        nextToolImage.sprite = equippedItem.NextOrFirst().Value.toolSprite;
        previousToolImage.sprite = equippedItem.PreviousOrLast().Value.toolSprite;
    }
}
