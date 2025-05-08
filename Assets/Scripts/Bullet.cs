using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 moveDirection = Vector2.zero;
    float bulletSpeed = 3f;

    private void Start()
    {
        float rotation = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        moveDirection = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));
    }

    private void Update()
    {
        transform.position += moveDirection * bulletSpeed * Time.deltaTime;

        //destroy bullet after X time or out of screen
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IHealth healthComponent = collider.gameObject.GetComponent(typeof(IHealth)) as IHealth;
        if (healthComponent != null)
        {
            healthComponent.Hit();
        }
        Destroy(gameObject);
    }
}
