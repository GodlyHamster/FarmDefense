using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolUIRenderer : MonoBehaviour
{
    public static ToolUIRenderer instance;

    [Header("Main Tools")]
    [SerializeField]
    private Image selectedToolImage;
    [SerializeField]
    private Image nextToolImage;
    [SerializeField]
    private Image previousToolImage;

    [Header("Sub Tools")]
    [SerializeField]
    private GameObject subToolMenu;
    [SerializeField]
    private Image selectedSubImage;
    [SerializeField]
    private TextMeshProUGUI selectedSubText;

    [SerializeField]
    private Image nextSubImage;
    [SerializeField]
    private TextMeshProUGUI nextSubText;

    [SerializeField]
    private Image previousSubImage;
    [SerializeField]
    private TextMeshProUGUI previousSubText;

    private LinkedListNode<EquipableItem> currentEquipped;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Inventory.OnInventoryUpdated += UpdateItemCount;
    }

    public void UpdateSelectedTool(LinkedListNode<EquipableItem> equippedItem)
    {
        currentEquipped = equippedItem;
        selectedToolImage.sprite = equippedItem.Value.itemSprite;
        nextToolImage.sprite = equippedItem.NextOrFirst().Value.itemSprite;
        previousToolImage.sprite = equippedItem.PreviousOrLast().Value.itemSprite;

        if (equippedItem.Value is SubtoolInterface)
        {
            LinkedListNode<Item> subtoolNode = (equippedItem.Value as SubtoolInterface).subtoolNode;

            selectedSubImage.sprite = subtoolNode.Value.itemSprite;
            selectedSubText.text = Inventory.instance.GetItemCount(subtoolNode.Value).ToString();
            nextSubImage.sprite = subtoolNode.NextOrFirst().Value.itemSprite;
            previousSubImage.sprite = subtoolNode.PreviousOrLast().Value.itemSprite;
            DisplaySubToolMenu(true);
        }
        else
        {
            DisplaySubToolMenu(false);
        }
    }

    public void UpdateItemCount()
    {
        if (currentEquipped.Value is SubtoolInterface)
        {
            LinkedListNode<Item> subtoolNode = (currentEquipped.Value as SubtoolInterface).subtoolNode;

            selectedSubText.text = Inventory.instance.GetItemCount(subtoolNode.Value).ToString();
        }
    }

    private void DisplaySubToolMenu(bool doDisplay)
    {
        subToolMenu.SetActive(doDisplay);
    }
}
