using System;
using UnityEngine;

[Serializable]
public struct HitInfo
{
    public HitInfo(int damage)
    {
        this.damage = damage;
        this.hitDirection = Vector2.zero;
    }

    public HitInfo(int damage, Vector2 hitDirection)
    {
        this.damage = damage;
        this.hitDirection = hitDirection;
    }

    public int damage;
    public Vector2 hitDirection;
}
