using System.Collections.Generic;
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
    private Image nextSubImage;
    [SerializeField]
    private Image previousSubImage;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateSelectedTool(LinkedListNode<EquipableItem> equippedItem)
    {
        selectedToolImage.sprite = equippedItem.Value.itemSprite;
        nextToolImage.sprite = equippedItem.NextOrFirst().Value.itemSprite;
        previousToolImage.sprite = equippedItem.PreviousOrLast().Value.itemSprite;

        if (equippedItem.Value is SubtoolInterface)
        {
            selectedSubImage.sprite = (equippedItem.Value as SubtoolInterface).subtoolNode.Value.itemSprite;
            nextSubImage.sprite = (equippedItem.Value as SubtoolInterface).subtoolNode.NextOrFirst().Value.itemSprite;
            previousSubImage.sprite = (equippedItem.Value as SubtoolInterface).subtoolNode.PreviousOrLast().Value.itemSprite;
            DisplaySubToolMenu(true);
        }
        else
        {
            DisplaySubToolMenu(false);
        }
    }

    private void DisplaySubToolMenu(bool doDisplay)
    {
        subToolMenu.SetActive(doDisplay);
    }
}
