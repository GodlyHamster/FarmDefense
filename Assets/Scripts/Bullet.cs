using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 moveDirection = Vector2.zero;
    float bulletSpeed = 5f;

    private float _aliveTime = 0f;

    private void Start()
    {
        float rotation = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        moveDirection = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));
    }

    private void Update()
    {
        transform.position += moveDirection * bulletSpeed * Time.deltaTime;

        _aliveTime += Time.deltaTime;
        if (_aliveTime > 10f)
        {
            Destroy(gameObject);
        }
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
