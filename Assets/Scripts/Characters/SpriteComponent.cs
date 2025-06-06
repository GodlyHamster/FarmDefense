using System;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    [Serializable]
    public class SpriteComponent : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        public void UpdateSprite(Vector2 velocity)
        {
            spriteRenderer.flipX = velocity.x > 0f;
        }
    }
}