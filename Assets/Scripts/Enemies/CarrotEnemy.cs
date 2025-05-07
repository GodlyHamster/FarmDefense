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
}
