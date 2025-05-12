using System;
using UnityEngine;

[Serializable]
public abstract class EquipableItem : ScriptableObject
{
    public Sprite toolSprite;

    public virtual void Equip() { }
    public virtual void Dequip() { }
    public virtual void Use(Vector2Int useLocation, GameObject user) { }
}
