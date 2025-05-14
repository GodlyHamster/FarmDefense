using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public int amount = 1;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item?.itemSprite;
    }

    public void Pickup()
    {
        Inventory.instance.AddItem(item, amount);
        Destroy(gameObject);
    }
}
