using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public int amount = 1;

    public void Initialize(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
        GetComponent<SpriteRenderer>().sprite = item?.itemSprite;
    }

    public void Pickup()
    {
        Inventory.instance.AddItem(item, amount);
        Destroy(gameObject);
    }
}
