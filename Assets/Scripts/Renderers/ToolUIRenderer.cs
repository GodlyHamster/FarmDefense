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

    private void OnEnable()
    {
        Inventory.OnInventoryUpdated += UpdateItemCount;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryUpdated -= UpdateItemCount;
    }

    private void Awake()
    {
        instance = this;
    }

    public void UpdateSelectedTool(LinkedListNode<EquipableItem> equippedItem)
    {
        //Display main tools
        currentEquipped = equippedItem;
        selectedToolImage.sprite = equippedItem.Value.itemSprite;
        nextToolImage.sprite = equippedItem.NextOrFirst().Value.itemSprite;
        previousToolImage.sprite = equippedItem.PreviousOrLast().Value.itemSprite;

        //Display sub tools and their count
        if (equippedItem.Value is SubtoolInterface)
        {
            LinkedListNode<Item> subtoolNode = (equippedItem.Value as SubtoolInterface).subtoolNode;

            selectedSubImage.sprite = subtoolNode.Value.itemSprite;
            nextSubImage.sprite = subtoolNode.NextOrFirst().Value.itemSprite;
            previousSubImage.sprite = subtoolNode.PreviousOrLast().Value.itemSprite;
            UpdateItemCount();
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

            //set the text to infinity icon if item is infinite, else set it to the count
            selectedSubText.text = subtoolNode.Value.isInfinite ? "<rotate=\"90\">8" : Inventory.instance.GetItemCount(subtoolNode.Value).ToString();
            nextSubText.text = subtoolNode.NextOrFirst().Value.isInfinite ? "<rotate=\"90\">8" : Inventory.instance.GetItemCount(subtoolNode.NextOrFirst().Value).ToString();
            previousSubText.text = subtoolNode.PreviousOrLast().Value.isInfinite ? "<rotate=\"90\">8" : Inventory.instance.GetItemCount(subtoolNode.PreviousOrLast().Value).ToString();
        }
    }

    private void DisplaySubToolMenu(bool doDisplay)
    {
        subToolMenu.SetActive(doDisplay);
    }
}
