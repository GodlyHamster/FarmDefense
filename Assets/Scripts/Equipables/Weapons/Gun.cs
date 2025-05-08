using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Tools/Weapons/Gun", order = 0)]
public class Gun : Weapon
{
    public CropScriptableObject ammoType;

    public GameObject bulletPrefab;

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
        if (!Inventory.instance.RemoveAmount(ammoType, 1))
        {
            Debug.Log($"Can't fire {name} because there are no {ammoType}!");
            return;
        }

        Vector3 direction = ((Vector2)useLocation - (Vector2)user.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        Instantiate(bulletPrefab, user.transform.position, rotation);
    }
}
