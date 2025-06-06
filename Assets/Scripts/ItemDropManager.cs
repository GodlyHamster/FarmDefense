using Assets.Scripts.Characters;
using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    public static ItemDropManager instance;

    [SerializeField]
    private GameObject itemPickupPrefab;

    private void OnEnable()
    {
        LootTableComponent.DropLoottable += HandleLootTableDrop;
    }
    private void OnDisable()
    {
        LootTableComponent.DropLoottable -= HandleLootTableDrop;
    }

    private void Awake()
    {
        instance = this;
    }

    public void SpawnItemPickup(Item item, Vector3 location)
    {
        Vector3 randomOffset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        GameObject itemPickup = Instantiate(itemPickupPrefab, location + randomOffset, Quaternion.identity);
        itemPickup.GetComponent<ItemPickup>().Initialize(item, 1);

    }

    public void HandleLootTableDrop(LootTable lootTable, Vector3 location)
    {
        if (lootTable == null) return;
        foreach (LootTableItem tableItem in lootTable.items)
        {
            int randomAmount = Random.Range(tableItem.minAmount, tableItem.maxAmount + 1);
            for (int i = 0; i < randomAmount; i++)
            {
                SpawnItemPickup(tableItem.item, location);
            }
        }
    }
}
