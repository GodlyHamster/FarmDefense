using System;
using UnityEngine;

[Serializable]
public abstract class EquipableItem : Item
{
    public virtual void Equip() { }
    public virtual void Dequip() { }
    public virtual void Use(Vector2Int useLocation, GameObject user) { }
}
