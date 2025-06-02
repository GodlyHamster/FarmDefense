using UnityEngine;

public class CarrotEnemy : Enemy
{
    [SerializeField]
    private Vector3 targetLocation;

    [SerializeField]
    Transform player;

    private void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        targetLocation = player.position;
        Vector3 moveDirection = (targetLocation - transform.position).normalized;
        transform.position += moveDirection * Time.deltaTime;
    }

    public override void Hit(HitInfo hitInfo)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (player is IHealth)
            {
                HitInfo hitInfo = new HitInfo(1);
                (player as IHealth).Hit(hitInfo);
            }
        }
    }
}
