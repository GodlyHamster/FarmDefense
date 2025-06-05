using System;
using UnityEngine;

[Serializable]
public struct HitInfo
{
    public HitInfo(int damage)
    {
        this.damage = damage;
        this.hitFromPos = Vector2.zero;
    }

    public HitInfo(int damage, Vector2 hitDirection)
    {
        this.damage = damage;
        this.hitFromPos = hitDirection;
    }

    public int damage;
    public Vector2 hitFromPos;
}
