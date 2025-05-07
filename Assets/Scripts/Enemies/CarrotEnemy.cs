using UnityEngine;

public class CarrotEnemy : Enemy
{
    [ContextMenu("Damage")]
    public void OnHit()
    {
        RemoveHealth(1);
    }
}
