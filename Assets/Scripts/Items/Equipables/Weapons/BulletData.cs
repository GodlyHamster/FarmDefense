using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Items/Weapons/Ammo", order = 1)]
public class BulletData : Item
{
    public Item requiredAmmo;
    public GameObject bulletPrefab;
}
