using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items/BaseItem", order = 0)]
public class Item : ScriptableObject
{
    public Sprite itemSprite;
}
