using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 moveDirection = Vector2.zero;

    private void Start()
    {
        float rotation = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        moveDirection = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));
    }

    private void Update()
    {
        transform.position += moveDirection * Time.deltaTime;
    }
}
