using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Items/Weapons/Gun", order = 0)]
public class Gun : Weapon, SubtoolInterface
{
    [field: SerializeField]
    public List<Item> subtoolItems { get; private set; } = new List<Item>();
    public LinkedList<Item> subtoolLinkedList { get; private set; } = new LinkedList<Item>();
    public LinkedListNode<Item> subtoolNode { get; private set; }

    private void OnEnable()
    {
        subtoolLinkedList.Clear();
        foreach (Item item in subtoolItems)
        {
            subtoolLinkedList.AddLast(item);
        }
        subtoolNode = subtoolLinkedList.First;
    }

    private void OnDisable()
    {
        subtoolLinkedList.Clear();
        subtoolNode = null;
    }

    public override void Equip()
    {
        base.Equip();
    }

    public override void Dequip()
    {
        base.Dequip();
    }

    public override void Use(Vector2Int useLocation, GameObject user)
    {
        if (subtoolNode.Value is not BulletData) return;
        BulletData bulletData = (subtoolNode.Value as BulletData);
        if (!Inventory.instance.RemoveAmount(bulletData, 1))
        {
            Debug.Log($"Can't fire {name} because there are no {bulletData}!");
            return;
        }

        Vector3 direction = ((Vector2)useLocation - (Vector2)user.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        Instantiate(bulletData.bulletPrefab, user.transform.position, rotation);
    }

    public void NextSubtool()
    {
        if (subtoolNode == null) return;
        subtoolNode = subtoolNode.NextOrFirst();
    }

    public void PreviousSubtool()
    {
        if (subtoolNode == null) return;
        subtoolNode = subtoolNode.PreviousOrLast();
    }
}
