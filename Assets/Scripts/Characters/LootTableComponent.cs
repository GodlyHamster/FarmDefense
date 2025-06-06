using System;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    public class LootTableComponent : MonoBehaviour
    {
        [SerializeField]
        private LootTable loottable;

        public static event Action<LootTable, Vector3> DropLoottable;

        public void DropLootTable()
        {
            if (loottable == null) return;
            DropLoottable?.Invoke(loottable, transform.position);
        }
    }
}