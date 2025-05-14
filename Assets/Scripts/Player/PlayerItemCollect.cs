using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlayerItemCollect : MonoBehaviour
{
    [SerializeField]
    private float pickupRange;

    private Dictionary<ItemPickup, Transform> itemPickupsInRange = new Dictionary<ItemPickup, Transform>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ItemPickup>(out ItemPickup item))
        {
            itemPickupsInRange.Add(item, collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ItemPickup>(out ItemPickup item))
        {
            itemPickupsInRange.Remove(item);
        }
    }

    private void Update()
    {
        var itemsTopickup = itemPickupsInRange.Where(x => Vector3.Distance(transform.position, x.Value.position) <= pickupRange).ToArray();
        foreach (var item in itemsTopickup)
        {
            item.Key.Pickup();
            itemPickupsInRange.Remove(item.Key);
        }
        foreach (var item in itemPickupsInRange)
        {
            Vector3 itemPos = item.Value.position;
            Vector3 moveDirection = (transform.position - itemPos).normalized;
            item.Value.position += moveDirection * 2 * Time.deltaTime;
        }
    }
}
