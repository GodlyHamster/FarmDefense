using System;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    [Serializable]
    public class MovementComponent
    {
        [SerializeField]
        private float moveSpeed = 1f;

        public void Move(Transform transform, Vector3 displace)
        {
            transform.position += displace.normalized * moveSpeed * Time.deltaTime;
        }

        public void MoveTowards(Transform transform, Vector3 destination)
        {
            Vector3 moveDirection = (destination - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        public void SetPos(Transform transform, Vector3 position)
        {
            transform.position = position;
        }
    }
}