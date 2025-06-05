using UnityEngine;

public class CarrotEnemy : Enemy
{
    [SerializeField]
    private Vector3 targetLocation;

    [SerializeField]
    Transform player;

    [Header("Entity values")]
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float speed = 1f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        targetLocation = player.position;
        Vector3 moveDirection = (targetLocation - transform.position).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    public override void Hit(HitInfo hitInfo)
    {
        //apply knockback based on hit direction
        //Vector2 knockbackVec = ((Vector2)transform.position - hitInfo.hitDirection).normalized;
        //rb.AddForce(knockbackVec, ForceMode2D.Impulse);

        RemoveHealth(hitInfo.damage);
    }

    public override void Die()
    {
        ItemDropManager.instance.HandleLootTableDrop(lootTable, transform.position);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (player is IHealth)
            {
                HitInfo hitInfo = new HitInfo(damage, transform.position);
                (player as IHealth).Hit(hitInfo);
            }
        }
    }
}
