using System;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField]
        private float accelleration = 1f;
        [SerializeField]
        private float maxSpeed = 2f;

        private Rigidbody2D rb;
        public Vector2 Velocity { get { return rb.linearVelocity; } }


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public virtual void UpdateMovement(EnemyBase enemybase)
        {
            Debug.Log("schmooving");
        }

        public void MoveTowards(Vector2 destination)
        {
            Vector2 moveDirection = (destination - rb.position).normalized;
            rb.linearVelocity += moveDirection * accelleration * Time.deltaTime;
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
            }
        }

        public void SetPos(Vector3 position)
        {
            rb.position = position;
        }
    }
}