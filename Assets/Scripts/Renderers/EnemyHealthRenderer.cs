using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Utility;
using Assets.Scripts.Characters;

public class EnemyHealthRenderer : MonoBehaviour
{
    [SerializeField]
    private Transform healthbarContainer;
    [SerializeField]
    private GameObject healthbarPrefab;

    private Dictionary<EnemyBase, HealthBar> enemyHealthbars = new Dictionary<EnemyBase, HealthBar>();

    private void OnEnable()
    {
        EnemyBase.OnSpawn += SpawnHealthbar;
        EnemyBase.OnDespawn += DeleteHealthbar;
    }


    private void OnDisable()
    {
        EnemyBase.OnSpawn -= SpawnHealthbar;
        EnemyBase.OnDespawn -= DeleteHealthbar;
    }

    private void SpawnHealthbar(EnemyBase enemy)
    {
        GameObject barObject = Instantiate(healthbarPrefab, healthbarContainer);

        RectTransform parent = barObject.GetComponent<RectTransform>();
        RectTransform health = parent.Find("ForegroundHealth").GetComponent<RectTransform>();
        HealthBar healthBar = new HealthBar(parent, health);

        enemyHealthbars.Add(enemy, healthBar);
    }

    private void DeleteHealthbar(EnemyBase enemy)
    {
        Destroy(enemyHealthbars[enemy].parent.gameObject);
        enemyHealthbars.Remove(enemy);
    }

    private void Update()
    {
        foreach (var item in enemyHealthbars)
        {
            //set healthbar display
            float maxWidth = item.Value.parent.sizeDelta.x;
            HealthComponent enemyHealth = item.Key.HealthComponent;
            float healthbarWidth = Utility.Remap(enemyHealth.Health, 0, enemyHealth.MaxHealth, 0, maxWidth);
            item.Value.foregroundHealth.sizeDelta.Set(healthbarWidth, 3);

            //set healthbar position
            Vector3 healthbarPos = item.Key.transform.position + new Vector3(0, 1);
            item.Value.parent.position = Camera.main.WorldToScreenPoint(healthbarPos);
        }
    }
}

public class HealthBar
{
    public HealthBar(RectTransform parent, RectTransform health)
    {
        this.parent = parent;
        this.foregroundHealth = health;
    }

    public RectTransform parent;
    public RectTransform foregroundHealth;
}
