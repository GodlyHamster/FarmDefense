using UnityEngine;

public class PlayerItemCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ItemPickup>(out ItemPickup item))
        {
            item.Pickup();
        }
    }
}
