using Assets.Scripts.Characters;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private HitInfo hitInfo;
    [SerializeField]
    private float bulletSpeed = 5f;

    Vector3 moveDirection = Vector2.zero;

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
        if (collider.gameObject.TryGetComponent<HealthComponent>(out HealthComponent healthComponent))
        {
            healthComponent.Hit(hitInfo);
        }
        Destroy(gameObject);
    }
}
