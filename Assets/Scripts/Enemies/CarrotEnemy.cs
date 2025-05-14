using UnityEngine;

public class CarrotEnemy : Enemy
{
    [SerializeField]
    private Vector3 targetLocation;

    [SerializeField]
    Transform player;

    private void Update()
    {
        targetLocation = player.position;
        Vector3 moveDirection = (targetLocation - transform.position).normalized;
        transform.position += moveDirection * Time.deltaTime;
    }

    public override void Hit()
    {
        //hit animation stuffs here

        RemoveHealth(1);
    }

    public override void Die()
    {
        base.Die();
        ItemDropManager.instance.HandleLootTableDrop(lootTable, transform.position);
        Destroy(gameObject);
    }
}
