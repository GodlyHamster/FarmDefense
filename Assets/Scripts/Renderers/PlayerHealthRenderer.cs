using Assets.Scripts.Characters;
using Assets.Scripts.Utility;
using UnityEngine;

public class PlayerHealthRenderer : MonoBehaviour
{
    [SerializeField]
    private RectTransform thisRect;
    private float maxWidth;

    [SerializeField]
    private RectTransform healthBar;

    [SerializeField]
    private HealthComponent playerHealthComponent;

    private void OnEnable()
    {
        playerHealthComponent.OnHealthChanged += UpdateHealthbar;
    }

    private void OnDisable()
    {
        playerHealthComponent.OnHealthChanged -= UpdateHealthbar;
    }

    private void Start()
    {
        maxWidth = thisRect.sizeDelta.x;
    }

    public void UpdateHealthbar(int currentHealth, int maxHealth)
    {
        float healthbarWidth = Utility.Remap(currentHealth, 0, maxHealth, 0, maxWidth);
        healthBar.sizeDelta = new Vector2(healthbarWidth, healthBar.sizeDelta.y);
    }
}