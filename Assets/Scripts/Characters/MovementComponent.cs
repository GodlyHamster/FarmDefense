using System;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    [Serializable]
    public class MovementComponent
    {
        [SerializeField]
        private float accelleration = 1f;
        [SerializeField]
        private float maxSpeed = 2f;

        private Rigidbody2D rb;
        public Vector2 Velocity { get { return rb.linearVelocity; } }

        public void Initialize(Rigidbody2D rb)
        {
            this.rb = rb;
        }

        public void Move(Transform transform, Vector3 displace)
        {
            transform.position += displace.normalized * accelleration * Time.deltaTime;
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

        public void SetPos(Transform transform, Vector3 position)
        {
            transform.position = position;
        }
    }
}